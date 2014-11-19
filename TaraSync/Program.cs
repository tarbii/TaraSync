using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThePresenter = TaraSync.Presenter.Presenter;

namespace TaraSync
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

            var f1 = new Form1();
            var pr = new ThePresenter(f1);

            Application.Run(f1);
        }
    }
}
