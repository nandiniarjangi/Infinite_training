using System;


namespace Assessment_1
{
    class RemoveCharacter
    {
        public static void Remove_Character(string s,int pos)
        {
            string result = " ";
            if(pos<0 || pos >= s.Length)
            {
                Console.WriteLine("Invalid position");
            }
            else
            {
                result = s.Remove(pos, 1);
            }
            Console.WriteLine("After Removing Characters:{0}", result);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the String");
            string s = Console.ReadLine();
            Console.WriteLine("Enter the position to remove");
            int pos = Convert.ToInt32(Console.ReadLine());
            Remove_Character(s, pos);
            Console.Read();

        }
    }
}
