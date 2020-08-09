using SuperDrive.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDrive.Domain.Exams
{
    public interface IGetExamByIdQueryHandler
        : IQueryHandler<int, Exam>
    {
    }
}
