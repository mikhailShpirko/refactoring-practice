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
            return new OleDbParameter[]
                    {
                        new OleDbParameter("@name", student.Name),
                        new OleDbParameter("@address", student.Address),
                        new OleDbParameter("@dateOfBirth", student.DateOfBirth),
                        new OleDbParameter("@entryDate", student.EntryDate)
                    };
        };

    }
}
