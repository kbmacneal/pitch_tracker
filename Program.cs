using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace pitch_tracker
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }

        //class BlazorHttpClientFactory : DefaultHttpClientFactory
        //{
        //    public override HttpClient CreateHttpClient(HttpMessageHandler handler)
        //    {
        //        return new HttpClient();
        //    }

        //    public override HttpMessageHandler CreateMessageHandler()
        //    {
        //        return null;
        //    }

        //}
    }
}