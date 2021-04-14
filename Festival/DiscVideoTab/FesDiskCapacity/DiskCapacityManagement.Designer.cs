namespace Festival.DiscVideoTab.FesDiskCapacity
{
    partial class DiskCapacityManagement
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
            Festival.Base.MenuMainCollection menuMainCollection1 = new Festival.Base.MenuMainCollection();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiskCapacityManagement));
            this.advDiskManagement = new Zuby.ADGV.AdvancedDataGridView();
            this.colFesDISCID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col合計 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col残り = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateTimeUpdate = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.dataGridViewFilter = new Festival.Base.DataGridViewFilter();
            ((System.ComponentModel.ISupportInitialize)(this.advDiskManagement)).BeginInit();
            this.SuspendLayout();
            // 
            // advDiskManagement
            // 
            this.advDiskManagement.AllowUserToAddRows = false;
            this.advDiskManagement.AllowUserToDeleteRows = false;
            this.advDiskManagement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advDiskManagement.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFesDISCID,
            this.col合計,
            this.col残り,
            this.colDateTimeUpdate});
            this.advDiskManagement.FilterAndSortEnabled = true;
            this.advDiskManagement.IsLoadConfig = false;
            this.advDiskManagement.Location = new System.Drawing.Point(70, 57);
            this.advDiskManagement.Name = "advDiskManagement";
            this.advDiskManagement.ReadOnly = true;
            this.advDiskManagement.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advDiskManagement.Size = new System.Drawing.Size(643, 191);
            this.advDiskManagement.TabIndex = 1;
            this.advDiskManagement.Visible = false;
            // 
            // colFesDISCID
            // 
            this.colFesDISCID.DataPropertyName = "FesDISCID";
            this.colFesDISCID.HeaderText = "Fes_DISCID";
            this.colFesDISCID.MinimumWidth = 22;
            this.colFesDISCID.Name = "colFesDISCID";
            this.colFesDISCID.ReadOnly = true;
            this.colFesDISCID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colFesDISCID.Width = 150;
            // 
            // col合計
            // 
            this.col合計.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col合計.DataPropertyName = "合計";
            this.col合計.HeaderText = "データサイズ合計";
            this.col合計.MinimumWidth = 22;
            this.col合計.Name = "col合計";
            this.col合計.ReadOnly = true;
            this.col合計.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // col残り
            // 
            this.col残り.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col残り.DataPropertyName = "残り";
            this.col残り.HeaderText = "残り";
            this.col残り.MinimumWidth = 22;
            this.col残り.Name = "col残り";
            this.col残り.ReadOnly = true;
            this.col残り.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // colDateTimeUpdate
            // 
            // 
            // 
            // 
            this.colDateTimeUpdate.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.colDateTimeUpdate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.colDateTimeUpdate.DataPropertyName = "DateTimeUpdate";
            this.colDateTimeUpdate.HeaderText = "colDateTimeUpdate";
            this.colDateTimeUpdate.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.colDateTimeUpdate.MinimumWidth = 22;
            // 
            // 
            // 
            // 
            // 
            // 
            this.colDateTimeUpdate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.colDateTimeUpdate.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            // 
            // 
            // 
            this.colDateTimeUpdate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.colDateTimeUpdate.MonthCalendar.DisplayMonth = new System.DateTime(2020, 8, 1, 0, 0, 0, 0);
            this.colDateTimeUpdate.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.colDateTimeUpdate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.colDateTimeUpdate.Name = "colDateTimeUpdate";
            this.colDateTimeUpdate.ReadOnly = true;
            this.colDateTimeUpdate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colDateTimeUpdate.Visible = false;
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
            this.dataGridViewFilter.Location = new System.Drawing.Point(3, 12);
            this.dataGridViewFilter.MainMenuEditModeCollection = menuMainCollection1;
            this.dataGridViewFilter.Name = "dataGridViewFilter";
            this.dataGridViewFilter.SCREEN_TITLE = null;
            this.dataGridViewFilter.Size = new System.Drawing.Size(776, 441);
            this.dataGridViewFilter.TabIndex = 0;
            // 
            // DiskCapacityManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.advDiskManagement);
            this.Controls.Add(this.dataGridViewFilter);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DiskCapacityManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ディスク容量チェック";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DiskCapacityManagement_FormClosing);
            this.Load += new System.EventHandler(this.DiskCapacityManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.advDiskManagement)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Base.DataGridViewFilter dataGridViewFilter;
        private Zuby.ADGV.AdvancedDataGridView advDiskManagement;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFesDISCID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col合計;
        private System.Windows.Forms.DataGridViewTextBoxColumn col残り;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn colDateTimeUpdate;
    }
}