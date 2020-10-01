using System;

namespace project_euler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting problem...");
            
            var start = DateTime.Now;
            (var pNum, var answer) = Problem.P0007();
            var elapsed = DateTime.Now.Subtract(start);

            Console.WriteLine($@"Problem #{pNum} returned in {elapsed:hh\:mm\:ss\.FFFF} with: ""{answer}"".");
            Console.WriteLine("End");
        }
    }
}
