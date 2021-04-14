namespace Festival.ManagementTab.FunctionID
{
    partial class FunctionIDMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            Festival.Base.MenuMainCollection menuMainCollection1 = new Festival.Base.MenuMainCollection();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FunctionIDMain));
            this.advFuntions = new Zuby.ADGV.AdvancedDataGridView();
            this.colDelete = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.colプロジェクトID = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.col機能ID = new Festival.Base.DataGridViewNumericColumn();
            this.col機能名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colタイムスタンプ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUpdateDate = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.colOldプロジェクトID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOld機能ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.dataGridViewFilter = new Festival.Base.DataGridViewFilter();
            ((System.ComponentModel.ISupportInitialize)(this.advFuntions)).BeginInit();
            this.SuspendLayout();
            // 
            // advFuntions
            // 
            this.advFuntions.AllowUserToDeleteRows = false;
            this.advFuntions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.advFuntions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advFuntions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDelete,
            this.colプロジェクトID,
            this.col機能ID,
            this.col機能名,
            this.colタイムスタンプ,
            this.colUpdateDate,
            this.colOldプロジェクトID,
            this.colOld機能ID});
            this.advFuntions.FilterAndSortEnabled = true;
            this.advFuntions.IsLoadConfig = false;
            this.advFuntions.Location = new System.Drawing.Point(25, 61);
            this.advFuntions.Name = "advFuntions";
            this.advFuntions.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advFuntions.Size = new System.Drawing.Size(721, 303);
            this.advFuntions.TabIndex = 1;
            this.advFuntions.Visible = false;
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
            this.colDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colDelete.Text = null;
            // 
            // colプロジェクトID
            // 
            this.colプロジェクトID.DataPropertyName = "プロジェクトID";
            this.colプロジェクトID.DisplayMember = "Text";
            this.colプロジェクトID.DropDownHeight = 106;
            this.colプロジェクトID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colプロジェクトID.DropDownWidth = 121;
            this.colプロジェクトID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colプロジェクトID.HeaderText = "プロジェクトID";
            this.colプロジェクトID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.colプロジェクトID.IntegralHeight = false;
            this.colプロジェクトID.ItemHeight = 15;
            this.colプロジェクトID.MinimumWidth = 22;
            this.colプロジェクトID.Name = "colプロジェクトID";
            this.colプロジェクトID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colプロジェクトID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.colプロジェクトID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // col機能ID
            // 
            this.col機能ID.DataPropertyName = "機能ID";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.col機能ID.DefaultCellStyle = dataGridViewCellStyle2;
            this.col機能ID.HeaderText = "機能ID";
            this.col機能ID.MaxInputLength = 8;
            this.col機能ID.MaxValueInput = ((long)(2147483647));
            this.col機能ID.MinimumWidth = 22;
            this.col機能ID.MinInputLength = 0;
            this.col機能ID.Name = "col機能ID";
            this.col機能ID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col機能ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // col機能名
            // 
            this.col機能名.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col機能名.DataPropertyName = "機能名";
            this.col機能名.HeaderText = "機能名";
            this.col機能名.MaxInputLength = 50;
            this.col機能名.MinimumWidth = 22;
            this.col機能名.Name = "col機能名";
            this.col機能名.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // colタイムスタンプ
            // 
            this.colタイムスタンプ.DataPropertyName = "タイムスタンプ";
            this.colタイムスタンプ.HeaderText = "タイムスタンプ";
            this.colタイムスタンプ.MinimumWidth = 22;
            this.colタイムスタンプ.Name = "colタイムスタンプ";
            this.colタイムスタンプ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colタイムスタンプ.Visible = false;
            // 
            // colUpdateDate
            // 
            // 
            // 
            // 
            this.colUpdateDate.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.colUpdateDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.colUpdateDate.DataPropertyName = "UpdateDate";
            this.colUpdateDate.HeaderText = "colUpdateDate";
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
            this.colUpdateDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colUpdateDate.Visible = false;
            // 
            // colOldプロジェクトID
            // 
            this.colOldプロジェクトID.DataPropertyName = "OldプロジェクトID";
            this.colOldプロジェクトID.HeaderText = "OldプロジェクトID";
            this.colOldプロジェクトID.MinimumWidth = 22;
            this.colOldプロジェクトID.Name = "colOldプロジェクトID";
            this.colOldプロジェクトID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colOldプロジェクトID.Visible = false;
            // 
            // colOld機能ID
            // 
            this.colOld機能ID.DataPropertyName = "Old機能ID";
            this.colOld機能ID.HeaderText = "Old機能ID";
            this.colOld機能ID.MinimumWidth = 22;
            this.colOld機能ID.Name = "colOld機能ID";
            this.colOld機能ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colOld機能ID.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(697, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "登録(&S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.dataGridViewFilter.Location = new System.Drawing.Point(12, 40);
            this.dataGridViewFilter.MainMenuEditModeCollection = menuMainCollection1;
            this.dataGridViewFilter.Name = "dataGridViewFilter";
            this.dataGridViewFilter.SCREEN_TITLE = null;
            this.dataGridViewFilter.Size = new System.Drawing.Size(760, 409);
            this.dataGridViewFilter.TabIndex = 3;
            // 
            // FunctionIDMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.advFuntions);
            this.Controls.Add(this.dataGridViewFilter);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FunctionIDMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "機能ID";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FunctionIDMain_FormClosing);
            this.Load += new System.EventHandler(this.functionID_Load);
            ((System.ComponentModel.ISupportInitialize)(this.advFuntions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Zuby.ADGV.AdvancedDataGridView advFuntions;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private Base.DataGridViewFilter dataGridViewFilter;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn colDelete;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn colプロジェクトID;
        private Base.DataGridViewNumericColumn col機能ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col機能名;
        private System.Windows.Forms.DataGridViewTextBoxColumn colタイムスタンプ;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn colUpdateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOldプロジェクトID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOld機能ID;
    }
}