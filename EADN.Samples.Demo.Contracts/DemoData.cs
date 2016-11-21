using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EADN.Samples.Demo.Contracts
{
    // DataContract Attribute immer benennen
    // Immer Konstanten nutzen, kein nameOf !
    [DataContract(Name = "DemoData", Namespace = Constants.XmlNamespace)]
    public class DemoData
    {
        // DataContract Attribute benennen, Order = 1
        // Order definiert die Ordnung der Attribute
        // Neue (produktive) Version 2, Order = 2 etc.
        [DataMember(Name="Id", Order =1)]
        public Guid Id { get; set; }

        [DataMember(Name = "Name", Order = 1)]
        public string Name { get; set; }

        [DataMember(Name = "Date", Order = 1)]
        public DateTime Date { get; set; }

        [DataMember(Name = "Data", Order = 1)]
        public byte[] Data { get; set; }

        [DataMember(Name = "Value", Order = 1)]
        public double Value { get; set; }

        [DataMember(Name = "EnumValue", Order = 1)]
        public DemoEnum EnumValue { get; set; }
    }
}
