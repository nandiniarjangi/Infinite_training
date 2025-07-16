using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_04
{
    public class Employees
    {
        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Title { get; set; }
        public string city { get; set; }

    }
    class Assessment_04
    {
        static void Main(string[] args)
        {
            List<Employees> emplist = new List<Employees>
            {
                new Employees{EmpId=1001,FirstName= "Malcolm", LastName= "Daruwalla", Title= "Manager", city="Mumbai"},
                new Employees{EmpId=1002,FirstName= "Asdin", LastName= "Dhalla", Title= "AsstManager",city="Mumbai"},
                new Employees{EmpId=1003,FirstName= "Madhavi", LastName= "Oza", Title= "Consultant",city="Pune"},
                new Employees{EmpId=1004,FirstName= "Saba", LastName= "Shaikh", Title= "SE", city="Pune"},
                new Employees{EmpId=1005,FirstName= "Nazia", LastName= "Shaikh", Title= "SE", city="Mumbai"},
                new Employees{EmpId=1006,FirstName= "Amit", LastName= "Pathak", Title= "Consultant",city="Chennai"},
                new Employees{EmpId=1007,FirstName= "Vijay", LastName= "Natarajan", Title= "Consultant",city="Mumbai"},
                new Employees{EmpId=1008,FirstName= "Rahul", LastName= "Dubey", Title= "Associate", city="Chennai"},
                new Employees{EmpId=1009,FirstName= "Suresh", LastName= "Mistry", Title= "Associate",city="Chennai"},
                new Employees{EmpId=1010,FirstName= "Sumit", LastName= "Shah", Title= "Manager",city="Pune"}
                };
            Console.WriteLine("------------To display all employees data------------");
            foreach (var x in emplist)
            {
                Console.WriteLine($"Employee Id : {x.EmpId} , Employee FirstName : {x.FirstName},Employee LastName : {x.LastName} ,Title : {x.Title},Employee City : {x.city}");
            }
            Console.WriteLine("------------------------");
            Console.WriteLine("Display details of all the employee whose location is not Mumbai");
            var result1 = emplist.Where(e1 => e1.city.ToLower() != "mumbai");
            foreach (var x in result1)
            {
                Console.WriteLine($"Employee Id : {x.EmpId} , Employee FirstName : {x.FirstName},Employee LastName : {x.LastName} ,Title : {x.Title},Employee City : {x.city}");
            }
            Console.WriteLine("------------------------");
            Console.WriteLine("Display details of all the employee whose title is AsstManager");
            var result2 = emplist.Where(e2 => e2.Title.ToLower() == "asstmanager");
            foreach (var x in result2)
            {
                Console.WriteLine($"Employee Id : {x.EmpId} , Employee FirstName : {x.FirstName},Employee LastName : {x.LastName} ,Title : {x.Title},Employee City : {x.city}");
            }

            Console.WriteLine("------------------------");
            Console.WriteLine("Display details of all the employee whose Last Name start with S");
            var result3 = emplist.Where(e3 => e3.LastName.StartsWith("S"));
            foreach (var x in result3)
            {
                Console.WriteLine($"Employee Id : {x.EmpId} , Employee FirstName : {x.FirstName},Employee LastName : {x.LastName} ,Title : {x.Title},Employee City : {x.city}");
            }
            Console.Read();
        }
    }
}