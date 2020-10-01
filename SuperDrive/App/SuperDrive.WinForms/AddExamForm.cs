using SuperDrive.Domain.Exams;
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
    public partial class AddExamForm : Form
    {
        private readonly ICreateExamCommandHandler _createExamCommandHandler;

        public AddExamForm()
        {
            InitializeComponent();
            _createExamCommandHandler = DependencyResolver.Instance.Resolve<ICreateExamCommandHandler>();
        }

        private Exam MapExamFromControls()
        {
            return new Exam(dtpDate.Value,
                        (int)nudCapacity.Value);
        }

        #region "Event handlers"

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var exam = MapExamFromControls();
                _createExamCommandHandler.Handle(exam);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}
