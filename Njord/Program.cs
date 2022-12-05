using HttpClients.Auth;
using HttpClients.ClientInterfaces;
using HttpClients.Implementations;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Njord;
using Radzen;
using System.Globalization;
using Domain.Auth;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7033") });

builder.Services.AddScoped<DialogService>();

builder.Services.AddScoped<IMemberService, MemberHttpClient>();
builder.Services.AddScoped<ITeamService, TeamHttpClient>();
builder.Services.AddScoped<IAuthService, JwtAuthService>();
builder.Services.AddScoped<IProjectService, ProjectHttpClient>();
builder.Services.AddScoped<ILogBookService, LogBookHttpClient>();
builder.Services.AddScoped<ITaskService, TaskHttpClient>();
builder.Services.AddScoped<IMeetingService, MeetingHttpClient>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();

builder.Services.AddAuthorizationCore();

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("da-DK");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("da-DK");

await builder.Build().RunAsync();
