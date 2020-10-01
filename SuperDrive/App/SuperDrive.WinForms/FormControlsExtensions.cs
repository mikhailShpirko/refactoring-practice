
using System.Windows.Forms;

namespace SuperDrive.WinForms
{
    public static class FormControlsExtensions
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

        public static bool TryGetSelectedBoundedObject<T>(this ComboBox cbx, out T selectedBoundedObject) where T : class
        {
            selectedBoundedObject = null;
            if (cbx.SelectedIndex > 0 &&
                    cbx.SelectedItem is T)
            {
                selectedBoundedObject = cbx.SelectedItem as T;
                return true;
            }

            return false;
        }
    }
}
