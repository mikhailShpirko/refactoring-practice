using MathEquationEvaluator.EquationItems.Operations;

namespace MathEquationEvaluator.Logic
{
    public class EquationOperationFactory: IFactory<Operation>
    {
        public Operation InitializeFromSign(char sign)
        {
            switch (sign)
            {
                case '+':
                    return new Add();
                case '-':
                    return new Subtract();
                case '*':
                    return new Multiply();
                case '/':
                    return new Divide();
                default:
                    return null;
            }
        }
    }
}
