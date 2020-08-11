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
