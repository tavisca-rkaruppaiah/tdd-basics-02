using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        static string userPressedKey = "0";
        static string firstPart = "";
        static char operand;
        static string result;
        static bool mAddition = false, mSubtraction = false, mMultiplication = false, mDivision = false;
        public string SendKeyPress(char key)
        {



            if (char.IsLetter(key))
            {
                key = char.ToUpper(key);

                switch (key)
                {
                    case 'C':
                        ClearCalculator();
                        break;
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
                            return PerformOperationManyTimes(key);
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
                            return PerformOperationManyTimes(key);
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
                            return PerformOperationManyTimes(key);
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
                            return PerformOperationManyTimes(key);
                        }
                    case '=':
                        result = PerformOperations(result, userPressedKey, operand);
                        userPressedKey = "0";
                        return result;


                    case '.':
                        userPressedKey = CheckRepeationDot(userPressedKey, key);
                        break;

                }
            }

            if(userPressedKey.Length >= 2)
            {
                if(userPressedKey.StartsWith("0"))
                {
                    userPressedKey = userPressedKey.Remove(0, 1);
                }
            }


            return userPressedKey;
        }

       

        public static string SetVariableValues(string firstNumber, char operationSymbol)
        {
            if (CheckStringIsNullOrNot(firstNumber))
            {

                firstPart = firstNumber;
                operand = operationSymbol;
                userPressedKey = "0";
                return firstNumber;
            }

            return firstNumber;
        }

        public static string PerformOperationManyTimes(char key)
        {
            result = PerformOperations(result, userPressedKey, key);
            userPressedKey = "0";
            operand = key;
            return result;

        }

        public static string CheckRepeationZero(string expression, char key)
        {

            if (CheckStringIsNullOrNot(userPressedKey))
            {
                if (userPressedKey.Equals("0"))
                {
                    return userPressedKey;
                }

                else
                {
                    userPressedKey += key;
                }


            }
            return userPressedKey;
        }

        public static string CheckRepeationDot(string expression, char key)
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
                expression = "0";
            }
            return expression;
        }
        public static void ClearCalculator()
        {
            userPressedKey = "0";
            operand = char.MinValue;
            firstPart = null;
            result = null;
            mAddition = mSubtraction = mMultiplication = mDivision = false;


        }

        public static bool CheckStringIsNullOrNot(string expression)
        {
            if (expression.Length == 0)
            {
                return false;
            }

            return true;
        }

        public static string ChangeSign(string expression)
        {
            double signNumber = 0.0;
            if (CheckStringIsNullOrNot(expression))
            {
                double.TryParse(expression, out signNumber);

                signNumber = signNumber * -1;
            }

            return signNumber.ToString();
        }

        public static string PerformOperations(string numberOne, string numberTwo, char operandSymbol)
        {
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
