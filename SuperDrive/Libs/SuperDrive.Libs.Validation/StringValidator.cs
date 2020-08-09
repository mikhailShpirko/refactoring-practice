using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDrive.Libs.Validation
{
    public partial class Validator
    {
        public static void ValidateNotEmptyString(string target, string exceptionMessage, string paramName)
        {
            if (string.IsNullOrWhiteSpace(target))
            {
                ThrowArgumentNullException(exceptionMessage, paramName);
            }
        }
    }
}
