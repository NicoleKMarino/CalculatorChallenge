﻿using System;
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
            List<char> delimiters = new List<char>() { ',', '\n' };
            if (inputString.Substring(0, 2) == "//")
            {
                delimiters.Add(inputString.ElementAt(2));
            }
            return inputString.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);

        }
    }
}