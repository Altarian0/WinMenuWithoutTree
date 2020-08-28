using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using WinMenu.Database;
using WinMenu.Helper;

namespace WinMenu.Forms
{
    /// <summary>
    /// Interaction logic for AddForm.xaml
    /// </summary>
    public partial class AddForm : Window
    {
        private string iconPath;
        private string iconsFolderPath = @"..\..\icons\";
        public AddForm()
        {
            InitializeComponent();
            ParentList.ItemsSource = DBHelper.GetContext().Object.Where(n => n.TypeId == 2).ToList();
        }

        /// <summary>
        /// Add new Folder or File
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (FileRB.IsChecked == false && FolderRB.IsChecked == false)
            {
                MessageBox.Show("Select type of Object");
                return;
            }

            decimal? size = null;
            int? parentId = null;
            if (SizeText.Text != "")
                size = decimal.Parse(SizeText.Text);

            if (ParentList.SelectedItem != null)
                parentId = ((Database.Object)ParentList.SelectedItem).Id;

            Database.Object object1 = new Database.Object
            {
                Title = NameText.Text,
                Icon = iconPath,
                ParentId = parentId,
                Size = FileRB.IsChecked == true ? size : null,
                TypeId = FileRB.IsChecked == true ? 1 : 2
            };

            DBHelper.GetContext().Object.Add(object1);

            if(object1.ParentId == null)
                ObjectListHelper.ObjectList.Add(object1);

            DBHelper.GetContext().SaveChanges();
            this.Close();
        }

        /// <summary>
        /// Input in Textbox only number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SizeText_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = ".0123456789".IndexOf(e.Text) < 0;
        }

        /// <summary>
        /// Get Icon from Explorer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Png files (*.png)|*.png";
            openFileDialog.ShowDialog();

            iconPath = openFileDialog.SafeFileName;

            try
            {
                File.Copy(openFileDialog.FileName, iconPath);
            }
            catch
            {

            }

            IconImage.Source = BitmapHelper.GetBitmapFromPath(openFileDialog.FileName);
        }

        private void FolderRB_Checked(object sender, RoutedEventArgs e)
        {
            BrowseButton.IsEnabled = false;
            SizeText.IsEnabled = false;
            try
            {
                File.Delete(iconPath);
                iconPath = "";
                IconImage.Source = null;
            }
            catch
            {

            }
        }

        private void FileRB_Checked(object sender, RoutedEventArgs e)
        {
            BrowseButton.IsEnabled = true;
            SizeText.IsEnabled = true;
        }
    }
}
