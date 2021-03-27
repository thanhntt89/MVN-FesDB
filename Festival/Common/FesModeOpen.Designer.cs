namespace Festival.Common
{
    partial class FesModeOpen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FesModeOpen));
            this.btnClosed = new System.Windows.Forms.Button();
            this.btnReadOnly = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClosed
            // 
            this.btnClosed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnClosed.ForeColor = System.Drawing.Color.Black;
            this.btnClosed.Location = new System.Drawing.Point(163, 123);
            this.btnClosed.Name = "btnClosed";
            this.btnClosed.Size = new System.Drawing.Size(122, 32);
            this.btnClosed.TabIndex = 2;
            this.btnClosed.Text = "閉じる";
            this.btnClosed.UseVisualStyleBackColor = false;
            this.btnClosed.Click += new System.EventHandler(this.btnClosed_Click);
            // 
            // btnReadOnly
            // 
            this.btnReadOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnReadOnly.ForeColor = System.Drawing.Color.Black;
            this.btnReadOnly.Location = new System.Drawing.Point(22, 66);
            this.btnReadOnly.Name = "btnReadOnly";
            this.btnReadOnly.Size = new System.Drawing.Size(263, 39);
            this.btnReadOnly.TabIndex = 1;
            this.btnReadOnly.Text = "参照(&R)";
            this.btnReadOnly.UseVisualStyleBackColor = false;
            this.btnReadOnly.Click += new System.EventHandler(this.btnReadOnly_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnEdit.ForeColor = System.Drawing.Color.Black;
            this.btnEdit.Location = new System.Drawing.Point(22, 12);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(263, 39);
            this.btnEdit.TabIndex = 0;
            this.btnEdit.Text = "更新(&U)";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // FesModeOpen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 167);
            this.Controls.Add(this.btnClosed);
            this.Controls.Add(this.btnReadOnly);
            this.Controls.Add(this.btnEdit);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FesModeOpen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "モード選択＜Festivalコンテンツ＞";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnReadOnly;
        private System.Windows.Forms.Button btnClosed;
    }
}