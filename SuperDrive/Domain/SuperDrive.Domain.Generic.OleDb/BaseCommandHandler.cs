using SuperDrive.Domain.Core;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace SuperDrive.Domain.Generic.OleDb
{
    public abstract class BaseCommandHandler<TData>: BaseHandler, ICommandHandler<TData>
    {
        protected BaseCommandHandler(IConnectionStringProvider connectionStringProvider)
          : base(connectionStringProvider)
        {

        }

        protected abstract string _commandText { get; }
        protected abstract Func<TData, OleDbParameter[]> _mapToParameters { get; }

        public void Handle(TData commandData)
        {
            using (var connection = new OleDbConnection(_connectionStringProvider.ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = _commandText;
                    command.Parameters.AddRange(_mapToParameters(commandData));
                    command.ExecuteNonQuery();
                }
            };
        }
    }
}
