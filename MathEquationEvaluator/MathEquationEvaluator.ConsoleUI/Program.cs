using System;
using System.Text;

namespace MathEquationEvaluator.ConsoleUI
{
    public class Program
    {
        /// <summary>
        /// ordered by priority for the equation ascending (low - to - high). higher index - high priority
        /// </summary>
        private static readonly char[] EQUATION_OPERATION_SIGNS = {'+', '-', '*', '/' };
        private static readonly char[] BRACKETS_SIGNS = {'(', ')'};

        private static readonly char OPENING_BRACKET_SIGN = BRACKETS_SIGNS[0];
        private static readonly char SPACE_CHARACTER = ' ';

        private static void Main(string[] args)
        {
            while (true)
            {
                //remove all previous input
                Console.Clear();
                Console.WriteLine("Enter the equation");
                var inputEquation = Console.ReadLine();

                try
                {
                    var reverseNotationEquation = PrepareReverseNotation(inputEquation);
                    Console.WriteLine(ConvertArrayToString(reverseNotationEquation));

                    var evaluationResult = EvaluateReverseNotationEquation(reverseNotationEquation);
                    Console.WriteLine(evaluationResult);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Wrong equation provided. Error details: {e.Message}");
                }
                
                //prevent from closing
                Console.WriteLine("Press enter to repeat");
                Console.ReadLine();
            }          
        }

        private static string[] PrepareReverseNotation(string equation)
        {
            //I want to be able to split equation parts into the array
            //so that I have separete array elements as numbers and equation operations
            //i.e. from this 2/(3+2)*5
            //get this [2], [/], [(], [3], [+], [2], [)], [*], [5]
            //without any loop
            //also I want support numbers with more than 1 digit - splitting would enable this support

            //further I'll split result by spaces, so before and after each equation operation sign there must be a space

            var normalizedEquation = NormalizeEquation(equation);          
            var equationItems = ConvertNormalizedEquationToArray(normalizedEquation);
            return ConvertEquationItemsReverseNotation(equationItems);
        }

        private static string NormalizeEquation(string equation)
        {
            var normalizedEquation = new StringBuilder();

            foreach (var character in equation)
            {
                //ignore existing spaces
                if (character == SPACE_CHARACTER)
                {
                    continue;
                }

                if (IsEquationSign(character))
                {
                    normalizedEquation.Append(SPACE_CHARACTER);
                    normalizedEquation.Append(character);
                    normalizedEquation.Append(SPACE_CHARACTER);
                }
                else
                {
                    normalizedEquation.Append(character);
                }
            }

            //Obviously, can the same be achieved with string.Replace, but not sure if usage of the function is allowed for the task
            return normalizedEquation.ToString();
        }

        private static string[] ConvertNormalizedEquationToArray(string normalizedEquation)
        {
            var equationItems = new string[0];
            var equationItemBuilder = new StringBuilder();

            void appendEquationItem()
            {
                if (equationItemBuilder.Length == 0)
                {
                    return;
                }
                PushToArray(ref equationItems, equationItemBuilder.ToString());
                equationItemBuilder.Clear();
            }

            foreach (var character in normalizedEquation)
            {
                if (character == SPACE_CHARACTER)
                {
                    appendEquationItem();
                }
                else
                {
                    equationItemBuilder.Append(character);
                }
            }

            //to append last item as after last item there is no space and it will be skipped in the loop above
            appendEquationItem();

            //Obviously, can the same be achieved with string.Split, but not sure if usage of the function is allowed for the task
            return equationItems;
        }
 
        private static string[] ConvertEquationItemsReverseNotation(string[] equationItems)
        {
            var reverseNotationEquationItems = new string[0];
            var operationStack = new string[0];
            for (var i = 0; i < equationItems.Length; i++)
            {
                if (decimal.TryParse(equationItems[i], out _))
                {
                    PushToArray(ref reverseNotationEquationItems, equationItems[i]);
                }
                else if(IsEquationSign(ConvertStringToCharacter(equationItems[i])))
                {
                    if (IsBracketSign(ConvertStringToCharacter(equationItems[i])))
                    {
                        if (ConvertStringToCharacter(equationItems[i]) == OPENING_BRACKET_SIGN)
                        {
                            PushToArray(ref operationStack, equationItems[i]);
                        }
                        else
                        {
                            try
                            {
                                var lastOperation = PeekFromArray(ref operationStack);
                                while (ConvertStringToCharacter(lastOperation) != OPENING_BRACKET_SIGN)
                                {
                                    PushToArray(ref reverseNotationEquationItems, lastOperation);
                                    lastOperation = PeekFromArray(ref operationStack);
                                }
                            }
                            //out of operation stack but still no opening bracket found
                            catch (IndexOutOfRangeException)
                            {
                                throw new NotSupportedException("Wrong equation provided. Opening/Closing Bracket(s) missing");
                            }
                        }
                    }    
                    else
                    {
                        if (IsUnaryOperationSign(ConvertStringToCharacter(equationItems[i]))
                        && (i == 0 //equation starts with unary operation
                            || IsEquationSign(ConvertStringToCharacter(equationItems[i - 1])))) //previous item is operation sign
                        {
                            //unary operations are read as 0 n o where n is number and o is operation
                            //i.e. -5 => 0 5 -
                            PushToArray(ref reverseNotationEquationItems, "0");
                        }
                        else
                        {                                               
                            while(!IsArrayEmpty(operationStack) && GetPriorityOfEquationOperation(PopFromArray(operationStack)) >= GetPriorityOfEquationOperation(equationItems[i]))
                            {
                                PushToArray(ref reverseNotationEquationItems, PeekFromArray(ref operationStack));
                            }
                        }
                        PushToArray(ref operationStack, equationItems[i]);
                    }
                }
                else
                {
                    throw new NotSupportedException($"'{equationItems[i]}' is not supported. Equation must contain only numbers or equation signs");
                }
            }

            for (var i = operationStack.Length - 1; i >= 0; i--)
            {
                if (IsBracketSign(ConvertStringToCharacter(operationStack[i])))
                {
                    throw new NotSupportedException("Wrong equation provided. Opening/Closing Bracket(s) missing");
                }
                PushToArray(ref reverseNotationEquationItems, operationStack[i]);
            }

            return reverseNotationEquationItems;
        }

        private static decimal EvaluateReverseNotationEquation(string[] reverseNotationEquationItems)
        {
            //decimal to handle division operations like 2/5 = 0.4
            //int would round it to 0
            var evaluationStack = new decimal[0];
            foreach (var equationItem in reverseNotationEquationItems)
            {
                if (decimal.TryParse(equationItem, out var number))
                {
                    PushToArray(ref evaluationStack, number);
                }
                else if (IsEquationOperationSign(ConvertStringToCharacter(equationItem)))
                {
                    if (evaluationStack.Length == 0)
                    {
                        throw new NotSupportedException("Not enough numbers in the equation");
                    }
                    var b = PeekFromArray(ref evaluationStack);
                    var a = PeekFromArray(ref evaluationStack);
                    Func<decimal> calculate;
                    var equationOperationSign = ConvertStringToCharacter(equationItem);
                    if (equationOperationSign == EQUATION_OPERATION_SIGNS[0])
                    {
                        calculate = () => a + b;
                    }
                    else if (equationOperationSign == EQUATION_OPERATION_SIGNS[1])
                    {
                        calculate = () => a - b;
                    }
                    else if (equationOperationSign == EQUATION_OPERATION_SIGNS[2])
                    {
                        calculate = () => a * b;
                    }
                    else
                    {
                        calculate = () => a / b;
                    }

                    PushToArray(ref evaluationStack, calculate());
                }
                else
                {
                    throw new NotSupportedException($"'{equationItem}' not supported in Reverse Notation");
                }
            }

            if (evaluationStack.Length > 1)
            {
                throw new Exception($"Wrong reverse notation evaluation. Stack must contain a single item at the end of calculation. Stack at the end: {ConvertArrayToString(evaluationStack)}. Reverse notation evaluetion: {ConvertArrayToString(reverseNotationEquationItems)}");
            }

            //handles empty input
            if (evaluationStack.Length == 0)
            {
                return 0;
            }

            return PeekFromArray(ref evaluationStack);
        }

        private static void PushToArray<T>(ref T[] array, T newItem)
        {
            Array.Resize(ref array, array.Length + 1);
            array[GetLastIndexOfArray(array)] = newItem;
        }

        private static T PeekFromArray<T>(ref T[] array)
        {
            var topItem = PopFromArray(array);
            Array.Resize(ref array, GetLastIndexOfArray(array));
            return topItem;
        }

        private static T PopFromArray<T>(T[] stack)
        {
            return stack[GetLastIndexOfArray(stack)];
        }

        private static string ConvertArrayToString<T>(T[] array)
        {
            var output = new StringBuilder();

            for (var i = 0; i < array.Length; i++)
            {
                output.Append(array[i]);
                if (i != GetLastIndexOfArray(array))
                {
                    output.Append(SPACE_CHARACTER);
                }
            }

            //Obviously, can the same be achieved with string.Join, but not sure if usage of the function is allowed for the task
            return output.ToString();
        }

        private static int GetLastIndexOfArray<T>(T[] array)
        {
            return array.Length - 1;
        }
       
        private static char ConvertStringToCharacter(string str)
        {
            return str.ToCharArray()[0];
        }

        private static bool IsArrayEmpty<T>(T[] array)
        {
            return array.Length == 0;
        }

        private static bool IsEquationSign(char item)
        {
            return IsEquationOperationSign(item)
                   || IsBracketSign(item);
        }

        private static bool IsUnaryOperationSign(char item)
        {
            return item == EQUATION_OPERATION_SIGNS[0]
                   || item == EQUATION_OPERATION_SIGNS[1];
        }

        private static bool IsEquationOperationSign(char item)
        {
            return Array.IndexOf(EQUATION_OPERATION_SIGNS, item) > -1;
        }

        private static bool IsBracketSign(char item)
        {
            return Array.IndexOf(BRACKETS_SIGNS, item) > -1;
        }

        private static int GetPriorityOfEquationOperation(string operation)
        {
            return Array.IndexOf(EQUATION_OPERATION_SIGNS, ConvertStringToCharacter(operation));
        }
    }
}
