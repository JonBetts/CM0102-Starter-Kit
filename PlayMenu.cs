using CM0102_Starter_Kit.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using static CM0102_Starter_Kit.Helper;

namespace CM0102_Starter_Kit {
    partial class PlayMenu
    #if DEBUG
        : MiddleForm
    #else
        : HidableForm
    #endif
    {
        public PlayMenu(MainMenu mainMenu) {
            this.mainMenu = mainMenu;
            InitialiseSharedControls("Choose Which Version To Play", 259, true);
            InitializeComponent();
        }

        protected override List<Button> GetButtons() {
            return new List<Button> {
                this.cm0102_standard,
                this.cm0102_nick_patcher,
                this.cm0102_retro
            };
        }

        private void RenameButtons() {
            Database database = CurrentDatabase();
            string databaseLabel = database.Label;
            // If using custom database, grab the filename that they saved it under
            if (CustomDatabase.Equals(database)) {
                string customDatabaseDetectorFile = Path.Combine(DataFolder, CustomDatabase.Name + ".txt");
                if (File.Exists(customDatabaseDetectorFile)) {
                    string[] lines = File.ReadAllLines(customDatabaseDetectorFile);
                    databaseLabel = lines[0];
                }
            }
            this.cm0102_standard.Text = databaseLabel + " (Standard)";
            this.cm0102_nick_patcher.Text = databaseLabel + " (Nick's Patcher)";
            this.cm0102_retro.Text = databaseLabel + " (Retro)";
        }

        protected override void RefreshForm() {
            RenameButtons();
        }

        private void CopyExe(bool setup, bool usingRetroOption) {
            if (setup) {
                // Right now only CM 89/90 has the retro option, so let's not overcomplicate it.
                if (usingRetroOption) {
                    File.WriteAllBytes(Path.Combine(GameFolder, Cm0102ExeFilename), Resources.cm89_retro_exe);
                } else {
                    File.WriteAllBytes(Path.Combine(GameFolder, Cm0102ExeFilename), CurrentDatabase().ExeFile);
                }
            } else {
                File.WriteAllBytes(Path.Combine(GameFolder, Cm0102ExeFilename), Resources.cm0102_exe);
            }
        }

        private void PlayButton_Click(object sender, EventArgs e) {
            Button button = (Button) sender;
            ShowLoader();

            // Remove any temporary files that weren't removed since the last session
            FileInfo[] tmpFiles = new DirectoryInfo(GameFolder).GetFiles("*.tmp");
            if (tmpFiles.Length > 0) {
                foreach (FileInfo tmpFile in tmpFiles) {
                    File.Delete(tmpFile.FullName);
                }
            }
            FileInfo[] lngFiles = new DirectoryInfo(GameFolder).GetFiles("*.lng");
            if (lngFiles.Length > 0) {
                foreach (FileInfo lngFile in lngFiles) {
                    File.Delete(lngFile.FullName);
                }
            }

            bool usingRetroOption = button.Equals(this.cm0102_retro);
            CopyExe(true, usingRetroOption);
            bool useDefaultConfig = !button.Equals(this.cm0102_nick_patcher);

            ProcessStartInfo playPsi = new ProcessStartInfo {
                WorkingDirectory = GameFolder,
                FileName = Path.Combine(GameFolder, CmLoaderExeFilename),
                UseShellExecute = false,
                Arguments = useDefaultConfig ? CmLoaderConfigFilename : CmLoaderCustomConfigFilename
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
            CopyExe(false, usingRetroOption);
            HideLoader();
            RefreshForm();
        }

        private void PlayMenu_FormClosed(object sender, FormClosedEventArgs e) {
            Application.Exit();
        }

        internal void ShowOrHideRetroButton() {
            this.cm0102_retro.Visible = CurrentDatabase().Equals(Cm89Database);
        }
    }
}
