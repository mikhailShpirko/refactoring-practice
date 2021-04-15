using MathEquationEvaluator.EquationItems;

namespace MathEquationEvaluator.Logic
{
    public interface INotationConverter
    {
        IConvertable ForEquationItems(EquationItem[] equationItems);
    }
}
