namespace YoutubeDownloader.Core.Wrappers
{
    public interface IYouTubeWrapper
    {
        byte[] GetBytes();

        string Title { get; }

        string Url { get; set; }
    }
}