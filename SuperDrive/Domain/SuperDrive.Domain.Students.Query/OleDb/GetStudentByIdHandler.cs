﻿using SuperDrive.Domain.Core;
using SuperDrive.DAL.OleDb;
using System;
using System.Data.OleDb;

namespace SuperDrive.Domain.Students.Query.OleDb
{
    public class GetStudentByIdHandler : BaseSingleRecordQueryHandler<int, Student>, IGetStudentByIdQueryHandler
    {
        public GetStudentByIdHandler(IConnectionStringProvider connectionStringProvider)
           : base(connectionStringProvider)
        {

        }

        protected override string _commandText => $@"
{Constants.SELECT_SQL}
WHERE st_id = @id";

        protected override Func<int, OleDbParameter[]> _mapToParameters => (id) =>
        {
            return new OleDbParameter[]
                    {
                        new OleDbParameter("@id", id)
                    };
        };

        protected override Func<OleDbDataReader, Student> _mapFromParameters => Constants.MapStudentFromReader;
       
    }
}
