namespace Festival.Common
{
    partial class CommonInput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommonInput));
            this.btnInput = new System.Windows.Forms.Button();
            this.txtInputText = new System.Windows.Forms.TextBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnBlank = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblColumName = new System.Windows.Forms.Label();
            this.dtInput = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            this.lblShortCutKey = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnInput
            // 
            this.btnInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnInput.ForeColor = System.Drawing.Color.Black;
            this.btnInput.Location = new System.Drawing.Point(211, 85);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(75, 23);
            this.btnInput.TabIndex = 3;
            this.btnInput.Text = "入力(&I)";
            this.btnInput.UseVisualStyleBackColor = false;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // txtInputText
            // 
            this.txtInputText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInputText.BackColor = System.Drawing.Color.White;
            this.txtInputText.ForeColor = System.Drawing.Color.Black;
            this.txtInputText.Location = new System.Drawing.Point(101, 51);
            this.txtInputText.Name = "txtInputText";
            this.txtInputText.Size = new System.Drawing.Size(428, 20);
            this.txtInputText.TabIndex = 0;
            // 
            // cboStatus
            // 
            this.cboStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboStatus.ForeColor = System.Drawing.Color.Black;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cboStatus.Location = new System.Drawing.Point(399, 51);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(123, 21);
            this.cboStatus.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "対象カラム名：";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(454, 85);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "閉じる";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Location = new System.Drawing.Point(373, 85);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "クリア(C)";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnBlank
            // 
            this.btnBlank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBlank.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnBlank.ForeColor = System.Drawing.Color.Black;
            this.btnBlank.Location = new System.Drawing.Point(292, 85);
            this.btnBlank.Name = "btnBlank";
            this.btnBlank.Size = new System.Drawing.Size(75, 23);
            this.btnBlank.TabIndex = 4;
            this.btnBlank.Text = "空欄(N)";
            this.btnBlank.UseVisualStyleBackColor = false;
            this.btnBlank.Click += new System.EventHandler(this.btnBlank_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "入力文字";
            // 
            // lblColumName
            // 
            this.lblColumName.AutoSize = true;
            this.lblColumName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblColumName.ForeColor = System.Drawing.Color.Black;
            this.lblColumName.Location = new System.Drawing.Point(98, 21);
            this.lblColumName.Name = "lblColumName";
            this.lblColumName.Size = new System.Drawing.Size(90, 13);
            this.lblColumName.TabIndex = 0;
            this.lblColumName.Text = "....columnName...";
            // 
            // dtInput
            // 
            this.dtInput.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.dtInput.BackgroundStyle.Class = "TextBoxBorder";
            this.dtInput.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtInput.ButtonClear.Text = "X";
            this.dtInput.ButtonClear.Visible = true;
            this.dtInput.Culture = new System.Globalization.CultureInfo("ja-JP");
            this.dtInput.DisabledBackColor = System.Drawing.Color.White;
            this.dtInput.ForeColor = System.Drawing.Color.Black;
            this.dtInput.Location = new System.Drawing.Point(262, 51);
            this.dtInput.Mask = "0000/00/00";
            this.dtInput.Name = "dtInput";
            this.dtInput.Size = new System.Drawing.Size(174, 19);
            this.dtInput.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtInput.TabIndex = 9;
            this.dtInput.Text = "";
            // 
            // lblShortCutKey
            // 
            this.lblShortCutKey.AutoSize = true;
            this.lblShortCutKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblShortCutKey.ForeColor = System.Drawing.Color.Green;
            this.lblShortCutKey.Location = new System.Drawing.Point(12, 90);
            this.lblShortCutKey.Name = "lblShortCutKey";
            this.lblShortCutKey.Size = new System.Drawing.Size(179, 13);
            this.lblShortCutKey.TabIndex = 59;
            this.lblShortCutKey.Text = "日付項目でCtrl+D　→　本日の日付";
            // 
            // CommonInput
            // 
            this.AcceptButton = this.btnInput;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 120);
            this.Controls.Add(this.lblShortCutKey);
            this.Controls.Add(this.txtInputText);
            this.Controls.Add(this.dtInput);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnBlank);
            this.Controls.Add(this.btnInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblColumName);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CommonInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "一括入力";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CommonInPut_FormClosing);
            this.Load += new System.EventHandler(this.BulkBatchInPut_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblColumName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInputText;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.Button btnBlank;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboStatus;
        private DevComponents.DotNetBar.Controls.MaskedTextBoxAdv dtInput;
        private System.Windows.Forms.Label lblShortCutKey;
    }
}