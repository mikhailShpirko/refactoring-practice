using SuperDrive.Domain.Exams;
using System;
using System.Windows.Forms;

namespace SuperDrive.WinForms
{
    public partial class ExamListForm : Form
    {
        private readonly IGetAllExamsQueryHandler _getAllExamsQueryHandler;

        public ExamListForm()
        {
            InitializeComponent();
            _getAllExamsQueryHandler = DependencyResolver.Instance.Resolve<IGetAllExamsQueryHandler>();
            RefreshExamList();
        }

        private void OpenForm(Form form)
        {
            form.MdiParent = MdiParent;            
            form.Show();
        }

        private void RefreshExamList()
        {
            try
            {
                var exams = _getAllExamsQueryHandler.Handle();
                examBindingSource.DataSource = exams;
                dgvExamList.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"{ex.Message}", "Error");
            }
        }

        #region "Event Handlers"

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var form = new AddExamForm();
            form.FormClosed += (s, args) => RefreshExamList();
            OpenForm(form);
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            if(!dgvExamList.TryGetSelectedBoundedObject<Exam>(out var selectedExam))
            {
                MessageBox.Show("Select an exam", "Error");
                return;
            }
            OpenForm(new ExamEnrollmentForm(selectedExam.Id));
        }

        #endregion


    }
}
