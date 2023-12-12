global using Microsoft.AspNetCore.Components.Authorization;
global using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using XFoodBlazor.Web.Client.Services.Authorization;

namespace XFoodBlazor.Web.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44318/api/") });
            builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddScoped<IAuthService, AuthService>();
            
            await builder
                .Build()
                .RunAsync();
        }
    }
}