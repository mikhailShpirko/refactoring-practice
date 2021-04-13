using System;
using MathEquationEvaluator.Core.DataStructures;
using MathEquationEvaluator.EquationItems;
using MathEquationEvaluator.EquationItems.Brackets;
using MathEquationEvaluator.EquationItems.Operations;

namespace MathEquationEvaluator.Logic
{
    public class EquationEvaluator: Equation, IEvaluatable
    {
        private readonly IEquationParser _equationParser;

        public EquationEvaluator(IEquationParser equationParser)
        {
            _equationParser = equationParser;
        }

        public IEvaluatable ForEquation(string equation)
        {
            var equationItems = _equationParser.ParseEquationItems(equation);

            var equationItemsStack = ConvertEquationItemsToReverseNotionStack(equationItems);

            SaveReverseNotationEquation(equationItemsStack.Items);

            return this;
        }

        public Equation Evaluate()
        {
            var evaluationStack = new Stack<decimal>();

            foreach (var equationItem in _reverseNotationItems.Items)
            {
                equationItem.ApplyToEvaluationStack(evaluationStack);
            }

            if (evaluationStack.Length > 1)
            {
                throw new Exception($"Wrong reverse notation evaluation. Stack must contain a single item at the end of calculation. Stack at the end: {evaluationStack}. Reverse notation evaluetion: {_reverseNotationItems}");
            }

            //handles empty input
            if (evaluationStack.IsEmpty)
            {
                evaluationStack.Push(0);
            }

            Result = evaluationStack.Peek();
            return this;
        }

        private Stack<EquationItem> ConvertEquationItemsToReverseNotionStack(EquationItem[] equationItems)
        {
            var equationStack = new Stack<EquationItem>();
            var operationStack = new Stack<EquationItem>();

            for (var i = 0; i < equationItems.Length; i++)
            {
                var equationItem = equationItems[i];

                if (equationItem is Operand)
                {
                    equationStack.Push(equationItem);
                }
                else if (equationItem is Operation operation)
                {
                    if (operation is IUnaryOperation
                        && (i == 0 //equation starts with unary operation
                            || equationItems[i - 1] is OpeningBracket 
                                    || equationItems[i - 1] is Operation))
                    {
                        //unary operations are read as 0 n o where n is number and o is operation
                        //i.e. -5 => 0 5 -
                        equationStack.Push(new Operand(0));
                    }
                    else
                    {
                        while (!operationStack.IsEmpty 
                               && operationStack.Pop() is Operation previousOperation 
                               && previousOperation.Priority >= operation.Priority)
                        {
                            equationStack.Push(operationStack.Peek());
                        }
                    }
                    operationStack.Push(operation);
                }
                else if (equationItem is OpeningBracket)
                {
                    operationStack.Push(equationItem);
                }
                else if (equationItem is ClosingBracket)
                {
                    try
                    {
                        var lastOperation = operationStack.Peek();
                        while (!(lastOperation is OpeningBracket))
                        {
                            equationStack.Push(lastOperation);
                            lastOperation = operationStack.Peek();
                        }
                    }
                    //out of operation stack but still no opening bracket found
                    catch (IndexOutOfRangeException)
                    {
                        throw new NotSupportedException("Wrong equation provided. Opening/Closing Bracket(s) missing");
                    }
                }
                else
                {
                    throw new NotSupportedException($"'{equationItem}' is not supported. Equation must contain only numbers or equation signs");
                }
            }

            while (!operationStack.IsEmpty)
            {
                equationStack.Push(operationStack.Peek());
            }

            return equationStack;
        }

        private void SaveReverseNotationEquation(EquationItem[] equationItems)
        {
            IPushableCollection<IReverseNotationItem> reverseNotationItems = new Stack<IReverseNotationItem>();
            foreach (var equationItem in equationItems)
            {
                if (equationItem is IReverseNotationItem reverseNotationItem)
                {
                    reverseNotationItems.Push(reverseNotationItem);
                }
                else
                {
                    throw new NotSupportedException($"'{equationItem}' is not supported in Reverse Notation");
                }
            }

            _reverseNotationItems = reverseNotationItems;
        }
    }
}
