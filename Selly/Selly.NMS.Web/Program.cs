using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using Selly.NMS.Web.APICallbacks;
using System.Security.Cryptography.X509Certificates;

namespace Selly.NMS.Web
{
    public class Program
    {
        public static ApiCallbacks Callbacks;
        public static IWebHost host;
        public static API.IConfiguration Config;

        public static void Main(string[] args)
        {
            Callbacks = new ApiCallbacks();
            Config = new Configuration();

            API.Program.SetCallbacks(Callbacks, Config);

            host = CreateWebHostBuilder(args).Build();
            var nms = Task.Run(() => host.Run());
            var api = Task.Run(() => API.Program.Main(args));
            Task.WhenAll(nms, api).Wait();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseKestrel(options =>
                {
                    options.ConfigureHttpsDefaults(ssl =>
                    {
                        var cert = new X509Certificate2(Config.CertificatePath, Config.CertificatePassword);
                        ssl.ServerCertificate = cert;
                    });
                })
                .UseUrls("https://*:5001")
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>();
        }
    }
}
