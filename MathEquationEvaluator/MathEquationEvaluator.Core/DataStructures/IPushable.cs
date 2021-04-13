namespace MathEquationEvaluator.Core.DataStructures
{
    public interface IPushableCollection<T>: ICollection<T>
    {
        void Push(T newItem);
    }
}
