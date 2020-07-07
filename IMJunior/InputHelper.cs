using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace IMJunior
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

        public AbilityType GetAbilityType()
        {
            return GetEnumValueFromInput<AbilityType>();
        }

        public OperationType GetOperationType()
        {
            return GetEnumValueFromInput<OperationType>();
        }

        public int GetNumber()
        {
            string rawInput = string.Empty;
            int integerInput = 0;
            do
            {
                rawInput = Console.ReadLine();
            }
            while (!int.TryParse(rawInput, out integerInput));

            return integerInput;
        }
    }
}
