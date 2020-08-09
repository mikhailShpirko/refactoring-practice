using SuperDrive.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDrive.Domain.Students
{
    public interface ICreateStudentCommandHandler
        : ICommandHandler<Student>
    {
    }
}
