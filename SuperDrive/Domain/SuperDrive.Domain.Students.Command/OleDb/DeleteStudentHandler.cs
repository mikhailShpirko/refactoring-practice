using SuperDrive.Domain.Core;
using SuperDrive.Domain.Generic.OleDb;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace SuperDrive.Domain.Students.Command.OleDb
{
    public class DeleteStudentHandler : BaseCommandHandler<int>, IDeleteStudentCommandHandler
    {
        public DeleteStudentHandler(IConnectionStringProvider connectionStringProvider)
            : base(connectionStringProvider)
        {

        }

        protected override string _commandText => @"
DELETE FROM st_student
WHERE st_id = @id";

        protected override Func<int, OleDbParameter[]> _mapToParameters => (id) => {
            return new OleDbParameter[]
                    {
                        new OleDbParameter("@id", id)
                    };
        };      
    }
}
