using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace CM0102_Starter_Kit {
    public partial class PlayMenu : HidableForm {
        private readonly MainMenu mainMenu;

        public PlayMenu(MainMenu mainMenu) {
            this.mainMenu = mainMenu;
            InitializeComponent();
        }

        protected override List<Control> GetButtonsToToggle() {
            return new List<Control> {
                this.standard_cm,
                this.nick_patcher_cm,
                this.exit
            };
        }

        private void LaunchGame(string playGameExe, Boolean usesStubProcess, Boolean usesCustomLoader) {
            ShowLoader(this.loader);
            ProcessStartInfo playPsi = new ProcessStartInfo {
                FileName = playGameExe,
                UseShellExecute = false,
                Arguments = usesCustomLoader ? Helper.CmLoaderCustomConfig : Helper.CmLoaderConfig
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
            HideLoader(this.loader);
        }

        private void StandardCm_Click(object sender, EventArgs e) {
            LaunchGame(Helper.CmLoader, true, false);
        }

        private void NickPatcherCm_Click(object sender, EventArgs e) {
            LaunchGame(Helper.CmLoader, true, true);
        }

        private void Cm93_Click(object sender, EventArgs e) {
            LaunchGame(Path.Combine(Helper.GameFolder, "cm93.exe"), false, false);
        }

        private void BackButton_Click(object sender, EventArgs e) {
            ShowNewScreen(mainMenu);
        }

        private void LeftArrow_Click(object sender, EventArgs e) {
            ShowNewScreen(mainMenu);
        }

        private void Exit_Click(object sender, EventArgs e) {
            mainMenu.Close();
        }

        private void PlayMenu_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = true;
            Exit_Click(sender, e);
        }
    }
}
