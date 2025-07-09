using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assessment_03
{
    class StreamAppend
    {
        public static void WriteData()
        {
            FileStream files = new FileStream("AppendFile.txt", FileMode.Append, FileAccess.Write);
            StreamWriter stream = new StreamWriter(files);
            Console.WriteLine("Enter text to append");
            string txt = Console.ReadLine();
            stream.WriteLine(txt);
            stream.Flush();
            stream.Close();
            files.Close();
            Console.WriteLine("data appended successfully");
        }
        static void Main()
        {

            WriteData();
            Console.Read();

        }
    }

}



