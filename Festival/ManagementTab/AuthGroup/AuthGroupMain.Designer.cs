namespace Festival.ManagementTab.AuthGroup
{
    partial class AuthGroupMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthGroupMain));
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.dtgAuthGroup = new Zuby.ADGV.AdvancedDataGridView();
            this.colDelete = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.col権限グループ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col権限名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUpdateDate = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.colOld権限グループ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewFilter = new Festival.Base.DataGridViewFilter();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAuthGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(696, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(76, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "登録(&S)";
            this.btnSave.Click += new System.EventHandler(this.btn_save);
            // 
            // dtgAuthGroup
            // 
            this.dtgAuthGroup.AllowUserToDeleteRows = false;
            this.dtgAuthGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgAuthGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgAuthGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDelete,
            this.col権限グループ,
            this.col権限名,
            this.colUpdateDate,
            this.colOld権限グループ});
            this.dtgAuthGroup.FilterAndSortEnabled = true;
            this.dtgAuthGroup.Location = new System.Drawing.Point(37, 66);
            this.dtgAuthGroup.Name = "dtgAuthGroup";
            this.dtgAuthGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtgAuthGroup.Size = new System.Drawing.Size(686, 257);
            this.dtgAuthGroup.TabIndex = 1;
            this.dtgAuthGroup.Visible = false;
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
            // col権限グループ
            // 
            this.col権限グループ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col権限グループ.DataPropertyName = "権限グループ";
            this.col権限グループ.HeaderText = "権限グループ";
            this.col権限グループ.MaxInputLength = 50;
            this.col権限グループ.MinimumWidth = 22;
            this.col権限グループ.Name = "col権限グループ";
            this.col権限グループ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // col権限名
            // 
            this.col権限名.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col権限名.DataPropertyName = "権限名";
            this.col権限名.HeaderText = "権限名";
            this.col権限名.MaxInputLength = 20;
            this.col権限名.MinimumWidth = 22;
            this.col権限名.Name = "col権限名";
            this.col権限名.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
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
            // colOld権限グループ
            // 
            this.colOld権限グループ.DataPropertyName = "Old権限グループ";
            this.colOld権限グループ.HeaderText = "Old権限グループ";
            this.colOld権限グループ.MinimumWidth = 22;
            this.colOld権限グループ.Name = "colOld権限グループ";
            this.colOld権限グループ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colOld権限グループ.Visible = false;
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
            this.dataGridViewFilter.Location = new System.Drawing.Point(12, 50);
            this.dataGridViewFilter.MainMenuEditModeCollection = menuMainCollection1;
            this.dataGridViewFilter.Name = "dataGridViewFilter";
            this.dataGridViewFilter.SCREEN_TITLE = null;
            this.dataGridViewFilter.Size = new System.Drawing.Size(760, 399);
            this.dataGridViewFilter.TabIndex = 3;
            // 
            // AuthGroupMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtgAuthGroup);
            this.Controls.Add(this.dataGridViewFilter);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AuthGroupMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "権限グループ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AuthGroupMain_FormClosing);
            this.Load += new System.EventHandler(this.AuthGroupMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgAuthGroup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Zuby.ADGV.AdvancedDataGridView dtgAuthGroup;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn colDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn col権限グループ;
        private System.Windows.Forms.DataGridViewTextBoxColumn col権限名;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn colUpdateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOld権限グループ;
        private Base.DataGridViewFilter dataGridViewFilter;
    }
}