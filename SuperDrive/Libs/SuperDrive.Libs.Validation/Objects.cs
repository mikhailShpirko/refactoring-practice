using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDrive.Libs.Validation
{
    public partial class Validator
    {
        public static void ValidateNotNullObject(object target, string exceptionMessage, string paramName)
        {
            if (target == null)
            {
                ThrowArgumentNullException(exceptionMessage, paramName);
            }
        }
    }
}
