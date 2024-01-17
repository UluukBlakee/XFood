global using Microsoft.AspNetCore.Components.Authorization;
global using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using XFoodBlazor.Web.Client.Services.Authorization;
using XFoodBlazor.Web.Client.Services.Pizzeria;
using XFoodBlazor.Web.Client.Services.Manager;
using XFoodBlazor.Web.Client.Services.Check_List;
using XFoodBlazor.Web.Client.Services.CheckListCriteria;

namespace XFoodBlazor.Web.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IPizzeriaService, PizzeriaService>();
            builder.Services.AddScoped<IManagerService, ManagerService>();
            builder.Services.AddScoped<ICheckService, CheckService>();
            builder.Services.AddScoped<ICheckListCriteriaService, CheckListCriteriaService>();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7051/api/") });
            
            await builder
                .Build()
                .RunAsync();
        }
    }
}