using System;
using System.Text;
using MathEquationEvaluator.Core.DataStructures;
using MathEquationEvaluator.EquationItems;
using MathEquationEvaluator.EquationItems.Brackets;
using MathEquationEvaluator.EquationItems.Operations;

namespace MathEquationEvaluator.Logic
{
    public class EquationItemsParser: IEquationParser
    {
        private readonly IFactory<Operation> _operationFactory;
        private readonly IFactory<Bracket> _bracketsFactory;

        private IPushableCollection<EquationItem> _equationItemsStack;

        public EquationItemsParser(IFactory<Operation> operationFactory,
            IFactory<Bracket> bracketsFactory)
        {
            _operationFactory = operationFactory;
            _bracketsFactory = bracketsFactory;
        }

        public EquationItem[] ParseEquationItems(string equation)
        {
            if (string.IsNullOrWhiteSpace(equation))
            {
                throw new ArgumentNullException(nameof(equation), "Equation not provided");
            }

            _equationItemsStack = new Stack<EquationItem>();
            var operandBuilder = new StringBuilder();

            //local function they will not be used anywhere else + sharing of local variables
            void appendOperand()
            {
                if (operandBuilder.Length > 0)
                {
                    var operand = operandBuilder.ToString();
                    //will parse if there are spaces vefore and/or after decimal
                    if (decimal.TryParse(operand, out var operandValue))
                    {
                        _equationItemsStack.Push(new Operand(operandValue));
                        operandBuilder.Clear();
                    }
                    else
                    {
                        throw new NotSupportedException($"Operand '{operand}' is not supported");
                    }
                }
            }

            foreach (var sign in equation)
            {
                var bracket = _bracketsFactory.InitializeFromSign(sign);
                var operation = _operationFactory.InitializeFromSign(sign);
                if (bracket != null || operation != null)
                {
                    var equationItem = bracket ?? (EquationItem)operation;
                    appendOperand();
                    _equationItemsStack.Push(equationItem);
                }
                else
                {
                    operandBuilder.Append(sign);
                }
            }

            appendOperand();

            return _equationItemsStack.Items;
        }
    }
}
