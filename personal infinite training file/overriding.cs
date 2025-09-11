using System;


namespace Day23_06csharp
{
    class Shape
    {
        protected float R, L, B;
        public virtual float Area()
        {
            return 3.14f * R * R;
        }
        public virtual float Circumference()
        {
            return 2 * 3.14f * R;
        }
    }
    class Rectangle : Shape
    {
     public void GetLB()
        {
            Console.WriteLine("Enter length:");
            L = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter breadth:");
            B = float.Parse(Console.ReadLine());
        }
        public override float Area()
        {
            GetLB();
            return L * B;
        }
    }
    

    class OveridingEg
    {
        static void Main()
        {
            Rectangle rectangle = new Rectangle();

            Console.WriteLine("Area of rectangle is{0}",rectangle.Area());
            Console.WriteLine("Rectangle circumference is{0}", rectangle.Circumference());
            Circle circle = new Circle();
            Console.WriteLine("Area of circle {0}",{1}",circle.Area(),circle.Circumference())

            Console.Read();
        }
    }
}
