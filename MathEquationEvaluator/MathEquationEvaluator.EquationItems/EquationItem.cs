namespace MathEquationEvaluator.EquationItems
{
    public abstract class EquationItem
    {
        private readonly string _item;
        protected EquationItem(string item)
        {
            _item = item;
        }

        public override string ToString()
        {
            return _item;
        }
    }
}
