using System;
using System.Drawing;
using System.Windows.Forms;
using CountDown.Properties;
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
            var loca = ((DaysForm) Owner).Location;
            loca.Y += 80;
            Location = loca;
        }

        private void SettingsForm_Shown(object sender, EventArgs e)
        {
            dateTimePicker.Value = Settings.Default.DestDate;
            textBox.Text = Settings.Default.Text;
            autoStartCheck.Checked = StartupRegistry.HasSetStartup("CountDown");
            topMostCheck.Checked = Settings.Default.TopMost;
        }

        #region Handle Settings Change

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.DestDate = dateTimePicker.Value;
            Settings.Default.Save();
            ((DaysForm) Owner).checkLeftDays();
        }

        private void autoStartCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (autoStartCheck.Checked)
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
            ((DaysForm) Owner).TopMost = topMostCheck.Checked;
            Settings.Default.TopMost = topMostCheck.Checked;
            Settings.Default.Save();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            ((DaysForm) Owner).setLocateLabel(textBox.Text);
            Settings.Default.Text = textBox.Text;
            Settings.Default.Save();
        }

        #region Color Change

        private void changeTextColorBtn_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.TextColor;
            colorDialog.ShowDialog();
            ((DaysForm) Owner).setTextColor(colorDialog.Color);
            Settings.Default.TextColor = colorDialog.Color;
            Settings.Default.Save();
        }

        private void changeRectColorBtn_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.RectColor;
            colorDialog.ShowDialog();
            ((DaysForm) Owner).setRectColor(colorDialog.Color);
            Settings.Default.RectColor = colorDialog.Color;
            Settings.Default.Save();
        }

        private void changeDaysColorBtn_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.DaysColor;
            colorDialog.ShowDialog();
            ((DaysForm) Owner).setDaysColor(colorDialog.Color);
            Settings.Default.DaysColor = colorDialog.Color;
            Settings.Default.Save();

            adjustTransparencyKeyToAdaptToNewColors();
        }

        private void adjustTransparencyKeyToAdaptToNewColors()
        {
            var rectC = Settings.Default.RectColor;
            var daysC = Settings.Default.DaysColor;
            int r = daysC.R;
            int g = daysC.G;
            int b = daysC.B;
            r += r < 255 ? 1 : -1;
            g += g < 255 ? 1 : -1;
            b += b < 255 ? 1 : -1;
            var tranKey = Color.FromArgb(r, g, b);
            if (tranKey.Equals(rectC))
            {
                r += r < 255 ? 1 : -1;
                tranKey = Color.FromArgb(r, g, b);
            }
            ((DaysForm) Owner).TransparencyKey = tranKey;
            ((DaysForm) Owner).BackColor = tranKey;
            Settings.Default.TransparencyKey = tranKey;
            Settings.Default.Save();
        }

        #endregion

        #endregion
    }
}