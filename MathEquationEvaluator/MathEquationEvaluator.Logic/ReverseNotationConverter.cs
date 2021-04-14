using System;
using MathEquationEvaluator.Core.DataStructures;
using MathEquationEvaluator.EquationItems;
using MathEquationEvaluator.EquationItems.Brackets;
using MathEquationEvaluator.EquationItems.Operations;

namespace MathEquationEvaluator.Logic
{
    public class ReverseNotationConverter: INotationConverter
    {
        protected IPushableCollection<IReverseNotationItem> _convertedEquation;
        protected Stack<IOperation> _operationsStack;
        protected EquationItem[] _equationItems;

        private void AppendOperationsUpToOpeningBracket()
        {
            var lastOperation = _operationsStack.Peek();
            while (!(lastOperation is OpeningBracket) && lastOperation is Operation operation)
            {
                _convertedEquation.Push(operation);
                lastOperation = _operationsStack.Peek();
            }
        }

        private void AppendHigherPriorityOpearations(Operation currentOperation)
        {
            while (!_operationsStack.IsEmpty
                   && _operationsStack.Pop() is Operation previousOperation
                   && previousOperation.Priority >= currentOperation.Priority)
            {
                _convertedEquation.Push(_operationsStack.Peek() as Operation);
            }
        }

        public IConvertable ForEquationItems(EquationItem[] equationItems)
        {
            _equationItems = equationItems;
            _convertedEquation = new Stack<IReverseNotationItem>();
            _operationsStack = new Stack<IOperation>();
            return this;
        }

        public IReverseNotationItem[] Convert()
        {
            for (var i = 0; i < _equationItems.Length; i++)
            {
                var equationItem = _equationItems[i];

                if (equationItem is Operand operand)
                {
                    _convertedEquation.Push(operand);
                }
                else if (equationItem is Operation operation)
                {
                    if (operation is IUnaryOperation
                        && (i == 0 //equation starts with unary operation
                            || _equationItems[i - 1] is IBeforeUnaryOperation))
                    {
                        //unary operations are read as 0 n o where n is number and o is operation
                        //i.e. -5 => 0 5 -
                        _convertedEquation.Push(new Operand(0));
                    }
                    else
                    {
                        AppendHigherPriorityOpearations(operation);
                    }
                    _operationsStack.Push(operation);
                }
                else if (equationItem is OpeningBracket openingBracket)
                {
                    _operationsStack.Push(openingBracket);
                }
                else if (equationItem is ClosingBracket)
                {
                    try
                    {
                        AppendOperationsUpToOpeningBracket();
                    }
                    //out of operation stack but still no opening bracket found
                    catch (IndexOutOfRangeException)
                    {
                        throw new NotSupportedException("Wrong equation provided. Opening/Closing Bracket(s) missing");
                    }
                }
            }

            while (!_operationsStack.IsEmpty && _operationsStack.Pop() is Operation)
            {
                _convertedEquation.Push(_operationsStack.Peek() as Operation);
            }

            //something went wrong
            if (!_operationsStack.IsEmpty)
            {
                throw new NotSupportedException($"Wrong equation provided. '{_operationsStack.Pop()}' not supported in Reverse Notation");
            }

            return _convertedEquation.Items;
        }
    }
}
