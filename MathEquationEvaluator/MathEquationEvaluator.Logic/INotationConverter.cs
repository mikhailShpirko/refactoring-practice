using System;
using System.Collections.Generic;
using System.Text;
using MathEquationEvaluator.EquationItems;

namespace MathEquationEvaluator.Logic
{
    public interface INotationConverter
    {
        IConvertable ForEquationItems(EquationItem[] equationItems);
    }
}
