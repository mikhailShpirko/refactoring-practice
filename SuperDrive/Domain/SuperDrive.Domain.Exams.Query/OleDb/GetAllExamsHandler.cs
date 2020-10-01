using SuperDrive.Domain.Core;
using SuperDrive.DAL.OleDb;
using System;
using System.Data.OleDb;

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
