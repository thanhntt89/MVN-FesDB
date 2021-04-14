namespace Festival.DBTab.RecommendProgramManagement
{
    partial class RecommendProgramMain
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
            Festival.Base.MenuMainCollection menuMainCollection1 = new Festival.Base.MenuMainCollection();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecommendProgramMain));
            this.fes歌手ID変更履歴BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewFilter = new Festival.Base.DataGridViewFilter();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnUpdate = new DevComponents.DotNetBar.ButtonX();
            this.btnAddNew = new DevComponents.DotNetBar.ButtonX();
            this.advRecommendProgram = new Zuby.ADGV.AdvancedDataGridView();
            this.colDelete = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.colプログラムID = new Festival.Base.DataGridViewNumericColumn();
            this.colプログラム名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col備考 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateTimeUpdate = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.colOldプログラムID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.fes歌手ID変更履歴BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advRecommendProgram)).BeginInit();
            this.SuspendLayout();
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
            this.dataGridViewFilter.Location = new System.Drawing.Point(3, 7);
            this.dataGridViewFilter.MainMenuEditModeCollection = menuMainCollection1;
            this.dataGridViewFilter.Name = "dataGridViewFilter";
            this.dataGridViewFilter.SCREEN_TITLE = null;
            this.dataGridViewFilter.Size = new System.Drawing.Size(779, 452);
            this.dataGridViewFilter.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(706, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(76, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "登録(&S)";
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUpdate.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(112, 7);
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
            this.btnAddNew.Location = new System.Drawing.Point(4, 7);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(102, 23);
            this.btnAddNew.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddNew.TabIndex = 3;
            this.btnAddNew.Text = "新規登録(&N)";
            this.btnAddNew.Visible = false;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // advRecommendProgram
            // 
            this.advRecommendProgram.AllowUserToDeleteRows = false;
            this.advRecommendProgram.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advRecommendProgram.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDelete,
            this.colプログラムID,
            this.colプログラム名,
            this.col備考,
            this.colDateTimeUpdate,
            this.colOldプログラムID});
            this.advRecommendProgram.FilterAndSortEnabled = true;
            this.advRecommendProgram.IsLoadConfig = false;
            this.advRecommendProgram.Location = new System.Drawing.Point(12, 54);
            this.advRecommendProgram.Name = "advRecommendProgram";
            this.advRecommendProgram.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advRecommendProgram.Size = new System.Drawing.Size(711, 311);
            this.advRecommendProgram.TabIndex = 2;
            this.advRecommendProgram.Visible = false;
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
            // colプログラムID
            // 
            this.colプログラムID.DataPropertyName = "プログラムID";
            this.colプログラムID.HeaderText = "プログラムID";
            this.colプログラムID.MaxInputLength = 10;
            this.colプログラムID.MaxValueInput = ((long)(2147483647));
            this.colプログラムID.MinimumWidth = 22;
            this.colプログラムID.MinInputLength = 0;
            this.colプログラムID.Name = "colプログラムID";
            this.colプログラムID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colプログラムID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // colプログラム名
            // 
            this.colプログラム名.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colプログラム名.DataPropertyName = "プログラム名";
            this.colプログラム名.HeaderText = "プログラム名";
            this.colプログラム名.MinimumWidth = 22;
            this.colプログラム名.Name = "colプログラム名";
            this.colプログラム名.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // col備考
            // 
            this.col備考.DataPropertyName = "備考";
            this.col備考.HeaderText = "備考";
            this.col備考.MinimumWidth = 22;
            this.col備考.Name = "col備考";
            this.col備考.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.col備考.Width = 120;
            // 
            // colDateTimeUpdate
            // 
            // 
            // 
            // 
            this.colDateTimeUpdate.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.colDateTimeUpdate.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.colDateTimeUpdate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.colDateTimeUpdate.BackgroundStyle.TextColor = System.Drawing.Color.Black;
            this.colDateTimeUpdate.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.colDateTimeUpdate.DataPropertyName = "DateTimeUpdate";
            this.colDateTimeUpdate.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
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
            // colOldプログラムID
            // 
            this.colOldプログラムID.DataPropertyName = "OldプログラムID";
            this.colOldプログラムID.HeaderText = "OldプログラムID";
            this.colOldプログラムID.MinimumWidth = 22;
            this.colOldプログラムID.Name = "colOldプログラムID";
            this.colOldプログラムID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colOldプログラムID.Visible = false;
            // 
            // RecommendProgramMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.advRecommendProgram);
            this.Controls.Add(this.dataGridViewFilter);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSave);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RecommendProgramMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Fesおすすめプログラム管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RecommendProgramMain_FormClosing);
            this.Load += new System.EventHandler(this.RecommendProgramMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fes歌手ID変更履歴BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advRecommendProgram)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Base.DataGridViewFilter dataGridViewFilter;
        private Zuby.ADGV.AdvancedDataGridView advRecommendProgram;
        private System.Windows.Forms.BindingSource fes歌手ID変更履歴BindingSource;
        private DevComponents.DotNetBar.ButtonX btnAddNew;
        private DevComponents.DotNetBar.ButtonX btnUpdate;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn colDelete;
        private Base.DataGridViewNumericColumn colプログラムID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colプログラム名;
        private System.Windows.Forms.DataGridViewTextBoxColumn col備考;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn colDateTimeUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOldプログラムID;
    }
}