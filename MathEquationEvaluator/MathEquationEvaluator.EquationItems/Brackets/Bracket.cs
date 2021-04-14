namespace MathEquationEvaluator.EquationItems.Brackets
{
    public abstract class Bracket: EquationItem, IOperation
    {
        protected Bracket(string item) : base(item)
        {
        }
    }
}
