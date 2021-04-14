namespace Festival.ManagementTab.ExecuteManagement
{
    partial class ExecuteMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            Festival.Base.MenuMainCollection menuMainCollection1 = new Festival.Base.MenuMainCollection();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExecuteMain));
            this.advExecute = new Zuby.ADGV.AdvancedDataGridView();
            this.colロック削除 = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col項目 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col状態 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col担当者 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPC名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLoadExecute = new DevComponents.DotNetBar.ButtonX();
            this.dataGridViewFilter = new Festival.Base.DataGridViewFilter();
            ((System.ComponentModel.ISupportInitialize)(this.advExecute)).BeginInit();
            this.SuspendLayout();
            // 
            // advExecute
            // 
            this.advExecute.AllowUserToAddRows = false;
            this.advExecute.AllowUserToDeleteRows = false;
            this.advExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.advExecute.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advExecute.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colロック削除,
            this.colID,
            this.col項目,
            this.col状態,
            this.col担当者,
            this.colPC名});
            this.advExecute.FilterAndSortEnabled = true;
            this.advExecute.IsLoadConfig = false;
            this.advExecute.Location = new System.Drawing.Point(45, 74);
            this.advExecute.Name = "advExecute";
            this.advExecute.ReadOnly = true;
            this.advExecute.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advExecute.Size = new System.Drawing.Size(682, 282);
            this.advExecute.TabIndex = 1;
            this.advExecute.Visible = false;
            // 
            // colロック削除
            // 
            this.colロック削除.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange;
            this.colロック削除.DataPropertyName = "ロック削除";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = "ロック削除";
            this.colロック削除.DefaultCellStyle = dataGridViewCellStyle1;
            this.colロック削除.HeaderText = "";
            this.colロック削除.MinimumWidth = 22;
            this.colロック削除.Name = "colロック削除";
            this.colロック削除.ReadOnly = true;
            this.colロック削除.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colロック削除.Text = null;
            this.colロック削除.Width = 75;
            // 
            // colID
            // 
            this.colID.DataPropertyName = "ID";
            this.colID.HeaderText = "ID";
            this.colID.MinimumWidth = 22;
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // col項目
            // 
            this.col項目.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col項目.DataPropertyName = "項目";
            this.col項目.HeaderText = "項目";
            this.col項目.MinimumWidth = 22;
            this.col項目.Name = "col項目";
            this.col項目.ReadOnly = true;
            this.col項目.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // col状態
            // 
            this.col状態.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col状態.DataPropertyName = "状態";
            this.col状態.HeaderText = "状態";
            this.col状態.MinimumWidth = 22;
            this.col状態.Name = "col状態";
            this.col状態.ReadOnly = true;
            this.col状態.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // col担当者
            // 
            this.col担当者.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col担当者.DataPropertyName = "担当者";
            this.col担当者.HeaderText = "担当者";
            this.col担当者.MinimumWidth = 22;
            this.col担当者.Name = "col担当者";
            this.col担当者.ReadOnly = true;
            this.col担当者.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // colPC名
            // 
            this.colPC名.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPC名.DataPropertyName = "PC名";
            this.colPC名.HeaderText = "PC名";
            this.colPC名.MinimumWidth = 22;
            this.colPC名.Name = "colPC名";
            this.colPC名.ReadOnly = true;
            this.colPC名.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // btnLoadExecute
            // 
            this.btnLoadExecute.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLoadExecute.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLoadExecute.Location = new System.Drawing.Point(12, 12);
            this.btnLoadExecute.Name = "btnLoadExecute";
            this.btnLoadExecute.Size = new System.Drawing.Size(75, 23);
            this.btnLoadExecute.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnLoadExecute.TabIndex = 0;
            this.btnLoadExecute.Text = "ロード実行";
            this.btnLoadExecute.Visible = false;
            this.btnLoadExecute.Click += new System.EventHandler(this.btnLoadExecute_Click);
            // 
            // dataGridViewFilter
            // 
            this.dataGridViewFilter.AllowUserEdit = false;
            this.dataGridViewFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewFilter.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridViewFilter.CancelClose = false;
            this.dataGridViewFilter.ColChoiseIndex = 0;
            this.dataGridViewFilter.ColDeletedIndex = 0;
            this.dataGridViewFilter.ColKeyIndex = 0;
            this.dataGridViewFilter.ColumnChoiseDataPropertyName = null;
            this.dataGridViewFilter.ColumnChoiseName = null;
            this.dataGridViewFilter.ColumnCollection = null;
            this.dataGridViewFilter.ColumnComboxChangeName = null;
            this.dataGridViewFilter.ColumnDeletedDataPropertyName = null;
            this.dataGridViewFilter.ColumnDeletedName = null;
            this.dataGridViewFilter.ColumnKeyDataPropertyName = null;
            this.dataGridViewFilter.ColumnKeyName = null;
            this.dataGridViewFilter.ColumnUpdateName = null;
            this.dataGridViewFilter.ColumnUpdateTimeDataPropertyName = null;
            this.dataGridViewFilter.ColumnUpdateTimeName = null;
            this.dataGridViewFilter.ColUpdatedIndex = 0;
            this.dataGridViewFilter.DataGridViewSource = null;
            this.dataGridViewFilter.DataSourceDisplay = null;
            this.dataGridViewFilter.DataTableSource = null;
            this.dataGridViewFilter.IsFilterActive = false;
            this.dataGridViewFilter.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewFilter.MainMenuEditModeCollection = menuMainCollection1;
            this.dataGridViewFilter.Name = "dataGridViewFilter";
            this.dataGridViewFilter.SCREEN_TITLE = null;
            this.dataGridViewFilter.Size = new System.Drawing.Size(760, 437);
            this.dataGridViewFilter.TabIndex = 2;
            // 
            // ExecuteMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.advExecute);
            this.Controls.Add(this.btnLoadExecute);
            this.Controls.Add(this.dataGridViewFilter);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExecuteMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "排他管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExecuteMain_FormClosing);
            this.Load += new System.EventHandler(this.ExecuteMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.advExecute)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnLoadExecute;
        private Zuby.ADGV.AdvancedDataGridView advExecute;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn colロック削除;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col項目;
        private System.Windows.Forms.DataGridViewTextBoxColumn col状態;
        private System.Windows.Forms.DataGridViewTextBoxColumn col担当者;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPC名;
        private Base.DataGridViewFilter dataGridViewFilter;
    }
}