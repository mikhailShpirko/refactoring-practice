using SuperDrive.Libs.Validation;
using System;

namespace SuperDrive.Domain.Students
{
    public class Student
    {
        public Student(int id,
                        string name,
                        string address,
                        DateTime dateOfBirth,
                        DateTime entryDate)
        {
            Validator.ValidateIntMinThreshold(id, 0 , "Id should not be negative number", nameof(id));
            Validator.ValidateNotEmptyString(name, "Name should not be empty", nameof(name));
            Validator.ValidateNotEmptyString(address, "Address should not be empty", nameof(address));
            Validator.ValidateDateMinThresholdInclusive(entryDate, dateOfBirth, "Student can not be born later than entered to school", nameof(dateOfBirth));

            Id = id;
            Name = name;
            Address = address;
            DateOfBirth = dateOfBirth;
            EntryDate = entryDate;            
        }

        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public string Address { get; protected set; }
        public DateTime DateOfBirth { get; protected set; }
        public DateTime EntryDate { get; protected set; }
    }
}
