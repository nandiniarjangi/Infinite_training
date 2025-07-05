using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


//Write a program in C# Sharp to create a file and write an array of strings to the file.

namespace Assignment_6
{
    class StreamReaderWriter
    {
        public void WriteData()
        {
            FileStream files = new FileStream("ArrayOfStrings.txt", FileMode.Append, FileAccess.Write);
            StreamWriter stream = new StreamWriter(files);

            Console.WriteLine("Enter a length of array : ");
            int length = Convert.ToInt32(Console.ReadLine());
            string[] array = new string[length];
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine("Enter the {0} element in the array : ", i + 1);
                array[i] = Console.ReadLine();
            }
            foreach (string line in array)
            {
                stream.WriteLine(line);
            }
            Console.WriteLine("Data written to the file successfuly");


            stream.Flush();
            stream.Close();
            files.Close();
        }
    }
    class Program_2
    {
        static void Main(string[] args)
        {
            StreamReaderWriter streamwrite = new StreamReaderWriter();
            streamwrite.WriteData();
            Console.Read();
        }
    }
}