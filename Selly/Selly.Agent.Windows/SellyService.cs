using AutoMapper;
using System;
using System.Diagnostics;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;

namespace Selly.Agent.Windows
{
    public partial class SellyService : ServiceBase
    {
        private static NmsApiClient _apiClient;
        public static NmsApiClient ApiClient { get => _apiClient; }

        ApiConfiguration config;
        EtwHelper etwHelper;
        SnmpClient snmpClient;

        public SellyService()
        {
            InitializeComponent();
            try
            {
                config = new ApiConfiguration();
                _apiClient = new NmsApiClient(config);
                etwHelper = new EtwHelper();
                snmpClient = new SnmpClient();

                Mapper.Initialize((mappings) =>
                {
                    mappings.CreateMap<FirewallAPI.Rule, Models.Rule>();
                });
            }
            catch (Exception e)
            {
                ExceptionHelper.WriteFile(e, "Constructor");
            }
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                ToastHelper.PopToast("Starting...");
                Task.Run(delegate { API.Program.Main(args, new ApiCallbacks(), config); });
                Task.Run(delegate { etwHelper.Run(); });
                Task.Run(delegate { snmpClient.Start(); });
            }
            catch (Exception e)
            {
                ExceptionHelper.WriteFile(e, "Global exception handler");
            }            
        }

        protected override void OnStop()
        {
            try
            {
                ToastHelper.PopToast("Stopping...");
                ApiClient.Dispose();
                etwHelper.Dispose();
                snmpClient.Close();
            }
            catch (Exception e)
            {
                ExceptionHelper.WriteFile(e, "On stop");
            }            
        }
    }

    public class Initialiser
    {
        public static void Init()
        {
            Mapper.Initialize((mappings) =>
            {
                mappings.CreateMap<FirewallAPI.Rule, Models.Rule>();
            });
        }
    }
}
