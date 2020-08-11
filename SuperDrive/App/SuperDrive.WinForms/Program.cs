using System;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Forms;
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
    static class Program
    {
        public static IServiceProvider ServiceProvider { get; set; }

        static void ConfigureServices()
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

            ServiceProvider = services.BuildServiceProvider();

        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ConfigureServices();
            Application.Run(new MainForm());
        }
    }
}
