using SuperDrive.Domain.Students;
using SuperDrive.Libs.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperDrive.Domain.Exams
{

    public class Exam
    {
        public Exam(int id,
                    DateTime date,
                    int capacity)
        {
            Validator.ValidateIntMinThreshold(id, 0, "Id should not be negative number", nameof(id));
            Validator.ValidateDateMinThreshold(date, DateTime.Now, "Can't create examp in past", nameof(date));
            Validator.ValidateIntMinThreshold(capacity, 1, "Capacity should be greater than 0", nameof(capacity));


            Id = id;
            Date = date;
            Capacity = capacity;
        }

        public int Id { get; private set; }
        public DateTime Date { get; private set; }
        public int Capacity { get; private set; }

        public Queue<Student> EnrollStudents(IEnumerable<Student> students, out bool isEnoughStudents)
        {
            isEnoughStudents = false;
            var enrolledStudents = new Queue<Student>();
            foreach(var student in students.OrderBy(s => s.EntryDate))
            {
                if(enrolledStudents.Count == Capacity)
                {
                    isEnoughStudents = true;
                    break;
                }
                enrolledStudents.Enqueue(student);
            }

            return enrolledStudents;
        }
    }
}
