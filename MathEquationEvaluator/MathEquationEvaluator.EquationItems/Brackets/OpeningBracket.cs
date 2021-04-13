using MathEquationEvaluator.EquationItems.Operations;

namespace MathEquationEvaluator.EquationItems.Brackets
{
    public class OpeningBracket: Bracket, IBeforeUnaryOperation
    {
        public OpeningBracket() 
            : base("(")
        {
        }
    }
}
