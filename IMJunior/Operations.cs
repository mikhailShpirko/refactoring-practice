using IMJunior.Operation;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMJunior
{
    public class Operations
    {
        private BaseOperation[] _operations;

        public Operations()
        {
            _operations = new BaseOperation[EnumExtensions.EnumArrayLength<OperationType>()];
            _operations[(int)OperationType.Add] = new AddOperation();
            _operations[(int)OperationType.Subtract] = new SubtractOperation();
        }

        public IOperation GetOperation(OperationType type, int operandPoints)
        {
            return _operations[(int)type].SetOperandPoints(operandPoints);
        }
    }
}
