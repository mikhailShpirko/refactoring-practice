using MathEquationEvaluator.Core.DataStructures;
using MathEquationEvaluator.Core.Extensions;

namespace MathEquationEvaluator.EquationItems
{
    public class Equation
    {
        protected IReverseNotationItem[] _reverseNotationItems;
        public decimal Result { get; protected set; }

        public override string ToString()
        {
            return _reverseNotationItems.ConvertToString();
        }
    }
}
