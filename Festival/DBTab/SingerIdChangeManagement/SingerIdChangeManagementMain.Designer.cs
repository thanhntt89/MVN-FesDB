namespace Festival.DBTab.SingerIdChangeManagement
{
    partial class SingerIdChangeManagementMain
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            Festival.Base.MenuMainCollection menuMainCollection1 = new Festival.Base.MenuMainCollection();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SingerIdChangeManagementMain));
            this.fes歌手ID変更履歴BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAddNew = new DevComponents.DotNetBar.ButtonX();
            this.advSingerIdChange = new Zuby.ADGV.AdvancedDataGridView();
            this.colDelete = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.col変更利用者ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col変更日時 = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.col変更前_歌手ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col変更前_歌手名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col変更前_歌手名検索用カナ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col変更前_歌手名ソート用カナ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col変更後_歌手ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col変更後_歌手名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col変更後_歌手名検索用カナ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col変更後_歌手名ソート用カナ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col履歴No = new Festival.Base.DataGridViewNumericColumn();
            this.colDateTimeUpdate = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.dataGridViewFilter = new Festival.Base.DataGridViewFilter();
            this.btnUpdate = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.fes歌手ID変更履歴BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advSingerIdChange)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddNew
            // 
            this.btnAddNew.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddNew.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddNew.Location = new System.Drawing.Point(31, 19);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(102, 23);
            this.btnAddNew.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddNew.TabIndex = 3;
            this.btnAddNew.Text = "新規登録(&N)";
            this.btnAddNew.Visible = false;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // advSingerIdChange
            // 
            this.advSingerIdChange.AllowUserToAddRows = false;
            this.advSingerIdChange.AllowUserToDeleteRows = false;
            this.advSingerIdChange.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advSingerIdChange.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDelete,
            this.col変更利用者ID,
            this.col変更日時,
            this.col変更前_歌手ID,
            this.col変更前_歌手名,
            this.col変更前_歌手名検索用カナ,
            this.col変更前_歌手名ソート用カナ,
            this.col変更後_歌手ID,
            this.col変更後_歌手名,
            this.col変更後_歌手名検索用カナ,
            this.col変更後_歌手名ソート用カナ,
            this.col履歴No,
            this.colDateTimeUpdate});
            this.advSingerIdChange.FilterAndSortEnabled = true;
            this.advSingerIdChange.IsLoadConfig = false;
            this.advSingerIdChange.Location = new System.Drawing.Point(12, 48);
            this.advSingerIdChange.Name = "advSingerIdChange";
            this.advSingerIdChange.ReadOnly = true;
            this.advSingerIdChange.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advSingerIdChange.Size = new System.Drawing.Size(513, 188);
            this.advSingerIdChange.TabIndex = 2;
            this.advSingerIdChange.Visible = false;
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
            this.colDelete.ReadOnly = true;
            this.colDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colDelete.Text = null;
            this.colDelete.Width = 75;
            // 
            // col変更利用者ID
            // 
            this.col変更利用者ID.DataPropertyName = "変更利用者ID";
            this.col変更利用者ID.HeaderText = "変更利用者ID";
            this.col変更利用者ID.MinimumWidth = 22;
            this.col変更利用者ID.Name = "col変更利用者ID";
            this.col変更利用者ID.ReadOnly = true;
            this.col変更利用者ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // col変更日時
            // 
            // 
            // 
            // 
            this.col変更日時.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.col変更日時.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.col変更日時.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.col変更日時.BackgroundStyle.TextColor = System.Drawing.Color.Black;
            this.col変更日時.ButtonClear.Text = "x";
            this.col変更日時.ButtonClear.Visible = true;
            this.col変更日時.ButtonDropDown.Visible = true;
            this.col変更日時.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.col変更日時.DataPropertyName = "変更日時";
            this.col変更日時.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.col変更日時.HeaderText = "変更日時";
            this.col変更日時.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.col変更日時.MinimumWidth = 22;
            // 
            // 
            // 
            // 
            // 
            // 
            this.col変更日時.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.col変更日時.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            // 
            // 
            // 
            this.col変更日時.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.col変更日時.MonthCalendar.DisplayMonth = new System.DateTime(2020, 8, 1, 0, 0, 0, 0);
            this.col変更日時.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.col変更日時.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.col変更日時.Name = "col変更日時";
            this.col変更日時.ReadOnly = true;
            this.col変更日時.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col変更日時.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // col変更前_歌手ID
            // 
            this.col変更前_歌手ID.DataPropertyName = "変更前_歌手ID";
            this.col変更前_歌手ID.HeaderText = "変更前_歌手ID";
            this.col変更前_歌手ID.MaxInputLength = 7;
            this.col変更前_歌手ID.MinimumWidth = 22;
            this.col変更前_歌手ID.Name = "col変更前_歌手ID";
            this.col変更前_歌手ID.ReadOnly = true;
            this.col変更前_歌手ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.col変更前_歌手ID.Width = 120;
            // 
            // col変更前_歌手名
            // 
            this.col変更前_歌手名.DataPropertyName = "変更前_歌手名";
            this.col変更前_歌手名.HeaderText = "変更前_歌手名";
            this.col変更前_歌手名.MaxInputLength = 255;
            this.col変更前_歌手名.MinimumWidth = 22;
            this.col変更前_歌手名.Name = "col変更前_歌手名";
            this.col変更前_歌手名.ReadOnly = true;
            this.col変更前_歌手名.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // col変更前_歌手名検索用カナ
            // 
            this.col変更前_歌手名検索用カナ.DataPropertyName = "変更前_歌手名検索用カナ";
            this.col変更前_歌手名検索用カナ.HeaderText = "変更前_歌手名検索用カナ";
            this.col変更前_歌手名検索用カナ.MaxInputLength = 255;
            this.col変更前_歌手名検索用カナ.MinimumWidth = 22;
            this.col変更前_歌手名検索用カナ.Name = "col変更前_歌手名検索用カナ";
            this.col変更前_歌手名検索用カナ.ReadOnly = true;
            this.col変更前_歌手名検索用カナ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.col変更前_歌手名検索用カナ.Width = 120;
            // 
            // col変更前_歌手名ソート用カナ
            // 
            this.col変更前_歌手名ソート用カナ.DataPropertyName = "変更前_歌手名ソート用カナ";
            this.col変更前_歌手名ソート用カナ.HeaderText = "変更前_歌手名ソート用カナ";
            this.col変更前_歌手名ソート用カナ.MaxInputLength = 255;
            this.col変更前_歌手名ソート用カナ.MinimumWidth = 22;
            this.col変更前_歌手名ソート用カナ.Name = "col変更前_歌手名ソート用カナ";
            this.col変更前_歌手名ソート用カナ.ReadOnly = true;
            this.col変更前_歌手名ソート用カナ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.col変更前_歌手名ソート用カナ.Width = 120;
            // 
            // col変更後_歌手ID
            // 
            this.col変更後_歌手ID.DataPropertyName = "変更後_歌手ID";
            this.col変更後_歌手ID.HeaderText = "変更後_歌手ID";
            this.col変更後_歌手ID.MaxInputLength = 7;
            this.col変更後_歌手ID.MinimumWidth = 22;
            this.col変更後_歌手ID.Name = "col変更後_歌手ID";
            this.col変更後_歌手ID.ReadOnly = true;
            this.col変更後_歌手ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // col変更後_歌手名
            // 
            this.col変更後_歌手名.DataPropertyName = "変更後_歌手名";
            this.col変更後_歌手名.HeaderText = "変更後_歌手名";
            this.col変更後_歌手名.MaxInputLength = 255;
            this.col変更後_歌手名.MinimumWidth = 22;
            this.col変更後_歌手名.Name = "col変更後_歌手名";
            this.col変更後_歌手名.ReadOnly = true;
            this.col変更後_歌手名.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // col変更後_歌手名検索用カナ
            // 
            this.col変更後_歌手名検索用カナ.DataPropertyName = "変更後_歌手名検索用カナ";
            this.col変更後_歌手名検索用カナ.HeaderText = "変更後_歌手名検索用カナ";
            this.col変更後_歌手名検索用カナ.MaxInputLength = 255;
            this.col変更後_歌手名検索用カナ.MinimumWidth = 22;
            this.col変更後_歌手名検索用カナ.Name = "col変更後_歌手名検索用カナ";
            this.col変更後_歌手名検索用カナ.ReadOnly = true;
            this.col変更後_歌手名検索用カナ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.col変更後_歌手名検索用カナ.Width = 120;
            // 
            // col変更後_歌手名ソート用カナ
            // 
            this.col変更後_歌手名ソート用カナ.DataPropertyName = "変更後_歌手名ソート用カナ";
            this.col変更後_歌手名ソート用カナ.HeaderText = "変更後_歌手名ソート用カナ";
            this.col変更後_歌手名ソート用カナ.MaxInputLength = 255;
            this.col変更後_歌手名ソート用カナ.MinimumWidth = 22;
            this.col変更後_歌手名ソート用カナ.Name = "col変更後_歌手名ソート用カナ";
            this.col変更後_歌手名ソート用カナ.ReadOnly = true;
            this.col変更後_歌手名ソート用カナ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.col変更後_歌手名ソート用カナ.Width = 120;
            // 
            // col履歴No
            // 
            this.col履歴No.DataPropertyName = "履歴No";
            this.col履歴No.HeaderText = "履歴No";
            this.col履歴No.MaxInputLength = 32767;
            this.col履歴No.MaxValueInput = ((long)(2147483647));
            this.col履歴No.MinimumWidth = 22;
            this.col履歴No.MinInputLength = 0;
            this.col履歴No.Name = "col履歴No";
            this.col履歴No.ReadOnly = true;
            this.col履歴No.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col履歴No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.col履歴No.Visible = false;
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
            this.dataGridViewFilter.Location = new System.Drawing.Point(2, 7);
            this.dataGridViewFilter.MainMenuEditModeCollection = menuMainCollection1;
            this.dataGridViewFilter.Name = "dataGridViewFilter";
            this.dataGridViewFilter.SCREEN_TITLE = null;
            this.dataGridViewFilter.Size = new System.Drawing.Size(779, 452);
            this.dataGridViewFilter.TabIndex = 0;
            // 
            // btnUpdate
            // 
            this.btnUpdate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUpdate.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnUpdate.Location = new System.Drawing.Point(114, 7);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(102, 23);
            this.btnUpdate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "編集(&F2)";
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // SingerIdChangeManagementMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.advSingerIdChange);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.dataGridViewFilter);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SingerIdChangeManagementMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "歌手ID変更管理";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SingerIdChangeManagementMain_FormClosing);
            this.Load += new System.EventHandler(this.SingerIdChangeManagementMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fes歌手ID変更履歴BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advSingerIdChange)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Base.DataGridViewFilter dataGridViewFilter;
        private Zuby.ADGV.AdvancedDataGridView advSingerIdChange;
        private System.Windows.Forms.BindingSource fes歌手ID変更履歴BindingSource;
        private DevComponents.DotNetBar.ButtonX btnAddNew;
        private DevComponents.DotNetBar.ButtonX btnUpdate;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn colDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn col変更利用者ID;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn col変更日時;
        private System.Windows.Forms.DataGridViewTextBoxColumn col変更前_歌手ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col変更前_歌手名;
        private System.Windows.Forms.DataGridViewTextBoxColumn col変更前_歌手名検索用カナ;
        private System.Windows.Forms.DataGridViewTextBoxColumn col変更前_歌手名ソート用カナ;
        private System.Windows.Forms.DataGridViewTextBoxColumn col変更後_歌手ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col変更後_歌手名;
        private System.Windows.Forms.DataGridViewTextBoxColumn col変更後_歌手名検索用カナ;
        private System.Windows.Forms.DataGridViewTextBoxColumn col変更後_歌手名ソート用カナ;
        private Base.DataGridViewNumericColumn col履歴No;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn colDateTimeUpdate;
    }
}