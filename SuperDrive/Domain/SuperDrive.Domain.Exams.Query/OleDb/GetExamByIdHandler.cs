using SuperDrive.Domain.Core;
using SuperDrive.Domain.Generic.OleDb;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace SuperDrive.Domain.Exams.Query.OleDb
{
    public class GetExamByIdHandler: BaseSingleRecordQueryHandler<int, Exam>, IGetExamByIdQueryHandler
    {
        public GetExamByIdHandler(IConnectionStringProvider connectionStringProvider)
           : base(connectionStringProvider)
        {

        }

        protected override string _commandText => $@"
{Constants.SELECT_SQL}
WHERE ex_id = @id";

        protected override Func<int, OleDbParameter[]> _mapToParameters => (id) =>
        {
            return new OleDbParameter[]
                    {
                        new OleDbParameter("@id", id)
                    };
        };

        protected override Func<OleDbDataReader, Exam> _mapFromParameters => Constants.MapExamFromReader;
        
    }
}
