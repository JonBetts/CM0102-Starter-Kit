using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace CM0102_Starter_Kit {
    partial class PlayMenu : HidableForm {
        public PlayMenu(MainMenu mainMenu) {
            this.mainMenu = mainMenu;
            this.SuspendLayout();
            InitialiseSharedControls("Choose Which Update To Play", 259, true);
            InitializeComponent();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        protected override List<Control> GetButtonsToToggle() {
            return new List<Control> {
                this.standard_cm,
                this.nick_patcher_cm
            };
        }

        private void LaunchGame(string playGameExe, Boolean usesStubProcess, Boolean usesCustomLoader) {
            ShowLoader();
            ProcessStartInfo playPsi = new ProcessStartInfo {
                FileName = playGameExe,
                UseShellExecute = false,
                Arguments = usesCustomLoader ? CmLoaderCustomConfig : CmLoaderConfig
            };
            Process playProcess = Process.Start(playPsi);
            playProcess.WaitForExit();
            playProcess.Close();

            if (usesStubProcess) {
                Process[] mainPlayProcesses = Process.GetProcessesByName("cm0102");
                foreach (Process process in mainPlayProcesses) {
                    process.WaitForExit();
                    process.Close();
                }
            }
            HideLoader();
        }

        private void StandardCm_Click(object sender, EventArgs e) {
            LaunchGame(CmLoader, true, false);
        }

        private void NickPatcherCm_Click(object sender, EventArgs e) {
            LaunchGame(CmLoader, true, true);
        }

        private void Cm93_Click(object sender, EventArgs e) {
            LaunchGame(Path.Combine(GameFolder, "cm93.exe"), false, false);
        }

        private void PlayMenu_FormClosed(object sender, FormClosedEventArgs e) {
            Application.Exit();
        }
    }
}
