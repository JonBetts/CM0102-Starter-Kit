using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace CM0102_Starter_Kit {
    class Helper {
        internal static readonly string GameFolder = Path.Combine(Directory.GetCurrentDirectory(), "Game");
        internal static readonly string DataFolderName = "Data";
        internal static readonly string DataFolder = Path.Combine(GameFolder, DataFolderName);
        internal static readonly string PicturesFolderName = "Pictures";
        internal static readonly string SoundsFolderName = "Sounds";
        internal static readonly string CmLoaderConfig = "CM0102LoaderDefault.ini";
        internal static readonly string CmLoaderCustomConfig = "CM0102LoaderCustom.ini";
        internal static readonly string CmLoaderAndroidConfig = "CM0102Loader.ini";
        internal static readonly string CmLoaderExe = "CM0102Loader.exe";
        internal static readonly string CmLoader = Path.Combine(GameFolder, CmLoaderExe);
        internal static readonly string Cm0102Exe = "cm0102.exe";
        internal static readonly string Cm0102GdiExe = "cm0102_GDI.exe";
        internal static readonly string Cm0102BackupExe = "cm0102.exe.bk";
        internal static readonly string Cm89Exe = "cm89.exe";
        internal static readonly string Cm93Exe = "cm93.exe";
        internal static readonly string Cm95Exe = "cm95.exe";
        internal static readonly string Cm3Exe = "cm3.exe";
        internal static readonly List<string> ExeFiles = new List<string> { Cm0102Exe, Cm0102GdiExe, Cm0102BackupExe, Cm89Exe, Cm93Exe, Cm95Exe, Cm3Exe };
        internal static readonly string CmScout = Path.Combine(GameFolder, "cmscout.exe");
        internal static readonly string PlayerFinder = Path.Combine(GameFolder, "gpf2.exe");
        internal static readonly string ExistingCommentary = Path.Combine(DataFolder, "events_eng.cfg");
        internal static readonly string ExistingCommentaryBackup = Path.Combine(DataFolder, "events_eng.cfg.bk");
        internal static readonly string OfficialEditor = Path.Combine(Path.Combine(GameFolder, "Editor"), "cm0102ed.exe");
        internal static readonly string PlayerSetupFile = "player_setup.cfg";
        internal static readonly string BackupSavesFolder = Path.Combine(Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory), "CM0102 Backups");
        internal static readonly string CustomDatabasesFolder = Path.Combine(GameFolder, "Custom Databases");
        internal static readonly string PatchesFolderName = "Patches";
        internal static readonly string PatchesFolder = Path.Combine(GameFolder, PatchesFolderName);
        internal static readonly string OptionalPatchesFolder = Path.Combine(PatchesFolder, "Optional");
        internal static readonly string MiscPatchesFolder = Path.Combine(OptionalPatchesFolder, "Misc");
        internal static readonly string ExagearFolder = Path.Combine(Path.Combine(GameFolder, "Android"), "Exagear");
        internal static readonly string Android11Patch = "Android11Patch.patch";
        internal static readonly string SwitchUpdateMessage = "Please use the Data Updates menu to load up a database first!";
        internal static readonly CultureInfo CultureInfo = new CultureInfo("en-GB");

        private static bool IsWindowsVistaOrLower() {
            OperatingSystem operatingSystem = Environment.OSVersion;
            return operatingSystem.Version.Major <= 5 || (operatingSystem.Version.Major == 6 && operatingSystem.Version.Minor == 0);
        }

        private static bool IsWindowsEightOrHigher() {
            OperatingSystem operatingSystem = Environment.OSVersion;
            return (operatingSystem.Version.Major == 6 && operatingSystem.Version.Minor >= 2) || operatingSystem.Version.Major == 10;
        }

        internal static bool GameFolderExists() {
            return Directory.Exists(GameFolder);
        }

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
            { 7, new ConfigLine(7, "IncreaseToSevenSubs", "false") },
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
            { 7, new ConfigLine(7, "IncreaseToSevenSubs", "false") },
            { 8, new ConfigLine(8, "RegenFixes", "false") },
            { 10, new ConfigLine(10, "AddTapaniRegenCode", "false") }
        };

        private static readonly Dictionary<int, ConfigLine> AndroidConfigLines = new Dictionary<int, ConfigLine> {
            { 9, new ConfigLine(9, "ForceLoadAllPlayers", "false") },
            { 14, new ConfigLine(14, "ChangeTo1280x800", "false") },
            { 16, new ConfigLine(16, "PatchFileDirectory", "Patches") }
        };

        internal class Database {
            internal Database(string name, string label, byte[] resourceFile, bool deleteDataFolder, string exeFile) {
                this.Name = name;
                this.Label = label;
                this.ResourceFile = resourceFile;
                this.DeleteDataFolder = deleteDataFolder;
                this.ConfigLines = new Dictionary<int, ConfigLine>();
                this.ExeFile = exeFile;
            }

            internal Database(string name, string label, byte[] resourceFile, bool deleteDataFolder, string exeFile, Database prerequisiteDatabase) : this(name, label, resourceFile, deleteDataFolder, exeFile) {
                this.PrerequisiteDatabase = prerequisiteDatabase;
            }

            internal Database(string name, string label, byte[] resourceFile, bool deleteDataFolder, string exeFile, Dictionary<int, ConfigLine> configLines) : this(name, label, resourceFile, deleteDataFolder, exeFile) {
                this.ConfigLines = configLines;
            }

            internal string Name { get; }
            internal string Label { get; }
            internal byte[] ResourceFile { get; set; }
            internal bool DeleteDataFolder { get; }
            internal Database PrerequisiteDatabase { get; }
            internal Dictionary<int, ConfigLine> ConfigLines { get; }
            internal string ExeFile { get; }
        }

        private static readonly Database OriginalDatabase = new Database("original_database", "Original (3.9.60)", Properties.Resources.original_data, true, Cm0102Exe);
        private static readonly Database PatchedDatabase = new Database("patched_database", "Patched (3.9.68)", Properties.Resources.patched_data, true, Cm0102Exe);
        private static readonly Database OctoberDatabase = new Database("october_database", "October 2021", Properties.Resources.october_data, false, Cm0102Exe, PatchedDatabase);
        private static readonly Database NovemberDatabase = new Database("november_database", "November 2020", Properties.Resources.november_data, false, Cm0102Exe, PatchedDatabase);
        private static readonly Database AprilDatabase = new Database("april_database", "April 2021", Properties.Resources.april_data, false, Cm0102Exe, PatchedDatabase);
        private static readonly Database LuessenhoffDatabase = new Database("luessenhoff_database", "Luessenhoff", Properties.Resources.luessenhoff_data, false, Cm0102Exe, OriginalDatabase);
        private static readonly Database Cm89Database = new Database("cm89_database", "1989/90", Properties.Resources.cm89_data, true, Cm89Exe, Cm89ConfigLines);
        private static readonly Database Cm93Database = new Database("cm93_database", "1993/94", Properties.Resources.cm93_data, true, Cm93Exe, Cm93ConfigLines);
        private static readonly Database Cm95Database = new Database("cm95_database", "1995/96", Properties.Resources.cm95_data, true, Cm95Exe, Cm95ConfigLines);
        private static readonly Database Cm3Database = new Database("cm3_database", "1998/99", Properties.Resources.cm3_data, true, Cm3Exe, Cm3ConfigLines);
        public static readonly Database CustomDatabase = new Database("custom_database", "Custom Database", null, false, Cm0102Exe, PatchedDatabase);

        internal static readonly List<Database> Databases = new List<Database> {
            OriginalDatabase, PatchedDatabase, OctoberDatabase, NovemberDatabase, AprilDatabase, LuessenhoffDatabase, Cm89Database, Cm93Database, Cm95Database, Cm3Database
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
