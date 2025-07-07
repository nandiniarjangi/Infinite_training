using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




//Create a list of employees with following property EmpId, EmpName, EmpCity, EmpSalary. Populate some data
//Write a program for following requirement
//a.	To display all employees data
//b.	To display all employees data whose salary is greater than 45000
//c.	To display all employees data who belong to Bangalore Region
//d.	To display all employees data by their names is Ascending order



namespace Assignment_7
{
    class Employees
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpCity { get; set; }
        public double Empsalary { get; set; }

    }
    class Program_3
    {
        static void Main()
        {
            List<Employees> employee = new List<Employees>();

            for (int i = 0; i < 3; i++)
            {
                Console.Write("enter the employee id {0} Id : ", i + 1);
                int e_id = Convert.ToInt32(Console.ReadLine());
                Console.Write("enter the employee {0} Name : ", i + 1);
                string e_name = Console.ReadLine();
                Console.Write("enter the employee {0} city : ", i + 1);
                string e_city = Console.ReadLine();
                Console.Write("enter the employee {0} salary : ", i + 1);
                double e_salary = Convert.ToDouble(Console.ReadLine());

                employee.Add(new Employees
                {
                    EmpId = e_id,
                    EmpName = e_name,
                    EmpCity = e_city,
                    Empsalary = e_salary
                });
            }
            Console.WriteLine("------------To display all employees data------------");
            foreach (var x in employee)
            {
                Console.WriteLine($"Employee Id : {x.EmpId} , Employee Name : {x.EmpName} ,Employee City : {x.EmpCity} ,Employee Salary : {x.Empsalary}");
            }
            Console.WriteLine("---------To display all employees data whose salary is greater than 45000-------------------");
            var emp = employee.Where(e => e.Empsalary > 45000);
            foreach (var y in emp)
            {
                if (y != null)
                {
                    Console.WriteLine($"Employee Id : {y.EmpId} , Employee Name : {y.EmpName} ,Employee City : {y.EmpCity} ,Employee Salary : {y.Empsalary}");
                }
                else
                    Console.WriteLine("Employee not found");
            }
            Console.WriteLine("----------To display all employees data who belong to Bangalore Region------------");
            var emp1 = employee.Where(e1 => e1.EmpCity.ToLower() == "banglore");
            foreach (var z in emp1)
            {
                Console.WriteLine($"Employee Id : {z.EmpId} , Employee Name : {z.EmpName} ,Employee City : {z.EmpCity} ,Employee Salary : {z.Empsalary}");
            }
            Console.WriteLine("-----------To display all employees data by their names is Ascending order------------");
            IEnumerable<Employees> sortedEmployees = employee.OrderBy(e2 => e2.EmpName);

            foreach (var n in sortedEmployees)
            {
                Console.WriteLine(n.EmpName);
            }
            Console.Read();

        }
    }
}
