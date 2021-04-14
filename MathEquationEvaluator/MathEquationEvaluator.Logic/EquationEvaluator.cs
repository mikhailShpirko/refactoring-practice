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
        private readonly INotationConverter _notationConverter;

        public EquationEvaluator(IEquationParser equationParser, INotationConverter notationConverter)
        {
            _equationParser = equationParser;
            _notationConverter = notationConverter;
        }

        public IEvaluatable ForEquation(string equation)
        {
            var equationItems = _equationParser.ParseEquationItems(equation);
            _reverseNotationItems = _notationConverter.ForEquationItems(equationItems).Convert();

            return this;
        }

        public Equation Evaluate()
        {
            var evaluationStack = new Stack<decimal>();

            foreach (var equationItem in _reverseNotationItems)
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


        
    }
}
