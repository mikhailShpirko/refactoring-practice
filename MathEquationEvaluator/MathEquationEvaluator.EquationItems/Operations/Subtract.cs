namespace MathEquationEvaluator.EquationItems.Operations
{
    public class Subtract: Operation, IUnaryOperation
    {
        public Subtract() 
            : base(1, "-")
        {
        }

        protected override decimal Execute(decimal a, decimal b)
        {
            return a - b;
        }
    }
}
