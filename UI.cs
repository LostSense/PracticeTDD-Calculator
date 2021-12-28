using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeTDD_Calculator
{
    public class UI
    {
        public string AskFirstNumber()
        {
            string message = "Input your first number: \b\n";
            return WriteConsoleMessage(message);
        }

        private string WriteConsoleMessage(string message)
        {
            Console.WriteLine(message);
            return message;
        }

        public string AskSecondNumber()
        {
            string message = "Input your second number: \b\n";
            return WriteConsoleMessage(message);
        }

        public string AskOperator(string[] operators)
        {
            string message = "Input your operation: \b\n";
            int lastOperator = operators.Length - 1;
            for (int i = 0; i < operators.Length; i++)
            {
                message += operators[i];
                if (i != lastOperator)
                {
                    message += ", ";
                }
            }
            message += "\b\n";
            return WriteConsoleMessage(message);
        }

        public string GetDataFromInput()
        {
            return Console.ReadLine();
        }

        public void GiveAnswerToUser(string answer)
        {
            WriteConsoleMessage("Your answer is: " + answer);
        }

        internal void WrongTypeOfValue_WriteNumericValue()
        {
            WriteConsoleMessage("Wrong value type. Your type should be numeric. \b\n");
        }

        internal void WrongTypeOfValue_WriteOperator()
        {
            WriteConsoleMessage("Wrong value. Write operator. \b\n");
        }

        internal void DivideByZeroError()
        {
            WriteConsoleMessage("You divided by zero!");
        }

        internal void AskIfUserWantOneMoreOperation()
        {
            WriteConsoleMessage("Type \"y\" if you want next operation. Or anything else if not.");
        }
    }
}
