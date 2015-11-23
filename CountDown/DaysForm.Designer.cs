namespace CountDown
{
    partial class DaysForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.leftDaysLabel = new System.Windows.Forms.Label();
            this.locateLabel = new System.Windows.Forms.Label();
            this.rightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.rightClickMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // leftDaysLabel
            // 
            this.leftDaysLabel.BackColor = System.Drawing.Color.Transparent;
            this.leftDaysLabel.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leftDaysLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.leftDaysLabel.Location = new System.Drawing.Point(61, 0);
            this.leftDaysLabel.Name = "leftDaysLabel";
            this.leftDaysLabel.Size = new System.Drawing.Size(134, 60);
            this.leftDaysLabel.TabIndex = 1;
            this.leftDaysLabel.Text = "？天";
            this.leftDaysLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // locateLabel
            // 
            this.locateLabel.AllowDrop = true;
            this.locateLabel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.locateLabel.ContextMenuStrip = this.rightClickMenu;
            this.locateLabel.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.locateLabel.ForeColor = System.Drawing.Color.Gray;
            this.locateLabel.Location = new System.Drawing.Point(0, 0);
            this.locateLabel.Name = "locateLabel";
            this.locateLabel.Size = new System.Drawing.Size(60, 60);
            this.locateLabel.TabIndex = 2;
            this.locateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.locateLabel.DragDrop += new System.Windows.Forms.DragEventHandler(this.locateLabel_DragDrop);
            this.locateLabel.DragEnter += new System.Windows.Forms.DragEventHandler(this.locateLabel_DragEnter);
            this.locateLabel.DoubleClick += new System.EventHandler(this.locateLabel_DoubleClick);
            this.locateLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Days_MouseDown);
            this.locateLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Days_MouseMove);
            this.locateLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Days_MouseUp);
            // 
            // rightClickMenu
            // 
            this.rightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingsMenuItem,
            this.ExitMenuItem});
            this.rightClickMenu.Name = "rightClickMenu";
            this.rightClickMenu.Size = new System.Drawing.Size(99, 48);
            // 
            // SettingsMenuItem
            // 
            this.SettingsMenuItem.Name = "SettingsMenuItem";
            this.SettingsMenuItem.Size = new System.Drawing.Size(98, 22);
            this.SettingsMenuItem.Text = "设置";
            this.SettingsMenuItem.Click += new System.EventHandler(this.SettingsMenuItem_Click);
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.Size = new System.Drawing.Size(98, 22);
            this.ExitMenuItem.Text = "退出";
            this.ExitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox.ContextMenuStrip = this.rightClickMenu;
            this.pictureBox.ImageLocation = "C:\\Users\\Richard\\Dropbox\\Pictures\\Portrait.jpg";
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(60, 60);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            this.pictureBox.DoubleClick += new System.EventHandler(this.locateLabel_DoubleClick);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Days_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Days_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Days_MouseUp);
            // 
            // DaysForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(195, 60);
            this.Controls.Add(this.leftDaysLabel);
            this.Controls.Add(this.locateLabel);
            this.Controls.Add(this.pictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DaysForm";
            this.ShowInTaskbar = false;
            this.Text = "CountDown";
            this.TransparencyKey = System.Drawing.Color.Gainsboro;
            this.Load += new System.EventHandler(this.Days_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.locateLabel_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.locateLabel_DragEnter);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Days_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Days_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Days_MouseUp);
            this.rightClickMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label leftDaysLabel;
        private System.Windows.Forms.Label locateLabel;
        private System.Windows.Forms.ContextMenuStrip rightClickMenu;
        private System.Windows.Forms.ToolStripMenuItem SettingsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
        private System.Windows.Forms.PictureBox pictureBox;


    }
}

