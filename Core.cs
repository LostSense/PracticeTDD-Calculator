using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeTDD_Calculator
{
    public class Core
    {
        private Calculator calc;
        private UI ui;
        private string[] operators;
        private bool calculatorkeepWorking = true;

        public Core()
        {
            calc = new Calculator();
            ui = new UI();
            DefineOperators();
        }

        private void DefineOperators()
        {
            operators = new string[] { "+", "-", "/", "*" };
        }

        public void Run()
        {
            do
            {
                calculatorkeepWorking = SpeakWithUserAndCalculate();
            } while (calculatorkeepWorking);
        }

        private bool SpeakWithUserAndCalculate()
        {
            float firstNum;
            float secondNum;
            string operation;
            string answer;
            ui.AskFirstNumber();
            firstNum = GetNumber();
            ui.AskSecondNumber();
            secondNum = GetNumber();
            ui.AskOperator(operators);
            operation = GetOperator();
            answer = Calculate(operation, firstNum, secondNum);
            ui.GiveAnswerToUser(answer);
            return AskUserIfHeWantAnotherOperation();
        }

        private string Calculate(string operation, float firstNum, float secondNum)
        {
            float answer = 0;
            if(operation == "+")
            {
                answer = calc.Add(firstNum, secondNum);
            }
            else if(operation == "-")
            {
                answer = calc.Extract(firstNum, secondNum);
            }
            else if(operation == "*")
            {
                answer = calc.Multiply(firstNum, secondNum);
            }
            else if(operation == "/")
            {
                try
                {
                    answer = calc.Divide(firstNum, secondNum);
                }
                catch
                {
                    ui.DivideByZeroError();
                }
            }
            else
            {
                return "Misterious Error";
            }
            return answer.ToString();
        }

        private bool AskUserIfHeWantAnotherOperation()
        {
            string inputValue;
            ui.AskIfUserWantOneMoreOperation();
            inputValue = ui.GetDataFromInput();
            if(inputValue == "y")
            {
                return true;
            }
            return false;
        }

        private string GetOperator()
        {
            string inputValue;
            bool rightOperator = false;
            do
            {
                inputValue = ui.GetDataFromInput();
                rightOperator = CheckIfOperatorIsValid(inputValue);
                if(!rightOperator)
                {
                    ui.WrongTypeOfValue_WriteOperator();
                }
            } while (!rightOperator);
            return inputValue;
        }

        private bool CheckIfOperatorIsValid(string inputValue)
        {
            for (int i = 0; i < operators.Length; i++)
            {
                if(operators[i] == inputValue)
                {
                    return true;
                }
            }
            return false;
        }

        private float GetNumber()
        {
            float number;
            string inputValue;
            bool valueIsNumeric = false;
            do
            {
                inputValue = ui.GetDataFromInput();
                valueIsNumeric = float.TryParse(inputValue, out number);
                if(!valueIsNumeric)
                {
                    ui.WrongTypeOfValue_WriteNumericValue();
                }
            } while (!valueIsNumeric);
            return number;
        }
    }
}
