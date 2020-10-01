using SuperDrive.Domain.Core;
using SuperDrive.DAL.OleDb;
using System;
using System.Data.OleDb;

namespace SuperDrive.Domain.Students.Command.OleDb
{
    public class UpdateStudentHandler : BaseCommandHandler<Student>, IUpdateStudentCommandHandler
    {
        public UpdateStudentHandler(IConnectionStringProvider connectionStringProvider) 
            : base(connectionStringProvider)
        {

        }

        protected override string _commandText => @"
UPDATE st_student 
SET st_name = @name, 
    st_address = @address, 
    st_dob = @dateOfBirth, 
    st_entry_date = @entryDate 
WHERE st_id = @id";

        protected override Func<Student, OleDbParameter[]> _mapToParameters => (student) => {
            return new OleDbParameter[]
                    {
                        new OleDbParameter("@name", student.Name),
                        new OleDbParameter("@address", student.Address),
                        new OleDbParameter("@dateOfBirth", student.DateOfBirth),
                        new OleDbParameter("@entryDate", student.EntryDate),
                        new OleDbParameter("@id", student.Id)
                    };
        }; 
    }
}
