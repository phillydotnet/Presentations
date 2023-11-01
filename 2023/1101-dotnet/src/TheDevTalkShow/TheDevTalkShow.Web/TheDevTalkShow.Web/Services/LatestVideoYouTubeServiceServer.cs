using TheDevTalkShow.Web.Client.Services;
using TheDevTalkShow.Web.Models;

namespace TheDevTalkShow.Web.Services
{
    public class LatestVideoYouTubeServiceServer(IHttpClientFactory httpClientFactory, string ApiKey) : ILatestYouTubeVideoService
    {
        public async Task<string> GetLatestVideoId()
        {
            var client = httpClientFactory.CreateClient();

            var ytResponse = await client.GetFromJsonAsync<YouTubeResponse>($"https://youtube.googleapis.com/youtube/v3/search?part=snippet&channelId=UC2iybVI2TE2LQ6straknrnA&maxResults=5&order=date&type=video&key={ApiKey}");

            if (ytResponse.items.Length > 0)
            {
                return ytResponse.items[0].id.videoId;
            }

            return string.Empty;
        }
    }
}
