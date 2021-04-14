namespace Festival.ManagementTab.ProjectID
{
    partial class ProjectIDMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectIDMain));
            this.btn_save = new DevComponents.DotNetBar.ButtonX();
            this.advProjects = new Zuby.ADGV.AdvancedDataGridView();
            this.colDelete = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.colプロジェクトID = new Festival.Base.DataGridViewNumericColumn();
            this.col機能名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUpdateDate = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.colOldプロジェクトID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewFilter = new Festival.Base.DataGridViewFilter();
            ((System.ComponentModel.ISupportInitialize)(this.advProjects)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_save
            // 
            this.btn_save.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_save.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_save.Location = new System.Drawing.Point(697, 12);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_save.TabIndex = 2;
            this.btn_save.Text = "登録(&S)";
            this.btn_save.Click += new System.EventHandler(this.btnSave);
            // 
            // advProjects
            // 
            this.advProjects.AllowUserToDeleteRows = false;
            this.advProjects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.advProjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advProjects.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDelete,
            this.colプロジェクトID,
            this.col機能名,
            this.colUpdateDate,
            this.colOldプロジェクトID});
            this.advProjects.FilterAndSortEnabled = true;
            this.advProjects.IsLoadConfig = false;
            this.advProjects.Location = new System.Drawing.Point(47, 56);
            this.advProjects.Name = "advProjects";
            this.advProjects.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advProjects.Size = new System.Drawing.Size(680, 301);
            this.advProjects.TabIndex = 1;
            this.advProjects.Visible = false;
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
            this.colDelete.Width = 75;
            // 
            // colプロジェクトID
            // 
            this.colプロジェクトID.DataPropertyName = "プロジェクトID";
            this.colプロジェクトID.HeaderText = "プロジェクトID";
            this.colプロジェクトID.MaxInputLength = 9;
            this.colプロジェクトID.MaxValueInput = ((long)(999999999));
            this.colプロジェクトID.MinimumWidth = 22;
            this.colプロジェクトID.MinInputLength = 0;
            this.colプロジェクトID.Name = "colプロジェクトID";
            this.colプロジェクトID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colプロジェクトID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // col機能名
            // 
            this.col機能名.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col機能名.DataPropertyName = "機能名";
            this.col機能名.HeaderText = "機能名";
            this.col機能名.MaxInputLength = 255;
            this.col機能名.MinimumWidth = 22;
            this.col機能名.Name = "col機能名";
            this.col機能名.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // colUpdateDate
            // 
            // 
            // 
            // 
            this.colUpdateDate.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.colUpdateDate.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.colUpdateDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.colUpdateDate.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText;
            this.colUpdateDate.DataPropertyName = "UpdateDate";
            this.colUpdateDate.HeaderText = "UpdateDate";
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
            // colOldプロジェクトID
            // 
            this.colOldプロジェクトID.DataPropertyName = "OldプロジェクトID";
            this.colOldプロジェクトID.HeaderText = "OldプロジェクトID";
            this.colOldプロジェクトID.MinimumWidth = 22;
            this.colOldプロジェクトID.Name = "colOldプロジェクトID";
            this.colOldプロジェクトID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colOldプロジェクトID.Visible = false;
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
            this.dataGridViewFilter.TabIndex = 3;
            // 
            // ProjectIDMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.advProjects);
            this.Controls.Add(this.dataGridViewFilter);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProjectIDMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "プロジェクトID";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProjectIDMain_FormClosing);
            this.Load += new System.EventHandler(this.ProjectIDMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.advProjects)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Zuby.ADGV.AdvancedDataGridView advProjects;
        private DevComponents.DotNetBar.ButtonX btn_save;
        private Base.DataGridViewFilter dataGridViewFilter;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn colDelete;
        private Base.DataGridViewNumericColumn colプロジェクトID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col機能名;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn colUpdateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOldプロジェクトID;
    }
}