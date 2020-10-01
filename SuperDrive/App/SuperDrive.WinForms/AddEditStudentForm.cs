using SuperDrive.Domain.Core;
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
    public partial class AddEditStudentForm : Form
    {
        private readonly ICommandHandler<Student> _addEditCommandHandler;
        private readonly int _addEditStudentId;


        public AddEditStudentForm()
        {
            _addEditCommandHandler = DependencyResolver.Instance.Resolve<ICreateStudentCommandHandler>();
            _addEditStudentId = 0;            
            InitializeComponent();
            SetFormTitle("Create new student");
        }

        public AddEditStudentForm(int id)
        {
            
            _addEditCommandHandler = DependencyResolver.Instance.Resolve<IUpdateStudentCommandHandler>();
            _addEditStudentId = id;
            InitializeComponent();

            var getByIdQueryHadler = DependencyResolver.Instance.Resolve<IGetStudentByIdQueryHandler>();
            var student = getByIdQueryHadler.Handle(id);
            MapStudentToControls(student);
            SetFormTitle("Update student info");
        }

        private void SetFormTitle(string title)
        {
            this.Text = title;
        }

        private void MapStudentToControls(Student student)
        {
            tbxName.Text = student.Name;
            tbxAddress.Text = student.Address;
            dtpDateOfBirth.Value = student.DateOfBirth;
            dtpEntryDate.Value = student.EntryDate;
        }

        private Student MapStudentFromControls()
        {
            return new Student(_addEditStudentId,
                                tbxName.Text,
                                tbxAddress.Text,
                                dtpDateOfBirth.Value,
                                dtpEntryDate.Value);
        }

        #region "Event handlers"

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var student = MapStudentFromControls();
                _addEditCommandHandler.Handle(student);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion
    }
}
