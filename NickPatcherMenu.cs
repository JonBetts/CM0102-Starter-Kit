using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace CM0102_Starter_Kit {
    public partial class NickPatcherMenu : Form {
        private readonly MainMenu mainMenu;

        public NickPatcherMenu(MainMenu mainMenu) {
            this.mainMenu = mainMenu;
            InitializeComponent();
        }

        private List<Control> GetButtonsToToggle() {
            return new List<Control> {
                this.apply,
                this.exit
            };
        }

        private void ShowLoader() {
            Helper.ShowLoader(this, this.loader, GetButtonsToToggle());
        }

        private void HideLoader() {
            Helper.HideLoader(this, this.loader, GetButtonsToToggle());
        }

        private void Apply_Click(object sender, EventArgs e) {
            ShowLoader();
            using (StreamWriter writer = new StreamWriter(Helper.CmLoaderConfigFile)) {
                writer.Write("Year = " + this.starting_year.Value + Environment.NewLine);
                writer.Write("SpeedMultiplier = " + this.game_speed.SelectedItem.ToString().Replace("x", "") + Environment.NewLine);
                writer.Write("CurrencyMultiplier = " + this.currency_inflation.Value + Environment.NewLine);
                writer.Write("ColouredAttributes = " + this.coloured_attributes.Checked.ToString().ToLower() + Environment.NewLine);
                writer.Write("DisableUnprotectedContracts = " + this.unprotected_contracts.Checked.ToString().ToLower() + Environment.NewLine);
                writer.Write("HideNonPublicBids = " + this.non_public_bids.Checked.ToString().ToLower() + Environment.NewLine);
                writer.Write("IncreaseToSevenSubs = " + this.seven_substitutes.Checked.ToString().ToLower() + Environment.NewLine);
                writer.Write("RemoveForeignPlayerLimit = " + this.foreign_player_limit.Checked.ToString().ToLower() + Environment.NewLine);
                writer.Write("NoWorkPermits = " + this.work_permits.Checked.ToString().ToLower() + Environment.NewLine);
                //writer.Write("ChangeTo1280x800 = " + this.resolution.Checked.ToString().ToLower() + Environment.NewLine);
                writer.Write("ChangeTo1280x800 = false" + Environment.NewLine);
                writer.Write("AutoLoadPatchFiles = false" + Environment.NewLine);
                writer.Write("PatchFileDirectory = ." + Environment.NewLine);
                writer.Write("DataDirectory = data" + Environment.NewLine);
                writer.Write("Debug = false" + Environment.NewLine);
            }
            Helper.DisplayMessage(this, "Settings successfully changed!");
            HideLoader();
        }

        private void BackButton_Click(object sender, EventArgs e) {
            Helper.ShowNewScreen(this, mainMenu);
        }

        private void LeftArrow_Click(object sender, EventArgs e) {
            Helper.ShowNewScreen(this, mainMenu);
        }

        private void Exit_Click(object sender, EventArgs e) {
            mainMenu.Close();
        }

        private void Loader_Paint(object sender, PaintEventArgs e) {
            Helper.RenderLoader(this, e);
        }

        private void NickPatcherMenu_Load(object sender, EventArgs e) {

        }

        private void NickPatcherMenu_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = true;
            Exit_Click(sender, e);
        }
    }
}
