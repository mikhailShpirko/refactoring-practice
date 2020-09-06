using System;

namespace IMJunior.BLL.Operation
{
    public abstract class BaseOperation: IOperation
    {
        protected int _operandPoints;

        public abstract Func<int, int> UpdateAbility { get; }

        public abstract Func<int, int> UpdatePoints { get; } 

        public BaseOperation SetOperandPoints(int operandPoints)
        {
            _operandPoints = operandPoints;
            return this;
        }
    }
}
