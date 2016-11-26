using EADN.Samples.Demo.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EADN.Samples.Demo.Implementation
{
    public sealed class ElaborateService : IElaborateService
    {
        public string CurrentData { get; set; } = string.Empty;

        public string GetData(string param)
        {
            CurrentData += " " + param;
            return CurrentData;
        }
    }
}
