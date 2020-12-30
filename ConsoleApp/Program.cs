using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeDownloader.Core.Wrappers;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IYouTubeWrapper youtube = new YouTubeWrapper("https://www.youtube.com/watch?v=Y1NfRN4D7NE");
            //byte[] bytes = youtube.GetBytes();

            //using (FileStream stream = new FileStream(@"C:\Users\hammo\Downloads\youtube_downloader.mp4", FileMode.CreateNew))
            //{
            //    stream.Write(bytes, 0, bytes.Length);
            //    stream.Close();
            //}

            youtube.Download();
        }
    }
}
