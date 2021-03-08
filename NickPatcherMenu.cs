using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CM0102_Starter_Kit {
    partial class NickPatcherMenu : HidableForm {
        public NickPatcherMenu(MainMenu mainMenu) {
            this.mainMenu = mainMenu;
            this.SuspendLayout();
            InitialiseSharedControls("Change Nick's Patcher Settings", 259, true);
            InitializeComponent();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        protected override List<Button> GetButtonsToToggle() {
            return new List<Button> {
                this.apply
            };
        }

        private Dictionary<ComboBox, int> GetComboBoxes() {
            return new Dictionary<ComboBox, int> {
                { this.game_speed, 1 }
            };
        }

        private Dictionary<NumericUpDown, int> GetNumericUpDowns() {
            return new Dictionary<NumericUpDown, int> {
                { this.starting_year, 0 },
                { this.currency_inflation, 2 }
            };
        }

        private Dictionary<CheckBox, int> GetCheckBoxes() {
            return new Dictionary<CheckBox, int> {
                { this.coloured_attributes, 3 },
                { this.unprotected_contracts, 4 },
                { this.non_public_bids, 5 },
                { this.seven_substitutes, 6 },
                { this.regen_fixes, 7 },
                { this.force_all_players, 8 },
                { this.tapani_regen, 9 },
                { this.uncap, 10 },
                { this.foreign_player_limit, 11 },
                { this.work_permits, 12 },
                { this.resolution, 13 }
            };
        }

        private Dictionary<Control, object> GetRestrictedControls() {
            return new Dictionary<Control, object> {
                { this.starting_year, 1993 },
                { this.coloured_attributes, true },
                { this.unprotected_contracts, true },
                { this.regen_fixes, true },
            };
        }

        protected override void RefreshForm() {
            bool usingNinetyThree = NinetyThreeDataLoaded();
            string[] lines = File.ReadAllLines(Path.Combine(GameFolder, CmLoaderCustomConfig));
            Dictionary<Control, object> restrictedControls = GetRestrictedControls();

            foreach (KeyValuePair<ComboBox, int> keyValuePair in GetComboBoxes()) {
                ComboBox comboBox = keyValuePair.Key;
                string line = lines[keyValuePair.Value];
                Match match = Regex.Match(line, @"\d+");
                comboBox.SelectedIndex = comboBox.FindStringExact("x" + match.Captures[0].Value);
            }
            foreach (KeyValuePair<NumericUpDown, int> keyValuePair in GetNumericUpDowns()) {
                NumericUpDown numericUpDown = keyValuePair.Key;

                if (usingNinetyThree && restrictedControls.TryGetValue(numericUpDown, out object defaultValue)) {
                    numericUpDown.Value = Convert.ToDecimal(defaultValue);
                    numericUpDown.Enabled = false;
                // Special case
                } else if (numericUpDown.Equals(this.starting_year) && numericUpDown.Value == 0) {
                    numericUpDown.Value = 2001;
                    numericUpDown.Enabled = true;
                } else {
                    string line = lines[keyValuePair.Value];
                    Match match = Regex.Match(line, @"\d+.*\d*");
                    numericUpDown.Value = Convert.ToDecimal(match.Captures[0].Value);
                    numericUpDown.Enabled = true;
                }
            }
            foreach (KeyValuePair<CheckBox, int> keyValuePair in GetCheckBoxes()) {
                CheckBox checkBox = keyValuePair.Key;

                if (usingNinetyThree && restrictedControls.TryGetValue(checkBox, out object defaultValue)) {
                    checkBox.Checked = Convert.ToBoolean(defaultValue);
                    checkBox.Enabled = false;
                } else {
                    string line = lines[keyValuePair.Value];
                    Match match = Regex.Match(line, "true|false");
                    checkBox.Checked = Convert.ToBoolean(match.Captures[0].Value);
                    checkBox.Enabled = true;
                }
            }
        }

        private void Apply_Click(object sender, EventArgs e) {
            List<string> values = new List<string> {
                "Year = " + (NinetyThreeDataLoaded() ? "0" : this.starting_year.Value.ToString()),
                "SpeedMultiplier = " + this.game_speed.SelectedItem.ToString().Replace("x", ""),
                "CurrencyMultiplier = " + this.currency_inflation.Value.ToString(),
                "ColouredAttributes = " + (NinetyThreeDataLoaded() ? "false" : this.coloured_attributes.Checked.ToString().ToLower()),
                "DisableUnprotectedContracts = " + (NinetyThreeDataLoaded() ? "false" : this.unprotected_contracts.Checked.ToString().ToLower()),
                "HideNonPublicBids = " + this.non_public_bids.Checked.ToString().ToLower(),
                "IncreaseToSevenSubs = " + this.seven_substitutes.Checked.ToString().ToLower(),
                "RegenFixes = " + (NinetyThreeDataLoaded() ? "false" : this.regen_fixes.Checked.ToString().ToLower()),
                "ForceLoadAllPlayers = " + this.force_all_players.Checked.ToString().ToLower(),
                "AddTapaniRegenCode = " + this.tapani_regen.Checked.ToString().ToLower(),
                "UnCap20s = " + this.uncap.Checked.ToString().ToLower(),
                "RemoveForeignPlayerLimit = " + this.foreign_player_limit.Checked.ToString().ToLower(),
                "NoWorkPermits = " + this.work_permits.Checked.ToString().ToLower(),
                "ChangeTo1280x800 = " + this.resolution.Checked.ToString().ToLower()
            };
            WriteConfigFile(values, CmLoaderCustomConfig);
            DisplayMessage("Settings successfully changed!");
        }

        private void NickPatcherMenu_FormClosed(object sender, FormClosedEventArgs e) {
            Application.Exit();
        }
    }
}
