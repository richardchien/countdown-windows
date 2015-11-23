using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace CountDown
{
    public partial class DaysForm : Form
    {
        public DaysForm()
        {
            InitializeComponent();
        }

        SettingsForm settingsForm;

        private void Days_Load(object sender, EventArgs e)
        {
            this.checkLeftDaysThread = new Thread(checkLeftDaysLoop);
            this.checkLeftDaysThread.IsBackground = true;
            this.checkLeftDaysThread.Start();

            this.Location = CountDown.Properties.Settings.Default.WindowLocation;

            string picPath = CountDown.Properties.Settings.Default.AvatarPath;
            if (File.Exists(picPath))
            {
                this.pictureBox.ImageLocation = picPath;
                this.locateLabel.Visible = false;
            }

            this.locateLabel.Text = CountDown.Properties.Settings.Default.Text;

            this.locateLabel.BackColor = CountDown.Properties.Settings.Default.RectColor;
            this.locateLabel.ForeColor = CountDown.Properties.Settings.Default.TextColor;
            this.leftDaysLabel.ForeColor = CountDown.Properties.Settings.Default.DaysColor;
            this.TransparencyKey = CountDown.Properties.Settings.Default.TransparencyKey;
            this.BackColor = CountDown.Properties.Settings.Default.TransparencyKey;

            this.TopMost = CountDown.Properties.Settings.Default.TopMost;
        }

        #region View Setter

        public void setTextColor(Color c)
        {
            this.locateLabel.ForeColor = c;
        }

        public void setRectColor(Color c)
        {
            this.locateLabel.BackColor = c;
        }

        public void setDaysColor(Color c)
        {
            this.leftDaysLabel.ForeColor = c;
        }

        public void setLocateLabel(string str)
        {
            this.locateLabel.Text = str;
        }

        private delegate void setLeftDaysLabelDelegate(string str);
        private void setLeftDaysLabel(string str)
        {
            if (this.leftDaysLabel.InvokeRequired)
            {
                setLeftDaysLabelDelegate d = setLeftDaysLabel;
                this.leftDaysLabel.Invoke(d, str);
            }
            else
            {
                this.leftDaysLabel.Text = str;
            }
        }

        #endregion

        #region Check Left Days (Main Function)

        Thread checkLeftDaysThread = null;

        public void checkLeftDays()
        {
            DateTime destDate = CountDown.Properties.Settings.Default.DestDate;
            DateTime nowDate = DateTime.Now;
            double destDateOA = destDate.ToOADate();
            double nowDateOA = nowDate.ToOADate();
            double leftTimeOA = destDateOA - nowDateOA;
            setLeftDaysLabel((leftTimeOA - (double)(int)leftTimeOA >= 0.0 ? ((int)leftTimeOA + 1).ToString() : ((int)leftTimeOA).ToString()) + "天");
        }

        private void checkLeftDaysLoop()
        {
            while (true)
            {
                checkLeftDays();
                Thread.Sleep(10000);
            }
        }

        #endregion

        #region Handle Mouse Drag to Move

        private bool mousePressingLeft = false;
        private Point mouseLocation;

        private void handleMouseDrag()
        {
            // 在MouseMove事件中调用此方法
            Point mouseSet = Control.MousePosition;
            mouseSet.Offset(mouseLocation.X, mouseLocation.Y);  //设置移动后的位置
            Location = mouseSet;
        }

        private void Days_MouseDown(object sender, MouseEventArgs e)
        {
            Console.WriteLine("MouseDown");
            // 若为左键则记录
            if (e.Button == MouseButtons.Left)
            {
                this.mousePressingLeft = true;
                // 获取鼠标按下时位置
                this.mouseLocation = new Point(-e.X, -e.Y);
            }
        }

        private void Days_MouseMove(object sender, MouseEventArgs e)
        {
            Console.WriteLine("MouseMove");
            // 左键点住移动，视为移动窗体
            if (mousePressingLeft)
            {
                handleMouseDrag();
            }
            /*else
                // 若不是移动窗体，则激活悬浮窗
                this.Activate();*/
        }

        private void Days_MouseUp(object sender, MouseEventArgs e)
        {
            Console.WriteLine("MouseUp");
            CountDown.Properties.Settings.Default.WindowLocation = this.Location;
            CountDown.Properties.Settings.Default.Save();
            this.mousePressingLeft = false;
        }

        #endregion

        #region Menu Click Event

        private void SettingsMenuItem_Click(object sender, EventArgs e)
        {
            if (this.settingsForm == null || this.settingsForm.IsDisposed)
            {
                this.settingsForm = new SettingsForm();
                this.settingsForm.Owner = this;
                this.settingsForm.Show();
            }
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region Handle Drag to Change Avatar

        private void locateLabel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void locateLabel_DragDrop(object sender, DragEventArgs e)
        {
            Array files = e.Data.GetData(DataFormats.FileDrop) as Array;
            List<string> picPaths = new List<string>();
            foreach (string file in files)
            {
                string extension = Path.GetExtension(file).ToLower().Substring(1);
                if (extension == "png" || extension == "jpg" || extension == "jpeg")
                    picPaths.Add(file);
            }

            if (picPaths.Count > 0)
            {
                this.pictureBox.ImageLocation = picPaths[0];
                CountDown.Properties.Settings.Default.AvatarPath = picPaths[0];
                CountDown.Properties.Settings.Default.Save();

                this.locateLabel.Visible = false;
            }
        }

        private void locateLabel_DoubleClick(object sender, EventArgs e)
        {
            this.pictureBox.ImageLocation = "";
            CountDown.Properties.Settings.Default.AvatarPath = "";
            CountDown.Properties.Settings.Default.Save();

            this.locateLabel.Visible = true;
        }

        #endregion

    }
}
