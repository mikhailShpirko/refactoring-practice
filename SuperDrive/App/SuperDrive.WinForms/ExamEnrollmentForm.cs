using SuperDrive.Domain.Exams;
using SuperDrive.Domain.Students;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperDrive.WinForms
{
    public partial class ExamEnrollmentForm : Form
    {
        private readonly IGetExamByIdQueryHandler _getExamByIdQueryHandler;
        private readonly IGetAllStudentsQueryHandler _getAllStudentsQueryHandler;

        public ExamEnrollmentForm(int examId)
        {
            InitializeComponent();
            _getAllStudentsQueryHandler = (IGetAllStudentsQueryHandler)Program.ServiceProvider.GetService(typeof(IGetAllStudentsQueryHandler));
            _getExamByIdQueryHandler = (IGetExamByIdQueryHandler)Program.ServiceProvider.GetService(typeof(IGetExamByIdQueryHandler));
            var exam = _getExamByIdQueryHandler.Handle(examId);
            MapExamToControls(exam);
            FillStudentsList(exam);
        }

        private void MapExamToControls(Exam exam)
        {
            lblCapacity.Text = exam.Capacity.ToString();
            lblDate.Text = exam.Date.ToShortDateString();
        }

        private void FillStudentsList(Exam exam)
        {
            var allStudents = _getAllStudentsQueryHandler.Handle();

            var enrolledStudents = exam.EnrollStudents(allStudents, out var isEnoughStudents);

            if(!isEnoughStudents)
            {
                MessageBox.Show(this, "Not enough students for the exam", "Warning");
            }

            studentBindingSource.DataSource = enrolledStudents;
            dgvEnrolledStudents.Refresh();
        }

        #region "Event Handlers"

        private void btnDone_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}
