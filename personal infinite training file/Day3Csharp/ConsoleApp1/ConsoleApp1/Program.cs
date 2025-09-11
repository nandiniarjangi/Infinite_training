using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3Csharp
{
    class Employee
    {
        int EmpId;
        string EmpName;
        DateTime DoJ;
        double Salary;
        //constructor 1
        public Employee()
        {
            EmpId = 1;
            EmpName = "Adithya";
            DoJ = Convert.ToDateTime("01/06/2025");
            Salary = 35000;
        }
        public void ShowEmployee()
        {
            Console.WriteLine($"{EmpId},{EmpName},{DoJ},and {Salary}");
        }
        //constructor 2
        public Employee(int empid,string ename)
        {
            EmpId = empid;
            EmpName = ename;

        }
        //constructor 3
        public Employee(int EmpId,string EmpName,DateTime DoJ,double Salary)
        {
           this. EmpId = EmpId;
            this.EmpName = EmpName;
            this.DoJ = DoJ;
            this.Salary = Salary;


        }
        //destructor
        ~Employee()
        {
            Console.WriteLine("Bye from Employee..");
            Console.Read();
        }
        class Program
        {
            static void Main(string[] args)
            {
                Employee employee = new Employee();
                employee.ShowEmployee();
                Employee employee2 = new Employee(100,"Akhilesh");
                employee2.ShowEmployee();
                Employee employee3 = new Employee(101, "Dinesh", Convert.ToDateTime(16/02/25),4000.0);
                employee3.ShowEmployee();
                employee2 = null;
                GC.Collect();
                Console.Read();
            }
        }
    }
}
