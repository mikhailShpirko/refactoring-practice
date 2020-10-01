using SuperDrive.Domain.Students;
using SuperDrive.Libs.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDrive.WinForms
{
    public class StudentComparersComboBoxItem
    {
        public string DisplayText { get; private set; }
        public IComparer<Student> Comparer { get; private set; }

        public StudentComparersComboBoxItem(string displayText,
                                            IComparer<Student> comparer)
        {
            Validator.ValidateNotEmptyString(displayText, "Student comparer display text is missing", nameof(displayText));
            Validator.ValidateNotNullObject(comparer, "Student comparer is missing", nameof(comparer));

            DisplayText = displayText;
            Comparer = comparer;
        }
    }
}
