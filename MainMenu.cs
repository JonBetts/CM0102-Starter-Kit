using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace CM0102_Starter_Kit {
    public partial class MainMenu : HidableForm {
        private readonly NickPatcherMenu nickPatcherMenu;
        private readonly VersionMenu versionMenu;
        private readonly PlayMenu playMenu;
        private enum MethodName { InstallVar, RunEditor, BackupSaves }

        public MainMenu() {
            this.nickPatcherMenu = new NickPatcherMenu(this);
            this.versionMenu = new VersionMenu(this);
            this.playMenu = new PlayMenu(this);
            InitializeComponent();
        }
 
        protected override List<Control> GetButtonsToToggle() {
            return new List<Control> {
                this.install_var,
                this.nick_patcher,
                this.editor,
                this.switch_update,
                this.play_game,
                this.visit_website,
                this.backup_saves,
                this.cm_scout,
                this.exit
            };
        }

        private string InstallVar() {
            string result = "Please use the Switch Data Update menu to load up a database first!";
            if (Helper.DataFolderExists()) {
                ShowLoader(this.loader);
                string varFile = Path.GetTempFileName();
                File.WriteAllBytes(varFile, Properties.Resources.events_eng);
                File.Copy(Helper.ExistingCommentary, Helper.ExistingCommentary + ".bk", true);
                File.Copy(varFile, Helper.ExistingCommentary, true);
                File.Delete(varFile);
                result = "VAR Commentary File successfully installed! Please note this only applies when playing the game in English!";
                HideLoader(this.loader);
            }
            return result;
        }

        private string RunEditor() {
            string result = "Please use the Switch Data Update menu to load up a database first!";
            if (Helper.DataFolderExists()) {
                RunExternalProcess(Helper.OfficialEditor);
                result = "";
            }
            return result;
        }
 
        private string BackupSaves() {
            string result = "No save games found!";
            FileInfo[] saveGames = new DirectoryInfo(Helper.GameFolder).GetFiles("*.sav");
            if (saveGames.Length > 0) {
                ShowLoader(this.loader);
                if (!Directory.Exists(Helper.BackupSavesFolder)) {
                    Directory.CreateDirectory(Helper.BackupSavesFolder);
                }
                foreach (FileInfo save in saveGames) {
                    File.Copy(save.FullName, Path.Combine(Helper.BackupSavesFolder, save.Name), true);
                }
                result = saveGames.Length + @" save game(s) successfully backed up (to C:\CM0102 Backups)!";
                HideLoader(this.loader);
            }
            return result;
        }

        private void RunProcess(MethodName methodName) {
            string result;

            switch (methodName) {
                case MethodName.InstallVar:
                    result = InstallVar();
                    break;
                case MethodName.RunEditor:
                    result = RunEditor();
                    break;
                case MethodName.BackupSaves:
                    result = BackupSaves();
                    break;
                default:
                    throw new NotImplementedException("Method not implemented correctly");
            }
            if (!String.IsNullOrEmpty(result)) {
                DisplayMessage(result);
            }
        }

        private void InstallVar_Click(object sender, EventArgs e) {
            RunProcess(MethodName.InstallVar);
        }

        private void NickPatcher_Click(object sender, EventArgs e) {
            if (Helper.DataFolderExists()) {
                ShowNewScreen(nickPatcherMenu);
            } else {
                DisplayMessage("Please use the Switch Data Update menu to load up a database first!");
            }
        }

        private void Editor_Click(object sender, EventArgs e) {
            RunProcess(MethodName.RunEditor);
        }

        private void SwitchUpdate_Click(object sender, EventArgs e) {
            ShowNewScreen(versionMenu);
        }

        private void PlayGame_Click(object sender, EventArgs e) {
            if (Helper.DataFolderExists()) {
                ShowNewScreen(playMenu);
            } else {
                DisplayMessage("Please use the Switch Data Update menu to load up a database first!");
            }
        }

        private void VisitWebsite_Click(object sender, EventArgs e) {
            var websitePsi = new ProcessStartInfo {
                FileName = "https://www.champman0102.net",
                UseShellExecute = true
            };
            Process.Start(websitePsi);
        }

        private void BackupSaves_Click(object sender, EventArgs e) {
            RunProcess(MethodName.BackupSaves);
        }

        private void CmScout_Click(object sender, EventArgs e) {
            RunExternalProcess(Helper.CmScout);
        }

        private void Exit_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void MainMenu_Load(object sender, EventArgs e) {
            if (!Helper.GameFolderExists()) {
                ShowLoader(this.loader);
                Directory.CreateDirectory(Helper.GameFolder);
                string zipTempFile = Path.GetTempFileName();
                File.WriteAllBytes(zipTempFile, Properties.Resources.Game);
                string zipFile = Path.ChangeExtension(zipTempFile, ".zip");
                File.Move(zipTempFile, zipFile);
                new FastZip().ExtractZip(zipFile, Helper.GameFolder, null);

                if (File.Exists(Helper.DefaultChangesFile)) {
                   FileInfo[] saveGames = new DirectoryInfo(Helper.DefaultGameFolder).GetFiles("*.sav");
                    if (saveGames.Length > 0) {
                        foreach (FileInfo save in saveGames) {
                            File.Copy(save.FullName, Path.Combine(Helper.GameFolder, save.Name), true);
                        }
                    }
                }
                HideLoader(this.loader);
            }
        }
    }
}
