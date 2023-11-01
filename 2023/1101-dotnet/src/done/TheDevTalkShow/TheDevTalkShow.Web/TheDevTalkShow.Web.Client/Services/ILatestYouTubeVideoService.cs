namespace TheDevTalkShow.Web.Client.Services
{
    public interface ILatestYouTubeVideoService
    {
        Task<string> GetLatestVideoId();
    }
}
