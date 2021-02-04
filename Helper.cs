using System;
using System.IO;

namespace CM0102_Starter_Kit {
    public static class Helper {
        public static readonly string ProgramFilesFolder = IsWindowsVistaOrLower() ? @"C:\Program Files" : @"C:\Program Files (x86)";
        public static readonly string DefaultGameFolder = Path.Combine(ProgramFilesFolder, "Championship Manager 01-02");
        public static readonly string DefaultChangesFile = Path.Combine(DefaultGameFolder, "changes.txt");
        public static readonly string GameFolder = Path.Combine(Directory.GetCurrentDirectory(), "Game");
        public static readonly string DataFolder = Path.Combine(GameFolder, "Data");
        public static readonly string CmLoader = Path.Combine(GameFolder, "CM0102Loader.exe");
        public static readonly string CmLoaderConfig = Path.Combine(GameFolder, "CM0102Loader.ini");
        public static readonly string CmLoaderCustomConfig = Path.Combine(GameFolder, "CM0102LoaderCustom.ini");
        public static readonly string CmScout = Path.Combine(GameFolder, "cmscout.exe");
        public static readonly string ExistingCommentary = Path.Combine(DataFolder, "events_eng.cfg");
        public static readonly string OfficialEditor = Path.Combine(Path.Combine(GameFolder, "Editor"), "cm0102ed.exe");
        public static readonly string BackupSavesFolder = @"C:\CM0102 Backups";

        public static bool IsWindowsVistaOrLower() {
            OperatingSystem operatingSystem = Environment.OSVersion;
            return operatingSystem.Version.Major <= 5 || (operatingSystem.Version.Major == 6 && operatingSystem.Version.Minor == 0);
        }

        public static bool IsWindowsEightOrHigher() {
            OperatingSystem operatingSystem = Environment.OSVersion;
            return (operatingSystem.Version.Major == 6 && operatingSystem.Version.Minor >= 2) || operatingSystem.Version.Major == 10;
        }

        public static void RemoveReadOnlyAttribute(DirectoryInfo currentFolder) {
            FileInfo[] files = currentFolder.GetFiles();
            foreach (FileInfo file in files) {
                file.IsReadOnly = false;
            }
            DirectoryInfo[] folders = currentFolder.GetDirectories();
            foreach (DirectoryInfo folder in folders) {
                RemoveReadOnlyAttribute(folder);
            }
        }

        public static bool GameFolderExists() {
            return Directory.Exists(GameFolder);
        }

        public static bool DataFolderExists() {
            return Directory.Exists(DataFolder);
        }
    }
}
