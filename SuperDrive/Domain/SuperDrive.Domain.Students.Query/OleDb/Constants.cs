using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace SuperDrive.Domain.Students.Query.OleDb
{
    internal class Constants
    {
        public const string SELECT_SQL = @"
SELECT 
    st_id,
    st_name, 
    st_address, 
    st_dob, 
    st_entry_date
FROM st_student
";
        public static Func<OleDbDataReader, Student> MapStudentFromReader => (reader) =>
        {
            return new Student(reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetDateTime(3),
                                reader.GetDateTime(4));
        };
    }
}
