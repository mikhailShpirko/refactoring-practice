namespace MathEquationEvaluator.EquationItems.Operations
{
    public class Multiply: Operation
    {
        public Multiply() 
            : base(3, "*")
        {
        }

        protected override decimal Execute(decimal a, decimal b)
        {
            return a * b;
        }
    }
}
