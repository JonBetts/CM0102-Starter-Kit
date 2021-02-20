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

        private void LaunchGame(string playGameExe, bool usesStubProcess, bool usesCustomLoader, bool renameExes) {
            ShowLoader();
            if (renameExes) {
                RenameExes();
            }
            ProcessStartInfo playPsi = new ProcessStartInfo {
                WorkingDirectory = GameFolder,
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
            if (renameExes) {
                RenameExes();
            }
            HideLoader();
        }

        private void StandardCm_Click(object sender, EventArgs e) {
            if (!NinetyThreeDataLoaded()) {
                LaunchGame(CmLoader, true, false, false);
            } else {
                DisplayMessage("Please load a compatible database first!");
            }
        }

        private void NickPatcherCm_Click(object sender, EventArgs e) {
            if (!NinetyThreeDataLoaded()) {
                LaunchGame(CmLoader, true, true, false);
            } else {
                DisplayMessage("Please load a compatible database first!");
            }
        }

        private void Cm93_Click(object sender, EventArgs e) {
            if (NinetyThreeDataLoaded()) {
                LaunchGame(CmLoader, true, false, true);
            } else {
                DisplayMessage("Please load the 1993/94 database first!");
            }
        }

        private void PlayMenu_FormClosed(object sender, FormClosedEventArgs e) {
            Application.Exit();
        }
    }
}
