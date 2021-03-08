﻿using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace CM0102_Starter_Kit {
    partial class MainMenu : HidableForm {
        private readonly NickPatcherMenu nickPatcherMenu;
        private readonly VersionMenu versionMenu;
        private readonly PlayMenu playMenu;

        public MainMenu() {
            this.SuspendLayout();
            InitialiseSharedControls("Setup Game", 373, false);
            InitializeComponent();
            this.ResumeLayout(false);
            this.PerformLayout();
            this.nickPatcherMenu = new NickPatcherMenu(this);
            this.versionMenu = new VersionMenu(this);
            this.playMenu = new PlayMenu(this);
        }
 
        protected override List<Button> GetButtonsToToggle() {
            return new List<Button> {
                this.switch_update,
                this.install_var,
                this.nick_patcher,
                this.editor,
                this.play_game,
                this.backup_saves,
                this.cm_scout,
                this.player_finder
            };
        }

        protected override void RefreshForm() {
            if (File.Exists(ExistingCommentaryBackup)) {
                this.install_var.Text = "Uninstall VAR Commentary";
            } else {
                this.install_var.Text = "Install VAR Commentary";
            }
        }

        private void InstallVar_Click(object sender, EventArgs e) {
            string result = "Please use the Switch Data Update menu to load up a database first!";
            if (DataFolderExists()) {
                if (NinetyThreeDataLoaded()) {
                    result = "Please load a compatible database first!";
                } else {
                    if (File.Exists(ExistingCommentaryBackup)) {
                        File.Delete(ExistingCommentary);
                        File.Move(ExistingCommentaryBackup, ExistingCommentary);
                        result = "VAR Commentary successfully uninstalled!";
                    } else {
                        File.Move(ExistingCommentary, ExistingCommentaryBackup);
                        File.WriteAllBytes(ExistingCommentary, Properties.Resources.events_eng);
                        result = "VAR Commentary successfully installed! Please note this only applies when playing the game in English!";
                    }
                    RefreshForm();
                }
            }
            DisplayMessage(result);
        }

        private void NickPatcher_Click(object sender, EventArgs e) {
            if (DataFolderExists()) {
                ShowNewScreen(nickPatcherMenu);
            } else {
                DisplayMessage("Please use the Switch Data Update menu to load up a database first!");
            }
        }

        private void RunExternalProcess(string workingDirectory, string executableFile) {
            ProcessStartInfo playPsi = new ProcessStartInfo {
                WorkingDirectory = workingDirectory,
                FileName = executableFile,
                UseShellExecute = false
            };
            Process playProcess = Process.Start(playPsi);
            playProcess.Close();
        }

        private void Editor_Click(object sender, EventArgs e) {
            if (DataFolderExists()) {
                RunExternalProcess(DataFolder, OfficialEditor);
            } else {
                DisplayMessage("Please use the Switch Data Update menu to load up a database first!");
            }
        }

        private void SwitchUpdate_Click(object sender, EventArgs e) {
            ShowNewScreen(versionMenu);
        }

        private void PlayGame_Click(object sender, EventArgs e) {
            if (DataFolderExists()) {
                ShowNewScreen(playMenu);
            } else {
                DisplayMessage("Please use the Switch Data Update menu to load up a database first!");
            }
        }

        private void BackupSaves_Click(object sender, EventArgs e) {
            string result = "No save games found!";
            FileInfo[] saveGames = new DirectoryInfo(GameFolder).GetFiles("*.sav");
            if (saveGames.Length > 0) {
                if (!Directory.Exists(BackupSavesFolder)) {
                    Directory.CreateDirectory(BackupSavesFolder);
                }
                foreach (FileInfo save in saveGames) {
                    File.Copy(save.FullName, Path.Combine(BackupSavesFolder, save.Name), true);
                }
                result = saveGames.Length + @" save game(s) successfully backed up (to C:\CM0102 Backups)!";
            }
            DisplayMessage(result);
        }

        private void CmScout_Click(object sender, EventArgs e) {
            RunExternalProcess(GameFolder, CmScout);
        }

        private void PlayerFinder_Click(object sender, EventArgs e) {
            RunExternalProcess(GameFolder, PlayerFinder);
        }

        private void MainMenu_Load(object sender, EventArgs e) {
            if (!GameFolderExists()) {
                string gameZipFile = GameFolder + ".zip";
                File.WriteAllBytes(gameZipFile, Properties.Resources.Game);
                new FastZip().ExtractZip(gameZipFile, GameFolder, null);
                File.Delete(gameZipFile);

                if (File.Exists(DefaultChangesFile)) {
                   FileInfo[] saveGames = new DirectoryInfo(DefaultGameFolder).GetFiles("*.sav");
                    if (saveGames.Length > 0) {
                        foreach (FileInfo save in saveGames) {
                            File.Copy(save.FullName, Path.Combine(GameFolder, save.Name), true);
                        }
                    }
                }
            } else {
                RefreshExeFiles();
            }
            RefreshForm();
        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e) {
            Application.Exit();
        }
    }
}
