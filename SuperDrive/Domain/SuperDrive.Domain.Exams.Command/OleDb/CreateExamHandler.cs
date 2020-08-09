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
            return new OleDbParameter[]
                    {
                        new OleDbParameter("@date", exam.Date),
                        new OleDbParameter("@capacity", exam.Capacity)
                    };
        };

        
    }
}
