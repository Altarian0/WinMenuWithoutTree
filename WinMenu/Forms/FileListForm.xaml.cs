using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WinMenu.Controls;
using WinMenu.Database;
using WinMenu.Helper;

namespace WinMenu.Forms
{
    /// <summary>
    /// Interaction logic for FileListForm.xaml
    /// </summary>
    public partial class FileListForm : Window
    {
        public FileListForm()
        {
            InitializeComponent();

            ObjectListHelper.ObjectList = new ObservableCollection<Database.Object>(DBHelper.GetContext().Object.Where(n => n.ParentId == null).ToList());
            MainList.ItemsSource = ObjectListHelper.ObjectList;
        }

        /// <summary>
        /// Open Add Object form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddForm addForm = new AddForm();
            addForm.Show();

            MainList.Items.Refresh();
        }

        private void MainList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
