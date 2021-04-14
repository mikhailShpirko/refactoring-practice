using MathEquationEvaluator.EquationItems.Brackets;

namespace MathEquationEvaluator.Logic
{
    public class EquationBracketInitializer : IEquationItemInitializer<Bracket>
    {
        public Bracket InitializeFromSign(char sign)
        {
            switch (sign)
            {
                case '(':
                    return new OpeningBracket();
                case ')':
                    return new ClosingBracket();
                default:
                    return null;
            }
        }
    }
}
