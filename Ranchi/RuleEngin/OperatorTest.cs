using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample.Rules
{
     public class Calculator
    {
        public decimal Add(decimal x, decimal y)
        {
            return x + y;
        }
        public decimal Subtract(decimal x, decimal y)
        {
            return x - y;
        }
        public decimal Multiply(decimal x, decimal y)
        {
            return x * y;
        }
        public decimal Divide(decimal x, decimal y)
        {
            if (y == 0)
                return 0;
            else
                return x / y;
        }

    }
}
