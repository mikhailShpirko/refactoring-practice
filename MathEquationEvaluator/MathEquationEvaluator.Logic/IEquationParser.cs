using MathEquationEvaluator.EquationItems;

namespace MathEquationEvaluator.Logic
{
    public interface IEquationParser
    {
        EquationItem[] ParseEquationItems(string equation);
    }
}
