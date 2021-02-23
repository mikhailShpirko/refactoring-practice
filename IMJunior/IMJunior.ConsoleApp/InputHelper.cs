using System;
using IMJunior.Util;
using IMJunior.BLL;

namespace IMJunior.ConsoleApp
{
    public class InputHelper
    {
        private T GetEnumValueFromInput<T>() 
            where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }

            string rawInput = string.Empty;
            T enumValue;

            do
            {
                rawInput = Console.ReadLine();
            }
            while (!EnumExtensions.TryGetEnumValueFromDescription(rawInput, out enumValue));
            EnumExtensions.TryGetEnumValueFromDescription(rawInput, out enumValue);
            return enumValue;
        }

        private bool IsNumberPositive(int number)
        {
            return number > 0;
        }

        private int GetNumberWithValidation(Func<int, bool> validate)
        {
            string rawInput = string.Empty;
            int integerInput = 0;
            do
            {
                rawInput = Console.ReadLine();
            }
            while (!(int.TryParse(rawInput, out integerInput) && 
                     validate(integerInput)));

            return integerInput;
        }

        public AbilityType GetAbilityType()
        {
            return GetEnumValueFromInput<AbilityType>();
        }

        public OperationType GetOperationType()
        {
            return GetEnumValueFromInput<OperationType>();
        }

        public int GetPositiveNumber()
        {
            return GetNumberWithValidation(IsNumberPositive);
        }

        public int GetPositiveNumberWithLimit(int limit)
        {
            return GetNumberWithValidation(input => IsNumberPositive(input) && input <= limit);
        }
    }
}
