﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            var sync = new Synchronizer(
                new SyncTarget(
                    @"C:\Users\Ronin\Desktop\A",
                    @"C:\Users\Ronin\Desktop\B"));

            sync.Synchronize();
        }
    }
}
