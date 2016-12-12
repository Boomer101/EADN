using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EADN.Samples.Demo.Implementation
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public sealed class ElaborateServiceSingle : Contracts.IElaborateService
    {
        public string CurrentData { get; set; } = string.Empty;
        public string GetData(string param)
        {
            CurrentData += " " + param;
            return CurrentData;
        }
    }
}
