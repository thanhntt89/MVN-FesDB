using Festival.DBTab.SingerIdChangeManagement;

namespace Festival.DBTab.SingerManagement
{
    partial class SingerRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SingerRegister));
            this.btnClearn = new DevComponents.DotNetBar.ButtonX();
            this.btnAddNew = new DevComponents.DotNetBar.ButtonX();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt歌手名ソート用英数 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt歌手名ソート用カナ = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt歌手名検索用カナ = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt歌手名 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtFes独自歌手ID = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFes独自歌手ID = new System.Windows.Forms.Label();
            this.lbl歌手名ソート用英数 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClearn
            // 
            this.btnClearn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClearn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClearn.Location = new System.Drawing.Point(378, 185);
            this.btnClearn.Name = "btnClearn";
            this.btnClearn.Size = new System.Drawing.Size(75, 23);
            this.btnClearn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClearn.TabIndex = 11;
            this.btnClearn.Text = "削除(&C)";
            this.btnClearn.Click += new System.EventHandler(this.btnClearn_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNew.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddNew.Location = new System.Drawing.Point(297, 185);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(75, 23);
            this.btnAddNew.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddNew.TabIndex = 10;
            this.btnAddNew.Text = "保存(&S)";
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Location = new System.Drawing.Point(459, 185);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "閉じる(&E)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txt歌手名ソート用英数);
            this.groupBox1.Controls.Add(this.txt歌手名ソート用カナ);
            this.groupBox1.Controls.Add(this.txt歌手名検索用カナ);
            this.groupBox1.Controls.Add(this.txt歌手名);
            this.groupBox1.Controls.Add(this.txtFes独自歌手ID);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblFes独自歌手ID);
            this.groupBox1.Controls.Add(this.lbl歌手名ソート用英数);
            this.groupBox1.Location = new System.Drawing.Point(2, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(532, 174);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(97, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "*";
            // 
            // txt歌手名ソート用英数
            // 
            this.txt歌手名ソート用英数.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt歌手名ソート用英数.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt歌手名ソート用英数.Border.Class = "TextBoxBorder";
            this.txt歌手名ソート用英数.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt歌手名ソート用英数.DisabledBackColor = System.Drawing.Color.White;
            this.txt歌手名ソート用英数.ForeColor = System.Drawing.Color.Black;
            this.txt歌手名ソート用英数.Location = new System.Drawing.Point(122, 142);
            this.txt歌手名ソート用英数.MaxLength = 255;
            this.txt歌手名ソート用英数.Name = "txt歌手名ソート用英数";
            this.txt歌手名ソート用英数.PreventEnterBeep = true;
            this.txt歌手名ソート用英数.Size = new System.Drawing.Size(397, 20);
            this.txt歌手名ソート用英数.TabIndex = 4;
            // 
            // txt歌手名ソート用カナ
            // 
            this.txt歌手名ソート用カナ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt歌手名ソート用カナ.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt歌手名ソート用カナ.Border.Class = "TextBoxBorder";
            this.txt歌手名ソート用カナ.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt歌手名ソート用カナ.DisabledBackColor = System.Drawing.Color.White;
            this.txt歌手名ソート用カナ.ForeColor = System.Drawing.Color.Black;
            this.txt歌手名ソート用カナ.Location = new System.Drawing.Point(122, 110);
            this.txt歌手名ソート用カナ.MaxLength = 255;
            this.txt歌手名ソート用カナ.Name = "txt歌手名ソート用カナ";
            this.txt歌手名ソート用カナ.PreventEnterBeep = true;
            this.txt歌手名ソート用カナ.Size = new System.Drawing.Size(397, 20);
            this.txt歌手名ソート用カナ.TabIndex = 3;
            // 
            // txt歌手名検索用カナ
            // 
            this.txt歌手名検索用カナ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt歌手名検索用カナ.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt歌手名検索用カナ.Border.Class = "TextBoxBorder";
            this.txt歌手名検索用カナ.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt歌手名検索用カナ.DisabledBackColor = System.Drawing.Color.White;
            this.txt歌手名検索用カナ.ForeColor = System.Drawing.Color.Black;
            this.txt歌手名検索用カナ.Location = new System.Drawing.Point(122, 78);
            this.txt歌手名検索用カナ.MaxLength = 255;
            this.txt歌手名検索用カナ.Name = "txt歌手名検索用カナ";
            this.txt歌手名検索用カナ.PreventEnterBeep = true;
            this.txt歌手名検索用カナ.Size = new System.Drawing.Size(397, 20);
            this.txt歌手名検索用カナ.TabIndex = 2;
            // 
            // txt歌手名
            // 
            this.txt歌手名.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt歌手名.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt歌手名.Border.Class = "TextBoxBorder";
            this.txt歌手名.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt歌手名.DisabledBackColor = System.Drawing.Color.White;
            this.txt歌手名.ForeColor = System.Drawing.Color.Black;
            this.txt歌手名.Location = new System.Drawing.Point(122, 46);
            this.txt歌手名.MaxLength = 255;
            this.txt歌手名.Name = "txt歌手名";
            this.txt歌手名.PreventEnterBeep = true;
            this.txt歌手名.Size = new System.Drawing.Size(397, 20);
            this.txt歌手名.TabIndex = 1;
            // 
            // txtFes独自歌手ID
            // 
            this.txtFes独自歌手ID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFes独自歌手ID.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtFes独自歌手ID.Border.Class = "TextBoxBorder";
            this.txtFes独自歌手ID.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFes独自歌手ID.DisabledBackColor = System.Drawing.Color.White;
            this.txtFes独自歌手ID.ForeColor = System.Drawing.Color.Black;
            this.txtFes独自歌手ID.Location = new System.Drawing.Point(122, 14);
            this.txtFes独自歌手ID.MaxLength = 9;
            this.txtFes独自歌手ID.Name = "txtFes独自歌手ID";
            this.txtFes独自歌手ID.PreventEnterBeep = true;
            this.txtFes独自歌手ID.Size = new System.Drawing.Size(397, 20);
            this.txtFes独自歌手ID.TabIndex = 0;
            this.txtFes独自歌手ID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtInputText_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "歌手名ソート用カナ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "歌手名検索用カナ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "歌手名";
            // 
            // lblFes独自歌手ID
            // 
            this.lblFes独自歌手ID.AutoSize = true;
            this.lblFes独自歌手ID.Location = new System.Drawing.Point(10, 18);
            this.lblFes独自歌手ID.Name = "lblFes独自歌手ID";
            this.lblFes独自歌手ID.Size = new System.Drawing.Size(83, 13);
            this.lblFes独自歌手ID.TabIndex = 0;
            this.lblFes独自歌手ID.Text = "Fes独自歌手ID";
            // 
            // lbl歌手名ソート用英数
            // 
            this.lbl歌手名ソート用英数.AutoSize = true;
            this.lbl歌手名ソート用英数.Location = new System.Drawing.Point(10, 146);
            this.lbl歌手名ソート用英数.Name = "lbl歌手名ソート用英数";
            this.lbl歌手名ソート用英数.Size = new System.Drawing.Size(106, 13);
            this.lbl歌手名ソート用英数.TabIndex = 0;
            this.lbl歌手名ソート用英数.Text = "歌手名ソート用英数";
            // 
            // SingerRegister
            // 
            this.AcceptButton = this.btnAddNew;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 208);
            this.Controls.Add(this.btnClearn);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SingerRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "歌手を新規に登録する";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SingerRegister_FormClosing);
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblFes独自歌手ID;
        private System.Windows.Forms.Label lbl歌手名ソート用英数;
        private DevComponents.DotNetBar.Controls.TextBoxX txt歌手名ソート用英数;
        private DevComponents.DotNetBar.Controls.TextBoxX txt歌手名ソート用カナ;
        private DevComponents.DotNetBar.Controls.TextBoxX txt歌手名検索用カナ;
        private DevComponents.DotNetBar.Controls.TextBoxX txt歌手名;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFes独自歌手ID;
        private System.Windows.Forms.Label label11;
    }
}