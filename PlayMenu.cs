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

        protected override List<Button> GetButtonsToToggle() {
            return new List<Button> {
                this.cm0102_standard,
                this.cm0102_nick_patcher,
                this.cm93_standard,
                this.cm93_nick_patcher
            };
        }

        private void LaunchGame(Button button) {
            bool ninetyThreeClicked = button.Equals(this.cm93_standard) || button.Equals(this.cm93_nick_patcher);
            bool canProceed = (ninetyThreeClicked && NinetyThreeDataLoaded()) || (!ninetyThreeClicked && !NinetyThreeDataLoaded());

            if (canProceed) {
                ShowLoader();
                bool useDefaultConfig = button.Equals(this.cm93_standard) || button.Equals(this.cm0102_standard);

                if (ninetyThreeClicked) {
                    RenameExes();
                }
                ProcessStartInfo playPsi = new ProcessStartInfo {
                    WorkingDirectory = GameFolder,
                    FileName = CmLoader,
                    UseShellExecute = false,
                    Arguments = useDefaultConfig ? CmLoaderConfig : CmLoaderCustomConfig
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
                if (ninetyThreeClicked) {
                    RenameExes();
                }
                HideLoader();
            } else {
                DisplayMessage("Please load a compatible database first!");
            }
        }

        private void PlayButton_Click(object sender, EventArgs e) {
            LaunchGame((Button) sender);
        }

        private void PlayMenu_FormClosed(object sender, FormClosedEventArgs e) {
            Application.Exit();
        }
    }
}
