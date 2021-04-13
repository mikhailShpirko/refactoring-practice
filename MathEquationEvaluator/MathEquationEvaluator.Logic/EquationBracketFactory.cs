using MathEquationEvaluator.EquationItems.Brackets;

namespace MathEquationEvaluator.Logic
{
    public class EquationBracketFactory : IFactory<Bracket>
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
