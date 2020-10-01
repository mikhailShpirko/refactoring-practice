
using System.Windows.Forms;

namespace SuperDrive.WinForms
{
    public static class DataGridViewExtensions
    {
        public static bool TryGetSelectedBoundedObject<T>(this DataGridView dgv, out T selectedBoundedObject) where T: class
        {
            selectedBoundedObject = null;
            if (dgv.SelectedRows.Count != 0 &&
                    dgv.SelectedRows[0].DataBoundItem is T)
            {
                selectedBoundedObject = dgv.SelectedRows[0].DataBoundItem as T;
                return true;
            }

            return false;
        }
    }
}
