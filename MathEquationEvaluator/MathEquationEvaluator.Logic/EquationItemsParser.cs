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
        private readonly IEquationItemInitializer<Operation> _operationFactory;
        private readonly IEquationItemInitializer<Bracket> _bracketsFactory;
        private readonly StringBuilder _operandBuilder;

        private IPushableCollection<EquationItem> _equationItemsStack;
         

        public EquationItemsParser(IEquationItemInitializer<Operation> operationFactory,
            IEquationItemInitializer<Bracket> bracketsFactory)
        {
            _operationFactory = operationFactory;
            _bracketsFactory = bracketsFactory;
            _operandBuilder = new StringBuilder();
        }

        private void AppendOperand()
        {
            if (_operandBuilder.Length == 0)
            {
                return;
            }

            var operand = _operandBuilder.ToString();
            //will parse if there are spaces vefore and/or after decimal
            if (decimal.TryParse(operand, out var operandValue))
            {
                _equationItemsStack.Push(new Operand(operandValue));
                _operandBuilder.Clear();
            }
            else
            {
                throw new NotSupportedException($"Lexeme '{operand}' is not supported");
            }
        }

        public EquationItem[] ParseEquationItems(string equation)
        {
            if (string.IsNullOrWhiteSpace(equation))
            {
                throw new ArgumentNullException(nameof(equation), "Equation not provided");
            }

            _equationItemsStack = new Stack<EquationItem>();
            _operandBuilder.Clear();

            foreach (var sign in equation)
            {
                var bracket = _bracketsFactory.InitializeFromSign(sign);
                var operation = _operationFactory.InitializeFromSign(sign);
                if (bracket != null || operation != null)
                {
                    var equationItem = bracket ?? (EquationItem)operation;
                    AppendOperand();
                    _equationItemsStack.Push(equationItem);
                }
                else
                {
                    _operandBuilder.Append(sign);
                }
            }

            AppendOperand();

            return _equationItemsStack.Items;
        }
    }
}
