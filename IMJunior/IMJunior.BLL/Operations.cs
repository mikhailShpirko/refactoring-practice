using IMJunior.BLL.Operation;
using IMJunior.Util;

namespace IMJunior.BLL
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
