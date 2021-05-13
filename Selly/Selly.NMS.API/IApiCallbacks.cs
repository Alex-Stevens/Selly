using Selly.NMS.API.DTO;

namespace Selly.NMS.API.APICallbacks
{
    public interface IApiCallbacks
    {
        void FirewallEvent(string source, PacketDroppedEvent e);
    }
}
