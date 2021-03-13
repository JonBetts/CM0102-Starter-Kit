using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using static CM0102_Starter_Kit.Helper;

namespace CM0102_Starter_Kit {
    partial class PlayMenu : HidableForm {
        public PlayMenu(MainMenu mainMenu) {
            this.mainMenu = mainMenu;
            this.SuspendLayout();
            InitialiseSharedControls("Choose Which Version To Play", 259, true);
            InitializeComponent();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        protected override List<Button> GetButtons() {
            return new List<Button> {
                this.cm0102_standard,
                this.cm0102_nick_patcher,
                this.cm89_standard,
                this.cm89_nick_patcher,
                this.cm93_standard,
                this.cm93_nick_patcher,
            };
        }

        private void DisableButtons(Database database) {
            foreach (Button button in GetButtons()) {
                button.Enabled = database.ButtonNames.Contains(button.Name);
            }
        }

        protected override void RefreshForm() {
            // This will need changing as soon as we add any other databases
            Database database = Cm93DataLoaded() ? Cm93Database : (Cm89DataLoaded() ? Cm89Database : OriginalDatabase);
            DisableButtons(database);
        }

        private void RenameExes(Button button) {
            bool Cm93Clicked = button.Equals(this.cm93_standard) || button.Equals(this.cm93_nick_patcher);
            bool Cm89Clicked = button.Equals(this.cm89_standard) || button.Equals(this.cm89_nick_patcher);

            if (Cm93Clicked || Cm89Clicked) {
                string exeToUse = Cm93Clicked ? Cm93 : Cm89;
                if (File.Exists(Cm0102Backup)) {
                    File.Move(Cm0102, exeToUse);
                    File.Move(Cm0102Backup, Cm0102);
                } else {
                    File.Move(Cm0102, Cm0102Backup);
                    File.Move(exeToUse, Cm0102);
                }
            }
        }

        private void PlayButton_Click(object sender, EventArgs e) {
            Button button = (Button) sender;
            ShowLoader();
            bool useDefaultConfig = button.Equals(this.cm0102_standard) || button.Equals(this.cm93_standard) || button.Equals(this.cm89_standard);
            RenameExes(button);

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
            RenameExes(button);
            HideLoader();
            RefreshForm();
        }

        private void PlayMenu_FormClosed(object sender, FormClosedEventArgs e) {
            Application.Exit();
        }
    }
}
