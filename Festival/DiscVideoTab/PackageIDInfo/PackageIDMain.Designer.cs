namespace Festival.DiscVideoTab.PackageIDInfo
{
    partial class PackageIDMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PackageIDMain));
            this.dataGridViewFilter = new Festival.Base.DataGridViewFilter();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.dtgPackage = new Zuby.ADGV.AdvancedDataGridView();
            this.colDelete = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.colパッケージID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFesDISCID = new Festival.Base.DataGridViewNumericColumn();
            this.colUpdateDate = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.colOldFesDISCID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPackage)).BeginInit();
            this.SuspendLayout();
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
            this.dataGridViewFilter.Location = new System.Drawing.Point(12, 41);
            this.dataGridViewFilter.MainMenuEditModeCollection = menuMainCollection1;
            this.dataGridViewFilter.Name = "dataGridViewFilter";
            this.dataGridViewFilter.SCREEN_TITLE = null;
            this.dataGridViewFilter.Size = new System.Drawing.Size(760, 408);
            this.dataGridViewFilter.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(697, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "登録(&S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtgPackage
            // 
            this.dtgPackage.AllowUserToDeleteRows = false;
            this.dtgPackage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgPackage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPackage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDelete,
            this.colパッケージID,
            this.colFesDISCID,
            this.colUpdateDate,
            this.colOldFesDISCID});
            this.dtgPackage.FilterAndSortEnabled = true;
            this.dtgPackage.Location = new System.Drawing.Point(36, 63);
            this.dtgPackage.Name = "dtgPackage";
            this.dtgPackage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtgPackage.Size = new System.Drawing.Size(432, 219);
            this.dtgPackage.TabIndex = 0;
            this.dtgPackage.Visible = false;
            // 
            // colDelete
            // 
            this.colDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange;
            this.colDelete.DataPropertyName = "Delete";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = "削除";
            this.colDelete.DefaultCellStyle = dataGridViewCellStyle1;
            this.colDelete.HeaderText = "";
            this.colDelete.MinimumWidth = 22;
            this.colDelete.Name = "colDelete";
            this.colDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colDelete.Text = null;
            this.colDelete.Width = 75;
            // 
            // colパッケージID
            // 
            this.colパッケージID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colパッケージID.DataPropertyName = "パッケージID";
            this.colパッケージID.HeaderText = "パッケージID";
            this.colパッケージID.MaxInputLength = 16;
            this.colパッケージID.MinimumWidth = 22;
            this.colパッケージID.Name = "colパッケージID";
            this.colパッケージID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // colFesDISCID
            // 
            this.colFesDISCID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFesDISCID.DataPropertyName = "FesDISCID";
            this.colFesDISCID.HeaderText = "FesDISCID";
            this.colFesDISCID.MaxInputLength = 9;
            this.colFesDISCID.MaxValueInput = ((long)(999999999));
            this.colFesDISCID.MinimumWidth = 22;
            this.colFesDISCID.MinInputLength = 0;
            this.colFesDISCID.Name = "colFesDISCID";
            this.colFesDISCID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colFesDISCID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // colUpdateDate
            // 
            // 
            // 
            // 
            this.colUpdateDate.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.colUpdateDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.colUpdateDate.DataPropertyName = "UpdateDate";
            this.colUpdateDate.HeaderText = "colDateTimeUpdate";
            this.colUpdateDate.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.colUpdateDate.MinimumWidth = 22;
            // 
            // 
            // 
            // 
            // 
            // 
            this.colUpdateDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.colUpdateDate.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            // 
            // 
            // 
            this.colUpdateDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.colUpdateDate.MonthCalendar.DisplayMonth = new System.DateTime(2020, 8, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.colUpdateDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.colUpdateDate.Name = "colUpdateDate";
            this.colUpdateDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colUpdateDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colUpdateDate.Visible = false;
            // 
            // colOldFesDISCID
            // 
            this.colOldFesDISCID.DataPropertyName = "OldFesDISCID";
            this.colOldFesDISCID.HeaderText = "OldFesDISCID";
            this.colOldFesDISCID.MinimumWidth = 22;
            this.colOldFesDISCID.Name = "colOldFesDISCID";
            this.colOldFesDISCID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colOldFesDISCID.Visible = false;
            // 
            // PackageIDMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtgPackage);
            this.Controls.Add(this.dataGridViewFilter);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PackageIDMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "パッケージID情報";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PackageIDMain_FormClosing);
            this.Load += new System.EventHandler(this.PackageIDMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPackage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Zuby.ADGV.AdvancedDataGridView dtgPackage;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn colDateTimeUpdate;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn colDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn colパッケージID;
        private Base.DataGridViewNumericColumn colFesDISCID;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn colUpdateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOldFesDISCID;
        private Base.DataGridViewFilter dataGridViewFilter;
    }
}