using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace CM0102_Starter_Kit {
    public partial class MainMenu : Form {
        private readonly NickPatcherMenu nickPatcherMenu;
        private readonly VersionMenu versionMenu;
        private readonly PlayMenu playMenu;
        private string isoFile;
        private enum MethodName { InstallVirtualDrive, MountCd, InstallGame, InstallPatch, RunEditor, UnmountAllDrives }

        public MainMenu() {
            this.nickPatcherMenu = new NickPatcherMenu(this);
            this.versionMenu = new VersionMenu(this);
            this.playMenu = new PlayMenu(this);
            InitializeComponent();
        }
 
        private List<Control> GetButtonsToToggle() {
            return new List<Control> {
                this.mount_cd,
                this.install_game,
                this.install_patch,
                this.install_var,
                this.nick_patcher,
                this.editor,
                this.switch_update,
                this.play_game,
                this.visit_website,
                this.backup_saves,
                this.exit
            };
        }

        private void ShowLoader() {
            Helper.ShowLoader(this, this.loader, GetButtonsToToggle());
        }

        private void HideLoader() {
            Helper.HideLoader(this, this.loader, GetButtonsToToggle());
        }

        private string InstallVirtualDrive() {
            /*string certificateFile = Helper.EXTERNAL_FOLDER + @"\win_cd_emu.cer";
            ProcessStartInfo certUtilPsi = new ProcessStartInfo {
                FileName = "certutil",
                UseShellExecute = false,
                Arguments = "-addstore TrustedPublisher " + certificateFile,
                WindowStyle = ProcessWindowStyle.Minimized
            };
            Process certUtilProcess = Process.Start(certUtilPsi);
            certUtilProcess.WaitForExit();*/

            string installFile = Path.GetTempFileName();
            File.WriteAllBytes(installFile, Properties.Resources.win_cd_emu_4_1);
            ProcessStartInfo virtualDrivePsi = new ProcessStartInfo {
                FileName = installFile,
                UseShellExecute = false,
                Arguments = "/UNATTENDED",
                WindowStyle = ProcessWindowStyle.Minimized
            };
            Process virtualDriveProcess = Process.Start(virtualDrivePsi);
            virtualDriveProcess.WaitForExit();
            virtualDriveProcess.Close();
            File.Delete(installFile);
            return "";
        }

        private string MountCd() {
            string isoFileTemp = Path.GetTempFileName();
            File.WriteAllBytes(isoFileTemp, Properties.Resources.cm0102);
            isoFile = Path.ChangeExtension(isoFileTemp, ".iso");
            File.Move(isoFileTemp, isoFile);

            string filename = Helper.IsWindowsEightOrHigher() ? "powershell.exe" : Helper.VirtualDriveExe;
            string arguments = Helper.IsWindowsEightOrHigher() ? "  -WindowStyle Hidden Mount-DiskImage -ImagePath '" + isoFile + "'"
                                                               : " " + isoFile + " /wait";
            ProcessStartInfo mountPsi = new ProcessStartInfo {
                FileName = filename,
                UseShellExecute = false,
                Arguments = arguments,
                WindowStyle = ProcessWindowStyle.Minimized
            };
            Process mountProcess = Process.Start(mountPsi);
            mountProcess.WaitForExit();

            string result = "CD successfully inserted!";
            if (mountProcess.ExitCode != 0) {
                result = "Something went wrong during CD insertion!";
            }
            mountProcess.Close();
            return result;
        }

        private string InstallGame() {
            ProcessStartInfo installPsi = new ProcessStartInfo {
                FileName = Path.Combine(GetDriveLetter(), "Setup.exe"),
                UseShellExecute = false
            };
            Process stubInstallProcess = Process.Start(installPsi);
            stubInstallProcess.WaitForExit();
            stubInstallProcess.Close();

            Process[] mainInstallProcesses = Process.GetProcessesByName("_ISDEL");
            foreach (Process process in mainInstallProcesses) {
                process.WaitForExit();
                process.Close();
            }

            string result = "CM01/02 successfully installed!";
            if (Directory.Exists(Helper.GameFolder)) {
                string loaderExeFile = Path.GetTempFileName();
                File.WriteAllBytes(loaderExeFile, Properties.Resources.cm0102_loader);
                File.Copy(loaderExeFile, Helper.CmLoaderExeFile);
                File.Delete(loaderExeFile);

                string loaderIniFile = Path.GetTempFileName();
                File.WriteAllText(loaderIniFile, Properties.Resources.cm0102_loader_config);
                File.Copy(loaderIniFile, Helper.CmLoaderConfigFile);
                File.Delete(loaderIniFile);

                Helper.RemoveReadOnlyAttribute(new DirectoryInfo(Helper.GameFolder));

                InstallPatch();
            } else {
                result = "Something went wrong during installation!";
            }
            return result;
        }

        private string InstallPatch() {
            string patchFileTmp = Path.GetTempFileName();
            File.WriteAllBytes(patchFileTmp, Properties.Resources.patch_3_9_68);
            string patchFileExe = Path.ChangeExtension(patchFileTmp, ".exe");
            File.Move(patchFileTmp, patchFileExe);

            ProcessStartInfo patchPsi = new ProcessStartInfo {
                FileName = patchFileExe,
                UseShellExecute = false
            };
            Process patchProcess = Process.Start(patchPsi);
            patchProcess.WaitForExit();

            string result = "Official 3.9.68 patch successfully installed!";
            if (patchProcess.ExitCode == 0) {
                Helper.RemoveReadOnlyAttribute(new DirectoryInfo(Helper.GameFolder));
            } else {
                result = "Something went wrong during installation!";
            }
            patchProcess.Close();
            File.Delete(patchFileExe);
            return result;
        }

        private string RunEditor() {
            string editorExe = Path.Combine(Helper.GameEditorFolder, "cm0102ed.exe");
            ProcessStartInfo editorPsi = new ProcessStartInfo {
                FileName = editorExe,
                UseShellExecute = false
            };
            Process editorProcess = Process.Start(editorPsi);
            editorProcess.WaitForExit();
            editorProcess.Close();
            return "";
        }

        private string UnmountAllDrives() {
            string filename = Helper.IsWindowsEightOrHigher() ? "powershell.exe" : Helper.VirtualDriveExe;
            string arguments = Helper.IsWindowsEightOrHigher() ? " -WindowStyle Hidden Dismount-DiskImage -ImagePath '" + isoFile + "'"
                                                               : " /unmountall";
            ProcessStartInfo unmountPsi = new ProcessStartInfo {
                FileName = filename,
                UseShellExecute = false,
                Arguments = arguments,
                WindowStyle = ProcessWindowStyle.Hidden
            };
            Process unmountProcess = Process.Start(unmountPsi);
            unmountProcess.WaitForExit();

            string result = "";
            if (unmountProcess.ExitCode == 0) {
                File.Delete(isoFile);
            } else {
                result = "Something went wrong when ejecting the CD!";
            }
            unmountProcess.Close();
            return result;
        }

        private string GetDriveLetter() {
            for (char c = 'A'; c <= 'Z'; c++) {
                string driveLetter = c.ToString() + ":";
                string path = Path.Combine(driveLetter, Helper.GameExe);
                if (File.Exists(path)) {
                    return driveLetter;
                }
            }
            return null;
        }

        private bool IsCdMounted() {
            return GetDriveLetter() != null;
        }

        public void RunExitTasks() {
            if (isoFile != null) {
                RunProcess(MethodName.UnmountAllDrives);
            }
        }

        private void RunProcess(MethodName methodName) {
            ShowLoader();
            string result = "";

            switch (methodName) {
                case MethodName.InstallVirtualDrive:
                    result = InstallVirtualDrive();
                    break;
                case MethodName.MountCd:
                    result = MountCd();
                    break;
                case MethodName.InstallGame:
                    result = InstallGame();
                    break;
                case MethodName.InstallPatch:
                    result = InstallPatch();
                    break;
                case MethodName.RunEditor:
                    result = RunEditor();
                    break;
                case MethodName.UnmountAllDrives:
                    result = UnmountAllDrives();
                    break;
                default:
                    break;
            }
            if (!String.IsNullOrEmpty(result)) {
                Helper.DisplayMessage(this, result);
            }
            HideLoader();
        }

        private void MountCd_Click(object sender, EventArgs e) {
            if (!Helper.IsWindowsEightOrHigher() && !Directory.Exists(Helper.VirtualDriveFolder)) {
                RunProcess(MethodName.InstallVirtualDrive);
            }
            if (!IsCdMounted()) {
                RunProcess(MethodName.MountCd);
            } else {
                Helper.DisplayMessage(this, "CD is already inserted!");
            }
        }

        private void InstallGame_Click(object sender, EventArgs e) {
            if (Directory.Exists(Helper.GameFolder)) {
                Helper.DisplayMessage(this, "CM0102 is already installed!");
            } else if (!IsCdMounted()) {
                Helper.DisplayMessage(this, "Please insert the CM01/02 CD first!");
            } else {
                RunProcess(MethodName.InstallGame);
            }
        }

        private void InstallPatch_Click(object sender, EventArgs e) {
            if (!Directory.Exists(Helper.GameFolder)) {
                Helper.DisplayMessage(this, "Please install CM01/02 first!");
            } else if (Helper.IsPatchInstalled()) {
                Helper.DisplayMessage(this, "Patch is already installed!");
            } else {
                RunProcess(MethodName.InstallPatch);
            }
        }

        private void InstallVar_Click(object sender, EventArgs e) {
            if (Directory.Exists(Helper.GameFolder)) {
                ShowLoader();
                string varFile = Path.GetTempFileName();
                File.WriteAllBytes(varFile, Properties.Resources.events_eng);

                File.Copy(Helper.ExistingCommentaryFile, Helper.ExistingCommentaryFile + ".bk", true);
                File.Copy(varFile, Helper.ExistingCommentaryFile, true);
                File.Delete(varFile);

                Helper.DisplayMessage(this, "VAR Commentary File successfully installed! Please note this only applies when playing the game in English!");
                HideLoader();
            } else {
                Helper.DisplayMessage(this, "Please install CM01/02 first!");
            }
        }

        private void NickPatcher_Click(object sender, EventArgs e) {
            if (Directory.Exists(Helper.GameFolder)) {
                Helper.ShowNewScreen(this, nickPatcherMenu);
            } else {
                Helper.DisplayMessage(this, "Please install CM01/02 first!");
            }
        }

        private void Editor_Click(object sender, EventArgs e) {
            if (Directory.Exists(Helper.GameFolder)) {
                RunProcess(MethodName.RunEditor);
            } else {
                Helper.DisplayMessage(this, "Please install CM01/02 first!");
            }
        }

        private void SwitchUpdate_Click(object sender, EventArgs e) {
            if (Directory.Exists(Helper.GameFolder)) {
                Helper.ShowNewScreen(this, versionMenu);
            } else {
                Helper.DisplayMessage(this, "Please install CM01/02 first!");
            }
        }

        private void PlayGame_Click(object sender, EventArgs e) {
            if (!Directory.Exists(Helper.GameFolder)) {
                Helper.DisplayMessage(this, "Please install CM01/02 first!");
            } else if (!IsCdMounted()) {
                Helper.DisplayMessage(this, "Please insert the CM01/02 CD first!");
            } else {
                Helper.ShowNewScreen(this, playMenu);
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
            if (Directory.Exists(Helper.GameFolder)) {
                FileInfo[] saveGames = new DirectoryInfo(Helper.GameFolder).GetFiles("*.sav");
                if (saveGames.Length > 0) {
                    ShowLoader();
                    if (!Directory.Exists(Helper.BackupSavesFolder)) {
                        Directory.CreateDirectory(Helper.BackupSavesFolder);
                    }
                    foreach (FileInfo save in saveGames) {
                        File.Copy(save.FullName, Path.Combine(Helper.BackupSavesFolder, save.Name), true);
                        File.Copy(save.FullName, Path.Combine(Helper.BackupSavesFolder, save.Name + ".bk"), true);
                    }
                    Helper.DisplayMessage(this, saveGames.Length + @" save game(s) successfully backed up (to C:\CM0102 Backups)!");
                    HideLoader();
                } else {
                    Helper.DisplayMessage(this, "No save games found!");
                }
            } else {
                Helper.DisplayMessage(this, "Please install CM01/02 first!");
            }
        }

        private void Exit_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void Loader_Paint(object sender, PaintEventArgs e) {
            Helper.RenderLoader(this, e);
        }

        private void MainMenu_Load(object sender, EventArgs e) {

        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e) {
            RunExitTasks();
        }
    }
}
