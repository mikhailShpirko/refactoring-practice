namespace MathEquationEvaluator.EquationItems.Operations
{
    public class Add: Operation, IUnaryOperation
    {
        public Add() 
            : base(0, "+")
        {
        }

        protected override decimal Execute(decimal a, decimal b)
        {
            return a + b;
        }
    }
}
