using System;
using System.IO;
using VideoLibrary;

namespace YoutubeDownloader.Core.Wrappers
{
    public class YouTubeWrapper : IYouTubeWrapper
    {
        private readonly YouTubeVideo _youTubeVideo;

        public YouTubeWrapper(string url)
        {
            if (!IsValidUrl(url))
                throw new Exception("Invalid URL.");

            Url = url;
            _youTubeVideo = YouTube.Default.GetVideo(url);
        }

        public string Title
        {
            get { return _youTubeVideo.Title; }
        }

        public string Url { get; set; }

        public byte[] GetBytes()
        {
            return _youTubeVideo.GetBytes();
        }

        public bool Download()
        {
            try
            {
                if (!IsValidUrl(Url))
                    throw new UriFormatException("Invalid URL.");

                byte[] bytes = GetBytes();

                using (FileStream stream = new FileStream($@"{Environment.GetFolderPath(Environment.SpecialFolder.MyVideos)}\{Title}.mp4", FileMode.CreateNew))
                {
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Close();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        protected virtual bool IsValidUrl(string url)
        {
            try
            {
                Uri uri = new Uri(url);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}