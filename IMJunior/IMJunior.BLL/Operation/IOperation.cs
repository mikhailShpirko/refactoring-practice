using System;

namespace IMJunior.BLL.Operation
{
    public interface IOperation
    {
        Func<int, int> UpdateAbility { get; }

        Func<int, int> UpdatePoints { get; }
    }
}
