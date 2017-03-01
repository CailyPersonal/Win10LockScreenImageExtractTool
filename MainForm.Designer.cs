namespace Win10LockScreenImageExtractTool
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Browse = new System.Windows.Forms.Button();
            this.OK = new System.Windows.Forms.Button();
            this.textBox_Target = new System.Windows.Forms.TextBox();
            this.label_Info = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Browse
            // 
            this.Browse.Location = new System.Drawing.Point(259, 83);
            this.Browse.Name = "Browse";
            this.Browse.Size = new System.Drawing.Size(75, 23);
            this.Browse.TabIndex = 0;
            this.Browse.Text = "浏览";
            this.Browse.UseVisualStyleBackColor = true;
            this.Browse.Click += new System.EventHandler(this.Browse_Click);
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(349, 46);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 60);
            this.OK.TabIndex = 2;
            this.OK.Text = "提取";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // textBox_Target
            // 
            this.textBox_Target.Location = new System.Drawing.Point(14, 48);
            this.textBox_Target.Name = "textBox_Target";
            this.textBox_Target.Size = new System.Drawing.Size(320, 21);
            this.textBox_Target.TabIndex = 3;
            // 
            // label_Info
            // 
            this.label_Info.AutoSize = true;
            this.label_Info.Location = new System.Drawing.Point(16, 25);
            this.label_Info.Name = "label_Info";
            this.label_Info.Size = new System.Drawing.Size(29, 12);
            this.label_Info.TabIndex = 4;
            this.label_Info.Text = "信息";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(13, 7);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(411, 10);
            this.progressBar.TabIndex = 5;
            this.progressBar.Visible = false;
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Checked = true;
            this.checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox.Location = new System.Drawing.Point(15, 87);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(120, 16);
            this.checkBox.TabIndex = 6;
            this.checkBox.Text = "完成后打开文件夹";
            this.checkBox.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(434, 123);
            this.Controls.Add(this.checkBox);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.label_Info);
            this.Controls.Add(this.textBox_Target);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.Browse);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Win 10 锁屏图片提取工具 v1.0";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Browse;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.TextBox textBox_Target;
        private System.Windows.Forms.Label label_Info;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.CheckBox checkBox;
    }
}

