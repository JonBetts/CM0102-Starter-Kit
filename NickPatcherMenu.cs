﻿using CM0102_Starter_Kit.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static CM0102_Starter_Kit.Helper;

namespace CM0102_Starter_Kit {
    partial class NickPatcherMenu
    #if DEBUG
        : MiddleForm
    #else
        : HidableForm
    #endif
    {
        public NickPatcherMenu(MainMenu mainMenu) {
            this.mainMenu = mainMenu;
            InitialiseSharedControls("Change Nick's Patcher Settings", 259, true);
            InitializeComponent();
        }

        protected override List<Button> GetButtons() {
            return new List<Button> {
                this.apply
            };
        }

        private Dictionary<ComboBox, int> GetComboBoxes() {
            return new Dictionary<ComboBox, int> {
                { this.game_speed, 2 }
            };
        }

        private Dictionary<NumericUpDown, int> GetNumericUpDowns() {
            return new Dictionary<NumericUpDown, int> {
                { this.starting_year, 1 },
                { this.currency_inflation, 3 }
            };
        }

        private Dictionary<CheckBox, int> GetCheckBoxes() {
            return new Dictionary<CheckBox, int> {
                { this.coloured_attributes, 4 },
                { this.unprotected_contracts, 5 },
                { this.non_public_bids, 6 },
                { this.nine_substitutes, 7 },
                { this.regen_fixes, 8 },
                { this.force_all_players, 9 },
                { this.tapani_regen, 10 },
                { this.uncap, 11 },
                { this.work_permits, 13 },
                { this.resolution, 14 }
            };
        }

        private Dictionary<CheckBox, string> GetCheckboxPatches() {
            return new Dictionary<CheckBox, string> {
                { this.foreign_player_limit, "NoForeignRestrictionsForAll.patch" },
                { this.hidden_attributes, "HiddenAttributes.patch" },
                { this.nine_substitutes, "IncreaseToNineSubs.patch" }
            };
        }

        protected override void RefreshForm() {
            Database database = CurrentDatabase();
            string[] lines = File.ReadAllLines(Path.Combine(GameFolder, CmLoaderCustomConfigFilename));

            // No ComboBoxes have restricted values, so haven't implemented that here
            foreach (KeyValuePair<ComboBox, int> keyValuePair in GetComboBoxes()) {
                ComboBox comboBox = keyValuePair.Key;
                string line = lines[keyValuePair.Value - 1];
                Match match = Regex.Match(line, @"\d+");
                comboBox.SelectedIndex = comboBox.FindStringExact("x" + match.Captures[0].Value);
            }
            foreach (KeyValuePair<NumericUpDown, int> keyValuePair in GetNumericUpDowns()) {
                NumericUpDown numericUpDown = keyValuePair.Key;
                int lineNumber = keyValuePair.Value;
                string line = lines[lineNumber - 1];
                Match match = Regex.Match(line, @"\d+\.*\d*");
                decimal lineValue = Convert.ToDecimal(match.Captures[0].Value, CultureInfo);

                if (database.ConfigLines.ContainsKey(lineNumber)) {
                    database.ConfigLines.TryGetValue(lineNumber, out ConfigLine configLine);
                    numericUpDown.Value = Convert.ToDecimal(configLine.Value, CultureInfo);
                    numericUpDown.Enabled = false;
                // Special case - we have gone from a restricted exe back to the default, so reset the starting year
                } else if (numericUpDown.Equals(this.starting_year) && lineValue == 0) {
                    numericUpDown.Value = 2001;
                    numericUpDown.Enabled = true;
                } else {
                    numericUpDown.Value = lineValue;
                    numericUpDown.Enabled = true;
                }
            }
            foreach (KeyValuePair<CheckBox, int> keyValuePair in GetCheckBoxes()) {
                CheckBox checkBox = keyValuePair.Key;
                int lineNumber = keyValuePair.Value;
                // If a check box is restricted, it's restricted to true on the page
                // (but in reality the value is false in the config file as we don't want to apply it on top of the exe)
                if (database.ConfigLines.ContainsKey(lineNumber)) {
                    checkBox.Checked = true;
                    checkBox.Enabled = false;
                } else {
                    string line = lines[lineNumber - 1];
                    Match match = Regex.Match(line, "true|false");
                    checkBox.Checked = Convert.ToBoolean(match.Captures[0].Value, CultureInfo);
                    checkBox.Enabled = true;
                }
            }
            // Special cases for checkboxes mapped to non-default patches
            foreach (KeyValuePair<CheckBox, string> keyValuePair in GetCheckboxPatches()) {
                if (File.Exists(Path.Combine(PatchesFolder, keyValuePair.Value))) {
                    keyValuePair.Key.Checked = true;
                }
            }
            // If multiple patch files exist in the main Patches folder, tick the "Miscellaneous Patches" checkbox
            FileInfo[] patchFiles = new DirectoryInfo(PatchesFolder).GetFiles("*.patch");
            // 6 is the most patches there can be in the Patches folder without having selected the Misc Patches
            if (patchFiles.Length > 6) {
                this.misc_patches.Checked = true;
            }
        }

        private void Apply_Click(object sender, EventArgs e) {
            ProgressWindow progressWindow = CreateNewProgressWindow("Applying changes", 95);
            progressWindow.SetProgressPercentage(0);

            List<string> values = new List<string> {
                "Year = " + GetStartingYear(),
                "SpeedMultiplier = " + this.game_speed.SelectedItem.ToString().Replace("x", ""),
                "CurrencyMultiplier = " + this.currency_inflation.Value.ToString(),
                "ColouredAttributes = " + (this.coloured_attributes.Enabled ? this.coloured_attributes.Checked.ToString().ToLower() : "false"),
                "DisableUnprotectedContracts = " + (this.unprotected_contracts.Enabled ? this.unprotected_contracts.Checked.ToString().ToLower() : "false"),
                "HideNonPublicBids = " + (this.non_public_bids.Enabled ? this.non_public_bids.Checked.ToString().ToLower() : "false"),
                "IncreaseToSevenSubs = false",
                "RegenFixes = " + (this.regen_fixes.Enabled ? this.regen_fixes.Checked.ToString().ToLower() : "false"),
                "ForceLoadAllPlayers = " + this.force_all_players.Checked.ToString().ToLower(),
                "AddTapaniRegenCode = " + (this.regen_fixes.Enabled ? this.tapani_regen.Checked.ToString().ToLower() : "false"),
                "UnCap20s = " + this.uncap.Checked.ToString().ToLower(),
                "RemoveForeignPlayerLimit = false",
                "NoWorkPermits = " + (this.work_permits.Enabled ? this.work_permits.Checked.ToString().ToLower() : "false"),
                "ChangeTo1280x800 = " + this.resolution.Checked.ToString().ToLower(),
                "AutoLoadPatchFiles = true",
                "PatchFileDirectory = " + PatchesFolderName,
                "DataDirectory = data",
                "DisableSplashScreen = false",
                "Debug = false",
                "NoCD = true"
            };
            WriteToFile(values, Path.Combine(GameFolder, CmLoaderCustomConfigFilename));
            progressWindow.SetProgressPercentage(10);

            // Copy miscellaneous patches to main Patches folder
            if (this.misc_patches.Enabled && this.misc_patches.Checked) {
            FileInfo[] patchFiles = new DirectoryInfo(Path.Combine(PatchesFolder, "Misc")).GetFiles("*.patch");
                if (patchFiles.Length > 0) {
                    foreach (FileInfo patchFile in patchFiles) {
                        File.Copy(patchFile.FullName, Path.Combine(PatchesFolder, patchFile.Name), true);
                    }
                }
            } else {
                FileInfo[] existingPatchFiles = new DirectoryInfo(PatchesFolder).GetFiles("*.patch");
                if (existingPatchFiles.Length > 0) {
                    foreach (FileInfo patchFile in existingPatchFiles) {
                        File.Delete(patchFile.FullName);
                    }
                }
            }
            progressWindow.SetProgressPercentage(20);
            
            // Copy other patches not provided by default in the CM0102 Loader
            string nineSubsPatch = "IncreaseToNineSubs.patch";
            if (this.nine_substitutes.Enabled && this.nine_substitutes.Checked) {
                File.Copy(Path.Combine(OptionalPatchesFolder, nineSubsPatch), Path.Combine(PatchesFolder, nineSubsPatch), true);
            } else {
                File.Delete(Path.Combine(PatchesFolder, nineSubsPatch));
            }

            string foreignLimitPatch = "NoForeignRestrictionsForAll.patch";
            if (this.foreign_player_limit.Enabled && this.foreign_player_limit.Checked) {
                File.Copy(Path.Combine(OptionalPatchesFolder, foreignLimitPatch), Path.Combine(PatchesFolder, foreignLimitPatch), true);
            } else {
                File.Delete(Path.Combine(PatchesFolder, foreignLimitPatch));
            }

            string hiddenAttributesPatch = "HiddenAttributes.patch";
            if (this.hidden_attributes.Enabled && this.hidden_attributes.Checked) {
                File.Copy(Path.Combine(OptionalPatchesFolder, hiddenAttributesPatch), Path.Combine(PatchesFolder, hiddenAttributesPatch), true);
            } else {
                File.Delete(Path.Combine(PatchesFolder, hiddenAttributesPatch));
            }
            progressWindow.SetProgressPercentage(30);

            // We may need to also update the data files, depending on which database is active and what the chosen starting year is.
            // Currently, this will trigger with the November 2020 and April 2021 databases with a 2020 starting year, and the October 2021 database with a 2021 starting year.
            Database currentDatabase = CurrentDatabase();

            if (currentDatabase.Equals(NovemberDatabase) || currentDatabase.Equals(NovemberDatabasePatched)) {
                mainMenu.versionMenu.SetupDatabase(starting_year.Value.Equals(2020) ? NovemberDatabasePatched : NovemberDatabase, progressWindow);
            } else if (currentDatabase.Equals(AprilDatabase) || currentDatabase.Equals(AprilDatabasePatched)) {
                mainMenu.versionMenu.SetupDatabase(starting_year.Value.Equals(2020) ? AprilDatabasePatched : AprilDatabase, progressWindow);
            } else if (currentDatabase.Equals(OctoberDatabase) || currentDatabase.Equals(OctoberDatabasePatched)) {
                mainMenu.versionMenu.SetupDatabase(starting_year.Value.Equals(2021) ? OctoberDatabasePatched : OctoberDatabase, progressWindow);
                // Apply Reading and Derby points deduction patch
                File.Copy(Path.Combine(OptionalPatchesFolder, PointsDeductionPatch), Path.Combine(PatchesFolder, PointsDeductionPatch), true);
            }
            progressWindow.SetProgressPercentage(100);
            DisplayMessage("Settings successfully changed!");
            progressWindow.Close();
        }

        private void NickPatcherMenu_FormClosed(object sender, FormClosedEventArgs e) {
            Application.Exit();
        }

        internal string GetStartingYear() {
            return this.starting_year.Enabled ? this.starting_year.Value.ToString() : "0";
        }

        private void ApplyPatch_Click(object sender, EventArgs e) {
            if (Directory.Exists(PatchesFolder)) {
                this.applyPatchDialog.InitialDirectory = GameFolder;
                this.applyPatchDialog.ShowDialog();
            } else {
                DisplayMessage("Patches folder not found!");
            }
        }

        private void ApplyPatchDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e) {
            string destFile = Path.Combine(PatchesFolder, Path.GetFileName(this.applyPatchDialog.FileName));
            File.Copy(this.applyPatchDialog.FileName, destFile, true);
            DisplayMessage("Patch file successfully added!");
        }
    }
}
