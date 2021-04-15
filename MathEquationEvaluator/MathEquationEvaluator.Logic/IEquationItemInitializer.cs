namespace MathEquationEvaluator.Logic
{
    public interface IEquationItemInitializer<T>
    {
        T InitializeFromSign(char sign);
    }
}
