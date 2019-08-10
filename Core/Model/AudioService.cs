using MediaToolkit;
using MediaToolkit.Model;
using Mp3Lib;
using System;
using System.IO;

namespace YoutubeDownloader.Core.Model
{
    public class AudioService
    {
        public EventHandler<EventArgs> TagModified { get; set; }

        public void ExtractAudio(string inputFile, string outputFile)
        {
            using (var engine = new Engine())
            {
                var mediaInputFile = new MediaFile(inputFile);
                var mediaOutputFile = new MediaFile(outputFile);

                engine.GetMetadata(mediaInputFile);
                engine.Convert(mediaInputFile, mediaOutputFile);
            }

            TagModified?.Invoke(this, new EventArgs());
        }

        public void SetAudioTags(string outputFile, string title, string album, string artist)
        {
            Mp3File mp3 = new Mp3File(outputFile);
            mp3.TagHandler.Title = title;
            mp3.TagHandler.Album = album;
            mp3.TagHandler.Artist = artist;
            mp3.Update();

            DeleteBackupFile(outputFile);

            TagModified?.Invoke(this, new EventArgs());
        }

        private void DeleteBackupFile(string outputFile)
        {
            var backupFile = Path.ChangeExtension(outputFile, ".bak");

            if (File.Exists(backupFile))
                File.Delete(backupFile);
        }
    }
}