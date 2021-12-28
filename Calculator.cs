using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeTDD_Calculator
{
    public class Calculator
    {
        public float Add(float firstNumber, float secondNumber)
        {
            return firstNumber + secondNumber;
        }

        public float Extract(float a, float b)
        {
            return a - b;
        }

        public float Multiply(float a, float b)
        {
            return a * b;
        }

        public float Divide(float a, float b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException();
            }
            return a / b;
        }
    }
}
