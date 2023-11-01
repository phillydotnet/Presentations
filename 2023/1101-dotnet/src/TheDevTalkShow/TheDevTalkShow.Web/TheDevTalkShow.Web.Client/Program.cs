using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TheDevTalkShow.Web.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// https://console.cloud.google.com/apis/credentials

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ILatestYouTubeVideoService, LatestYouTubeVideoServiceWasm>();

await builder.Build().RunAsync();
