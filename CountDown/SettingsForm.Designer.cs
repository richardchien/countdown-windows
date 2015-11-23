namespace CountDown
{
    partial class SettingsForm
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
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.autoStartCheck = new System.Windows.Forms.CheckBox();
            this.textBox = new System.Windows.Forms.TextBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.changeTextColorBtn = new System.Windows.Forms.Button();
            this.changeDaysColorBtn = new System.Windows.Forms.Button();
            this.changeRectColorBtn = new System.Windows.Forms.Button();
            this.topMostCheck = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(12, 12);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(128, 20);
            this.dateTimePicker.TabIndex = 0;
            this.dateTimePicker.Value = new System.DateTime(2015, 6, 7, 9, 0, 0, 0);
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // autoStartCheck
            // 
            this.autoStartCheck.AutoSize = true;
            this.autoStartCheck.Location = new System.Drawing.Point(12, 64);
            this.autoStartCheck.Name = "autoStartCheck";
            this.autoStartCheck.Size = new System.Drawing.Size(74, 17);
            this.autoStartCheck.TabIndex = 1;
            this.autoStartCheck.Text = "开机启动";
            this.autoStartCheck.UseVisualStyleBackColor = true;
            this.autoStartCheck.CheckedChanged += new System.EventHandler(this.autoStartCheck_CheckedChanged);
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(12, 38);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(128, 20);
            this.textBox.TabIndex = 2;
            this.textBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // changeTextColorBtn
            // 
            this.changeTextColorBtn.Location = new System.Drawing.Point(12, 87);
            this.changeTextColorBtn.Name = "changeTextColorBtn";
            this.changeTextColorBtn.Size = new System.Drawing.Size(128, 23);
            this.changeTextColorBtn.TabIndex = 3;
            this.changeTextColorBtn.Text = "更改文字颜色";
            this.changeTextColorBtn.UseVisualStyleBackColor = true;
            this.changeTextColorBtn.Click += new System.EventHandler(this.changeTextColorBtn_Click);
            // 
            // changeDaysColorBtn
            // 
            this.changeDaysColorBtn.Location = new System.Drawing.Point(12, 145);
            this.changeDaysColorBtn.Name = "changeDaysColorBtn";
            this.changeDaysColorBtn.Size = new System.Drawing.Size(128, 23);
            this.changeDaysColorBtn.TabIndex = 4;
            this.changeDaysColorBtn.Text = "更改倒数日颜色";
            this.changeDaysColorBtn.UseVisualStyleBackColor = true;
            this.changeDaysColorBtn.Click += new System.EventHandler(this.changeDaysColorBtn_Click);
            // 
            // changeRectColorBtn
            // 
            this.changeRectColorBtn.Location = new System.Drawing.Point(12, 116);
            this.changeRectColorBtn.Name = "changeRectColorBtn";
            this.changeRectColorBtn.Size = new System.Drawing.Size(128, 23);
            this.changeRectColorBtn.TabIndex = 5;
            this.changeRectColorBtn.Text = "更改方块颜色";
            this.changeRectColorBtn.UseVisualStyleBackColor = true;
            this.changeRectColorBtn.Click += new System.EventHandler(this.changeRectColorBtn_Click);
            // 
            // topMostCheck
            // 
            this.topMostCheck.AutoSize = true;
            this.topMostCheck.Location = new System.Drawing.Point(90, 64);
            this.topMostCheck.Name = "topMostCheck";
            this.topMostCheck.Size = new System.Drawing.Size(50, 17);
            this.topMostCheck.TabIndex = 6;
            this.topMostCheck.Text = "置顶";
            this.topMostCheck.UseVisualStyleBackColor = true;
            this.topMostCheck.CheckedChanged += new System.EventHandler(this.topMostCheck_CheckedChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(152, 180);
            this.Controls.Add(this.topMostCheck);
            this.Controls.Add(this.changeRectColorBtn);
            this.Controls.Add(this.changeDaysColorBtn);
            this.Controls.Add(this.changeTextColorBtn);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.autoStartCheck);
            this.Controls.Add(this.dateTimePicker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "设置";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.Shown += new System.EventHandler(this.SettingsForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.CheckBox autoStartCheck;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button changeTextColorBtn;
        private System.Windows.Forms.Button changeDaysColorBtn;
        private System.Windows.Forms.Button changeRectColorBtn;
        private System.Windows.Forms.CheckBox topMostCheck;
    }
}