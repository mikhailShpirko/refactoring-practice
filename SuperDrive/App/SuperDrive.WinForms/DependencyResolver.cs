using System;
using Microsoft.Extensions.DependencyInjection;
using SuperDrive.Domain.Exams;
using SuperDrive.Domain.Exams.Command.OleDb;
using SuperDrive.Domain.Exams.Query.OleDb;
using SuperDrive.Domain.Students;
using SuperDrive.Domain.Students.Command.OleDb;
using SuperDrive.Domain.Students.Query.OleDb;
using SuperDrive.Domain.Core;
using SuperDrive.Util.ConnectionStringProviders;

namespace SuperDrive.WinForms
{
    public class DependencyResolver
    {
        private readonly IServiceProvider _serviceProvider;

        private static DependencyResolver _instance;

        public static DependencyResolver Instance => _instance ?? (_instance = new DependencyResolver());

        public DependencyResolver()
        {
            var services = new ServiceCollection();

            #region "Domain.Exam"

            services.AddTransient<ICreateExamCommandHandler, CreateExamHandler>();
            services.AddTransient<IGetAllExamsQueryHandler, GetAllExamsHandler>();
            services.AddTransient<IGetExamByIdQueryHandler, GetExamByIdHandler>();

            #endregion

            #region "Domain.Student"

            services.AddTransient<ICreateStudentCommandHandler, CreateStudentHandler>();
            services.AddTransient<IUpdateStudentCommandHandler, UpdateStudentHandler>();
            services.AddTransient<IDeleteStudentCommandHandler, DeleteStudentHandler>();
            services.AddTransient<IGetAllStudentsQueryHandler, GetAllStudentsHandler>();
            services.AddTransient<IGetStudentByIdQueryHandler, GetStudentByIdHandler>();

            #endregion

            #region "ConnectionStringProvider"

            services.AddTransient<IConnectionStringProvider, ConnectionStringFromConfig>();

            #endregion

            _serviceProvider = services.BuildServiceProvider();
        }

        public T Resolve<T>()
        {
            return (T)_serviceProvider.GetService(typeof(T));
        }
    }
}
