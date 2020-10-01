using SuperDrive.Domain.Students;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SuperDrive.Libs.BubleSort;

namespace SuperDrive.WinForms
{
    public partial class StudentListForm : Form
    {
        private readonly IGetAllStudentsQueryHandler _getAllStudentsQueryHandler;
        private readonly IDeleteStudentCommandHandler _deleteStudentCommandHandler;

        public StudentListForm()
        {
            InitializeComponent();

            _getAllStudentsQueryHandler = DependencyResolver.Instance.Resolve<IGetAllStudentsQueryHandler>();
            _deleteStudentCommandHandler = DependencyResolver.Instance.Resolve<IDeleteStudentCommandHandler>();

            cbxSortOrder.DataSource = new List<StudentComparersComboBoxItem>
            {
                new StudentComparersComboBoxItem("Name", new ByNameComparer()),
                new StudentComparersComboBoxItem("Entry Date", new ByEntryDateComparer())
            };

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

                if (cbxSortOrder.TryGetSelectedBoundedObject<StudentComparersComboBoxItem>(out var selectedItem))
                {
                    students = students.ToArray().BubleSort(selectedItem.Comparer);
                }

                studentBindingSource.DataSource = students;
                dgvStudentList.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"{ex.Message}", "Error");
            }
            
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
            if (!dgvStudentList.TryGetSelectedBoundedObject<Student>(out var selectedStudent))
            {
                MessageBox.Show("Select a student", "Error");
                return;
            }
            _deleteStudentCommandHandler.Handle(selectedStudent.Id);
            RefreshStudentList();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            OpenAddEditStudentForm(new AddEditStudentForm());
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!dgvStudentList.TryGetSelectedBoundedObject<Student>(out var selectedStudent))
            {
                MessageBox.Show("Select a student", "Error");
                return;
            }
            OpenAddEditStudentForm(new AddEditStudentForm(selectedStudent.Id));
        }

        #endregion


    }
}
