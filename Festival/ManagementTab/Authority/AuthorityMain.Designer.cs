namespace Festival.ManagementTab.Authority
{
    partial class AuthorityMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthorityMain));
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.dtgAuthority = new Zuby.ADGV.AdvancedDataGridView();
            this.colDelete = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.col権限グループ = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.colプロジェクトID = new Festival.Base.DataGridViewNumericColumn();
            this.col機能ID = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.col更新タイプ = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.colUpdateDate = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.colOld権限グループ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOldプロジェクトID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOld機能ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonXColumn1 = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewNumericColumn1 = new Festival.Base.DataGridViewNumericColumn();
            this.dataGridViewComboBoxExColumn1 = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.dataGridViewComboBoxExColumn2 = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxXColumn1 = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.dataGridViewFilter = new Festival.Base.DataGridViewFilter();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAuthority)).BeginInit();
            this.SuspendLayout();
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
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "登録(&S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtgAuthority
            // 
            this.dtgAuthority.AllowUserToDeleteRows = false;
            this.dtgAuthority.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgAuthority.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgAuthority.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDelete,
            this.col権限グループ,
            this.colプロジェクトID,
            this.col機能ID,
            this.col更新タイプ,
            this.colUpdateDate,
            this.colOld権限グループ,
            this.colOldプロジェクトID,
            this.colOld機能ID});
            this.dtgAuthority.FilterAndSortEnabled = true;
            this.dtgAuthority.Location = new System.Drawing.Point(29, 60);
            this.dtgAuthority.Name = "dtgAuthority";
            this.dtgAuthority.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtgAuthority.Size = new System.Drawing.Size(719, 296);
            this.dtgAuthority.TabIndex = 1;
            this.dtgAuthority.Visible = false;
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
            // col権限グループ
            // 
            this.col権限グループ.DataPropertyName = "権限グループ";
            this.col権限グループ.DisplayMember = "Text";
            this.col権限グループ.DropDownHeight = 106;
            this.col権限グループ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.col権限グループ.DropDownWidth = 121;
            this.col権限グループ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.col権限グループ.HeaderText = "権限グループ";
            this.col権限グループ.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.col権限グループ.IntegralHeight = false;
            this.col権限グループ.ItemHeight = 15;
            this.col権限グループ.MinimumWidth = 22;
            this.col権限グループ.Name = "col権限グループ";
            this.col権限グループ.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col権限グループ.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.col権限グループ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.col権限グループ.Width = 200;
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
            this.colプロジェクトID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colプロジェクトID.Width = 150;
            // 
            // col機能ID
            // 
            this.col機能ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col機能ID.DataPropertyName = "機能ID";
            this.col機能ID.DisplayMember = "Text";
            this.col機能ID.DropDownHeight = 106;
            this.col機能ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.col機能ID.DropDownWidth = 121;
            this.col機能ID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.col機能ID.HeaderText = "機能ID";
            this.col機能ID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.col機能ID.IntegralHeight = false;
            this.col機能ID.ItemHeight = 15;
            this.col機能ID.MinimumWidth = 22;
            this.col機能ID.Name = "col機能ID";
            this.col機能ID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col機能ID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.col機能ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // col更新タイプ
            // 
            this.col更新タイプ.DataPropertyName = "更新タイプ";
            this.col更新タイプ.DisplayMember = "Text";
            this.col更新タイプ.DropDownHeight = 106;
            this.col更新タイプ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.col更新タイプ.DropDownWidth = 121;
            this.col更新タイプ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.col更新タイプ.HeaderText = "更新タイプ";
            this.col更新タイプ.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.col更新タイプ.IntegralHeight = false;
            this.col更新タイプ.ItemHeight = 15;
            this.col更新タイプ.MinimumWidth = 22;
            this.col更新タイプ.Name = "col更新タイプ";
            this.col更新タイプ.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col更新タイプ.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.col更新タイプ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.col更新タイプ.Width = 120;
            // 
            // colUpdateDate
            // 
            // 
            // 
            // 
            this.colUpdateDate.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.colUpdateDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
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
            // colOld権限グループ
            // 
            this.colOld権限グループ.DataPropertyName = "Old権限グループ";
            this.colOld権限グループ.HeaderText = "Old権限グループ";
            this.colOld権限グループ.MinimumWidth = 22;
            this.colOld権限グループ.Name = "colOld権限グループ";
            this.colOld権限グループ.ReadOnly = true;
            this.colOld権限グループ.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colOld権限グループ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colOld権限グループ.Visible = false;
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
            // dataGridViewButtonXColumn1
            // 
            this.dataGridViewButtonXColumn1.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = "削除";
            this.dataGridViewButtonXColumn1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewButtonXColumn1.HeaderText = "";
            this.dataGridViewButtonXColumn1.MinimumWidth = 22;
            this.dataGridViewButtonXColumn1.Name = "dataGridViewButtonXColumn1";
            this.dataGridViewButtonXColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewButtonXColumn1.Text = null;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "権限グループ";
            this.dataGridViewTextBoxColumn1.HeaderText = "権限グループ";
            this.dataGridViewTextBoxColumn1.MaxInputLength = 50;
            this.dataGridViewTextBoxColumn1.MinimumWidth = 22;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // dataGridViewNumericColumn1
            // 
            this.dataGridViewNumericColumn1.DataPropertyName = "プロジェクトID";
            this.dataGridViewNumericColumn1.HeaderText = "プロジェクトID";
            this.dataGridViewNumericColumn1.MaxInputLength = 9;
            this.dataGridViewNumericColumn1.MaxValueInput = ((long)(999999999));
            this.dataGridViewNumericColumn1.MinimumWidth = 22;
            this.dataGridViewNumericColumn1.MinInputLength = 0;
            this.dataGridViewNumericColumn1.Name = "dataGridViewNumericColumn1";
            this.dataGridViewNumericColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewNumericColumn1.Width = 150;
            // 
            // dataGridViewComboBoxExColumn1
            // 
            this.dataGridViewComboBoxExColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewComboBoxExColumn1.DataPropertyName = "機能ID";
            this.dataGridViewComboBoxExColumn1.DisplayMember = "Text";
            this.dataGridViewComboBoxExColumn1.DropDownHeight = 106;
            this.dataGridViewComboBoxExColumn1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dataGridViewComboBoxExColumn1.DropDownWidth = 121;
            this.dataGridViewComboBoxExColumn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dataGridViewComboBoxExColumn1.HeaderText = "機能ID";
            this.dataGridViewComboBoxExColumn1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dataGridViewComboBoxExColumn1.IntegralHeight = false;
            this.dataGridViewComboBoxExColumn1.ItemHeight = 15;
            this.dataGridViewComboBoxExColumn1.MinimumWidth = 22;
            this.dataGridViewComboBoxExColumn1.Name = "dataGridViewComboBoxExColumn1";
            this.dataGridViewComboBoxExColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxExColumn1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridViewComboBoxExColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // dataGridViewComboBoxExColumn2
            // 
            this.dataGridViewComboBoxExColumn2.DataPropertyName = "更新タイプ";
            this.dataGridViewComboBoxExColumn2.DisplayMember = "Text";
            this.dataGridViewComboBoxExColumn2.DropDownHeight = 106;
            this.dataGridViewComboBoxExColumn2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dataGridViewComboBoxExColumn2.DropDownWidth = 121;
            this.dataGridViewComboBoxExColumn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dataGridViewComboBoxExColumn2.HeaderText = "更新タイプ";
            this.dataGridViewComboBoxExColumn2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dataGridViewComboBoxExColumn2.IntegralHeight = false;
            this.dataGridViewComboBoxExColumn2.ItemHeight = 15;
            this.dataGridViewComboBoxExColumn2.MinimumWidth = 22;
            this.dataGridViewComboBoxExColumn2.Name = "dataGridViewComboBoxExColumn2";
            this.dataGridViewComboBoxExColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxExColumn2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridViewComboBoxExColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewComboBoxExColumn2.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DateTimeUpdate";
            this.dataGridViewTextBoxColumn2.HeaderText = "UpdateDate";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 22;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewCheckBoxXColumn1
            // 
            this.dataGridViewCheckBoxXColumn1.Checked = true;
            this.dataGridViewCheckBoxXColumn1.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.dataGridViewCheckBoxXColumn1.CheckValue = "N";
            this.dataGridViewCheckBoxXColumn1.DataPropertyName = "AddNew";
            this.dataGridViewCheckBoxXColumn1.HeaderText = "";
            this.dataGridViewCheckBoxXColumn1.MinimumWidth = 22;
            this.dataGridViewCheckBoxXColumn1.Name = "dataGridViewCheckBoxXColumn1";
            this.dataGridViewCheckBoxXColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxXColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewCheckBoxXColumn1.Visible = false;
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
            // AuthorityMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtgAuthority);
            this.Controls.Add(this.dataGridViewFilter);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AuthorityMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "権限割り当て";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AuthorityMain_FormClosing);
            this.Load += new System.EventHandler(this.PrivilegeMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgAuthority)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Zuby.ADGV.AdvancedDataGridView dtgAuthority;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn dataGridViewButtonXColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private Base.DataGridViewNumericColumn dataGridViewNumericColumn1;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn dataGridViewComboBoxExColumn1;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn dataGridViewComboBoxExColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn dataGridViewCheckBoxXColumn1;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn colDelete;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn col権限グループ;
        private Base.DataGridViewNumericColumn colプロジェクトID;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn col機能ID;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn col更新タイプ;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn colUpdateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOld権限グループ;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOldプロジェクトID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOld機能ID;
        private Base.DataGridViewFilter dataGridViewFilter;
    }
}