using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace IMJunior
{
    public static class EnumExtensions
    {
        private static void ValidateEnumType<T>()
            where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }
        }

        public static string GetDescription<T>(this T enumerationValue)
            where T : struct
        {
            ValidateEnumType<T>();

            var type = enumerationValue.GetType();


            //Tries to find a DescriptionAttribute for a potential friendly name
            //for the enum
            var memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo.Length > 0)
            {
                var attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs.Length > 0)
                {
                    //Pull out the description value
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            //If we have no description attribute, just return the ToString of the enum
            return enumerationValue.ToString();
        }

        public static bool TryGetEnumValueFromDescription<T>(string description, out T enumValue) 
            where T : struct
        {
            ValidateEnumType<T>();

            T[] enumArray = EnumToArray<T>();

            enumValue = enumArray.FirstOrDefault(a => a.GetDescription().ToLower() == description.ToLower());
            return enumArray.Any(a => a.GetDescription().ToLower() == description.ToLower());
        }

        public static T[] EnumToArray<T>()
            where T : struct
        {
            ValidateEnumType<T>();
            return (T[])Enum.GetValues(typeof(T));
        }

        public static int EnumArrayLength<T>()
            where T : struct
        {
            ValidateEnumType<T>();
            return Enum.GetNames(typeof(T)).Length;
        }
    }
}
