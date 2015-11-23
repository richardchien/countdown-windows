using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RC;

namespace CountDown
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            Point loca = ((DaysForm)this.Owner).Location;
            loca.Y += 80;
            this.Location = loca;
        }

        private void SettingsForm_Shown(object sender, EventArgs e)
        {
            this.dateTimePicker.Value = CountDown.Properties.Settings.Default.DestDate;
            this.textBox.Text = CountDown.Properties.Settings.Default.Text;
            this.autoStartCheck.Checked = StartupRegistry.HasSetStartup("CountDown");
            this.topMostCheck.Checked = CountDown.Properties.Settings.Default.TopMost;
        }

        #region Handle Settings Change

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            CountDown.Properties.Settings.Default.DestDate = this.dateTimePicker.Value;
            CountDown.Properties.Settings.Default.Save();
            ((DaysForm)this.Owner).checkLeftDays();
        }

        private void autoStartCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (this.autoStartCheck.Checked)
            {
                StartupRegistry.SetStartup("CountDown");
            }
            else
            {
                StartupRegistry.UnsetStartup("CountDown");
            }
        }

        private void topMostCheck_CheckedChanged(object sender, EventArgs e)
        {
            ((DaysForm)this.Owner).TopMost = this.topMostCheck.Checked;
            CountDown.Properties.Settings.Default.TopMost = this.topMostCheck.Checked;
            CountDown.Properties.Settings.Default.Save();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            ((DaysForm)this.Owner).setLocateLabel(this.textBox.Text);
            CountDown.Properties.Settings.Default.Text = this.textBox.Text;
            CountDown.Properties.Settings.Default.Save();
        }

        #region Color Change

        private void changeTextColorBtn_Click(object sender, EventArgs e)
        {
            this.colorDialog.Color = CountDown.Properties.Settings.Default.TextColor;
            this.colorDialog.ShowDialog();
            ((DaysForm)this.Owner).setTextColor(this.colorDialog.Color);
            CountDown.Properties.Settings.Default.TextColor = this.colorDialog.Color;
            CountDown.Properties.Settings.Default.Save();
        }

        private void changeRectColorBtn_Click(object sender, EventArgs e)
        {
            this.colorDialog.Color = CountDown.Properties.Settings.Default.RectColor;
            this.colorDialog.ShowDialog();
            ((DaysForm)this.Owner).setRectColor(this.colorDialog.Color);
            CountDown.Properties.Settings.Default.RectColor = this.colorDialog.Color;
            CountDown.Properties.Settings.Default.Save();
        }

        private void changeDaysColorBtn_Click(object sender, EventArgs e)
        {
            this.colorDialog.Color = CountDown.Properties.Settings.Default.DaysColor;
            this.colorDialog.ShowDialog();
            ((DaysForm)this.Owner).setDaysColor(this.colorDialog.Color);
            CountDown.Properties.Settings.Default.DaysColor = this.colorDialog.Color;
            CountDown.Properties.Settings.Default.Save();

            adjustTransparencyKeyToAdaptToNewColors();
        }

        private void adjustTransparencyKeyToAdaptToNewColors()
        {
            Color rectC = CountDown.Properties.Settings.Default.RectColor;
            Color daysC = CountDown.Properties.Settings.Default.DaysColor;
            int r = daysC.R;
            int g = daysC.G;
            int b = daysC.B;
            r += r < 255 ? 1 : -1;
            g += g < 255 ? 1 : -1;
            b += b < 255 ? 1 : -1;
            Color tranKey = Color.FromArgb(r, g, b);
            if (tranKey.Equals(rectC))
            {
                r += r < 255 ? 1 : -1;
                tranKey = Color.FromArgb(r, g, b);
            }
            ((DaysForm)this.Owner).TransparencyKey = tranKey;
            ((DaysForm)this.Owner).BackColor = tranKey;
            CountDown.Properties.Settings.Default.TransparencyKey = tranKey;
            CountDown.Properties.Settings.Default.Save();
        }

        #endregion

        #endregion
    }
}
