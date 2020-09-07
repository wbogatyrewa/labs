using System;

namespace labs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nWhat is your name? ");
            var name = Console.ReadLine();
            Console.WriteLine($"\nHello, {name}!");
            Console.Write("\nPress any key to exit...");
            Console.ReadKey(true);
        }
    }
}
