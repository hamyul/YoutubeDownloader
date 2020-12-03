using System;
using System.Diagnostics;
using System.IO;
using YoutubeDownloader.Core.Utils;
using YoutubeDownloader.Core.Wrappers;

namespace YoutubeDownloader.Core.Model
{
    public class VideoService : IVideoService
    {
        private IYouTubeWrapper _youTube;

        public VideoService(IYouTubeWrapper youTube)
        {
            _youTube = youTube;
        }

        public EventHandler<EventArgs> Downloaded { get; set; }

        public string Download(string savePath)
        {
            try
            {
                if (string.IsNullOrEmpty(savePath))
                    throw new ArgumentException("Invalid argument.");

                string fileName = GetFilename(savePath, _youTube.Title);

                if (!SaveFileToDisk(fileName, _youTube.GetBytes()))
                    throw new IOException("Could not save file on disk.");

                Downloaded?.Invoke(this, new EventArgs());

                return fileName;
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return string.Empty;
            }
        }

        protected virtual bool SaveFileToDisk(string filename, byte[] videoContent)
        {
            bool output = true;
            try
            {
                File.WriteAllBytes(filename, videoContent);
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                output = false;
            }

            return output;
        }

        protected string GetFilename(string path, string title)
        {
            return new FilenameFixer(title, path).GetFilename();
        }
    }
}