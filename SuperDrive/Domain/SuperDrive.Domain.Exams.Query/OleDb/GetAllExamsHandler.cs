using SuperDrive.Domain.Core;
using SuperDrive.Domain.Generic.OleDb;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace SuperDrive.Domain.Exams.Query.OleDb
{
    public class GetAllExamsHandler: BaseMultipleRecordsQueryHandler<Exam>, IGetAllExamsQueryHandler
    {
        public GetAllExamsHandler(IConnectionStringProvider connectionStringProvider)
           : base(connectionStringProvider)
        {

        }

        protected override string _commandText => Constants.SELECT_SQL;

        protected override Func<OleDbDataReader, Exam> _mapFromReader => Constants.MapExamFromReader;
       
    }
}
