using SuperDrive.Domain.Core;
using System;
using System.Configuration;

namespace SuperDrive.Util.ConnectionStringProviders
{
    public class ConnectionStringFromConfig : IConnectionStringProvider
    {
        private const string CONNECTION_STRING_NAME = "DbConnectionString";

        public string ConnectionString => ConfigurationManager.ConnectionStrings[CONNECTION_STRING_NAME].ConnectionString;
    }
}
