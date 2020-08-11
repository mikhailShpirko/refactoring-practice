using SuperDrive.Domain.Core;
using SuperDrive.Domain.Generic.OleDb;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace SuperDrive.Domain.Students.Command.OleDb
{
    public class CreateStudentHandler : BaseCommandHandler<Student>, ICreateStudentCommandHandler
    {
        public CreateStudentHandler(IConnectionStringProvider connectionStringProvider)
           : base(connectionStringProvider)
        {

        }

        protected override string _commandText => @"
INSERT INTO st_student (st_name, st_address, st_dob, st_entry_date) 
VALUES (@name, @address, @dateOfBirth, @entryDate)";

        protected override Func<Student, OleDbParameter[]> _mapToParameters => (student) => {
            //OleDb requres to explicitly state type to OleDbType.Date for dates on INSERT
            var dateOfBirthParam = new OleDbParameter("@dateOfBirth", OleDbType.Date)
            {
                Value = student.DateOfBirth
            };
            var entryDateParam = new OleDbParameter("@entryDate", OleDbType.Date)
            {
                Value = student.EntryDate
            };
            return new OleDbParameter[]
                    {
                        new OleDbParameter("@name", student.Name),
                        new OleDbParameter("@address", student.Address),
                        dateOfBirthParam,
                        entryDateParam
                    };
        };

    }
}
