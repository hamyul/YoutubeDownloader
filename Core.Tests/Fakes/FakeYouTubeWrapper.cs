namespace YoutubeDownloader.Core.Tests.Fakes
{
    class FakeYouTubeWrapper : IYoutube
    {
        public IYoutubeVideo GetVideo(string url)
        {
            return new FakeYouTubeVideoWrapper();
        }
    }
}
