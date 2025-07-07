using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;




//3. Write a program in C# Sharp to count the number of lines in a file.



namespace Assignment_6
{
    class StreamRead
    {
        public void ReadData()
        {
            FileStream files = new FileStream("ArrayOfStrings.txt", FileMode.Open, FileAccess.Read);

            StreamReader stream = new StreamReader(files);
            int count = 0;
            string line = stream.ReadLine();
            while (line != null)
            {
                Console.WriteLine("{0} ", line);
                line = stream.ReadLine();
                count++;
            }
            Console.WriteLine($"The file contains {count} lines ");
            stream.Close();
            files.Close();
        }

    }
    class Program_3
    {
        static void Main()
        {

            StreamRead streamreader = new StreamRead();
            streamreader.ReadData();
            Console.Read();
        }
    }
}