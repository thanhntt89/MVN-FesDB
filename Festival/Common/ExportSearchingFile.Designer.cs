namespace Festival.Common
{
    partial class ExportSearchingFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportSearchingFile));
            this.bntExport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radFilterRecord = new System.Windows.Forms.RadioButton();
            this.radCheckOnRecord = new System.Windows.Forms.RadioButton();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.txtExportFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboExportContent = new System.Windows.Forms.ComboBox();
            this.ExportContent = new System.Windows.Forms.Label();
            this.radTSVExport = new System.Windows.Forms.RadioButton();
            this.radExcelExport = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bntExport
            // 
            this.bntExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bntExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bntExport.ForeColor = System.Drawing.Color.Black;
            this.bntExport.Location = new System.Drawing.Point(371, 191);
            this.bntExport.Name = "bntExport";
            this.bntExport.Size = new System.Drawing.Size(75, 23);
            this.bntExport.TabIndex = 7;
            this.bntExport.Text = "出力(O)";
            this.bntExport.UseVisualStyleBackColor = false;
            this.bntExport.Click += new System.EventHandler(this.bntExport_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(452, 191);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "閉じる";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox1.Controls.Add(this.radFilterRecord);
            this.groupBox1.Controls.Add(this.radCheckOnRecord);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 126);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(515, 55);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "対象レコード";
            // 
            // radFilterRecord
            // 
            this.radFilterRecord.AutoSize = true;
            this.radFilterRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.radFilterRecord.ForeColor = System.Drawing.Color.Black;
            this.radFilterRecord.Location = new System.Drawing.Point(180, 19);
            this.radFilterRecord.Name = "radFilterRecord";
            this.radFilterRecord.Size = new System.Drawing.Size(107, 17);
            this.radFilterRecord.TabIndex = 6;
            this.radFilterRecord.TabStop = true;
            this.radFilterRecord.Text = "表示中のレコード";
            this.radFilterRecord.UseVisualStyleBackColor = false;
            // 
            // radCheckOnRecord
            // 
            this.radCheckOnRecord.AutoSize = true;
            this.radCheckOnRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.radCheckOnRecord.ForeColor = System.Drawing.Color.Black;
            this.radCheckOnRecord.Location = new System.Drawing.Point(19, 19);
            this.radCheckOnRecord.Name = "radCheckOnRecord";
            this.radCheckOnRecord.Size = new System.Drawing.Size(142, 17);
            this.radCheckOnRecord.TabIndex = 5;
            this.radCheckOnRecord.TabStop = true;
            this.radCheckOnRecord.Text = "選択チェックONのレコード";
            this.radCheckOnRecord.UseVisualStyleBackColor = false;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnOpenFile.ForeColor = System.Drawing.Color.Black;
            this.btnOpenFile.Location = new System.Drawing.Point(498, 88);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(29, 21);
            this.btnOpenFile.TabIndex = 4;
            this.btnOpenFile.Text = "...";
            this.btnOpenFile.UseVisualStyleBackColor = false;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // txtExportFile
            // 
            this.txtExportFile.BackColor = System.Drawing.Color.White;
            this.txtExportFile.ForeColor = System.Drawing.Color.Black;
            this.txtExportFile.Location = new System.Drawing.Point(92, 89);
            this.txtExportFile.Name = "txtExportFile";
            this.txtExportFile.ReadOnly = true;
            this.txtExportFile.Size = new System.Drawing.Size(394, 20);
            this.txtExportFile.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(14, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "出力ファイル";
            // 
            // cboExportContent
            // 
            this.cboExportContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboExportContent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboExportContent.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboExportContent.ForeColor = System.Drawing.Color.Black;
            this.cboExportContent.FormattingEnabled = true;
            this.cboExportContent.Location = new System.Drawing.Point(92, 50);
            this.cboExportContent.Name = "cboExportContent";
            this.cboExportContent.Size = new System.Drawing.Size(394, 21);
            this.cboExportContent.TabIndex = 2;
            this.cboExportContent.SelectedIndexChanged += new System.EventHandler(this.cboExportContent_SelectedIndexChanged);
            // 
            // ExportContent
            // 
            this.ExportContent.AutoSize = true;
            this.ExportContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ExportContent.ForeColor = System.Drawing.Color.Black;
            this.ExportContent.Location = new System.Drawing.Point(14, 52);
            this.ExportContent.Name = "ExportContent";
            this.ExportContent.Size = new System.Drawing.Size(55, 13);
            this.ExportContent.TabIndex = 3;
            this.ExportContent.Text = "出力内容";
            // 
            // radTSVExport
            // 
            this.radTSVExport.AutoSize = true;
            this.radTSVExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.radTSVExport.ForeColor = System.Drawing.Color.Black;
            this.radTSVExport.Location = new System.Drawing.Point(221, 19);
            this.radTSVExport.Name = "radTSVExport";
            this.radTSVExport.Size = new System.Drawing.Size(70, 17);
            this.radTSVExport.TabIndex = 1;
            this.radTSVExport.TabStop = true;
            this.radTSVExport.Text = "TSV形式";
            this.radTSVExport.UseVisualStyleBackColor = false;
            this.radTSVExport.CheckedChanged += new System.EventHandler(this.radTSVExport_CheckedChanged);
            // 
            // radExcelExport
            // 
            this.radExcelExport.AutoSize = true;
            this.radExcelExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.radExcelExport.ForeColor = System.Drawing.Color.Black;
            this.radExcelExport.Location = new System.Drawing.Point(92, 19);
            this.radExcelExport.Name = "radExcelExport";
            this.radExcelExport.Size = new System.Drawing.Size(75, 17);
            this.radExcelExport.TabIndex = 0;
            this.radExcelExport.TabStop = true;
            this.radExcelExport.Text = "Excel形式";
            this.radExcelExport.UseVisualStyleBackColor = false;
            this.radExcelExport.CheckedChanged += new System.EventHandler(this.radExcelExport_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(14, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "出力形式";
            // 
            // ExportSearchingFile
            // 
            this.AcceptButton = this.bntExport;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 224);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.bntExport);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.txtExportFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboExportContent);
            this.Controls.Add(this.ExportContent);
            this.Controls.Add(this.radTSVExport);
            this.Controls.Add(this.radExcelExport);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportSearchingFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ファイル出力";
            this.Load += new System.EventHandler(this.ExportSearchingFile_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radExcelExport;
        private System.Windows.Forms.RadioButton radTSVExport;
        private System.Windows.Forms.Label ExportContent;
        private System.Windows.Forms.ComboBox cboExportContent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtExportFile;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radFilterRecord;
        private System.Windows.Forms.RadioButton radCheckOnRecord;
        private System.Windows.Forms.Button bntExport;
        private System.Windows.Forms.Button btnClose;
    }
}