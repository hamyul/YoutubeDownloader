using System;

namespace YoutubeDownloader.Core.Model
{
    public interface IVideoService
    {
        EventHandler<EventArgs> Downloaded { get; set; }

        string Download(string savePath);
    }
}