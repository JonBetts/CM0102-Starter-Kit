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
        private readonly NickPatcherMenu nickPatcherMenu;
        private readonly VersionMenu versionMenu;
        private readonly PlayMenu playMenu;
        private readonly AndroidMenu androidMenu;

        public MainMenu() {
            InitialiseSharedControls("Setup Game", 373, false);
            InitializeComponent();
            this.nickPatcherMenu = new NickPatcherMenu(this);
            this.versionMenu = new VersionMenu(this);
            this.playMenu = new PlayMenu(this);
            this.androidMenu = new AndroidMenu(this);
        }
 
        protected override List<Button> GetButtons() {
            return new List<Button> {
                this.switch_update,
                this.install_var,
                this.nick_patcher,
                this.editor,
                this.play_game,
                this.backup_saves,
                this.cm_scout,
                this.player_finder,
                this.android_menu
            };
        }

        protected override void RefreshForm() {
            if (File.Exists(ExistingCommentaryBackup)) {
                this.install_var.Text = "Uninstall VAR Commentary";
            } else {
                this.install_var.Text = "Install VAR Commentary";
            }
        }

        private void RefreshExeFiles(ProgressWindow progressWindow) {
            string tempZipFolder = Path.Combine(Directory.GetCurrentDirectory(), "Temp");
            string tempZipFile = tempZipFolder + ".zip";
            File.WriteAllBytes(tempZipFile, Properties.Resources.Exes);
            progressWindow.SetProgressPercentage(40);
            new FastZip().ExtractZip(tempZipFile, tempZipFolder, null);
            progressWindow.SetProgressPercentage(60);

            // We now only need to ensure the main exe file is restored here
            File.Copy(Path.Combine(GameFolder, Cm0102BackupExe), Path.Combine(GameFolder, Cm0102Exe), true);
            progressWindow.SetProgressPercentage(80);
            File.Delete(tempZipFile);
            Directory.Delete(tempZipFolder, true);
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
                    File.WriteAllBytes(ExistingCommentary, Properties.Resources.events_eng);
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
                RunExternalProcess(DataFolder, OfficialEditor);
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
            ProgressWindow progressWindow = new ProgressWindow("Backing up save games", 85);
            progressWindow.Show();
            progressWindow.Refresh();
            int progressPerc = 0;
            progressWindow.SetProgressPercentage(progressPerc);
            string result = "No save games found!";
            FileInfo[] saveGames = new DirectoryInfo(GameFolder).GetFiles("*.sav");

            if (saveGames.Length > 0) {
                if (!Directory.Exists(BackupSavesFolder)) {
                    Directory.CreateDirectory(BackupSavesFolder);
                }
                foreach (FileInfo save in saveGames) {
                    File.Copy(save.FullName, Path.Combine(BackupSavesFolder, save.Name), true);
                    progressPerc = progressPerc + 5;
                    progressWindow.SetProgressPercentage(Math.Min(progressPerc, 100));
                }
                result = saveGames.Length + @" save game(s) successfully backed up (to C:\CM0102 Backups)!";
            }
            progressWindow.SetProgressPercentage(100);
            progressWindow.Close();
            DisplayMessage(result);
        }

        private void CmScout_Click(object sender, EventArgs e) {
            RunExternalProcess(GameFolder, CmScout);
        }

        private void PlayerFinder_Click(object sender, EventArgs e) {
            RunExternalProcess(GameFolder, PlayerFinder);
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

            ProgressWindow progressWindow = new ProgressWindow("Loading Starter Kit", 100);
            progressWindow.Show();
            progressWindow.Refresh();

            if (!GameFolderExists()) {
                Directory.CreateDirectory(GameFolder);
                string gameZipFile = GameFolder + ".zip";
                File.WriteAllBytes(gameZipFile, Properties.Resources.Game);
                progressWindow.SetProgressPercentage(20);
                new FastZip().ExtractZip(gameZipFile, GameFolder, null);
                File.Delete(gameZipFile);
                progressWindow.SetProgressPercentage(40);

                Thread.Sleep(2000);
                string exesZipFile = Path.Combine(GameFolder, "Exes.zip");
                File.WriteAllBytes(exesZipFile, Properties.Resources.Exes);
                progressWindow.SetProgressPercentage(60);
                new FastZip().ExtractZip(exesZipFile, GameFolder, null);
                File.Delete(exesZipFile);
                int nextProgressPerc = 80;
                progressWindow.SetProgressPercentage(nextProgressPerc);

                if (File.Exists(DefaultChangesFile)) {
                   FileInfo[] saveGames = new DirectoryInfo(DefaultGameFolder).GetFiles("*.sav");
                    if (saveGames.Length > 0) {
                        foreach (FileInfo save in saveGames) {
                            File.Copy(save.FullName, Path.Combine(GameFolder, save.Name), true);
                            progressWindow.SetProgressPercentage(Math.Min(++nextProgressPerc, 100));
                        }
                    }
                }
            } else {
                RefreshExeFiles(progressWindow);
            }
            progressWindow.SetProgressPercentage(100);
            RefreshForm();
            progressWindow.Close();
        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e) {
            Application.Exit();
        }
    }
}
