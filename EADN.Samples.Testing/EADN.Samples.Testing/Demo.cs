using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EADN.Samples.Testing
{
    public class Demo
    {

        public string Foo(string argument)
        {
            if(argument == null)
            {
                throw new ArgumentNullException();
            }

            return $"Repeat: {argument} ";
        }
    }
}
