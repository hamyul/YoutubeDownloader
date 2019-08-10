using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeDownloader.Core.Wrappers
{
    public interface IYouTubeWrapper
    {
        byte[] GetBytes();
        string Title { get; }

        string Url { get; set; }
    }
}
