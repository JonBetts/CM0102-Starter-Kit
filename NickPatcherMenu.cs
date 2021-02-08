using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace CM0102_Starter_Kit {
    public partial class NickPatcherMenu : HidableForm {
        public NickPatcherMenu() {
            InitialiseSharedControls("Change Nick's Patcher Settings", 255, true);
            InitializeComponent();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        protected override List<Control> GetButtonsToToggle() {
            return new List<Control> {
                this.apply
            };
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
                writer.Write("RemoveForeignPlayerLimit = " + this.foreign_player_limit.Checked.ToString().ToLower() + Environment.NewLine);
                writer.Write("NoWorkPermits = " + this.work_permits.Checked.ToString().ToLower() + Environment.NewLine);
                writer.Write("ChangeTo1280x800 = false" + Environment.NewLine);
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
