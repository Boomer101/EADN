using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace EADN.Samples.Demo.Contracts
{
    [ServiceContract(Name= "Demo", Namespace=Constants.XmlNamespace)]
    public interface IDemo
    {
        [OperationContract(Name = "GetApplicationDomainName")]
        string GetApplicationDomainName(); // Verbindungskontrolle 

        [OperationContract(Name = "SetValue")]
        void SetValue(double value);

        [OperationContract(Name = "GetValue")]
        double GetValue();

        [OperationContract(Name = "NextValue")]
        DemoEnum NextValue(DemoEnum enumValue);

        [OperationContract(Name = "Update")]
        IList<DemoData> Update(DemoData data, int amount);
    }
}
