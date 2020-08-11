using SuperDrive.Domain.Students;
using SuperDrive.Libs.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperDrive.Domain.Exams
{

    public class Exam
    {
        //for new records
        public Exam(DateTime date,
                    int capacity)
            : this(0, date, capacity)
        {
            Validator.ValidateDateMinThreshold(date, DateTime.Now, "Can't create exam in past", nameof(date));
        }

        //for query in db
        public Exam(int id,
                    DateTime date,
                    int capacity)
        {
            Validator.ValidateIntMinThreshold(id, 0, "Id should not be negative number", nameof(id));
            Validator.ValidateIntMinThreshold(capacity, 1, "Capacity should be greater than 0", nameof(capacity));


            Id = id;
            Date = date.Date; //time part is reduntant
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
