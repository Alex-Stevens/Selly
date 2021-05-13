using System.IO;
using Selly.NMS.API;
using System.Reflection;
using System;

namespace Selly.NMS.Web
{
    public class Configuration : API.IConfiguration
    {
        string _certificatePath = "";
        string IConfiguration.CertificatePath
        {
            get
            {
                var certPath = Environment.GetEnvironmentVariable("CERTIFICATE_PATH");
                if(certPath == null)
                {
                    string asmPath = Assembly.GetExecutingAssembly().Location;
                    string asmParent = Path.GetDirectoryName(asmPath);
                    certPath = Path.Combine(asmParent, "selly.pfx");
                }
                return certPath;
            }
            set
            {
                _certificatePath = value;
            }
        }

        string _certificatePassword = "selly";
        string IConfiguration.CertificatePassword
        {
            get
            {
                var certPath = Environment.GetEnvironmentVariable("CERTIFICATE_PASSWORD");
                if (certPath != null)
                {
                    _certificatePassword = certPath;
                }
                
                return _certificatePassword;
            }
            set
            {
                _certificatePassword = value;
            }
        }
    }
}
