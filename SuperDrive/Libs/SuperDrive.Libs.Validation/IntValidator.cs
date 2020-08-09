using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDrive.Libs.Validation
{
    public partial class Validator
    {
        public static void ValidateIntMinThreshold(int target, int minThreshold, string exceptionMessage, string paramName)
        {
            if (minThreshold > target)
            {
                ThrowArgumentException(exceptionMessage, paramName);
            }
        }
    }
}
