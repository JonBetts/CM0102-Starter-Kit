using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

public static class Helper {
    public static readonly string ProgramFilesFolder = IsWindowsXpOrLower() ? @"C:\Program Files" : @"C:\Program Files (x86)";
    public static readonly string GameFolder = Path.Combine(ProgramFilesFolder, "Championship Manager 01-02");
    public static readonly string GameDataFolder = Path.Combine(GameFolder, "Data");
    public static readonly string GameDataFolderBackup = Path.Combine(GameFolder, "Data_backup");
    public static readonly string OriginalDataFolder = Path.Combine(GameFolder, "original_data");
    public static readonly string PatchedDataFolder = Path.Combine(GameFolder, "patched_data");
    public static readonly string MarchDataFolder = Path.Combine(GameFolder, "march_data");
    public static readonly string NovemberDataFolder = Path.Combine(GameFolder, "november_data");
    public static readonly string NinetyThreeDataFolder = Path.Combine(GameFolder, "ninety_three_data");
    public static readonly string LuessenhoffDataFolder = Path.Combine(GameFolder, "luessenhoff_data");
    public static readonly string GameEditorFolder = Path.Combine(GameFolder, "Editor");
    public static readonly string VirtualDriveFolder = Path.Combine(ProgramFilesFolder, "WinCDEmu");
    public static readonly string VirtualDriveExe = Path.Combine(VirtualDriveFolder, "batchmnt.exe");
    public static readonly string ExistingCommentaryFile = Path.Combine(GameDataFolder, "events_eng.cfg");
    public static readonly string GameExe = "cm0102.exe";
    public static readonly string CmLoaderExeFile = Path.Combine(GameFolder, "CM0102Loader.exe");
    public static readonly string CmLoaderConfigFile = Path.Combine(GameFolder, "CM0102Loader.ini");
    public static readonly string BackupSavesFolder = @"C:\CM0102 Backups";

    public static bool IsWindowsXpOrLower() {
        OperatingSystem operatingSystem = Environment.OSVersion;
        return operatingSystem.Platform == PlatformID.Win32NT && operatingSystem.Version.Major == 5;
    }

    public static bool IsWindowsEightOrHigher() {
        OperatingSystem operatingSystem = Environment.OSVersion;
        return (operatingSystem.Version.Major == 6 && operatingSystem.Version.Minor >= 2) || operatingSystem.Version.Major == 10;
    }

    private static void ToggleButtons(List<Control> controls, bool toggle) {
        foreach (Control control in controls) {
            control.Enabled = toggle;
        }
    }

    public static void ShowLoader(Form form, PictureBox loader, List<Control> controls) {
        form.Cursor = System.Windows.Forms.Cursors.WaitCursor;
        loader.Visible = true;
        ToggleButtons(controls, false);
    }

    public static void HideLoader(Form form, PictureBox loader, List<Control> controls) {
        form.Cursor = System.Windows.Forms.Cursors.Default;
        ToggleButtons(controls, true);
        loader.Visible = false;
    }

    public static void DisplayMessage(Form form, string message) {
        using (new CentreMessageBox(form)) {
            MessageBox.Show(message);
        }
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

    public static void RenderLoader(Form form, PaintEventArgs e) {
        StringFormat format = new StringFormat {
            LineAlignment = StringAlignment.Center,
            Alignment = StringAlignment.Center
        };
        e.Graphics.DrawString("Please Wait...", new Font("Verdana", 18, FontStyle.Bold), Brushes.White, form.ClientRectangle, format);
    }

    public static bool IsPatchInstalled() {
        return File.Exists(Path.Combine(Helper.GameFolder, "changes.txt"));
    }

    public static void ShowNewScreen(Form parent, Form child) {
        child.Left = parent.Left;
        child.Top = parent.Top;
        child.Show();
        parent.Hide();
    }
}
