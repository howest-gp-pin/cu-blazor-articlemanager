using ArticleManager.Web;
using ArticleManager.Web.Models;
using ArticleManager.Web.Services;
using ArticleManager.Web.Services.Mocks;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace ArticleManager.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddTransient<ICRUDService<Category>, FakeCategoryService>();

            await builder.Build().RunAsync();
        }
    }
}