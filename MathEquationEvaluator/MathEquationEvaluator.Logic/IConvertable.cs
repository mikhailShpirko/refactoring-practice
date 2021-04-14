using System;
using System.Collections.Generic;
using System.Text;
using MathEquationEvaluator.EquationItems;

namespace MathEquationEvaluator.Logic
{
    public interface IConvertable
    {
        IReverseNotationItem[] Convert();
    }
}
