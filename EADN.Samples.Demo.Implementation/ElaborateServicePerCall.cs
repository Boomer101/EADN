using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EADN.Samples.Demo.Contracts;
using System.ServiceModel;

namespace EADN.Samples.Demo.Implementation
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public sealed class ElaborateServicePerCall : IElaborateService
    {
        public string CurrentData { get; set; } = string.Empty;
        public string GetData(string param)
        {
            CurrentData += " " + param;
            return CurrentData;
        }
    }
}
