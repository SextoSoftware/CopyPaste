using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cindy_Restaurant.Forms;
using Cindy_Restaurant.Form_View;
using Cindy_Restaurant.Folder_Updates;

namespace Cindy_Restaurant
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmSplash());
        }
    }
}
