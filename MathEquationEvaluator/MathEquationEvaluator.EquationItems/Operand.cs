using MathEquationEvaluator.Core.DataStructures;

namespace MathEquationEvaluator.EquationItems
{
    public class Operand: EquationItem, IReverseNotationItem
    {
        public decimal Value { get; private set; }
        public Operand(decimal value) 
            : base(value.ToString())
        {
            Value = value;
        }

        public void ApplyToEvaluationStack(Stack<decimal> evaluationStack)
        {
            evaluationStack.Push(Value);
        }
    }
}
