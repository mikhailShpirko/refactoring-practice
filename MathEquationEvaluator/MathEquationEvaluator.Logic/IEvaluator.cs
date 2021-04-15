namespace MathEquationEvaluator.Logic
{
    public interface IEvaluator
    {
        IEvaluatable ForEquation(string equation);
    }
}
