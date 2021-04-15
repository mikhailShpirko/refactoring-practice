using System.Text;

namespace MathEquationEvaluator.Core.Extensions
{
    public static class ArrayExtensions
    {
        public static int GetLastIndex<T>(this T[] array)
        {
            return array.Length - 1;
        }

        public static string ConvertToString<T>(this T[] array)
        {
            var output = new StringBuilder();

            for (var i = 0; i < array.Length; i++)
            {
                output.Append(array[i]);
                if (i != array.GetLastIndex())
                {
                    output.Append(' ');
                }
            }

            //Obviously, can the same be achieved with string.Join, but not sure if usage of the function is allowed for the task
            return output.ToString();
        }
    }
}
