float res = 0;
while (true)
{
    Console.WriteLine("Enter a:");
    float a = float.Parse(Console.ReadLine());
    Console.WriteLine("Enter b:");
    float b = float.Parse(Console.ReadLine());
    Console.WriteLine("Enter operator:");
    string opperator = Console.ReadLine();
    if (opperator == "+")
    {
        res = a + b;
        Console.WriteLine($"Result: {res:f2}");
    }
    else if (opperator == "-")
    {
        res = a - b;
        Console.WriteLine($"Result: {res:f2}");
    }
    else if (opperator == "*")
    {
        res = a * b;
        Console.WriteLine($"Result: {res:f2}");
    }
    else if (opperator == "/")
    {
        if (b == 0)
        {
            Console.WriteLine("Infinity");
        }
        else
        {
            res = a / b;
            Console.WriteLine($"Result: {res:f2}");
        }
        
    }
    else
    {
        Console.WriteLine("Invalid operator!");
    }
    Console.WriteLine("---------------------");
}