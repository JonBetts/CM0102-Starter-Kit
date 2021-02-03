using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CM0102_Starter_Kit {

    [TypeDescriptionProvider(typeof(AbstractControlDescriptionProvider<HidableForm, Form>))]
    public abstract class HidableForm : Form {
        protected abstract List<Control> GetButtonsToToggle();

        private void ToggleButtons(bool toggle) {
            foreach (Control control in GetButtonsToToggle()) {
                control.Enabled = toggle;
            }
        }

        protected void ShowLoader(PictureBox loader) {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            loader.Visible = true;
            ToggleButtons(false);
        }

        protected void HideLoader(PictureBox loader) {
            this.Cursor = System.Windows.Forms.Cursors.Default;
            ToggleButtons(true);
            loader.Visible = false;
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

        public void ShowNewScreen(Form child) {
            child.Left = this.Left;
            child.Top = this.Top;
            child.Show();
            this.Hide();
        }

        public void RunExternalProcess(PictureBox loader, string externalProcess) {
            ProcessStartInfo psi = new ProcessStartInfo {
                FileName = externalProcess,
                UseShellExecute = false
            };
            Process process = Process.Start(psi);
            //process.Close();
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

