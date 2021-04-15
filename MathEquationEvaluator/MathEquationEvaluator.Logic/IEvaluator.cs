using System;
using System.Collections.Generic;
using System.Text;

namespace MathEquationEvaluator.Logic
{
    public interface IEvaluator
    {
        IEvaluatable ForEquation(string equation);
    }
}
