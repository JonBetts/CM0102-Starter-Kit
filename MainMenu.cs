using CM0102_Starter_Kit.Properties;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using static CM0102_Starter_Kit.Helper;

namespace CM0102_Starter_Kit {
    partial class MainMenu
    #if DEBUG
        : MiddleForm
    #else
        : HidableForm
    #endif
    {
        internal readonly NickPatcherMenu nickPatcherMenu;
        internal readonly VersionMenu versionMenu;
        internal readonly PlayMenu playMenu;
        internal readonly AndroidMenu androidMenu;

        public MainMenu() {
            this.nickPatcherMenu = new NickPatcherMenu(this);
            this.versionMenu = new VersionMenu(this);
            this.playMenu = new PlayMenu(this);
            this.androidMenu = new AndroidMenu(this);
            InitialiseSharedControls("Setup Game", 373, false);
            InitializeComponent();
        }
 
        protected override List<Button> GetButtons() {
            return new List<Button> {
                this.switch_update,
                this.install_var,
                this.nick_patcher,
                this.editor,
                this.play_game,
                this.android_menu,
                this.cm_scout,
                this.player_finder,
                this.backup_saves,
                this.restore_saves
            };
        }

        protected override void RefreshForm() {
            if (File.Exists(ExistingCommentaryBackup)) {
                this.install_var.Text = "Uninstall VAR Commentary";
            } else {
                this.install_var.Text = "Install VAR Commentary";
            }
        }

        private void RefreshExeFile(ProgressWindow progressWindow) {
            progressWindow.SetProgressPercentage(40);
            File.WriteAllBytes(Path.Combine(GameFolder, Cm0102ExeFilename), Resources.cm0102_exe);
            progressWindow.SetProgressPercentage(80);
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

        private void SwitchUpdate_Click(object sender, EventArgs e) {
            ShowNewScreen(versionMenu);
        }

        private void InstallVar_Click(object sender, EventArgs e) {
            string result = SwitchUpdateMessage;
            if (DataFolderExists()) {
                if (File.Exists(ExistingCommentaryBackup)) {
                    File.Delete(ExistingCommentary);
                    File.Move(ExistingCommentaryBackup, ExistingCommentary);
                    result = "VAR Commentary successfully uninstalled!";
                } else {
                    File.Move(ExistingCommentary, ExistingCommentaryBackup);
                    File.WriteAllBytes(ExistingCommentary, Resources.events_eng);
                    result = "VAR Commentary successfully installed! Please note this only applies when playing the game in English!";
                }
                RefreshForm();
            }
            DisplayMessage(result);
        }

        private void NickPatcher_Click(object sender, EventArgs e) {
            if (DataFolderExists()) {
                ShowNewScreen(nickPatcherMenu);
            } else {
                DisplayMessage(SwitchUpdateMessage);
            }
        }

        private void Editor_Click(object sender, EventArgs e) {
            if (DataFolderExists()) {
                RunExternalProcess(DataFolder, Path.Combine(GameFolder, "Editor", "cm0102ed.exe"));
            } else {
                DisplayMessage(SwitchUpdateMessage);
            }
        }

        private void PlayGame_Click(object sender, EventArgs e) {
            if (DataFolderExists()) {
                ShowNewScreen(playMenu);
            } else {
                DisplayMessage(SwitchUpdateMessage);
            }
        }

        private void BackupSaves_Click(object sender, EventArgs e) {
            string result = "No save games found!";
            FileInfo[] saveGames = new DirectoryInfo(GameFolder).GetFiles("*.sav");

            if (saveGames.Length > 0) {
                ProgressWindow progressWindow = CreateNewProgressWindow("Backing up save games", 85);
                int progressPerc = 0;
                progressWindow.SetProgressPercentage(progressPerc);

                if (!Directory.Exists(BackupSavesFolder)) {
                    Directory.CreateDirectory(BackupSavesFolder);
                }
                foreach (FileInfo save in saveGames) {
                    File.Copy(save.FullName, Path.Combine(BackupSavesFolder, save.Name), true);
                    progressPerc += 5;
                    progressWindow.SetProgressPercentage(Math.Min(progressPerc, 100));
                }
                result = saveGames.Length + @" save game(s) successfully backed up to your desktop!";
                progressWindow.SetProgressPercentage(100);
                progressWindow.Close();
            }
            DisplayMessage(result);
        }

        private void RestoreSaves_Click(object sender, EventArgs e) {
            if (Directory.Exists(BackupSavesFolder)) {
                this.restoreSaveDialog.InitialDirectory = BackupSavesFolder;
                this.restoreSaveDialog.ShowDialog();
            } else {
                DisplayMessage("No backed up save games found!");
            }
        }

        private void RestoreSavesDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e) {
            string destFile = Path.Combine(GameFolder, Path.GetFileName(this.restoreSaveDialog.FileName));
            File.Copy(this.restoreSaveDialog.FileName, destFile, true);
            DisplayMessage("Save game successfully restored!");
        }

        private void CmScout_Click(object sender, EventArgs e) {
            RunExternalProcess(GameFolder, Path.Combine(GameFolder, "cmscout.exe"));
        }

        private void PlayerFinder_Click(object sender, EventArgs e) {
            RunExternalProcess(GameFolder, Path.Combine(GameFolder, "gpf2.exe"));
        }

        private void AndroidMenu_Click(object sender, EventArgs e) {
            if (DataFolderExists()) {
                ShowNewScreen(androidMenu);
            } else {
                DisplayMessage(SwitchUpdateMessage);
            }
        }

        private void MainMenu_Load(object sender, EventArgs e) {
            Process[] mainProcesses = Process.GetProcessesByName("CM0102StarterKit");
            if (mainProcesses.Length > 1) { 
                DisplayMessage("The Starter Kit is already running! Exiting...");
                Application.Exit();
            }
            ProgressWindow progressWindow = CreateNewProgressWindow("Loading Starter Kit", 100);

            if (!Directory.Exists(GameFolder)) {
                string gameZipFile = GameFolder + ".zip";
                File.WriteAllBytes(gameZipFile, Resources.Game);
                progressWindow.SetProgressPercentage(30);
                new FastZip().ExtractZip(gameZipFile, GameFolder, null);
                progressWindow.SetProgressPercentage(60);
                File.Delete(gameZipFile);

                Thread.Sleep(2000);
                progressWindow.SetProgressPercentage(90);
            }
            RefreshExeFile(progressWindow);
            progressWindow.SetProgressPercentage(100);
            RefreshForm();
            progressWindow.Close();
        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e) {
            Application.Exit();
        }
    }
}
