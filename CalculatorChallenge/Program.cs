using CalculatorService;
using System;

namespace R365_Calculator_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator _calculatorService = new Calculator();

            Console.WriteLine("Enter Numbers");
            string input = Console.ReadLine();
            int result = _calculatorService.Add(input);
            Console.WriteLine("Result: " + result);
            Console.ReadLine();
        }
    }
}