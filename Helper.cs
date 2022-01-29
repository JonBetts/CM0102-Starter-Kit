using CM0102_Starter_Kit.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace CM0102_Starter_Kit {
    class Helper {
        internal static readonly string GameFolder = Path.Combine(Directory.GetCurrentDirectory(), "Game");
        internal static readonly string DataFolderName = "Data";
        internal static readonly string DataFolder = Path.Combine(GameFolder, DataFolderName);
        internal static readonly string FontsFolder = Path.Combine(DataFolder, "Fonts");
        internal static readonly string CmLoaderConfigFilename = "CM0102LoaderDefault.ini";
        internal static readonly string CmLoaderCustomConfigFilename = "CM0102LoaderCustom.ini";
        internal static readonly string Cm0102ExeFilename = "cm0102.exe";
        internal static readonly string CmLoaderExeFilename = "CM0102Loader.exe";
        internal static readonly string ExistingCommentary = Path.Combine(DataFolder, "events_eng.cfg");
        internal static readonly string ExistingCommentaryBackup = Path.Combine(DataFolder, "events_eng.cfg.bk");
        internal static readonly string PlayerSetupFilename = "player_setup.cfg";
        internal static readonly string BackupSavesFolder = Path.Combine(Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory), "CM0102 Backups");
        internal static readonly string CustomDatabasesFolder = Path.Combine(GameFolder, "Custom Databases");
        internal static readonly string PatchesFolderName = "Patches";
        internal static readonly string PatchesFolder = Path.Combine(GameFolder, PatchesFolderName);
        internal static readonly string OptionalPatchesFolder = Path.Combine(PatchesFolder, "Optional");
        internal static readonly string PointsDeductionPatch = "PointsDeductions.patch";
        internal static readonly string ExagearFolder = Path.Combine(GameFolder, "Android", "Exagear");
        internal static readonly string SwitchUpdateMessage = "Please use the Data Updates menu to load up a database first!";
        internal static readonly CultureInfo CultureInfo = new CultureInfo("en-GB");

        internal static bool DataFolderExists() {
            return Directory.Exists(DataFolder);
        }

        internal class ConfigLine {
            internal ConfigLine(int lineNumber, string name, string value) {
                this.LineNumber = lineNumber;
                this.Name = name;
                this.Value = value;
            }

            internal int LineNumber { get; }
            internal string Name { get; }
            internal string Value { get; }
        }

        private static readonly Dictionary<int, ConfigLine> Cm89ConfigLines = new Dictionary<int, ConfigLine> {
            { 1, new ConfigLine(1, "Year", "1989") },
            { 4, new ConfigLine(4, "ColouredAttributes", "false") },
            { 5, new ConfigLine(5, "DisableUnprotectedContracts", "false") },
            { 12, new ConfigLine(12, "RemoveForeignPlayerLimit", "false") }
        };

        private static readonly Dictionary<int, ConfigLine> Cm93ConfigLines = new Dictionary<int, ConfigLine> {
            { 1, new ConfigLine(1, "Year", "1993") },
            { 4, new ConfigLine(4, "ColouredAttributes", "false") },
            { 5, new ConfigLine(5, "DisableUnprotectedContracts", "false") },
            { 8, new ConfigLine(8, "RegenFixes", "false") }
        };

        private static readonly Dictionary<int, ConfigLine> Cm95ConfigLines = new Dictionary<int, ConfigLine> {
            { 1, new ConfigLine(1, "Year", "1995") },
            { 4, new ConfigLine(4, "ColouredAttributes", "false") },
            { 5, new ConfigLine(5, "DisableUnprotectedContracts", "false") },
            { 8, new ConfigLine(8, "RegenFixes", "false") }
        };

        private static readonly Dictionary<int, ConfigLine> Cm3ConfigLines = new Dictionary<int, ConfigLine> {
            { 1, new ConfigLine(1, "Year", "1998") },
            { 4, new ConfigLine(4, "ColouredAttributes", "false") },
            { 5, new ConfigLine(5, "DisableUnprotectedContracts", "false") },
            { 8, new ConfigLine(8, "RegenFixes", "false") },
            { 10, new ConfigLine(10, "AddTapaniRegenCode", "false") }
        };

        private static readonly Dictionary<int, ConfigLine> AndroidConfigLines = new Dictionary<int, ConfigLine> {
            { 9, new ConfigLine(9, "ForceLoadAllPlayers", "false") },
            { 14, new ConfigLine(14, "ChangeTo1280x800", "false") },
            { 16, new ConfigLine(16, "PatchFileDirectory", "Patches") }
        };

        private static readonly Dictionary<int, ConfigLine> Nov2020ConfigLines = new Dictionary<int, ConfigLine> {
            { 1, new ConfigLine(1, "Year", "2020") }
        };

        private static readonly Dictionary<int, ConfigLine> Apr2021ConfigLines = new Dictionary<int, ConfigLine> {
            { 1, new ConfigLine(1, "Year", "2020") }
        };

        private static readonly Dictionary<int, ConfigLine> Oct2021ConfigLines = new Dictionary<int, ConfigLine> {
            { 1, new ConfigLine(1, "Year", "2021") }
        };


        internal class Database {
            internal Database(string name, string label, byte[] dataFile, bool deleteDataFolder, byte[] exeFile) {
                this.Name = name;
                this.Label = label;
                this.DataFile = dataFile;
                this.DeleteDataFolder = deleteDataFolder;
                this.ConfigLines = new Dictionary<int, ConfigLine>();
                this.ExeFile = exeFile;
            }

            internal Database(string name, string label, byte[] dataFile, bool deleteDataFolder, byte[] exeFile, Database prerequisiteDatabase) : this(name, label, dataFile, deleteDataFolder, exeFile) {
                this.PrerequisiteDatabase = prerequisiteDatabase;
            }

            internal Database(string name, string label, byte[] dataFile, bool deleteDataFolder, byte[] exeFile, Dictionary<int, ConfigLine> configLines) : this(name, label, dataFile, deleteDataFolder, exeFile) {
                this.ConfigLines = configLines;
            }

            internal Database(string name, string label, byte[] dataFile, bool deleteDataFolder, byte[] exeFile, Database prerequisiteDatabase, Dictionary<int, ConfigLine> configLines) : this(name, label, dataFile, deleteDataFolder, exeFile, prerequisiteDatabase) {
                this.ConfigLines = configLines;
            }

            internal string Name { get; }
            internal string Label { get; }
            internal byte[] DataFile { get; set; }
            internal bool DeleteDataFolder { get; }
            internal Database PrerequisiteDatabase { get; }
            internal Dictionary<int, ConfigLine> ConfigLines { get; }
            internal byte[] ExeFile { get; }
        }

        internal static readonly Database OriginalDatabase = new Database("original_database", "Original (3.9.60)", Resources.original_data, true, Resources.cm0102_exe);
        internal static readonly Database PatchedDatabase = new Database("patched_database", "Patched (3.9.68)", Resources.patched_data, true, Resources.cm0102_exe);
        internal static readonly Database OctoberDatabase = new Database("october_database", "October 2021", Resources.october_data, false, Resources.cm0102_exe, PatchedDatabase);
        internal static readonly Database NovemberDatabase = new Database("november_database", "November 2020", Resources.november_data, false, Resources.cm0102_exe, PatchedDatabase);
        internal static readonly Database AprilDatabase = new Database("april_database", "April 2021", Resources.april_data, false, Resources.cm0102_exe, PatchedDatabase);
        internal static readonly Database LuessenhoffDatabase = new Database("luessenhoff_database", "Luessenhoff", Resources.luessenhoff_data, false, Resources.cm0102_exe, OriginalDatabase);
        internal static readonly Database Cm89Database = new Database("cm89_database", "1989/90", Resources.cm89_data, true, Resources.cm89_exe, Cm89ConfigLines);
        internal static readonly Database Cm93Database = new Database("cm93_database", "1993/94", Resources.cm93_data, true, Resources.cm93_exe, Cm93ConfigLines);
        internal static readonly Database Cm95Database = new Database("cm95_database", "1995/96", Resources.cm95_data, true, Resources.cm95_exe, Cm95ConfigLines);
        internal static readonly Database Cm3Database = new Database("cm3_database", "1998/99", Resources.cm3_data, true, Resources.cm3_exe, Cm3ConfigLines);
        internal static readonly Database CustomDatabase = new Database("custom_database", "Custom Database", null, false, Resources.cm0102_exe, PatchedDatabase);
        internal static readonly Database OctoberDatabasePatched = new Database("october_database_patched", "October 2021", Resources.october_data_patched, false, Resources.cm0102_oct_exe, PatchedDatabase, Oct2021ConfigLines);
        internal static readonly Database NovemberDatabasePatched = new Database("november_database_patched", "November 2020", Resources.november_data_patched, false, Resources.cm0102_nov_exe, PatchedDatabase, Nov2020ConfigLines);
        internal static readonly Database AprilDatabasePatched = new Database("april_database_patched", "April 2021", Resources.april_data_patched, false, Resources.cm0102_apr_exe, PatchedDatabase, Apr2021ConfigLines);

        internal static readonly List<Database> Databases = new List<Database> {
            OriginalDatabase, PatchedDatabase, OctoberDatabase, NovemberDatabase, AprilDatabase, LuessenhoffDatabase, Cm89Database,
            Cm93Database, Cm95Database, Cm3Database, OctoberDatabasePatched, NovemberDatabasePatched, AprilDatabasePatched
        };

        internal static Database CurrentDatabase() {
            foreach (Database database in Databases) {
                if (File.Exists(Path.Combine(DataFolder, database.Name + ".txt"))) {
                    return database;
                }
            }
            // Default case if any other database is loaded
            return CustomDatabase;
        }

        internal static void WriteToFile(List<string> lines, string file) {
            using (StreamWriter writer = new StreamWriter(file)) {
                for (int currentLine = 1; currentLine <= lines.Count; ++currentLine) {
                    writer.WriteLine(lines[currentLine - 1]);
                }
            }
        }

        internal static List<string> GetDefaultConfigFileLines(string configFile, Database database, bool copyForAndroid) {
            string[] existingLines = File.ReadAllLines(configFile);
            List<string> newLines = new List<string>();

            for (int currentLine = 1; currentLine <= existingLines.Length; ++currentLine) {
                if (database.ConfigLines.TryGetValue(currentLine, out ConfigLine configLine)) {
                    // Year is a special case - set it to 0 in the file if there is a custom value set for it
                    if (currentLine == 1) {
                        newLines.Add("Year = 0");
                    } else {
                        newLines.Add(configLine.Name + " = " + configLine.Value);
                    }
                } else if (copyForAndroid && AndroidConfigLines.TryGetValue(currentLine, out ConfigLine androidConfigLine)) {
                    newLines.Add(androidConfigLine.Name + " = " + androidConfigLine.Value);
                } else {
                    newLines.Add(existingLines[currentLine - 1]);
                }
            }
            return newLines;
        }
    }
}
