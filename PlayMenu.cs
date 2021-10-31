using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
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
                this.cm0102_nick_patcher
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
        }

        protected override void RefreshForm() {
            RenameButtons();
        }

        private void CopyExe(bool setup) {
            String exeFile = CurrentDatabase().ExeFile;
            if (!exeFile.Equals(Cm0102Exe)) {
                if (setup) {
                    File.Copy(Path.Combine(GameFolder, exeFile), Path.Combine(GameFolder, Cm0102Exe), true);
                } else {
                    File.Copy(Path.Combine(GameFolder, Cm0102BackupExe), Path.Combine(GameFolder, Cm0102Exe), true);
                }
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

            CopyExe(true);
            bool useDefaultConfig = button.Equals(this.cm0102_standard);

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
            CopyExe(false);
            HideLoader();
            RefreshForm();
        }

        private void PlayMenu_FormClosed(object sender, FormClosedEventArgs e) {
            Application.Exit();
        }
    }
}
