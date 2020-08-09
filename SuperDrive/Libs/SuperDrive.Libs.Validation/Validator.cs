using System;

namespace SuperDrive.Libs.Validation
{
    public partial class Validator
    {
        private static void ThrowArgumentException(string message, string paramName)
        {
            throw new ArgumentException(message, paramName);
        }

        private static void ThrowArgumentNullException(string message, string paramName)
        {
            throw new ArgumentNullException(message, paramName);
        }
    }
}
