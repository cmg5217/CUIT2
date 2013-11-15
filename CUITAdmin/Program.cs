using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CUITAdmin
{
    static class Program
    {
        public static char userType = 'A';
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
            if(userType != '\0') Application.Run(new frmCUITAdminMain(userType));
            //Application.Run(new TestForm());
        }
    }
}
