using System;
using System.Collections.Generic;
using System.Text;

namespace MathEquationEvaluator.Logic
{
    public interface IFactory<T>
    {
        T InitializeFromSign(char sign);
    }
}
