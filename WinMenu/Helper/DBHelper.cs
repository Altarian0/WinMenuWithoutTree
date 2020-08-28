using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinMenu.Database;

namespace WinMenu.Helper
{
    public class DBHelper
    {
        private static WinMenu2Entities Context = new WinMenu2Entities();
        public static WinMenu2Entities GetContext()
        {
            return Context;
        }
    }
}
