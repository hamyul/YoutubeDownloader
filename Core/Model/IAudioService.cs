using System;

namespace YoutubeDownloader.Core.Model
{
    public interface IAudioService
    {
        EventHandler<EventArgs> TagModified { get; set; }

        void ExtractAudio(string inputFile, string outputFile);
        void SetAudioTags(string outputFile, string title, string album, string artist);
    }
}