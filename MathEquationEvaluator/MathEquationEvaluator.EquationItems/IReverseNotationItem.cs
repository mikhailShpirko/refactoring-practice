using MathEquationEvaluator.Core.DataStructures;

namespace MathEquationEvaluator.EquationItems
{
    public interface IReverseNotationItem
    {
        void ApplyToEvaluationStack(Stack<decimal> evaluationStack);
    }
}
