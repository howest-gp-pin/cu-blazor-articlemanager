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

            builder.Services.AddTransient<ICRUDService<Category>, FakeCategoryService>();
            builder.Services.AddTransient<ICRUDService<Article>, FakeArticleService>();
            builder.Services.AddSingleton<HttpClient>();

            await builder.Build().RunAsync();
        }
    }
}