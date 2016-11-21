using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EADN.Samples.Demo.Contracts
{
    [DataContract(Name ="DemoEnum", Namespace = Constants.XmlNamespace)]
    public enum DemoEnum
    {
        [EnumMember]
        Unknown,

        [EnumMember]
        Large,

        [EnumMember]
        Medium,

        [EnumMember]
        Small
    }
}
