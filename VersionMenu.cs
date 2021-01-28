using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace CM0102_Starter_Kit {
    public partial class VersionMenu : Form {
        private readonly MainMenu mainMenu;
        private enum VersionName { Original, Patched, March, November, Luessenhoff, NinetyThree }

        public VersionMenu(MainMenu mainMenu) {
            this.mainMenu = mainMenu;
            InitializeComponent();
        }

        private List<Control> GetButtonsToToggle() {
            return new List<Control> {
                this.original_database,
                this.patched_database,
                this.march_database,
                this.november_database,
                this.luessenhoff_database,
                this.exit
            };
        }

        private void ShowLoader() {
            Helper.ShowLoader(this, this.loader, GetButtonsToToggle());
        }

        private void HideLoader() {
            Helper.HideLoader(this, this.loader, GetButtonsToToggle());
        }

        private void CopyDataToGame(VersionName version) {
            DirectoryInfo source;
            byte[] resourceFile;
            bool deleteDataFolder;

            switch (version) {
                case VersionName.Patched:
                    source = new DirectoryInfo(Helper.PatchedDataFolder);
                    resourceFile = Properties.Resources.patched_data;
                    deleteDataFolder = true;
                    break;
                case VersionName.March:
                    source = new DirectoryInfo(Helper.MarchDataFolder);
                    resourceFile = Properties.Resources.march_data;
                    deleteDataFolder = false;
                    break;
                case VersionName.November:
                    source = new DirectoryInfo(Helper.NovemberDataFolder);
                    resourceFile = Properties.Resources.november_data;
                    deleteDataFolder = false;
                    break;
                case VersionName.Luessenhoff:
                    source = new DirectoryInfo(Helper.LuessenhoffDataFolder);
                    resourceFile = Properties.Resources.luessenhoff_data;
                    deleteDataFolder = true;
                    break;
                case VersionName.NinetyThree:
                    source = new DirectoryInfo(Helper.NinetyThreeDataFolder);
                    resourceFile = Properties.Resources.luessenhoff_data; // will be ninety_three_data
                    deleteDataFolder = true;
                    break;
                default:
                case VersionName.Original:
                    source = new DirectoryInfo(Helper.OriginalDataFolder);
                    resourceFile = Properties.Resources.original_data;
                    deleteDataFolder = true;
                    break;
            }
            if (deleteDataFolder) {
                // We are just moving to a backup folder for now, just in case
                if (Directory.Exists(Helper.GameDataFolderBackup)) {
                    Directory.Delete(Helper.GameDataFolderBackup, true);
                }
                Directory.Move(Helper.GameDataFolder, Helper.GameDataFolderBackup);
                Directory.CreateDirectory(Helper.GameDataFolder);
            }
            string zipTempFile = Path.GetTempFileName();
            File.WriteAllBytes(zipTempFile, resourceFile);
            string zipFile = Path.ChangeExtension(zipTempFile, ".zip");
            File.Move(zipTempFile, zipFile);
            new FastZip().ExtractZip(zipFile, Helper.GameFolder, null);

            FileInfo[] files = source.GetFiles();
            foreach (FileInfo file in files) {
                file.IsReadOnly = false;
                File.Copy(file.FullName, Path.Combine(Helper.GameDataFolder, file.Name), true);
            }
            File.Delete(zipFile);
            Directory.Delete(source.FullName, true);
        }

        private void SwitchVersion(VersionName versionName) {
            ShowLoader();
            string label;

            switch (versionName) {
                case VersionName.Patched:
                    CopyDataToGame(VersionName.Patched);
                    label = "Patched (3.9.68)";
                    break;
                case VersionName.March:
                    CopyDataToGame(VersionName.Patched);
                    CopyDataToGame(VersionName.March);
                    label = "March 2020";
                    break;
                case VersionName.November:
                    CopyDataToGame(VersionName.Patched);
                    CopyDataToGame(VersionName.November);
                    label = "November 2020";
                    break;
                case VersionName.Luessenhoff:
                    CopyDataToGame(VersionName.Original);
                    CopyDataToGame(VersionName.Luessenhoff);
                    label = "Luessenhoff";
                    break;
                case VersionName.NinetyThree:
                    CopyDataToGame(VersionName.Patched);
                    CopyDataToGame(VersionName.NinetyThree);
                    label = "1993/94";
                    break;
                default:
                case VersionName.Original:
                    CopyDataToGame(VersionName.Original);
                    label = "Original (3.9.60)";
                    break;
            }
            Helper.DisplayMessage(this, label + " database successfully loaded!");
            HideLoader();
        }

        private void OriginalDatabase_Click(object sender, EventArgs e) {
            SwitchVersion(VersionName.Original);
        }

        private void PatchedDatabase_Click(object sender, EventArgs e) {
            SwitchVersion(VersionName.Patched);
        }

        private void MarchDatabase_Click(object sender, EventArgs e) {
            if (Helper.IsPatchInstalled()) {
                SwitchVersion(VersionName.March);
            } else {
                Helper.DisplayMessage(this, "You need to install the official 3.9.68 patch to use this version!");
            }

        }

        private void NovemberDatabase_Click(object sender, EventArgs e) {
            if (Helper.IsPatchInstalled()) {
                SwitchVersion(VersionName.November);
            } else {
                Helper.DisplayMessage(this, "You need to install the official 3.9.68 patch to use this version!");
            }
        }

        private void LuessenhoffDatabase_Click(object sender, EventArgs e) {
            SwitchVersion(VersionName.Luessenhoff);
        }

        private void NinetyThreeDatabase_Click(object sender, EventArgs e) {
            SwitchVersion(VersionName.NinetyThree);
        }

        private void BackButton_Click(object sender, EventArgs e) {
            Helper.ShowNewScreen(this, mainMenu);
        }

        private void LeftArrow_Click(object sender, EventArgs e) {
            Helper.ShowNewScreen(this, mainMenu);
        }

        private void Exit_Click(object sender, EventArgs e) {
            mainMenu.Close();
        }

        private void Loader_Paint(object sender, PaintEventArgs e) {
            Helper.RenderLoader(this, e);
        }

        private void VersionMenu_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = true;
            Exit_Click(sender, e);
        }
    }
}
