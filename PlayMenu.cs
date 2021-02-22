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
                this.nick_patcher_cm,
                this.cm_93
            };
        }

        private void LaunchGame(bool usesCustomLoader, bool renameExes) {
            ShowLoader();
            if (renameExes) {
                RenameExes();
            }
            ProcessStartInfo playPsi = new ProcessStartInfo {
                WorkingDirectory = GameFolder,
                FileName = CmLoader,
                UseShellExecute = false,
                Arguments = usesCustomLoader ? CmLoaderCustomConfig : CmLoaderConfig
            };
            Process playProcess = Process.Start(playPsi);
            playProcess.WaitForExit();
            playProcess.Close();

            // The loader is a stub process for the game, so let's wait for the game to be closed
            Process[] mainPlayProcesses = Process.GetProcessesByName("cm0102");
            foreach (Process process in mainPlayProcesses) {
                process.WaitForExit();
                process.Close();
            }
            if (renameExes) {
                RenameExes();
            }
            HideLoader();
        }

        private void OverridePatcherSettings() {
            string destinationFile = Path.Combine(GameFolder, CmLoaderCustomConfig);
            string[] lines = File.ReadAllLines(destinationFile);

            using (StreamWriter writer = new StreamWriter(destinationFile)) {
                for (int currentLine = 1; currentLine <= lines.Length; ++currentLine) {
                    if (currentLine == 1) {
                        writer.WriteLine("Year = 2001");
                    } else {
                        writer.WriteLine(lines[currentLine - 1]);
                    }
                }
            }
        }

        private void Cm0102_Click(object sender, EventArgs e) {
            if (!NinetyThreeDataLoaded()) {
                LaunchGame(false, false);
            } else {
                DisplayMessage("Please load a compatible database first!");
            }
        }

        private void Cm0102Patched_Click(object sender, EventArgs e) {
            if (!NinetyThreeDataLoaded()) {
                LaunchGame(true, false);
            } else {
                DisplayMessage("Please load a compatible database first!");
            }
        }

        private void Cm93_Click(object sender, EventArgs e) {
            if (NinetyThreeDataLoaded()) {
                LaunchGame(false, true);
            } else {
                DisplayMessage("Please load the 1993/94 database first!");
            }
        }

        private void Cm93Patched_Click(object sender, EventArgs e) {
            if (NinetyThreeDataLoaded()) {
                OverridePatcherSettings();
                LaunchGame(true, true);
            } else {
                DisplayMessage("Please load the 1993/94 database first!");
            }
        }

        private void PlayMenu_FormClosed(object sender, FormClosedEventArgs e) {
            Application.Exit();
        }
    }
}
