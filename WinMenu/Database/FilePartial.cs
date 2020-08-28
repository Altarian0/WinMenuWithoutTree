using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WinMenu.Database
{
    partial class Object : INotifyPropertyChanged
    {
        public bool ChildIsNull
        {
            get
            {
                return (Object1.Count == 0);
            }
        }
        public BitmapImage IconSource
        {
            get
            {
                if (TypeId == 1)
                    if (Icon == null || Icon == "" || new FileInfo(Icon).Extension != ".png")
                        return null;

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                if (TypeId == 1)
                    bitmap.UriSource = new Uri(@"..\..\icons\"+Icon, UriKind.RelativeOrAbsolute);
                if (TypeId == 2)
                    bitmap.UriSource = new Uri(@"..\..\1200px-OneDrive_Folder_Icon.svg.png", UriKind.RelativeOrAbsolute);
                bitmap.EndInit();

                return bitmap;

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
