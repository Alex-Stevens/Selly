using Selly.Agent.API;
using Selly.Agent.Windows.Properties;

namespace Selly.Agent.Windows
{
    class ApiConfiguration : IApiConfiguration
    {
        public ApiConfiguration()
        {
            CertificatePath = Settings.Default[nameof(CertificatePath)].ToString();
            CertificatePassword = Settings.Default[nameof(CertificatePassword)].ToString();
            Endpoint = Settings.Default[nameof(Endpoint)].ToString();
            ServerEndpoint = Settings.Default[nameof(ServerEndpoint)].ToString();
            AppSettingsPath = Settings.Default[nameof(AppSettingsPath)].ToString();
        }

        public string CertificatePath { get; private set; }

        public string CertificatePassword { get; private set; }

        public string Endpoint { get; private set; }

        public string ServerEndpoint { get; private set; }

        public string AppSettingsPath { get; private set; }
    }
}