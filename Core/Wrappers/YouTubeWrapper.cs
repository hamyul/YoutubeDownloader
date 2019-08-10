using System;
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

        protected virtual bool IsValidUrl(string url)
        {
            try
            {
                Uri uri = new Uri(url);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}