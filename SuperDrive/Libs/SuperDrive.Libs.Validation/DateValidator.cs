using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDrive.Libs.Validation
{
    public partial class Validator
    {
        public static void ValidateDateMinThreshold(DateTime target, DateTime minThreshold, string exceptionMessage, string paramName)
        {
            if (minThreshold > target)
            {
                ThrowArgumentException(exceptionMessage, paramName);
            }
        }

        public static void ValidateDateMinThresholdInclusive(DateTime target, DateTime minThreshold, string exceptionMessage, string paramName)
        {
            if (minThreshold >= target)
            {
                ThrowArgumentException(exceptionMessage, paramName);
            }
        }
    }
}
