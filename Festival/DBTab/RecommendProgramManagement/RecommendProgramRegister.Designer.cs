namespace Festival.DBTab.RecommendProgramManagement
{
    partial class RecommendProgramRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecommendProgramRegister));
            this.btnClearn = new DevComponents.DotNetBar.ButtonX();
            this.btnAddNew = new DevComponents.DotNetBar.ButtonX();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt備考 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtプログラム名 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label4 = new System.Windows.Forms.Label();
            this.lblプログラム名 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClearn
            // 
            this.btnClearn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClearn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClearn.Location = new System.Drawing.Point(378, 120);
            this.btnClearn.Name = "btnClearn";
            this.btnClearn.Size = new System.Drawing.Size(75, 23);
            this.btnClearn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClearn.TabIndex = 3;
            this.btnClearn.Text = "削除(&C)";
            this.btnClearn.Click += new System.EventHandler(this.btnClearn_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNew.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddNew.Location = new System.Drawing.Point(297, 120);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(75, 23);
            this.btnAddNew.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddNew.TabIndex = 2;
            this.btnAddNew.Text = "保存(&S)";
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Location = new System.Drawing.Point(459, 120);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "閉じる(&E)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txt備考);
            this.groupBox1.Controls.Add(this.txtプログラム名);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblプログラム名);
            this.groupBox1.Location = new System.Drawing.Point(2, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(532, 109);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txt備考
            // 
            this.txt備考.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt備考.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt備考.Border.Class = "TextBoxBorder";
            this.txt備考.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt備考.DisabledBackColor = System.Drawing.Color.White;
            this.txt備考.ForeColor = System.Drawing.Color.Black;
            this.txt備考.Location = new System.Drawing.Point(82, 71);
            this.txt備考.MaxLength = 255;
            this.txt備考.Name = "txt備考";
            this.txt備考.PreventEnterBeep = true;
            this.txt備考.Size = new System.Drawing.Size(439, 20);
            this.txt備考.TabIndex = 1;
            // 
            // txtプログラム名
            // 
            this.txtプログラム名.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtプログラム名.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtプログラム名.Border.Class = "TextBoxBorder";
            this.txtプログラム名.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtプログラム名.DisabledBackColor = System.Drawing.Color.White;
            this.txtプログラム名.ForeColor = System.Drawing.Color.Black;
            this.txtプログラム名.Location = new System.Drawing.Point(82, 39);
            this.txtプログラム名.MaxLength = 255;
            this.txtプログラム名.Name = "txtプログラム名";
            this.txtプログラム名.PreventEnterBeep = true;
            this.txtプログラム名.Size = new System.Drawing.Size(439, 20);
            this.txtプログラム名.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "備考";
            // 
            // lblプログラム名
            // 
            this.lblプログラム名.AutoSize = true;
            this.lblプログラム名.Location = new System.Drawing.Point(12, 43);
            this.lblプログラム名.Name = "lblプログラム名";
            this.lblプログラム名.Size = new System.Drawing.Size(64, 13);
            this.lblプログラム名.TabIndex = 0;
            this.lblプログラム名.Text = "プログラム名";
            // 
            // RecommendProgramRegister
            // 
            this.AcceptButton = this.btnAddNew;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 143);
            this.Controls.Add(this.btnClearn);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RecommendProgramRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "歌手を新規に登録する";
            this.Load += new System.EventHandler(this.SingerRegister_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.ButtonX btnAddNew;
        private DevComponents.DotNetBar.ButtonX btnClearn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblプログラム名;
        private DevComponents.DotNetBar.Controls.TextBoxX txt備考;
        private DevComponents.DotNetBar.Controls.TextBoxX txtプログラム名;
    }
}