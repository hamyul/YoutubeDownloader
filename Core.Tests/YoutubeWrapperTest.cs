using Microsoft.VisualStudio.TestTools.UnitTesting;
using VideoLibrary;

namespace YoutubeDownloader.Core.Tests
{
    [TestClass]
    public class YoutubeWrapperTest
    {
        [TestMethod]
        public void should_return_instance_of_IYoutube()
        {
            var sut = new TestableYoutubeWrapper();
            Assert.IsInstanceOfType(sut, typeof(IYoutube));
        }
    }

    public class TestableYoutubeWrapper : YoutubeWrapper
    {
        protected override YouTubeVideo GetNativeVideo(string url)
        {
            return null;
        }
    }
}
