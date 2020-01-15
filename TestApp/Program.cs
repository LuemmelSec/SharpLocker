using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            String input = SharpLockerLib.Program.Run();
            Console.WriteLine(input);
            //Console.ReadKey();
        }
    }
}
