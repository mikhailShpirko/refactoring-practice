using SuperDrive.Domain.Core;
using SuperDrive.Domain.Generic.OleDb;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace SuperDrive.Domain.Exams.Command.OleDb
{
    public class CreateExamHandler : BaseCommandHandler<Exam>, ICreateExamCommandHandler
    {
        public CreateExamHandler(IConnectionStringProvider connectionStringProvider)
           : base(connectionStringProvider)
        {

        }

        protected override string _commandText => @"
INSERT INTO ex_exam (ex_date, ex_capacity)
VALUES (@date, @capacity)";

        protected override Func<Exam, OleDbParameter[]> _mapToParameters => (exam) =>
        {
            //OleDb requres to explicitly state type to OleDbType.Date for dates on INSERT
            var dateParam = new OleDbParameter("@date", OleDbType.Date)
            {
                Value = exam.Date
            };
            return new OleDbParameter[]
                    {
                        dateParam,
                        new OleDbParameter("@capacity", exam.Capacity)
                    };
        };

        
    }
}
