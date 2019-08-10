using Microsoft.VisualStudio.TestTools.UnitTesting;
using YoutubeDownloader.Core.Model;
using YoutubeDownloader.Core.Tests.Fakes;
using YoutubeDownloader.Core.Wrappers;

namespace YoutubeDownloader.Core.Tests
{
    [TestClass]
    public class VideoServiceTest
    {
        private IYouTubeWrapper FakeYouTubeWrapper
        {
            get { return new FakeYouTubeWrapper("https://www.youtube.com/watch?v=vVnE9o5Uxik"); }
        }

        [TestMethod]
        public void should_create_instance_of_type_VideoService()
        {
            var service = new TestableVideoService(null);
            Assert.IsInstanceOfType(service, typeof(IVideoService));
        }

        [TestMethod]
        public void should_download_video_when_informed_youtubewrapper_and_save_folder()
        {
            var service = new TestableVideoService(FakeYouTubeWrapper);
            var filename = service.Download(@"C:\Temp");

            Assert.IsTrue(!string.IsNullOrEmpty(filename));
        }

        [TestMethod]
        public void should_not_download_video_when_save_folder_not_informed()
        {
            var service = new TestableVideoService(FakeYouTubeWrapper);
            var filename = service.Download(string.Empty);

            Assert.IsTrue(string.IsNullOrEmpty(filename));
        }

        [TestMethod]
        public void should_not_download_video_when_invalid_save_folder_informed()
        {
            var service = new TestableVideoService(FakeYouTubeWrapper);
            var filename = service.Download(null);

            Assert.IsTrue(string.IsNullOrEmpty(filename));
        }

        [TestMethod]
        public void should_fail_download_when_cannot_save_on_disk()
        {
            var service = new TestableVideoService(FakeYouTubeWrapper) { FailOnSaveToDisk = true };
            var filename = service.Download(null);

            Assert.IsTrue(string.IsNullOrEmpty(filename));
        }
    }

    internal class TestableVideoService : VideoService
    {
        public TestableVideoService(IYouTubeWrapper youTube)
            : base(youTube)
        {
        }

        public bool FailOnSaveToDisk { get; set; }

        protected override bool SaveFileToDisk(string filename, byte[] videoContent)
        {
            return !FailOnSaveToDisk;
        }
    }
}