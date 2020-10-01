using SuperDrive.Domain.Exams;
using SuperDrive.Domain.Students;
using System;
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
            _getAllStudentsQueryHandler = DependencyResolver.Instance.Resolve<IGetAllStudentsQueryHandler>();
            _getExamByIdQueryHandler = DependencyResolver.Instance.Resolve<IGetExamByIdQueryHandler>();
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
