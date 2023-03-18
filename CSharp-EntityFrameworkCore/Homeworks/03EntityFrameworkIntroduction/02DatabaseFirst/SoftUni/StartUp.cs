using SoftUni.Data;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext dBcontext = new SoftUniContext();
            Console.WriteLine("Connection success!");
        }
    }
}