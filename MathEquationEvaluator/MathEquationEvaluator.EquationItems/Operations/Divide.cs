namespace MathEquationEvaluator.EquationItems.Operations
{
    public class Divide: Operation
    {
        public Divide() 
            : base(4, "/")
        {
        }

        protected override decimal Execute(decimal a, decimal b)
        {
            return a / b;
        }
    }
}
