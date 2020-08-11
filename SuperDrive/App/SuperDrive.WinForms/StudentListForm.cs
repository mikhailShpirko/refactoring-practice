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
using SuperDrive.Libs.BubleSort;

namespace SuperDrive.WinForms
{
    public partial class StudentListForm : BaseListForm
    {
        private readonly IGetAllStudentsQueryHandler _getAllStudentsQueryHandler;
        private readonly IDeleteStudentCommandHandler _deleteStudentCommandHandler;

        private readonly IComparer<Student>[] _studentComparers = new IComparer<Student>[]
        {
            new ByNameComparer(),
            new ByEntryDateComparer()
        };

        public StudentListForm()
        {
            InitializeComponent();

            _getAllStudentsQueryHandler = (IGetAllStudentsQueryHandler)Program.ServiceProvider.GetService(typeof(IGetAllStudentsQueryHandler));
            _deleteStudentCommandHandler = (IDeleteStudentCommandHandler)Program.ServiceProvider.GetService(typeof(IDeleteStudentCommandHandler));

            RefreshStudentList();
        }



        private void RefreshStudentList()
        {
            try
            {
                var students = _getAllStudentsQueryHandler.Handle();

                if (!string.IsNullOrWhiteSpace(tbxSearch.Text))
                {
                    students = students.Where(s => s.Name.ToLower().Contains(tbxSearch.Text.Trim().ToLower()));
                }

                if (cbxSortOrder.SelectedIndex > 0 && cbxSortOrder.SelectedIndex < _studentComparers.Length)
                {
                    students = students.ToArray().BubleSort(_studentComparers[cbxSortOrder.SelectedIndex]);
                }

                studentBindingSource.DataSource = students;
                dgvStudentList.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"{ex.Message}", "Error");
            }
            
        }

        private int GetSelectedStudentId()
        {
            return GetSelectedRow<Student>(dgvStudentList).Id;
        }

        private void OpenAddEditStudentForm(AddEditStudentForm form)
        {
            form.MdiParent = MdiParent;
            form.FormClosed += (sender, args) => RefreshStudentList();
            form.Show();
        }

        #region "Event handlers"

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            RefreshStudentList();
        }

        private void cbxSortOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshStudentList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!IsRowSelected(dgvStudentList))
            {
                return;
            }
            _deleteStudentCommandHandler.Handle(GetSelectedStudentId());
            RefreshStudentList();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            OpenAddEditStudentForm(new AddEditStudentForm());
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!IsRowSelected(dgvStudentList))
            {
                return;
            }
            OpenAddEditStudentForm(new AddEditStudentForm(GetSelectedStudentId()));
        }

        #endregion


    }
}
