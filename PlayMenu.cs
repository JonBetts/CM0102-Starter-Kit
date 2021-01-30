using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace CM0102_Starter_Kit {
    public partial class PlayMenu : Form {
        private readonly MainMenu mainMenu;

        public PlayMenu(MainMenu mainMenu) {
            this.mainMenu = mainMenu;
            InitializeComponent();
        }

        private List<Control> GetButtonsToToggle() {
            return new List<Control> {
                this.standard_cm,
                this.nick_patcher_cm,
                this.exit
            };
        }

        private void ShowLoader() {
            Helper.ShowLoader(this, this.loader, GetButtonsToToggle());
        }

        private void HideLoader() {
            Helper.HideLoader(this, this.loader, GetButtonsToToggle());
        }

        private void LaunchGame(string playGameExe, Boolean usesStubProcess) {
            ShowLoader();
            ProcessStartInfo playPsi = new ProcessStartInfo {
                FileName = playGameExe,
                UseShellExecute = false
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
            LaunchGame(Path.Combine(Helper.GameFolder, Helper.GameExe), false);
        }

        private void NickPatcherCm_Click(object sender, EventArgs e) {
            if (!File.Exists(Helper.CmLoaderExeFile) || !File.Exists(Helper.CmLoaderConfigFile)) {
               Helper.CopyNickPatcherFiles();
            }
            if (Helper.IsPatchInstalled()) {
                LaunchGame(Helper.CmLoaderExeFile, true);
            } else {
                Helper.DisplayMessage(this, "The Official 3.9.68 Patch needs to be installed first!");
            }
        }

        private void Cm93_Click(object sender, EventArgs e) {
            LaunchGame(Path.Combine(Helper.GameFolder, "cm93.exe"), false);
        }

        private void BackButton_Click(object sender, EventArgs e) {
            Helper.ShowNewScreen(this, mainMenu);
        }

        private void LeftArrow_Click(object sender, EventArgs e) {
            Helper.ShowNewScreen(this, mainMenu);
        }

        private void Exit_Click(object sender, EventArgs e) {
            mainMenu.Close();
        }

        private void Loader_Paint(object sender, PaintEventArgs e) {
            Helper.RenderLoader(this, e);
        }

        private void PlayMenu_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = true;
            Exit_Click(sender, e);
        }
    }
}
