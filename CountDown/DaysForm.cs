using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using CountDown.Properties;

namespace CountDown
{
    public partial class DaysForm : Form
    {
        private SettingsForm settingsForm;

        public DaysForm()
        {
            InitializeComponent();
        }

        private void Days_Load(object sender, EventArgs e)
        {
            checkLeftDaysThread = new Thread(checkLeftDaysLoop);
            checkLeftDaysThread.IsBackground = true;
            checkLeftDaysThread.Start();

            Location = Settings.Default.WindowLocation;

            var picPath = Settings.Default.AvatarPath;
            if (File.Exists(picPath))
            {
                pictureBox.ImageLocation = picPath;
                locateLabel.Visible = false;
            }

            locateLabel.Text = Settings.Default.Text;

            locateLabel.BackColor = Settings.Default.RectColor;
            locateLabel.ForeColor = Settings.Default.TextColor;
            leftDaysLabel.ForeColor = Settings.Default.DaysColor;
            TransparencyKey = Settings.Default.TransparencyKey;
            BackColor = Settings.Default.TransparencyKey;

            TopMost = Settings.Default.TopMost;
        }

        #region View Setter

        public void setTextColor(Color c)
        {
            locateLabel.ForeColor = c;
        }

        public void setRectColor(Color c)
        {
            locateLabel.BackColor = c;
        }

        public void setDaysColor(Color c)
        {
            leftDaysLabel.ForeColor = c;
        }

        public void setLocateLabel(string str)
        {
            locateLabel.Text = str;
        }

        private delegate void setLeftDaysLabelDelegate(string str);

        private void setLeftDaysLabel(string str)
        {
            if (leftDaysLabel.InvokeRequired)
            {
                setLeftDaysLabelDelegate d = setLeftDaysLabel;
                leftDaysLabel.Invoke(d, str);
            }
            else
            {
                leftDaysLabel.Text = str;
            }
        }

        #endregion

        #region Check Left Days (Main Function)

        private Thread checkLeftDaysThread;

        public void checkLeftDays()
        {
            var destDate = Settings.Default.DestDate;
            var nowDate = DateTime.Now;
            var destDateOA = destDate.ToOADate();
            var nowDateOA = nowDate.ToOADate();
            var leftTimeOA = destDateOA - nowDateOA;
            setLeftDaysLabel((leftTimeOA - (double) (int) leftTimeOA >= 0.0
                ? ((int) leftTimeOA + 1).ToString()
                : ((int) leftTimeOA).ToString()) + "天");
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

        private bool mousePressingLeft;
        private Point mouseLocation;

        private void handleMouseDrag()
        {
            // 在MouseMove事件中调用此方法
            var mouseSet = MousePosition;
            mouseSet.Offset(mouseLocation.X, mouseLocation.Y); //设置移动后的位置
            Location = mouseSet;
        }

        private void Days_MouseDown(object sender, MouseEventArgs e)
        {
            Console.WriteLine("MouseDown");
            // 若为左键则记录
            if (e.Button == MouseButtons.Left)
            {
                mousePressingLeft = true;
                // 获取鼠标按下时位置
                mouseLocation = new Point(-e.X, -e.Y);
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
            Settings.Default.WindowLocation = Location;
            Settings.Default.Save();
            mousePressingLeft = false;
        }

        #endregion

        #region Menu Click Event

        private void SettingsMenuItem_Click(object sender, EventArgs e)
        {
            if (settingsForm == null || settingsForm.IsDisposed)
            {
                settingsForm = new SettingsForm();
                settingsForm.Owner = this;
                settingsForm.Show();
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
            var files = e.Data.GetData(DataFormats.FileDrop) as Array;
            var picPaths = new List<string>();
            foreach (string file in files)
            {
                var extension = Path.GetExtension(file).ToLower().Substring(1);
                if (extension == "png" || extension == "jpg" || extension == "jpeg")
                    picPaths.Add(file);
            }

            if (picPaths.Count > 0)
            {
                pictureBox.ImageLocation = picPaths[0];
                Settings.Default.AvatarPath = picPaths[0];
                Settings.Default.Save();

                locateLabel.Visible = false;
            }
        }

        private void locateLabel_DoubleClick(object sender, EventArgs e)
        {
            pictureBox.ImageLocation = "";
            Settings.Default.AvatarPath = "";
            Settings.Default.Save();

            locateLabel.Visible = true;
        }

        #endregion
    }
}