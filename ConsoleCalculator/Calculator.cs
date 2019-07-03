using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        
       string userPressedKey = "";
        string firstPart = "";
        char operand;
        string result;
        bool mAddition = false, mSubtraction = false, mMultiplication = false, mDivision = false;
        public string SendKeyPress(char key)
        {



            if (char.IsLetter(key))
            {
                key = char.ToUpper(key);

                switch (key)
                {
                    case 'C':
                        return ClearCalculator();

                    case 'S':
                        userPressedKey = ChangeSign(userPressedKey);
                        break;

                    case 'X':
                        if (mDivision == false)
                        {
                            result = SetVariableValues(userPressedKey, '*');
                            mDivision = true;
                            return result;
                        }
                        else
                        {
                            result = PerformOperations(result, userPressedKey, '*');
                            operand = '*';
                            return result;
                        }

                }
            }
            if (char.IsDigit(key))
            {
                switch (key)
                {
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        userPressedKey += key;
                        break;
                    case '0':
                        userPressedKey = CheckRepeationZero(userPressedKey, key);
                        break;

                }
            }
            else
            {
                switch (key)
                {
                    case '+':
                        if (mAddition == false)
                        {
                            result = SetVariableValues(userPressedKey, key);
                            mAddition = true;
                            return result;

                        }
                        else
                        {
                            result = PerformOperations(result, userPressedKey, key);
                            operand = key;
                            return result;

                        }

                    case '-':
                        if (mSubtraction == false)
                        {
                            result = SetVariableValues(userPressedKey, key);
                            mSubtraction = true;
                            return result;

                        }
                        else
                        {
                            result = PerformOperations(result, userPressedKey, key);
                            operand = key;
                            return result;
                        }


                    case '/':
                        if (mDivision == false)
                        {
                            result = SetVariableValues(userPressedKey, key);
                            mDivision = true;
                            return result;

                        }
                        else
                        {
                            result = PerformOperations(result, userPressedKey, key);
                            operand = key;
                            return result;

                        }

                    case '=':
                        result = PerformOperations(result, userPressedKey, operand);
                        return result;


                    case '.':
                        userPressedKey = CheckRepeationDot(userPressedKey, key);
                        break;

                }
            }


            return userPressedKey;
        }



        public string SetVariableValues(string firstNumber, char operationSymbol)
        {
            if (CheckStringIsNullOrNot(firstNumber))
            {

                firstPart = firstNumber;
                operand = operationSymbol;
                userPressedKey = "";
                return firstNumber;
            }

            return firstNumber;
        }

        public string CheckRepeationZero(string expression, char key)
        {

            if (userPressedKey.Equals("0"))
            {
                return userPressedKey;
            }

            else
            {
                userPressedKey += key;
            }
            return userPressedKey;
        }

        public string CheckRepeationDot(string expression, char key)
        {

            if (CheckStringIsNullOrNot(expression))
            {

                if (expression.Contains("."))
                {
                    return expression;
                }
                else
                {
                    return expression += key;
                }
            }
            else
            {
                expression = "";
            }
            return expression;
        }
        public string ClearCalculator()
        {
            userPressedKey = "";
            operand = char.MinValue;
            firstPart = null;
            result = null;
            mAddition = mSubtraction = mMultiplication = mDivision = false;

            return "0";


        }

        public bool CheckStringIsNullOrNot(string expression)
        {
            if (expression.Length == 0)
            {
                return false;
            }

            return true;
        }

        public string ChangeSign(string expression)
        {
            double signNumber = 0.0;
            if (CheckStringIsNullOrNot(expression))
            {
                double.TryParse(expression, out signNumber);

                signNumber = signNumber * -1;
            }

            return signNumber.ToString();
        }

        public string PerformOperations(string numberOne, string numberTwo, char operandSymbol)
        {
            userPressedKey = "";
            double number1, number2, result = 0.0;
            double.TryParse(numberOne, out number1);
            double.TryParse(numberTwo, out number2);

            switch (operandSymbol)
            {
                case '+':
                    result = number1 + number2;
                    break;
                case '-':
                    result = number1 - number2;
                    break;
                case '/':
                    if (number2 > 0)
                    {
                        result = number1 / number2;
                    }
                    else
                    {
                        ClearCalculator();
                        return "-E-";
                    }
                    break;
                case '*':
                    result = number1 * number2;
                    break;
            }


            return result.ToString();
        }
    }
}
