using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2Csharp
{
    class InstanceVSStatic
    {
        int mydata;//non static member or instance member
        static int ourdata;//static member
        public void accessFunction()
        {
            InstanceVSStatic instobj1 = new InstanceVSStatic();
            instobj1.mydata = 5;
            InstanceVSStatic instobj2 = new InstanceVSStatic();
            instobj2.mydata = 10;
            Console.WriteLine(instobj1.mydata + " " + instobj2.mydata);
        }
        static void Main() => InstanceVSStatic.accessFunction();
    }
}
