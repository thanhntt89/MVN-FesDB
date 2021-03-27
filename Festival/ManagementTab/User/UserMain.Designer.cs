namespace Festival.ManagementTab.User
{
    partial class UserMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserMain));
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.dtgUser = new Zuby.ADGV.AdvancedDataGridView();
            this.colDelete = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.col利用者ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col権限グループ = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.col利用者名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUpdateDate = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.colOld利用者ID = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.dataGridViewFilter = new Festival.Base.DataGridViewFilter();
            ((System.ComponentModel.ISupportInitialize)(this.dtgUser)).BeginInit();
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
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "登録(&S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtgUser
            // 
            this.dtgUser.AllowUserToDeleteRows = false;
            this.dtgUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgUser.ColumnHeadersHeight = 24;
            this.dtgUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDelete,
            this.col利用者ID,
            this.col権限グループ,
            this.col利用者名,
            this.colUpdateDate,
            this.colOld利用者ID});
            this.dtgUser.FilterAndSortEnabled = true;
            this.dtgUser.Location = new System.Drawing.Point(33, 62);
            this.dtgUser.Name = "dtgUser";
            this.dtgUser.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtgUser.Size = new System.Drawing.Size(719, 310);
            this.dtgUser.TabIndex = 1;
            this.dtgUser.Visible = false;
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
            // col利用者ID
            // 
            this.col利用者ID.DataPropertyName = "利用者ID";
            this.col利用者ID.HeaderText = "利用者ID";
            this.col利用者ID.MaxInputLength = 50;
            this.col利用者ID.MinimumWidth = 22;
            this.col利用者ID.Name = "col利用者ID";
            this.col利用者ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.col利用者ID.Width = 200;
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
            this.col権限グループ.Width = 250;
            // 
            // col利用者名
            // 
            this.col利用者名.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col利用者名.DataPropertyName = "利用者名";
            this.col利用者名.HeaderText = "利用者名";
            this.col利用者名.MaxInputLength = 30;
            this.col利用者名.MinimumWidth = 22;
            this.col利用者名.Name = "col利用者名";
            this.col利用者名.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // colUpdateDate
            // 
            this.colUpdateDate.Checked = true;
            this.colUpdateDate.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.colUpdateDate.CheckValue = "N";
            this.colUpdateDate.DataPropertyName = "UpdateDate";
            this.colUpdateDate.HeaderText = "DateTimeUpdate";
            this.colUpdateDate.MinimumWidth = 22;
            this.colUpdateDate.Name = "colUpdateDate";
            this.colUpdateDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colUpdateDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colUpdateDate.Visible = false;
            // 
            // colOld利用者ID
            // 
            this.colOld利用者ID.Checked = true;
            this.colOld利用者ID.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.colOld利用者ID.CheckValue = "N";
            this.colOld利用者ID.DataPropertyName = "Old利用者ID";
            this.colOld利用者ID.HeaderText = "Old利用者ID";
            this.colOld利用者ID.MinimumWidth = 22;
            this.colOld利用者ID.Name = "colOld利用者ID";
            this.colOld利用者ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colOld利用者ID.Visible = false;
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
            this.dataGridViewFilter.TabIndex = 4;
            // 
            // UserMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtgUser);
            this.Controls.Add(this.dataGridViewFilter);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "利用者";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserMain_FormClosing);
            this.Load += new System.EventHandler(this.UserMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Zuby.ADGV.AdvancedDataGridView dtgUser;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn colDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn col利用者ID;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn col権限グループ;
        private System.Windows.Forms.DataGridViewTextBoxColumn col利用者名;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn colUpdateDate;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn colOld利用者ID;
        private Base.DataGridViewFilter dataGridViewFilter;
    }
}