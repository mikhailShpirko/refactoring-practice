using System;
using MathEquationEvaluator.Core.DataStructures;

namespace MathEquationEvaluator.EquationItems.Operations
{
    public abstract class Operation: EquationItem, IOperation, IReverseNotationItem, IBeforeUnaryOperation
    {
        public readonly int Priority;
        protected Operation(int priority,
                            string item) 
            : base(item)
        {
            Priority = priority;
        }

        protected abstract decimal Execute(decimal a, decimal b);

        public void ApplyToEvaluationStack(Stack<decimal> evaluationStack)
        {
            if (evaluationStack.Length < 2)
            {
                throw new NotSupportedException("Not enough numbers in the equation");
            }
            var b = evaluationStack.Peek();
            var a = evaluationStack.Peek();

            evaluationStack.Push(Execute(a, b));
        }
    }
}
