using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
            List<int> negativeNums = new List<int>();

            foreach (var number in inputs)
            {
                int i = int.TryParse(number, out i) ? i : 0;
                if(i < 0) negativeNums.Add(i);
                if (i > 1000) i = 0;

                total += i;
            }

            if (negativeNums.Count > 0)
            {
                throw new Exception("These negative numbers are not allowed:" + String.Join(",", negativeNums));
            }

            return total;
        }

        public String[] ParseString (string inputString)
        {
            List<string> delimiters = new List<string>() { ",", "\n" };
            if (inputString.Substring(0, 2) == "//")
            {
                int endOfDelimIndex = inputString.IndexOf('\n');
                string singleDelimiter = inputString.Substring(2, endOfDelimIndex - 2);

                if (endOfDelimIndex > -1)
                {
                    int leftIndex = singleDelimiter.IndexOf('[');
                    int rightIndex = singleDelimiter.IndexOf(']');
                    if (leftIndex == 0 && rightIndex >= 0)
                    {
                        singleDelimiter = singleDelimiter.Substring(1, rightIndex - 1);
                    }
                    delimiters.Add(singleDelimiter);
                }
            }
            return inputString.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);
        }
    }
}