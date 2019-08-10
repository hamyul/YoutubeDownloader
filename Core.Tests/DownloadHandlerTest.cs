using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YoutubeDownloader.Core.Model;

namespace YoutubeDownloader.Core.Tests
{
    [TestClass]
    public class DownloadHandlerTest
    {
        [TestMethod]
        public void Test()
        {
            VideoService videoService = new VideoService();
            string filename = videoService.Download("https://www.youtube.com/watch?v=KLofiHLn11Y", @"C:\Temp\YouTubeDownloader");


        }

        [TestMethod]
        public void Test2()
        {
            AudioService audioService = new AudioService();
            audioService.ExtractAudio(@"C:\Temp\YouTubeDownloader\LULA TRANSFERIDO DE PRESÍDIO!.mp4", @"C:\Temp\YouTubeDownloader\LULA TRANSFERIDO DE PRESÍDIO!.mp3");
            audioService.SetAudioTags(@"C:\Temp\YouTubeDownloader\LULA TRANSFERIDO DE PRESÍDIO!.mp3", "Test", "Test album", "YouTube");
        }
    }
}
