using SuperDrive.Domain.Core;
using SuperDrive.Domain.Generic.OleDb;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace SuperDrive.Domain.Students.Query.OleDb
{
    public class GetAllStudentsHandler : BaseMultipleRecordsQueryHandler<Student>, IGetAllStudentsQueryHandler
    {
        public GetAllStudentsHandler(IConnectionStringProvider connectionStringProvider)
           : base(connectionStringProvider)
        {

        }

        protected override string _commandText => Constants.SELECT_SQL;

        protected override Func<OleDbDataReader, Student> _mapFromReader => Constants.MapStudentFromReader;

    }
}
