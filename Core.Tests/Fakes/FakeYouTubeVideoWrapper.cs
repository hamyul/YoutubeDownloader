using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeDownloader.Core.Tests.Fakes
{
    public class FakeYouTubeVideoWrapper : IYoutubeVideo
    {
        public string FullName { get { return string.Empty; } }
    }
}
