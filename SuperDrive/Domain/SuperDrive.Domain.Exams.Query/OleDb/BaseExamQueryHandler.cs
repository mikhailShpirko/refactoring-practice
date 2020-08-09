using SuperDrive.Domain.Core;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace SuperDrive.Domain.Exams.Query.OleDb
{
    public abstract class BaseExamQueryHandler: BaseHandler
    {
        protected BaseExamQueryHandler(IConnectionStringProvider connectionStringProvider)
           : base(connectionStringProvider)
        {

        }

        protected const string _selectSql = @"
SELECT 
    ex_id,
    ex_date, 
    ex_capacity
FROM ex_exam
";
        protected static Exam MapExamFromDataReader(OleDbDataReader reader)
        {
            return new Exam(reader.GetInt32(0),
                            reader.GetDateTime(1),
                            reader.GetInt32(2));
        }
    }
}
