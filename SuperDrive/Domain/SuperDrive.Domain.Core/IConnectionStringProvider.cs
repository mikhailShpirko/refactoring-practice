using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDrive.Domain.Core
{
    public interface IConnectionStringProvider
    {
        string ConnectionString { get; }
    }
}
