using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EADN.Samples.Demo.Contracts
{
    [ServiceContract(Name ="ElaborateService", Namespace =Constants.XmlNamespace)]
    public interface IElaborateService
    {
        [OperationContract(Name ="GetData")]
        string GetData(string param);
    }
}
