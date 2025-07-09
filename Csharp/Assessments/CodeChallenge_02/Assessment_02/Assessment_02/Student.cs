using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_2
{
    abstract class Student
    {
        int student_id;
        string name;
        double grade;
        public abstract bool Ispassed(double grade);
    }
    class Under_Graduate : Student
    {
        public override bool Ispassed(double grade)
        {
            if (grade > 70.0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    class Graduate : Student
    {
        public override bool Ispassed(double grade)
        {
            if (grade > 80.0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    class Stud
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------Entering the under graduate student details-----------");
            Console.WriteLine("Enter the student id : ");
            int sid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the student name : ");
            string sname = Console.ReadLine();
            Console.WriteLine("Enter the student grade : ");
            double sgrade = Convert.ToDouble(Console.ReadLine());
            Under_Graduate under_graduate = new Under_Graduate();
            bool result_underGraduate = under_graduate.Ispassed(sgrade);
            Console.WriteLine("------------- Displaying Undergraduate Student Details----------");
            Console.WriteLine("Student id : {0} : ,Student Name :{1} , Student Grade : {2} , Result : {3}", sid, sname, sgrade, result_underGraduate);
            Console.WriteLine("----------Entering the graduate student details----------");
            Console.WriteLine("Enter the student id : ");
            int sid1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the student name : ");
            string sname1 = Console.ReadLine();
            Console.WriteLine("Enter the student grade : ");
            double sgrade1 = Convert.ToDouble(Console.ReadLine());
            Graduate graduate = new Graduate();
            bool result_graduate = graduate.Ispassed(sgrade1);
            Console.WriteLine("-------------Displaying graduate Student Details----------");
            Console.WriteLine("Student id : {0} : ,Student Name :{1} , Student Grade : {2} , Result : {3}", sid1, sname1, sgrade1, result_graduate);
            Console.Read();
        }
    }

}