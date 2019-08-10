using System;
using System.Diagnostics;
using System.IO;
using VideoLibrary;

namespace YoutubeDownloader.Core.Model
{
    public class VideoService
    {
        public EventHandler<EventArgs> Downloaded { get; set; }

        public string Download(string url, string savePath)
        {
            try
            {
                YouTubeVideo video = YouTube.Default.GetVideo(url);
                string filename = GetFilename(savePath, video.Title);
                File.WriteAllBytes(filename, video.GetBytes());
                Downloaded?.Invoke(this, new EventArgs());

                return filename;
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return string.Empty;
            }
        }

        protected string GetFilename(string path, string title)
        {
            string filename = Path.ChangeExtension(title.Replace(" - YouTube", string.Empty), ".mp4");
            foreach(char c in new string(Path.GetInvalidFileNameChars()))
            {
                filename = filename.Replace(c.ToString(), string.Empty);
            }
            
            foreach(char c in new string(Path.GetInvalidPathChars()))
            {
                path = path.Replace(c.ToString(), string.Empty);
            }

            return Path.Combine(path, filename);
        }
    }
}