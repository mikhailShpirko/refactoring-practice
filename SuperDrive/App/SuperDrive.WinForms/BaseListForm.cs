using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperDrive.WinForms
{
    public class BaseListForm: Form
    {
        protected bool IsRowSelected(DataGridView dataGridView)
        {
            if (dataGridView.SelectedRows.Count != 0) return true;
            MessageBox.Show(this, "Select a record", "Error");
            return false;
        }

        protected T GetSelectedRow<T>(DataGridView dataGridView)
        {
            return (T)dataGridView.SelectedRows[0].DataBoundItem;
        }

    }
}
