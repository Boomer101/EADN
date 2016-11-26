using EADN.Samples.Demo.Contracts;
using EADN.Samples.Demo.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EADN.Samples.Demo.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost serviceHost = null;
            ServiceHost elaborateServiceHost = null;

            try
            {
                // Host erzeugen
                serviceHost = new ServiceHost(typeof(DemoService));

                // Konfigurieren CBA -> deklarativ
                //serviceHost.AddServiceEndpoint(
                //    typeof(IDemo), 
                //    new BasicHttpBinding(), 
                //    "http://localhost:4711/DemoService");

                // Starten
                serviceHost.Open();
                
                // Deklarativ konfiguriert -> app.config
                elaborateServiceHost = new ServiceHost(typeof(ElaborateService));
                elaborateServiceHost.Open();

                Console.WriteLine("Host is running...");
                Console.ReadKey();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Caught exception: {exception.Message}");
            }
            finally
            {
                if(serviceHost != null)
                {
                    serviceHost.Close();
                }

                // C# 6.0:
                elaborateServiceHost?.Close();
            }
        }
    }
}
