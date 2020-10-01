using System;
using System.Windows.Forms;

namespace SuperDrive.WinForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void StudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormAsChild(new StudentListForm());
        }

        private void ExamsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormAsChild(new ExamListForm());
        }

        private void OpenFormAsChild(Form form)
        {
            form.MdiParent = this;
            form.Show();
        }
    }
}
