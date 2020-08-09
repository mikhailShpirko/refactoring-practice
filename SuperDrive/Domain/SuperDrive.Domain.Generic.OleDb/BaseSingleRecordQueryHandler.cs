using SuperDrive.Domain.Core;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace SuperDrive.Domain.Generic.OleDb
{
    public abstract class BaseSingleRecordQueryHandler<TQuery, TResult> 
        : BaseHandler, IQueryHandler<TQuery, TResult> where TResult : class
    {
        protected BaseSingleRecordQueryHandler(IConnectionStringProvider connectionStringProvider)
          : base(connectionStringProvider)
        {

        }

        protected abstract string _commandText { get; }
        protected abstract Func<TQuery, OleDbParameter[]> _mapToParameters { get; }
        protected abstract Func<OleDbDataReader, TResult> _mapFromParameters { get; }

        public TResult Handle(TQuery queryData)
        {
            using (var connection = new OleDbConnection(_connectionStringProvider.ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = _commandText;
                    command.Parameters.AddRange(_mapToParameters(queryData));
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return _mapFromParameters(reader);
                        }
                        return null;
                    }
                }
            }
        }
    }
}
