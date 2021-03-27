namespace Festival.DBTab.FesContent
{
    partial class FesContentImportList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FesContentImportList));
            this.btnImport = new System.Windows.Forms.Button();
            this.btnClosed = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdSongInFileExcel = new System.Windows.Forms.RadioButton();
            this.rdSongInFileText = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdNoneReplaceNull = new System.Windows.Forms.RadioButton();
            this.rdReplaceNull = new System.Windows.Forms.RadioButton();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.txtInputFilePath = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnImport.ForeColor = System.Drawing.Color.Black;
            this.btnImport.Location = new System.Drawing.Point(416, 48);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 5;
            this.btnImport.Text = "入力(&F5)";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnClosed
            // 
            this.btnClosed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClosed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnClosed.ForeColor = System.Drawing.Color.Black;
            this.btnClosed.Location = new System.Drawing.Point(497, 48);
            this.btnClosed.Name = "btnClosed";
            this.btnClosed.Size = new System.Drawing.Size(75, 23);
            this.btnClosed.TabIndex = 6;
            this.btnClosed.Text = "閉じる";
            this.btnClosed.UseVisualStyleBackColor = false;
            this.btnClosed.Click += new System.EventHandler(this.btnClosed_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox2.Controls.Add(this.rdSongInFileExcel);
            this.groupBox2.Controls.Add(this.rdSongInFileText);
            this.groupBox2.Enabled = false;
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(320, 59);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(252, 56);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "入力リスト";
            this.groupBox2.Visible = false;
            // 
            // rdSongInFileExcel
            // 
            this.rdSongInFileExcel.AutoSize = true;
            this.rdSongInFileExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rdSongInFileExcel.ForeColor = System.Drawing.Color.Black;
            this.rdSongInFileExcel.Location = new System.Drawing.Point(158, 24);
            this.rdSongInFileExcel.Name = "rdSongInFileExcel";
            this.rdSongInFileExcel.Size = new System.Drawing.Size(73, 17);
            this.rdSongInFileExcel.TabIndex = 0;
            this.rdSongInFileExcel.Text = "更新項目";
            this.rdSongInFileExcel.UseVisualStyleBackColor = false;
            this.rdSongInFileExcel.CheckedChanged += new System.EventHandler(this.rdSongInFileExcel_CheckedChanged);
            // 
            // rdSongInFileText
            // 
            this.rdSongInFileText.AutoSize = true;
            this.rdSongInFileText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rdSongInFileText.Checked = true;
            this.rdSongInFileText.ForeColor = System.Drawing.Color.Black;
            this.rdSongInFileText.Location = new System.Drawing.Point(50, 24);
            this.rdSongInFileText.Name = "rdSongInFileText";
            this.rdSongInFileText.Size = new System.Drawing.Size(85, 17);
            this.rdSongInFileText.TabIndex = 0;
            this.rdSongInFileText.TabStop = true;
            this.rdSongInFileText.Text = "録音可能曲";
            this.rdSongInFileText.UseVisualStyleBackColor = false;
            this.rdSongInFileText.CheckedChanged += new System.EventHandler(this.rdSongInFileText_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox1.Controls.Add(this.rdNoneReplaceNull);
            this.groupBox1.Controls.Add(this.rdReplaceNull);
            this.groupBox1.Enabled = false;
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(15, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 56);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "NULL上書き";
            this.groupBox1.Visible = false;
            // 
            // rdNoneReplaceNull
            // 
            this.rdNoneReplaceNull.AutoSize = true;
            this.rdNoneReplaceNull.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rdNoneReplaceNull.ForeColor = System.Drawing.Color.Black;
            this.rdNoneReplaceNull.Location = new System.Drawing.Point(103, 24);
            this.rdNoneReplaceNull.Name = "rdNoneReplaceNull";
            this.rdNoneReplaceNull.Size = new System.Drawing.Size(54, 17);
            this.rdNoneReplaceNull.TabIndex = 0;
            this.rdNoneReplaceNull.Text = "しない";
            this.rdNoneReplaceNull.UseVisualStyleBackColor = false;
            // 
            // rdReplaceNull
            // 
            this.rdReplaceNull.AutoSize = true;
            this.rdReplaceNull.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rdReplaceNull.Checked = true;
            this.rdReplaceNull.ForeColor = System.Drawing.Color.Black;
            this.rdReplaceNull.Location = new System.Drawing.Point(20, 24);
            this.rdReplaceNull.Name = "rdReplaceNull";
            this.rdReplaceNull.Size = new System.Drawing.Size(44, 17);
            this.rdReplaceNull.TabIndex = 0;
            this.rdReplaceNull.TabStop = true;
            this.rdReplaceNull.Text = "する";
            this.rdReplaceNull.UseVisualStyleBackColor = false;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnOpenFile.ForeColor = System.Drawing.Color.Black;
            this.btnOpenFile.Location = new System.Drawing.Point(541, 17);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(31, 23);
            this.btnOpenFile.TabIndex = 2;
            this.btnOpenFile.Text = "...";
            this.btnOpenFile.UseVisualStyleBackColor = false;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // txtInputFilePath
            // 
            this.txtInputFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInputFilePath.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtInputFilePath.Border.Class = "TextBoxBorder";
            this.txtInputFilePath.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtInputFilePath.DisabledBackColor = System.Drawing.Color.White;
            this.txtInputFilePath.ForeColor = System.Drawing.Color.Black;
            this.txtInputFilePath.Location = new System.Drawing.Point(83, 18);
            this.txtInputFilePath.Name = "txtInputFilePath";
            this.txtInputFilePath.PreventEnterBeep = true;
            this.txtInputFilePath.ReadOnly = true;
            this.txtInputFilePath.Size = new System.Drawing.Size(452, 20);
            this.txtInputFilePath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "入力ファイル\t\t\t\t\t\t";
            // 
            // FesContentImportList
            // 
            this.AcceptButton = this.btnImport;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 74);
            this.Controls.Add(this.btnClosed);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.txtInputFilePath);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FesContentImportList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "リスト取込";
            this.Load += new System.EventHandler(this.ImportList_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtInputFilePath;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdNoneReplaceNull;
        private System.Windows.Forms.RadioButton rdReplaceNull;
        private System.Windows.Forms.RadioButton rdSongInFileExcel;
        private System.Windows.Forms.RadioButton rdSongInFileText;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnClosed;
    }
}