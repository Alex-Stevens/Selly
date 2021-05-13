namespace Selly.NMS.API
{
    public interface IConfiguration
    {
        string CertificatePath { get; set; }
        string CertificatePassword { get; set; }
    }
}
