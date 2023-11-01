using TheDevTalkShow.Web.Client.Pages;
using TheDevTalkShow.Web.Client.Services;
using TheDevTalkShow.Web.Components;
using TheDevTalkShow.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddHttpClient();

//builder.Services.AddScoped<ILatestYouTubeVideoService, LatestVideoYouTubeServiceServer>();

var apiKey = builder.Configuration["ApiKey"];

builder.Services.AddScoped<ILatestYouTubeVideoService, LatestVideoYouTubeServiceServer>(
    serviceProvider => new LatestVideoYouTubeServiceServer(
            httpClientFactory: serviceProvider.GetRequiredService<IHttpClientFactory>(),
            ApiKey: apiKey));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Counter).Assembly);

app.MapGet("/youtube/latest", async (ILatestYouTubeVideoService latestYouTubeVideo) =>
{
    var response = await latestYouTubeVideo.GetLatestVideoId();

    if (string.IsNullOrEmpty(response))
    {
        return Results.Problem();
    }

    return Results.Ok(response);
});

app.Run();
