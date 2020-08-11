using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDrive.Domain.Students
{
    public class ByEntryDateComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return x.EntryDate.CompareTo(y.EntryDate);
        }
    }
}
