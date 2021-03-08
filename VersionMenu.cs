using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace CM0102_Starter_Kit {
    partial class VersionMenu : HidableForm {
        private enum VersionName { Original, Patched, March, November, Luessenhoff, NinetyThree }

        public VersionMenu(MainMenu mainMenu) {
            this.mainMenu = mainMenu;
            this.SuspendLayout();
            InitialiseSharedControls("Switch Data Update", 325, true);
            InitializeComponent();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        protected override List<Button> GetButtonsToToggle() {
            return new List<Button> {
                this.original_database,
                this.patched_database,
                this.march_database,
                this.november_database,
                this.luessenhoff_database
            };
        }

        private List<string> GetConfigFileLines(string configFile) {
            string[] lines = File.ReadAllLines(Path.Combine(GameFolder, configFile));

            return new List<string> {
                "Year = " + (NinetyThreeDataLoaded() ? "0" : "2001"),
                lines[1],
                lines[2],
                NinetyThreeDataLoaded() ? "ColouredAttributes = false" : lines[3],
                NinetyThreeDataLoaded() ? "DisableUnprotectedContracts = false" : lines[4],
                lines[5],
                lines[6],
                NinetyThreeDataLoaded() ? "RegenFixes = false" : lines[7],
                lines[8],
                lines[9],
                lines[10],
                lines[11],
                lines[12],
                lines[13]
            };
        }

        private void UpdateConfigFiles() {
            List<string> defaultLines = GetConfigFileLines(CmLoaderConfig);
            WriteConfigFile(defaultLines, CmLoaderConfig);
            List<string> customLines = GetConfigFileLines(CmLoaderCustomConfig);
            WriteConfigFile(customLines, CmLoaderCustomConfig);
        }

        private void CopyDataToGame(VersionName version) {
            byte[] resourceFile;
            bool deleteDataFolder = false;

            switch (version) {
                case VersionName.Patched:
                    resourceFile = Properties.Resources.patched_data;
                    deleteDataFolder = true;
                    break;
                case VersionName.March:
                    resourceFile = Properties.Resources.march_data;
                    break;
                case VersionName.November:
                    resourceFile = Properties.Resources.november_data;
                    break;
                case VersionName.Luessenhoff:
                    resourceFile = Properties.Resources.luessenhoff_data;
                    break;
                case VersionName.NinetyThree:
                    resourceFile = Properties.Resources.ninety_three_data;
                    deleteDataFolder = true;
                    break;
                default:
                case VersionName.Original:
                    resourceFile = Properties.Resources.original_data;
                    deleteDataFolder = true;
                    break;
            }
            if (deleteDataFolder && DataFolderExists()) {
                Directory.Delete(DataFolder, true);
            }
            Directory.CreateDirectory(DataFolder);
            string dataZipFile = DataFolder + ".zip";
            File.WriteAllBytes(dataZipFile, resourceFile);
            new FastZip().ExtractZip(dataZipFile, DataFolder, null);
            File.Delete(dataZipFile);

            // Update the loader config files as switching betwen CM93/94 and anything else requires some changes
            UpdateConfigFiles();
        }

        private void SwitchVersion(VersionName versionName) {
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
                    CopyDataToGame(VersionName.NinetyThree);
                    label = "1993/94";
                    break;
                default:
                case VersionName.Original:
                    CopyDataToGame(VersionName.Original);
                    label = "Original (3.9.60)";
                    break;
            }
            DisplayMessage(label + " database successfully loaded!");
        }

        private void OriginalDatabase_Click(object sender, EventArgs e) {
            SwitchVersion(VersionName.Original);
        }

        private void PatchedDatabase_Click(object sender, EventArgs e) {
            SwitchVersion(VersionName.Patched);
        }

        private void MarchDatabase_Click(object sender, EventArgs e) {
            SwitchVersion(VersionName.March);
        }

        private void NovemberDatabase_Click(object sender, EventArgs e) {
            SwitchVersion(VersionName.November);
        }

        private void LuessenhoffDatabase_Click(object sender, EventArgs e) {
            SwitchVersion(VersionName.Luessenhoff);
        }

        private void NinetyThreeDatabase_Click(object sender, EventArgs e) {
            SwitchVersion(VersionName.NinetyThree);
        }

        private void VersionMenu_FormClosed(object sender, FormClosedEventArgs e) {
            Application.Exit();
        }
    }
}
