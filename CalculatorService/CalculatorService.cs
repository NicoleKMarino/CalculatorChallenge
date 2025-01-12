using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService
{
    public class Calculator
    {
        public int Add(string inputString)
        {
            string[] inputs = ParseString(inputString);
            int total = 0;

            if (inputs.Length > 2) throw new Exception("Cannot calculate more than two numbers");

            foreach (var number in inputs)
            {
                int i = int.TryParse(number, out i) ? i : 0;
                total += i;
            }

            return total;
        }

        public String[] ParseString (string inputString)
        {
            return inputString.Split(',');
        }
    }
}