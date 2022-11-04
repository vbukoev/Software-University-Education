namespace Shapes 
{
    using System;
    using Shapes.Exceptions;
    using Shapes.Models;
    public class StartUp
    {
        public static void Main()
        {
            try
            {
                Shape rectangle = new Rectangle(7.5, 6.5);
                Shape circle = new Circle(3.5);

                Console.WriteLine(rectangle.CalculateArea());
                Console.WriteLine(rectangle.CalculatePerimeter());

                Console.WriteLine(circle.CalculateArea());
                Console.WriteLine(circle.CalculatePerimeter());

            }
            catch (InvalidSideException ise)
            {
                Console.WriteLine(ise.Message);
            }
            catch (InvalidRadiusException ire)
            {
                Console.WriteLine(ire.Message);
            }
        }
    }
}
