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
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            /* BOGGIES TEST CODE
            Year current = new Year();
            current.setYear(2018);

            TestClass test = new TestClass();
            test.loadCalender(current);

            string hello = "dick eater";
            test.addEvent(9, 4, 12.5, 14.5, hello, current);
            */
        }
    }
}
