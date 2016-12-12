using EADN.Samples.Demo.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace EADN.Samples.Demo.WindowsServiceHost
{
    partial class DemoService : ServiceBase
    {
        // EADN.Samples.Demo.Contracts
        ServiceHost serviceHost = null;
        //ServiceHost elaborateServiceHost = null;
        public DemoService()
        {
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {
            // EventLog Eintrag machen
            EventLog.WriteEntry("Hello from OnStart", EventLogEntryType.Information);

            // Host erzeugen
            serviceHost = new ServiceHost(typeof(DemoService));

            // Konfigurieren CBA -> imperativ
            serviceHost.AddServiceEndpoint(
                typeof(IDemo),
                new BasicHttpBinding(),
                "http://localhost:4711/DemoService");

            // Starten
            serviceHost.Open();
        }
        protected override void OnStop()
        {
            EventLog.WriteEntry("Hello from OnStart", EventLogEntryType.Information);

            serviceHost?.Close();
        }
        protected override void OnPause()
        {
            /* Regel: Reinschauen was in der Base-Klasse passiert, 
                dann entscheiden ob base.method nötig ist
                base.OnPause(); 
            */
            EventLog.WriteEntry("Hello from OnPause", EventLogEntryType.Information);
        }
        protected override void OnContinue()
        {
            // Reflection
            EventLog.WriteEntry($"Hello from {MethodInfo.GetCurrentMethod().Name}", EventLogEntryType.Information);
        }
        protected override void OnCustomCommand(int command)
        {
            EventLog.WriteEntry($"Hello from {MethodInfo.GetCurrentMethod().Name}", EventLogEntryType.Information);
            base.OnCustomCommand(command);
        }
        protected override void OnShutdown()
        {
            EventLog.WriteEntry($"Hello from {MethodInfo.GetCurrentMethod().Name}", EventLogEntryType.Information);
            base.OnShutdown();
        }
    }
}