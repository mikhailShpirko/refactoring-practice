using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDrive.Domain.Core
{
    public interface IQueryHandler<TResult>
    {
        TResult Handle();
    }

    public interface IQueryHandler<TQuery, TResult>
    {
        TResult Handle(TQuery queryData);
    }
}
