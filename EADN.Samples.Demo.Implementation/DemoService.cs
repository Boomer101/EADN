using EADN.Samples.Demo.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EADN.Samples.Demo.Implementation
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class DemoService : IDemo
    {
        //[ThreadStatic]
        private double InternalValue;

        private Random RandomGenerator = new Random();

        public string GetApplicationDomainName()
        {
            return AppDomain.CurrentDomain.FriendlyName;
        }

        public double GetValue()
        {
            return InternalValue;
        }

        public void SetValue(double value)
        {
            InternalValue = value;
        }

        public DemoEnum NextValue(DemoEnum enumValue)
        {
            IList values = Enum.GetValues(typeof(DemoEnum));
            int index = values.IndexOf(enumValue);
            return (DemoEnum)values[(index + 1)%4] ;
        }

        public IList<DemoData> Update(DemoData data, int amount)
        {
            List<DemoData> demoData = new List<DemoData>();

            data.Name += " Round-trip";
            demoData.Add(data);
            for (int index = 0; index < amount; index++)
            {
                demoData.Add(GenerateDemoDataObject());
            }

            return demoData;
        }

        private DemoData GenerateDemoDataObject()
        {
            DemoData demoData = new DemoData();
            demoData.Id = Guid.NewGuid();
            demoData.Date = DateTime.Now;
            demoData.EnumValue = DemoEnum.Medium;

            int sizeData = RandomGenerator.Next(10, 1024);
            demoData.Data = new byte[sizeData];
            RandomGenerator.NextBytes(demoData.Data);

            demoData.Value = RandomGenerator.NextDouble();
            demoData.Name = $"Name is: {Guid.NewGuid()}"; // $=Interpolated String

            return demoData;
        }
    }
}
