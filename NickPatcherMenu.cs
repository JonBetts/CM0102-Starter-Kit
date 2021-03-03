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

        protected override List<Control> GetButtonsToToggle() {
            return new List<Control> {
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

        protected override void RefreshForm() {
            string[] lines = File.ReadAllLines(Path.Combine(GameFolder, CmLoaderCustomConfig));
            foreach (KeyValuePair<ComboBox, int> comboBox in GetComboBoxes()) {
                string line = lines[comboBox.Value];
                Match match = Regex.Match(line, @"\d+");
                comboBox.Key.SelectedIndex = comboBox.Key.FindStringExact("x" + match.Captures[0].Value);
            }
            foreach (KeyValuePair<NumericUpDown, int> numericUpDown in GetNumericUpDowns()) {
                string line = lines[numericUpDown.Value];
                Match match = Regex.Match(line, @"\d+.*\d*");
                numericUpDown.Key.Value = Convert.ToDecimal(match.Captures[0].Value);
            }
            foreach (KeyValuePair<CheckBox, int> checkBox in GetCheckBoxes()) {
                string line = lines[checkBox.Value];
                Match match = Regex.Match(line, "true|false");
                checkBox.Key.Checked = Convert.ToBoolean(match.Captures[0].Value);
            }
        }

        private void Apply_Click(object sender, EventArgs e) {
            using (StreamWriter writer = new StreamWriter(Path.Combine(GameFolder, CmLoaderCustomConfig))) {
                writer.Write("Year = " + this.starting_year.Value + Environment.NewLine);
                writer.Write("SpeedMultiplier = " + this.game_speed.SelectedItem.ToString().Replace("x", "") + Environment.NewLine);
                writer.Write("CurrencyMultiplier = " + this.currency_inflation.Value + Environment.NewLine);
                writer.Write("ColouredAttributes = " + this.coloured_attributes.Checked.ToString().ToLower() + Environment.NewLine);
                writer.Write("DisableUnprotectedContracts = " + this.unprotected_contracts.Checked.ToString().ToLower() + Environment.NewLine);
                writer.Write("HideNonPublicBids = " + this.non_public_bids.Checked.ToString().ToLower() + Environment.NewLine);
                writer.Write("IncreaseToSevenSubs = " + this.seven_substitutes.Checked.ToString().ToLower() + Environment.NewLine);
                writer.Write("RegenFixes = " + this.regen_fixes.Checked.ToString().ToLower() + Environment.NewLine);
                writer.Write("ForceLoadAllPlayers = " + this.force_all_players.Checked.ToString().ToLower() + Environment.NewLine);
                writer.Write("AddTapaniRegenCode = " + this.tapani_regen.Checked.ToString().ToLower() + Environment.NewLine);
                writer.Write("UnCap20s = " + this.uncap.Checked.ToString().ToLower() + Environment.NewLine);
                writer.Write("RemoveForeignPlayerLimit = " + this.foreign_player_limit.Checked.ToString().ToLower() + Environment.NewLine);
                writer.Write("NoWorkPermits = " + this.work_permits.Checked.ToString().ToLower() + Environment.NewLine);
                writer.Write("ChangeTo1280x800 = " + this.resolution.Checked.ToString().ToLower() + Environment.NewLine);
                writer.Write("AutoLoadPatchFiles = false" + Environment.NewLine);
                writer.Write("PatchFileDirectory = ." + Environment.NewLine);
                writer.Write("DataDirectory = data" + Environment.NewLine);
                writer.Write("Debug = false" + Environment.NewLine);
                writer.Write("NoCD = true" + Environment.NewLine);
            }
            DisplayMessage("Settings successfully changed!");
        }

        private void NickPatcherMenu_FormClosed(object sender, FormClosedEventArgs e) {
            Application.Exit();
        }
    }
}
