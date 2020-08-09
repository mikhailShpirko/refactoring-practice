using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDrive.Domain.Core
{
    public interface ICommandHandler<TData>
    {
        void Handle(TData commandData);    
    }
}
