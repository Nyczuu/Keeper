using System.Windows.Controls;

namespace Keeper.WPF.Extensions
{
    static class ListBoxExtensions
    {
        public static ListBox SetDefaults(this ListBox listBox, SelectionMode selectionMode = SelectionMode.Extended)
        {
            listBox.SelectionMode = selectionMode;
            return listBox;
        }
    }
}
