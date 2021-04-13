using System;
using MathEquationEvaluator.Logic;

namespace MathEquationEvaluator.ConsoleUI
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var operationsFactory = new EquationOperationFactory();
            var bracketsFactory = new EquationBracketFactory();
            var equationParser = new EquationItemsParser(operationsFactory, bracketsFactory);
            var equationEvaluator = new EquationEvaluator(equationParser);
            while (true)
            {
                //remove all previous input
                Console.Clear();
                Console.WriteLine("Enter the equation");
                var inputEquation = Console.ReadLine();

                try
                {
                    var equation = equationEvaluator.ForEquation(inputEquation).Evaluate();
                    Console.WriteLine(equation);
                    Console.WriteLine(equation.Result);
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
    }
}
