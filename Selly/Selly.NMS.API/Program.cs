using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Selly.NMS.API.APICallbacks;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Selly.NMS.API
{
    public class Program
    {
        public static IApiCallbacks Callbacks;
        public static IConfiguration Configuration;

        public static void SetCallbacks(IApiCallbacks callbacks, IConfiguration config)
        {
            Callbacks = callbacks;
            Configuration = config;
        }

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseKestrel(options =>
                {
                    options.ConfigureHttpsDefaults(ssl =>
                    {
                        var cert = new X509Certificate2(Configuration.CertificatePath, Configuration.CertificatePassword);
                        ssl.ServerCertificate = cert;
                    });
                })
                .UseUrls("https://*:5002")
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>();
    }
}