﻿using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CM0102_Starter_Kit {
    [TypeDescriptionProvider(typeof(AbstractControlDescriptionProvider<HidableForm, Form>))]
    abstract partial class HidableForm : Form {
        protected static readonly string ProgramFilesFolder = IsWindowsVistaOrLower() ? @"C:\Program Files" : @"C:\Program Files (x86)";
        protected static readonly string DefaultGameFolder = Path.Combine(ProgramFilesFolder, "Championship Manager 01-02");
        protected static readonly string DefaultChangesFile = Path.Combine(DefaultGameFolder, "changes.txt");
        protected static readonly string GameFolder = Path.Combine(Directory.GetCurrentDirectory(), "Game");
        protected static readonly string DataFolder = Path.Combine(GameFolder, "Data");
        protected static readonly string CmLoader = Path.Combine(GameFolder, "CM0102Loader.exe");
        protected static readonly string CmLoaderConfig = "CM0102LoaderDefault.ini";
        protected static readonly string CmLoaderCustomConfig = "CM0102LoaderCustom.ini";
        protected static readonly string Cm0102 = Path.Combine(GameFolder, "cm0102.exe");
        protected static readonly string Cm0102Gdi = Path.Combine(GameFolder, "cm0102_GDI.exe");
        protected static readonly string Cm0102Backup = Path.Combine(GameFolder, "cm0102.exe.bk");
        protected static readonly string Cm93 = Path.Combine(GameFolder, "cm93.exe");
        protected static readonly string CmScout = Path.Combine(GameFolder, "cmscout.exe");
        protected static readonly string PlayerFinder = Path.Combine(GameFolder, "gpf2.exe");
        protected static readonly string ExistingCommentary = Path.Combine(DataFolder, "events_eng.cfg");
        protected static readonly string ExistingCommentaryBackup = Path.Combine(DataFolder, "events_eng.cfg.bk");
        protected static readonly string OfficialEditor = Path.Combine(Path.Combine(GameFolder, "Editor"), "cm0102ed.exe");
        protected static readonly string BackupSavesFolder = @"C:\CM0102 Backups";
        protected MainMenu mainMenu;

        protected static bool IsWindowsVistaOrLower() {
            OperatingSystem operatingSystem = Environment.OSVersion;
            return operatingSystem.Version.Major <= 5 || (operatingSystem.Version.Major == 6 && operatingSystem.Version.Minor == 0);
        }

        protected static bool IsWindowsEightOrHigher() {
            OperatingSystem operatingSystem = Environment.OSVersion;
            return (operatingSystem.Version.Major == 6 && operatingSystem.Version.Minor >= 2) || operatingSystem.Version.Major == 10;
        }

        protected static bool GameFolderExists() {
            return Directory.Exists(GameFolder);
        }

        protected static bool DataFolderExists() {
            return Directory.Exists(DataFolder);
        }

        protected static bool NinetyThreeDataLoaded() {
            return File.Exists(Path.Combine(DataFolder, "ninety_three.txt"));
        }

        protected abstract List<Button> GetButtonsToToggle();

        protected virtual void RefreshForm() { }

        private void ToggleButtons(bool toggle) {
            exit.Enabled = toggle;
            back_button.Enabled = toggle;

            foreach (Button button in GetButtonsToToggle()) {
                button.Enabled = toggle;
            }
        }

        protected void RenameExes() {
            if (File.Exists(Cm0102Backup)) {
                File.Move(Cm0102, Cm93);
                File.Move(Cm0102Backup, Cm0102);
            } else {
                File.Move(Cm0102, Cm0102Backup);
                File.Move(Cm93, Cm0102);
            }
        }

        protected void RefreshExeFiles() {
            string tempZipFolder = Path.Combine(Directory.GetCurrentDirectory(), "Temp");
            string tempZipFile = tempZipFolder + ".zip";
            File.WriteAllBytes(tempZipFile, Properties.Resources.Game);
            new FastZip().ExtractZip(tempZipFile, tempZipFolder, null);

            if (File.Exists(Cm0102)) {
                File.Delete(Cm0102);
            }
            File.Move(Path.Combine(tempZipFolder, "cm0102.exe"), Cm0102);

            if (File.Exists(Cm0102Gdi)) {
                File.Delete(Cm0102Gdi);
            }
            File.Move(Path.Combine(tempZipFolder, "cm0102_GDI.exe"), Cm0102Gdi);

            if (File.Exists(Cm93)) {
                File.Delete(Cm93);
            }
            File.Move(Path.Combine(tempZipFolder, "cm93.exe"), Cm93);

            if (File.Exists(CmLoader)) {
                File.Delete(CmLoader);
            }
            File.Move(Path.Combine(tempZipFolder, "CM0102Loader.exe"), CmLoader);

            if (File.Exists(Cm0102Backup)) {
                File.Delete(Cm0102Backup);
            }

            File.Delete(tempZipFile);
            Directory.Delete(tempZipFolder, true);
        }

        protected void WriteConfigFile(List<string> lines, string configFile) {
            using (StreamWriter writer = new StreamWriter(Path.Combine(GameFolder, configFile))) {
                for (int currentLine = 1; currentLine <= lines.Count; ++currentLine) {
                    writer.WriteLine(lines[currentLine - 1]);
                }
                writer.WriteLine("AutoLoadPatchFiles = false");
                writer.WriteLine("PatchFileDirectory = .");
                writer.WriteLine("DataDirectory = data");
                writer.WriteLine("Debug = false");
                writer.WriteLine("NoCD = true");
            }
        }

        protected void ShowLoader() {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.loader.Visible = true;
            ToggleButtons(false);
        }

        protected void HideLoader() {
            this.Cursor = System.Windows.Forms.Cursors.Default;
            ToggleButtons(true);
            this.loader.Visible = false;
        }

        protected void RenderLoader(PaintEventArgs e) {
            StringFormat format = new StringFormat {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center
            };
            e.Graphics.DrawString("Please Wait...", new Font("Verdana", 18, FontStyle.Bold), Brushes.White, this.ClientRectangle, format);
        }

        protected void Loader_Paint(object sender, PaintEventArgs e) {
            RenderLoader(e);
        }

        protected void DisplayMessage(string message) {
            using (new CentreMessageBox(this)) {
                MessageBox.Show(message);
            }
        }

        protected void ShowNewScreen(HidableForm newForm) {
            this.Hide();
            newForm.StartPosition = FormStartPosition.Manual;
            newForm.Location = this.Location;
            newForm.Size = this.Size;
            newForm.RefreshForm();
            newForm.Show();
        }

        private void BackButton_Click(object sender, EventArgs e) {
            ShowNewScreen(mainMenu);
        }

        private void Exit_Click(object sender, EventArgs e) {
            this.Close();
        }
    }

    public class AbstractControlDescriptionProvider<TAbstract, TBase> : TypeDescriptionProvider {
        public AbstractControlDescriptionProvider() : base(TypeDescriptor.GetProvider(typeof(TAbstract))) { }

        public override Type GetReflectionType(Type objectType, object instance) {
            if (objectType == typeof(TAbstract)) {
                return typeof(TBase);
            }
            return base.GetReflectionType(objectType, instance);
        }

        public override object CreateInstance(IServiceProvider provider, Type objectType, Type[] argTypes, object[] args) {
            if (objectType == typeof(TAbstract)) {
                objectType = typeof(TBase);
            }
            return base.CreateInstance(provider, objectType, argTypes, args);
        }
    }
}

