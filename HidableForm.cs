using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CM0102_Starter_Kit {
    abstract partial class HidableForm : Form {
        protected MainMenu mainMenu;
        protected abstract List<Button> GetButtons();

        protected virtual void RefreshForm() { }

        private void ToggleButtons(bool toggle) {
            exit.Enabled = toggle;
            back_button.Enabled = toggle;

            foreach (Button button in GetButtons()) {
                button.Enabled = toggle;
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

        private void RenderLoader(PaintEventArgs e) {
            StringFormat format = new StringFormat {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center
            };
            e.Graphics.DrawString("Please Wait...", new Font("Verdana", 18, FontStyle.Bold), Brushes.White, this.ClientRectangle, format);
        }

        private void Loader_Paint(object sender, PaintEventArgs e) {
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
}

