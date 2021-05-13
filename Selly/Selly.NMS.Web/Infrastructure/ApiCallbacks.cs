using Selly.NMS.API.APICallbacks;
using Selly.NMS.Web.Hubs;
using AutoMapper;
using Selly.NMS.Web.Models;
using System.Linq;
using System;
using Microsoft.AspNetCore.SignalR;

namespace Selly.NMS.Web.APICallbacks
{
    public class ApiCallbacks : IApiCallbacks
    {
        public void FirewallEvent(string source, API.DTO.PacketDroppedEvent e)
        {
            var domainEvent = Mapper.Map<Models.PacketDroppedEvent>(e);

            // TODO: DB Context: Not from DI
            using (MainDbContext db = new MainDbContext())
            {
                var device = db.Devices.Where(dev => dev.Address == e.LocalAddress).FirstOrDefault();
                domainEvent.Device = device;
                db.Events.Add(domainEvent);
                db.SaveChanges();

                try
                {
                    var hub = (IHubContext<HomeHub>)Program.host.Services.GetService(typeof(IHubContext<HomeHub>));

                    string msg = $@"Event occurred. Port: {e.LocalPort}. Address: {e.RemoteAddress}. FID: {e.FilterName}";
                    hub.Clients.All.SendAsync("messageReceived", msg).Wait();
                }
                catch (NullReferenceException)
                {
                    // TODO: Log exception.
                }
            }
        }
    }
}