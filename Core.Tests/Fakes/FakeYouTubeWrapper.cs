using YoutubeDownloader.Core.Wrappers;

namespace YoutubeDownloader.Core.Tests.Fakes
{
    public class FakeYouTubeWrapper : IYouTubeWrapper
    {
        public FakeYouTubeWrapper(string url)
        {
            Url = url;
        }

        public string Title => "Fake title";

        public string Url { get; set; }

        public byte[] GetBytes()
        {
            return null;
        }
    }
}