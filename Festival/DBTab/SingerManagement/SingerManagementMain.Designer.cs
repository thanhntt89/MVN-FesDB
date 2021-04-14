namespace Festival.DBTab.SingerManagement
{
    partial class SingerManagementMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SingerManagementMain));
            this.fes歌手ID変更履歴BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnUpdate = new DevComponents.DotNetBar.ButtonX();
            this.btnAddNew = new DevComponents.DotNetBar.ButtonX();
            this.advSinger = new Zuby.ADGV.AdvancedDataGridView();
            this.colDelete = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.colFes独自歌手ID = new Festival.Base.DataGridViewNumericColumn();
            this.col歌手名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col歌手名検索用カナ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col歌手名ソート用カナ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col歌手名ソート用英数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateTimeUpdate = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.colOldFes独自歌手ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewFilter = new Festival.Base.DataGridViewFilter();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.fes歌手ID変更履歴BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advSinger)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUpdate.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(135, 92);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(102, 23);
            this.btnUpdate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "編集(&F2)";
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddNew.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddNew.Enabled = false;
            this.btnAddNew.Location = new System.Drawing.Point(27, 92);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(102, 23);
            this.btnAddNew.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddNew.TabIndex = 3;
            this.btnAddNew.Text = "新規登録(&N)";
            this.btnAddNew.Visible = false;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // advSinger
            // 
            this.advSinger.AllowUserToDeleteRows = false;
            this.advSinger.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advSinger.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDelete,
            this.colFes独自歌手ID,
            this.col歌手名,
            this.col歌手名検索用カナ,
            this.col歌手名ソート用カナ,
            this.col歌手名ソート用英数,
            this.colDateTimeUpdate,
            this.colOldFes独自歌手ID});
            this.advSinger.FilterAndSortEnabled = true;
            this.advSinger.IsLoadConfig = false;
            this.advSinger.Location = new System.Drawing.Point(12, 54);
            this.advSinger.Name = "advSinger";
            this.advSinger.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advSinger.Size = new System.Drawing.Size(747, 325);
            this.advSinger.TabIndex = 2;
            this.advSinger.Visible = false;
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
            // colFes独自歌手ID
            // 
            this.colFes独自歌手ID.DataPropertyName = "Fes独自歌手ID";
            this.colFes独自歌手ID.HeaderText = "Fes独自歌手ID";
            this.colFes独自歌手ID.MaxInputLength = 9;
            this.colFes独自歌手ID.MaxValueInput = ((long)(999999999));
            this.colFes独自歌手ID.MinimumWidth = 22;
            this.colFes独自歌手ID.MinInputLength = 0;
            this.colFes独自歌手ID.Name = "colFes独自歌手ID";
            this.colFes独自歌手ID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colFes独自歌手ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colFes独自歌手ID.Width = 150;
            // 
            // col歌手名
            // 
            this.col歌手名.DataPropertyName = "歌手名";
            this.col歌手名.HeaderText = "歌手名";
            this.col歌手名.MinimumWidth = 22;
            this.col歌手名.Name = "col歌手名";
            this.col歌手名.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.col歌手名.Width = 250;
            // 
            // col歌手名検索用カナ
            // 
            this.col歌手名検索用カナ.DataPropertyName = "歌手名検索用カナ";
            this.col歌手名検索用カナ.HeaderText = "歌手名検索用カナ";
            this.col歌手名検索用カナ.MinimumWidth = 22;
            this.col歌手名検索用カナ.Name = "col歌手名検索用カナ";
            this.col歌手名検索用カナ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.col歌手名検索用カナ.Width = 250;
            // 
            // col歌手名ソート用カナ
            // 
            this.col歌手名ソート用カナ.DataPropertyName = "歌手名ソート用カナ";
            this.col歌手名ソート用カナ.HeaderText = "歌手名ソート用カナ";
            this.col歌手名ソート用カナ.MinimumWidth = 22;
            this.col歌手名ソート用カナ.Name = "col歌手名ソート用カナ";
            this.col歌手名ソート用カナ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.col歌手名ソート用カナ.Width = 250;
            // 
            // col歌手名ソート用英数
            // 
            this.col歌手名ソート用英数.DataPropertyName = "歌手名ソート用英数";
            this.col歌手名ソート用英数.HeaderText = "歌手名ソート用英数";
            this.col歌手名ソート用英数.MinimumWidth = 22;
            this.col歌手名ソート用英数.Name = "col歌手名ソート用英数";
            this.col歌手名ソート用英数.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.col歌手名ソート用英数.Width = 250;
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
            this.colDateTimeUpdate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colDateTimeUpdate.Visible = false;
            // 
            // colOldFes独自歌手ID
            // 
            this.colOldFes独自歌手ID.DataPropertyName = "OldFes独自歌手ID";
            this.colOldFes独自歌手ID.HeaderText = "OldFes独自歌手ID";
            this.colOldFes独自歌手ID.MinimumWidth = 22;
            this.colOldFes独自歌手ID.Name = "colOldFes独自歌手ID";
            this.colOldFes独自歌手ID.ReadOnly = true;
            this.colOldFes独自歌手ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colOldFes独自歌手ID.Visible = false;
            // 
            // dataGridViewFilter
            // 
            this.dataGridViewFilter.AllowUserEdit = false;
            this.dataGridViewFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
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
            this.dataGridViewFilter.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewFilter.IsFilterActive = false;
            this.dataGridViewFilter.Location = new System.Drawing.Point(3, 36);
            this.dataGridViewFilter.MainMenuEditModeCollection = menuMainCollection1;
            this.dataGridViewFilter.Name = "dataGridViewFilter";
            this.dataGridViewFilter.SCREEN_TITLE = null;
            this.dataGridViewFilter.Size = new System.Drawing.Size(779, 423);
            this.dataGridViewFilter.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(706, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(76, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "登録(&S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // SingerManagementMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.advSinger);
            this.Controls.Add(this.dataGridViewFilter);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAddNew);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SingerManagementMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Fes独自歌手管理";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SingerManagementMain_FormClosing);
            this.Load += new System.EventHandler(this.SingerIdChangeManagementMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fes歌手ID変更履歴BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advSinger)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Base.DataGridViewFilter dataGridViewFilter;
        private Zuby.ADGV.AdvancedDataGridView advSinger;
        private System.Windows.Forms.BindingSource fes歌手ID変更履歴BindingSource;
        private DevComponents.DotNetBar.ButtonX btnAddNew;
        private DevComponents.DotNetBar.ButtonX btnUpdate;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn colDelete;
        private Base.DataGridViewNumericColumn colFes独自歌手ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col歌手名;
        private System.Windows.Forms.DataGridViewTextBoxColumn col歌手名検索用カナ;
        private System.Windows.Forms.DataGridViewTextBoxColumn col歌手名ソート用カナ;
        private System.Windows.Forms.DataGridViewTextBoxColumn col歌手名ソート用英数;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn colDateTimeUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOldFes独自歌手ID;
    }
}