using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace CM0102_Starter_Kit {
    public partial class NickPatcherMenu : HidableForm {
        private readonly MainMenu mainMenu;

        public NickPatcherMenu(MainMenu mainMenu) {
            this.mainMenu = mainMenu;
            InitializeComponent();
        }

        protected override List<Control> GetButtonsToToggle() {
            return new List<Control> {
                this.apply,
                this.exit
            };
        }

        private void Apply_Click(object sender, EventArgs e) {
            ShowLoader(this.loader);
            using (StreamWriter writer = new StreamWriter(Helper.CmLoaderCustomConfig)) {
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
            HideLoader(this.loader);
        }

        private void BackButton_Click(object sender, EventArgs e) {
            ShowNewScreen(mainMenu);
        }

        private void LeftArrow_Click(object sender, EventArgs e) {
            ShowNewScreen(mainMenu);
        }

        private void Exit_Click(object sender, EventArgs e) {
            mainMenu.Close();
        }

        private void NickPatcherMenu_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = true;
            Exit_Click(sender, e);
        }
    }
}
