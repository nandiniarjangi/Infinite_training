using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_2
{
    class Products : IComparable<Products>
    {
        int product_id;
        string product_name;
        double price;
        public Products(int PID, string PName, double Price)
        {
            product_id = PID;
            product_name = PName;
            price = Price;
        }
        public override string ToString()
        {
            return $"Product Id:{product_id},Product name:{product_name},Price:{price}";
        }
        public int CompareTo(Products anotherobj)
        {
            return this.price.CompareTo(anotherobj.price);
        }
        static void Main(string[] args)
        {
            List<Products> product = new List<Products>();
            for (int i = 0; i < 10; i++)
            {
                Console.Write("Enter the product {0} Id:", i + 1);
                int p_id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the product {0} Name:", i + 1);
                string p_name = Console.ReadLine();
                Console.Write("Enter the product {0} price:", i + 1);
                double p_price = Convert.ToDouble(Console.ReadLine());
                Products p = new Products(p_id, p_name, p_price);
                product.Add(p);
            }
            Console.WriteLine("Before Sorting:");
            foreach (Products x in product)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("After sorting: ");
            product.Sort();
            foreach (Products x in product)
            {
                Console.WriteLine(x);
            }
            Console.Read();
        }
    }
}
