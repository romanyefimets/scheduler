using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduler
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static AccountManagement help = new AccountManagement();
        public static User user = new User();
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            help.LoadFromFile();

            //Application.Run(new Form1());
            Application.Run(new Login());

            
        }
    }
}
