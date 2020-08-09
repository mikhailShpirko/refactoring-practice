using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace SuperDrive.Domain.Exams.Query.OleDb
{
    internal class Constants
    {
        public const string SELECT_SQL = @"
SELECT 
    ex_id,
    ex_date, 
    ex_capacity
FROM ex_exam
";
        public static Func<OleDbDataReader, Exam> MapExamFromReader => (reader) =>
        {
            return new Exam(reader.GetInt32(0),
                            reader.GetDateTime(1),
                            reader.GetInt32(2));
        };
    }
}
