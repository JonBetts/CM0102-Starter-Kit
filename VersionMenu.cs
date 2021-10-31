using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using static CM0102_Starter_Kit.Helper;

namespace CM0102_Starter_Kit {
    partial class VersionMenu
    #if DEBUG
        : MiddleForm
    #else
        : HidableForm
    #endif
    {

        public VersionMenu(MainMenu mainMenu) {
            this.mainMenu = mainMenu;
            InitialiseSharedControls("Data Updates", 355, true);
            InitializeComponent();
        }

        protected override List<Button> GetButtons() {
            return new List<Button> {
                this.april_database,
                this.original_database,
                this.patched_database,
                this.march_database,
                this.november_database,
                this.luessenhoff_database,
                this.cm89_database,
                this.cm93_database,
                this.cm95_database,
                this.cm3_database,
                this.save_database,
                this.load_database
            };
        }

        private void UpdateConfigFiles(Database database) {
            string defaultConfig = Path.Combine(GameFolder, CmLoaderConfig);
            List<string> defaultLines = GetDefaultConfigFileLines(defaultConfig, database, false);
            WriteToFile(defaultLines, defaultConfig);

            string customConfig = Path.Combine(GameFolder, CmLoaderCustomConfig);
            List<string> customLines = GetDefaultConfigFileLines(customConfig, database, false);
            WriteToFile(customLines, customConfig);
        }

        private void CopyDataToGame(Database database) {
            string tempFolder = Path.Combine(GameFolder, "Temp");
            string dataZipFile = DataFolder + ".zip";
            File.WriteAllBytes(dataZipFile, database.ResourceFile);
            new FastZip().ExtractZip(dataZipFile, tempFolder, null);

            if (DataFolderExists()) {
                // If this has previously been saved as a 'Custom Database', then remove the need to setup a prerequisite database first (i.e. delete the Data folder)
                if (database.DeleteDataFolder || File.Exists(Path.Combine(tempFolder, CustomDatabase.Name + ".txt"))) {
                    foreach (string folder in Directory.GetDirectories(DataFolder)) {
                        Directory.Delete(folder, true);
                    }
                    foreach (string file in Directory.GetFiles(DataFolder)) {
                        File.Delete(file);
                    }
                } else {
                    // If we're not deleting the Data folder, we still need to ensure the database detector files are removed
                    foreach (Database existingDatabase in Databases) {
                        File.Delete(Path.Combine(DataFolder, existingDatabase.Name + ".txt"));
                    }
                }
            } else {
                Directory.CreateDirectory(DataFolder);
            }
            foreach (string folder in Directory.GetDirectories(tempFolder)) {
                Directory.Move(folder, Path.Combine(DataFolder, new DirectoryInfo(folder).Name));
            }
            foreach (string file in Directory.GetFiles(tempFolder)) {
                File.Copy(file, Path.Combine(DataFolder, Path.GetFileName(file)), true);
            }
            Directory.Delete(tempFolder, true);
            File.Delete(dataZipFile);
        }

        private void SetupDatabase(Database database, ProgressWindow progressWindow) {
            if (database.PrerequisiteDatabase != null) {
                CopyDataToGame(database.PrerequisiteDatabase);
                progressWindow.SetProgressPercentage(40);
            }
            CopyDataToGame(database);
            progressWindow.SetProgressPercentage(80);
            // Update the loader config files as switching between CM89, CM93 and anything else requires some changes
            UpdateConfigFiles(database);
        }

        private string FindFolderContainingData(string folderName) {
            if (File.Exists(Path.Combine(folderName, PlayerSetupFile)) && !folderName.Equals(DataFolder)) {
                return folderName;
            }
            foreach (string subFolder in Directory.GetDirectories(folderName)) {
                return FindFolderContainingData(subFolder);
            }
            return DataFolder;
        }

        private void SwitchDatabase_Click(object sender, EventArgs e) {
            ProgressWindow progressWindow = new ProgressWindow("Loading selected database", 75);
            progressWindow.Show();
            progressWindow.Refresh();
            progressWindow.SetProgressPercentage(0);

            Button button = (Button) sender;
            Database database = Databases.Where(v => string.Equals(v.Name, button.Name)).FirstOrDefault();
            SetupDatabase(database, progressWindow);

            progressWindow.SetProgressPercentage(100);
            progressWindow.Close();
            DisplayMessage(database.Label + " database successfully loaded!");
        }

        private void SaveDatabase_Click(object sender, EventArgs e) {
            if (DataFolderExists()) {
                this.saveDatabaseDialog.InitialDirectory = CustomDatabasesFolder;
                this.saveDatabaseDialog.ShowDialog();
            } else {
                DisplayMessage(SwitchUpdateMessage);
            }
        }

        private void SaveDatabaseDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e) {
            ProgressWindow progressWindow = new ProgressWindow("Saving custom database", 80);
            progressWindow.Show();
            progressWindow.Refresh();
            progressWindow.SetProgressPercentage(20);

            // Ensure any database detector files are removed prior to saving this as a custom database, and also add the custom database detector file.
            foreach (Database database in Databases) {
                File.Delete(Path.Combine(DataFolder, database.Name + ".txt"));
            }
            string customDetectorFile = Path.Combine(DataFolder, CustomDatabase.Name + ".txt");
            string databaseName = Path.GetFileNameWithoutExtension(this.saveDatabaseDialog.FileName);
            List<string> lines = new List<string> { databaseName };
            WriteToFile(lines, customDetectorFile);
            progressWindow.SetProgressPercentage(40);
            new FastZip().CreateZip(this.saveDatabaseDialog.FileName, DataFolder, true, null);
            progressWindow.SetProgressPercentage(100);
            DisplayMessage("Custom database successfully saved!");
            progressWindow.Close();
        }

        private void LoadDatabase_Click(object sender, EventArgs e) {
            this.loadDatabaseDialog.InitialDirectory = CustomDatabasesFolder;
            this.loadDatabaseDialog.ShowDialog();
        }

        private void LoadDatabaseDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e) {
            string closingMessage = "Custom database successfully loaded!";
            ProgressWindow progressWindow = new ProgressWindow("Loading custom database", 80);
            progressWindow.Show();
            progressWindow.Refresh();
            progressWindow.SetProgressPercentage(0);

            Database customDatabase = CustomDatabase;
            customDatabase.ResourceFile = File.ReadAllBytes(this.loadDatabaseDialog.FileName);
            SetupDatabase(customDatabase, progressWindow);

            // Folder structures of data updates aren't always the same.
            // We need to search for the files and move them to the correct place.
            string baseFolder = FindFolderContainingData(DataFolder);
            if (!baseFolder.Equals(DataFolder)) {
                foreach (string subFolder in Directory.GetDirectories(baseFolder)) {
                    // Hopefully the Data folder will never have any subfolders in it at this point!
                    Directory.Move(subFolder, Path.Combine(DataFolder, new DirectoryInfo(subFolder).Name));
                }
                foreach (string file in Directory.GetFiles(baseFolder)) {
                    File.Copy(file, Path.Combine(DataFolder, Path.GetFileName(file)), true);
                }
                // Delete any leftover folders (ensure we don't delete "Fonts" folder if it exists).
                foreach (string dataSubFolder in Directory.GetDirectories(DataFolder)) {
                    if (!Path.GetFileName(dataSubFolder).Equals("Fonts")) {
                        Directory.Delete(dataSubFolder, true);
                    }
                }
            }
            // Add an error message if no valid database files can be found.
            if (!File.Exists(Path.Combine(DataFolder, PlayerSetupFile))) {
                closingMessage = "No valid database found!";
            }
            progressWindow.SetProgressPercentage(100);
            DisplayMessage(closingMessage);
            progressWindow.Close();
        }

        private void VersionMenu_FormClosed(object sender, FormClosedEventArgs e) {
            Application.Exit();
        }
    }
}
