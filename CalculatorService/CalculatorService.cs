using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService
{
    public class Calculator
    {
        public int Add(string inputString)
        {
            int total = 0;

            if (!String.IsNullOrEmpty(inputString))
            {
                string[] inputs = ParseString(inputString);
                List<int> negativeNums = new List<int>();

                foreach (var number in inputs)
                {
                    int i = int.TryParse(number, out i) ? i : 0;
                    if (i < 0) negativeNums.Add(i);
                    if (i > 1000) i = 0;

                    total += i;
                }

                if (negativeNums.Count > 0)
                {
                    throw new Exception("These negative numbers are not allowed:" + String.Join(",", negativeNums));
                }
            }

            return total;
        }

        public String[] ParseString(string inputString)
        {
            List<string> delimiters = new List<string>() { ",", "\n" };
            if (inputString.Substring(0, 2) == "//")
            {
                int endOfDelimIndex = inputString.IndexOf('\n');
                string singleDelimiter = inputString.Substring(2, endOfDelimIndex - 2);
                string multiDelimiter = inputString.Substring(2, endOfDelimIndex - 2);

                if (endOfDelimIndex > -1)
                {
                    int leftIndex = singleDelimiter.IndexOf('[');
                    int rightIndex = singleDelimiter.IndexOf(']');

                    foreach (char c in inputString)
                    {
                        if (leftIndex >= 0 && rightIndex > leftIndex)
                        {
                            singleDelimiter = multiDelimiter.Substring(leftIndex + 1, rightIndex - leftIndex - 1);

                            delimiters.Add(singleDelimiter);
                            leftIndex = multiDelimiter.IndexOf('[', rightIndex);
                            rightIndex = multiDelimiter.IndexOf(']', rightIndex + 1);
                        }
                    }

                    if (multiDelimiter == singleDelimiter)
                    {
                        delimiters.Add(multiDelimiter);
                    }
                }
            }
            return inputString.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);
        }
    }
}