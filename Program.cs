using System;
using System.Windows.Forms;

namespace CM0102_Starter_Kit {
    static class Program {
        internal static MainMenu mainMenu;
        internal static NickPatcherMenu nickPatcherMenu;
        internal static VersionMenu versionMenu;
        internal static PlayMenu playMenu;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            mainMenu = new MainMenu();
            nickPatcherMenu = new NickPatcherMenu();
            versionMenu = new VersionMenu();
            playMenu = new PlayMenu();
            Application.Run(mainMenu);
        }
    }
}
