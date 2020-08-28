using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WinMenu.Controls
{
    /// <summary>
    /// Interaction logic for FileControl.xaml
    /// </summary>
    public partial class FileControl : UserControl
    {
        public Database.Object Object { get; set; }
        public bool ListVisible { get; set; }
        public FileControl()
        {
            InitializeComponent();
            DataContextChanged += FileControl_DataContextChanged;
        }


        private void FileControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Object = (Database.Object)DataContext;
        }

        private void MainButton_Click(object sender, RoutedEventArgs e)
        {
            if (Object.Object1.Count == 0)
                return;

            if (ChildList.ItemsSource == null)
            {
                ChildList.Visibility = Visibility.Visible;
                ChildList.ItemsSource = Object.Object1;
                CanBrowseText.Text = @"/\";
            }
            else
            {
                CanBrowseText.Text = @"\/";
                ChildList.ItemsSource = null;
                ChildList.Visibility = Visibility.Collapsed;
            }
        }
    }
}
