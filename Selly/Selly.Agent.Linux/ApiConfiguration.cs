using System;
using Selly.Agent.API;

namespace Selly.Agent.Linux
{
    internal class ApiConfiguration : IApiConfiguration
    {
        public ApiConfiguration()
        {
            CertificatePath = @"/home/user/selly/Selly-LIN.pfx";
            CertificatePassword = "selly";
            Endpoint = "https://*:5002";
            AppSettingsPath = @"/home/user/selly/Selly/Selly.Agent.Linux/bin/Debug/netcoreapp2.0/appsettings";
            ServerEndpoint = "https://192.168.1.125:5002";
        }

        public string CertificatePath { get; private set; }

        public string CertificatePassword { get; private set; }

        public string Endpoint { get; private set; }

        public string ServerEndpoint { get; private set; }

        public string AppSettingsPath { get; private set; }
    }
}