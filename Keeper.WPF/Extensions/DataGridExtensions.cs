using System.Windows.Controls;

namespace Keeper.WPF.Extensions
{
    static class DataGridExtensions
    {
        public static DataGrid SetDefaults(this DataGrid dataGrid)
        {
            dataGrid.CanUserAddRows = false;
            dataGrid.CanUserDeleteRows = false;
            dataGrid.IsReadOnly = true;

            return dataGrid;
        }
    }
}
