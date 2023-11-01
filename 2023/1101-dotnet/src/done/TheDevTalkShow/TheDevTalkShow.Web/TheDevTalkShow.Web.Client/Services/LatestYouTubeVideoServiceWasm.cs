using System.Net.Http.Json;

namespace TheDevTalkShow.Web.Client.Services
{
    public class LatestYouTubeVideoServiceWasm(HttpClient httpClient) : ILatestYouTubeVideoService
    {
        public async Task<string> GetLatestVideoId()
        {
            return await httpClient.GetFromJsonAsync<string>("youtube/latest") ?? string.Empty;
        }
    }
}
