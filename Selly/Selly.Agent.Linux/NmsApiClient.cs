using Selly.NMS.API.DTO;
using System;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Selly.Agent.API;

namespace Selly.Agent.Linux
{
    public class NmsApiClient : IDisposable
    {
        private const string CONTENT_TYPE = "application/json";
        private X509Certificate2 certificate;
        private HttpClient client;

        public NmsApiClient(IApiConfiguration config)
        {
            // Select certificate to send 
            certificate = new X509Certificate2(config.CertificatePath, config.CertificatePassword);

            // Configure handler
            HttpClientHandler handler = new HttpClientHandler();
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback = CheckCertificate;
            handler.ClientCertificates.Add(certificate);

            // HTTP client
            client = new HttpClient(handler);
            client.BaseAddress = new Uri(config.ServerEndpoint);
        }

        public async Task SendRequest()
        {
            var content = new StringContent("");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync("api/values", content);
        }

        public async Task SendEvent(Event data)
        {
            // Configure content
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue(CONTENT_TYPE);

            // Make request 
            var response = await client.PostAsync("api/events", content);
            if (!response.IsSuccessStatusCode) { throw new Exception($"Bad status code {response.StatusCode}"); }

            // Process reponse
            var jsonResponse = await response.Content.ReadAsStringAsync();
        }

        private static bool CheckCertificate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}
