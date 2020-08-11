using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDrive.Domain.Students
{
    public class ByNameComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}
