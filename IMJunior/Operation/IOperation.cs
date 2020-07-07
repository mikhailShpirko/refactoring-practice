using System;
using System.Collections.Generic;
using System.Text;

namespace IMJunior.Operation
{
    public interface IOperation
    {
        Func<int, int> UpdateAbility { get; }

        Func<int, int> UpdatePoints { get; }
    }
}
