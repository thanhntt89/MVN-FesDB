namespace Festival.Base
{
    partial class NavDataGridView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NavDataGridView));
            this.hScrollBar = new System.Windows.Forms.HScrollBar();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.btnPreRow = new System.Windows.Forms.Button();
            this.btnUnFilterAndSort = new System.Windows.Forms.Button();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.btnFirstRow = new System.Windows.Forms.Button();
            this.btnNextRow = new System.Windows.Forms.Button();
            this.btnLastRow = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // hScrollBar
            // 
            this.hScrollBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hScrollBar.Location = new System.Drawing.Point(0, 0);
            this.hScrollBar.Name = "hScrollBar";
            this.hScrollBar.Size = new System.Drawing.Size(652, 31);
            this.hScrollBar.TabIndex = 6;
            this.hScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar_Scroll);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer.Panel1.Controls.Add(this.btnPreRow);
            this.splitContainer.Panel1.Controls.Add(this.btnUnFilterAndSort);
            this.splitContainer.Panel1.Controls.Add(this.txtNumber);
            this.splitContainer.Panel1.Controls.Add(this.btnFirstRow);
            this.splitContainer.Panel1.Controls.Add(this.btnNextRow);
            this.splitContainer.Panel1.Controls.Add(this.btnLastRow);
            this.splitContainer.Panel1MinSize = 255;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.hScrollBar);
            this.splitContainer.Size = new System.Drawing.Size(912, 31);
            this.splitContainer.SplitterDistance = 255;
            this.splitContainer.SplitterWidth = 5;
            this.splitContainer.TabIndex = 1;
            // 
            // btnPreRow
            // 
            this.btnPreRow.FlatAppearance.BorderSize = 0;
            this.btnPreRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreRow.Location = new System.Drawing.Point(34, 1);
            this.btnPreRow.Margin = new System.Windows.Forms.Padding(0);
            this.btnPreRow.Name = "btnPreRow";
            this.btnPreRow.Size = new System.Drawing.Size(25, 19);
            this.btnPreRow.TabIndex = 1;
            this.btnPreRow.Text = "<";
            this.btnPreRow.UseVisualStyleBackColor = true;
            this.btnPreRow.Click += new System.EventHandler(this.btnPreRow_Click);
            // 
            // btnUnFilterAndSort
            // 
            this.btnUnFilterAndSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUnFilterAndSort.Enabled = false;
            this.btnUnFilterAndSort.FlatAppearance.BorderSize = 0;
            this.btnUnFilterAndSort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnFilterAndSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnFilterAndSort.Image = ((System.Drawing.Image)(resources.GetObject("btnUnFilterAndSort.Image")));
            this.btnUnFilterAndSort.Location = new System.Drawing.Point(206, 3);
            this.btnUnFilterAndSort.Margin = new System.Windows.Forms.Padding(0);
            this.btnUnFilterAndSort.Name = "btnUnFilterAndSort";
            this.btnUnFilterAndSort.Size = new System.Drawing.Size(25, 19);
            this.btnUnFilterAndSort.TabIndex = 5;
            this.btnUnFilterAndSort.UseVisualStyleBackColor = true;
            this.btnUnFilterAndSort.Click += new System.EventHandler(this.btnUnFilterAndSort_Click);
            // 
            // txtNumber
            // 
            this.txtNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumber.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNumber.Location = new System.Drawing.Point(62, 5);
            this.txtNumber.Multiline = true;
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(80, 19);
            this.txtNumber.TabIndex = 2;
            this.txtNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNumber.Click += new System.EventHandler(this.txtNumber_Click);
            this.txtNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
            this.txtNumber.Leave += new System.EventHandler(this.txtNumber_Leave);
            // 
            // btnFirstRow
            // 
            this.btnFirstRow.FlatAppearance.BorderSize = 0;
            this.btnFirstRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirstRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFirstRow.Location = new System.Drawing.Point(7, 1);
            this.btnFirstRow.Margin = new System.Windows.Forms.Padding(0);
            this.btnFirstRow.Name = "btnFirstRow";
            this.btnFirstRow.Size = new System.Drawing.Size(25, 19);
            this.btnFirstRow.TabIndex = 0;
            this.btnFirstRow.Text = "|<";
            this.btnFirstRow.UseVisualStyleBackColor = true;
            this.btnFirstRow.Click += new System.EventHandler(this.btnFirstRow_Click);
            // 
            // btnNextRow
            // 
            this.btnNextRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextRow.FlatAppearance.BorderSize = 0;
            this.btnNextRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextRow.Location = new System.Drawing.Point(150, 1);
            this.btnNextRow.Margin = new System.Windows.Forms.Padding(0);
            this.btnNextRow.Name = "btnNextRow";
            this.btnNextRow.Size = new System.Drawing.Size(25, 19);
            this.btnNextRow.TabIndex = 3;
            this.btnNextRow.Text = ">";
            this.btnNextRow.UseVisualStyleBackColor = true;
            this.btnNextRow.Click += new System.EventHandler(this.btnNextRow_Click);
            // 
            // btnLastRow
            // 
            this.btnLastRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLastRow.FlatAppearance.BorderSize = 0;
            this.btnLastRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLastRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLastRow.Location = new System.Drawing.Point(177, 1);
            this.btnLastRow.Margin = new System.Windows.Forms.Padding(0);
            this.btnLastRow.Name = "btnLastRow";
            this.btnLastRow.Size = new System.Drawing.Size(25, 19);
            this.btnLastRow.TabIndex = 4;
            this.btnLastRow.Text = ">|";
            this.btnLastRow.UseVisualStyleBackColor = true;
            this.btnLastRow.Click += new System.EventHandler(this.btnLastRow_Click);
            // 
            // NavDataGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.splitContainer);
            this.Name = "NavDataGridView";
            this.Size = new System.Drawing.Size(912, 31);
            this.Load += new System.EventHandler(this.NavDataGridView_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.HScrollBar hScrollBar;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Button btnPreRow;
        private System.Windows.Forms.Button btnFirstRow;
        private System.Windows.Forms.Button btnNextRow;
        private System.Windows.Forms.Button btnLastRow;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Button btnUnFilterAndSort;
    }
}
