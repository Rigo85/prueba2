using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldService
{
    public class HelloWorldService : IHelloWorldService
    {
        public String GetMessage(string name)
        {
            return "Hello world from " + name + "!";
        }
    }
}
