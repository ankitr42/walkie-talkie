using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace WalkieTalkie
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Mutex mutex = null;
            try
            {
                Mutex.OpenExisting("WalkieTalkieSingleInstance");
                MessageBox.Show("WalkieTalkie is already running.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            catch { try { mutex = new Mutex(true, "WalkieTalkieSingleInstance"); } catch { } }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new wndMain());
            GC.KeepAlive(mutex);
        }
    }
}
