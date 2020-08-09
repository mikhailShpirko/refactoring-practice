using SuperDrive.Libs.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDrive.Domain.Core
{
    public abstract class BaseHandler
    {
        protected readonly IConnectionStringProvider _connectionStringProvider;

        protected BaseHandler(IConnectionStringProvider connectionStringProvider)
        {
            Validator.ValidateNotEmptyString(connectionStringProvider.ConnectionString, "Connection String can not be empty", nameof(connectionStringProvider.ConnectionString));
            _connectionStringProvider = connectionStringProvider;
        }
    }
}
