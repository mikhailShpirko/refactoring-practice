using SuperDrive.Domain.Core;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace SuperDrive.Domain.Generic.OleDb
{
    public abstract class BaseMultipleRecordsQueryHandler<T>
        : BaseHandler, IQueryHandler<IEnumerable<T>>
    {
        protected BaseMultipleRecordsQueryHandler(IConnectionStringProvider connectionStringProvider)
          : base(connectionStringProvider)
        {

        }

        protected abstract string _commandText { get; }
        protected abstract Func<OleDbDataReader, T> _mapFromReader { get; }

        public IEnumerable<T> Handle()
        {
            using (var connection = new OleDbConnection(_connectionStringProvider.ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = _commandText;
                    using (var reader = command.ExecuteReader())
                    {
                        var result = new List<T>();
                        while (reader.Read())
                        {
                            result.Add(_mapFromReader(reader));
                        }
                        return result;
                    }
                }
            }
        }
    }
}
