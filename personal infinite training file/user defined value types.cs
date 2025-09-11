using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2CSharp
{
    struct Student
    {
        public float mathsmarks;
        public float Sciencemarks;
        public void show()
        {
            Console.WriteLine(mathsmarks + s1.Sciencemarks);
        }
    }
    class UserDefinedValueTypes
    {
        public static void Main()
        {
            Student s1 = new Student();
            s1.mathsmarks = 91.5f;
            s1.Sciencemarks = 80f;
            Console.WriteLine(s1.mathsmarks + s1.Sciencemarks);
            s1.show();
            Student s2 = s1;//assigning s1 to s2
            Console.WriteLine(s2.mathsmarks + s2.Sciencemarks);
            Console.WriteLine("----After reassigning the value----");
            s1.mathsmarks = 95;
            Console.WriteLine(s1.mathsmarks + s1.Sciencemarks);
            Console.WriteLine(s2.mathsmarks + s2.Sciencemarks);
            Console.Read();
        }
    }
    enum cities {Agra=3,Banglore=1,Chennai=2,Delhi=4,Hyderabad=6,Vizag=5 }
    class Enumerations
    {
        enum Days {Mon=10,Tue,Wed,Thurs,Fri=20,Sat,Sun}
       
    public static void EnumOps()
        {
            foreach(int c in Enum.GetValues(typeof(cities)))
            {
                if (c == 1) { 
                    Console.WriteLine(Enum.GetName(typeof(cities), c)+" "+"is a Garden City");
                else if (c == 2) {
                        Console.WriteLine(Enum.GetName(typeof(cities), c) + " " + "is a Temple City");
                    }
                    else if (c == 5) {
                        Console.WriteLine(Enum.GetName(typeof(cities), c) + " " + "is a steel City");
                    }
                    Enumerations e = new Enumerations();
                    foreach(int i in Enum.GetValues(typeof(Enumerations.Days)))
                        Console.WriteLine("-------");
                        foreach(var x in Enum.GetNames(typeof(cities)))
                        {
                            Console.WriteLine(x);
                        }
                        Console.WriteLine("---Accessing constants---");
                        int wkstart = (int)Days.Mon;
                        int weekend = (int)Days.Fri;
                        Console.WriteLine("Mondays are Weekstarts :{0}", wkstart);
                        Console.WriteLine("Fridays are Weekstarts :{0}", wkend);
                        
            }
        }
    }
}

        
       
