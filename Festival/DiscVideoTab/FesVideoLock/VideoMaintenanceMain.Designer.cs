namespace Festival.DiscVideoTab.FesVideoLock
{
    partial class VideoMaintenanceMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoMaintenanceMain));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.advVideoMain = new Zuby.ADGV.AdvancedDataGridView();
            this.dataGridViewFilter = new Festival.Base.DataGridViewFilter();
            this.dataGridViewButtonXColumn1 = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.dataGridViewCheckBoxXColumn1 = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDelete = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.colChoice = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.colVideoCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaterialID = new Festival.Base.DataGridViewNumericColumn();
            this.colContents = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaterialEndDate = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.colBackgroundVideoLock = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.colOldVideoCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOldMaterialID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOldContents = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOldMaterialEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOldBackgroundVideoLock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUpdateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVideoCodeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.advVideoMain)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(867, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "登録(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(12, 3);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "リスト取込(&I)";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // advVideoMain
            // 
            this.advVideoMain.AllowUserToDeleteRows = false;
            this.advVideoMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.advVideoMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advVideoMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDelete,
            this.colChoice,
            this.colVideoCode,
            this.colMaterialID,
            this.colContents,
            this.colMaterialEndDate,
            this.colBackgroundVideoLock,
            this.colOldVideoCode,
            this.colOldMaterialID,
            this.colOldContents,
            this.colOldMaterialEndDate,
            this.colOldBackgroundVideoLock,
            this.colUpdateDate,
            this.colVideoCodeId});
            this.advVideoMain.FilterAndSortEnabled = true;
            this.advVideoMain.IsLoadConfig = false;
            this.advVideoMain.Location = new System.Drawing.Point(29, 81);
            this.advVideoMain.Name = "advVideoMain";
            this.advVideoMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advVideoMain.Size = new System.Drawing.Size(896, 281);
            this.advVideoMain.TabIndex = 2;
            this.advVideoMain.Visible = false;
            // 
            // dataGridViewFilter
            // 
            this.dataGridViewFilter.AllowUserEdit = true;
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
            this.dataGridViewFilter.ColumnOldVideoCodeDataPropertyName = null;
            this.dataGridViewFilter.ColumnOldVideoLockTypeDataPropertyName = null;
            this.dataGridViewFilter.ColumnUpdateName = null;
            this.dataGridViewFilter.ColumnUpdateTimeDataPropertyName = null;
            this.dataGridViewFilter.ColumnUpdateTimeName = null;
            this.dataGridViewFilter.ColumnVideoCodeDataPropertyName = null;
            this.dataGridViewFilter.ColumnVideoContentTypeDataPropertyName = null;
            this.dataGridViewFilter.ColumnVideoLockTypeDataPropertyName = null;
            this.dataGridViewFilter.ColumnVideoLockTypeTextDataPropertyName = null;
            this.dataGridViewFilter.ColUpdatedIndex = 0;
            this.dataGridViewFilter.DataGridViewSource = null;
            this.dataGridViewFilter.DataSourceDisplay = null;
            this.dataGridViewFilter.DataTableSource = null;
            this.dataGridViewFilter.IsFilterActive = true;
            this.dataGridViewFilter.Location = new System.Drawing.Point(12, 32);
            this.dataGridViewFilter.MainMenuEditModeCollection = menuMainCollection1;
            this.dataGridViewFilter.Name = "dataGridViewFilter";
            this.dataGridViewFilter.SCREEN_TITLE = null;
            this.dataGridViewFilter.Size = new System.Drawing.Size(930, 467);
            this.dataGridViewFilter.TabIndex = 3;
            // 
            // dataGridViewButtonXColumn1
            // 
            this.dataGridViewButtonXColumn1.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange;
            this.dataGridViewButtonXColumn1.DataPropertyName = "Delete";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.NullValue = "Delete";
            this.dataGridViewButtonXColumn1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewButtonXColumn1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.dataGridViewButtonXColumn1.HeaderText = "";
            this.dataGridViewButtonXColumn1.MinimumWidth = 22;
            this.dataGridViewButtonXColumn1.Name = "dataGridViewButtonXColumn1";
            this.dataGridViewButtonXColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewButtonXColumn1.Text = null;
            this.dataGridViewButtonXColumn1.Width = 75;
            // 
            // dataGridViewCheckBoxXColumn1
            // 
            this.dataGridViewCheckBoxXColumn1.Checked = true;
            this.dataGridViewCheckBoxXColumn1.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.dataGridViewCheckBoxXColumn1.CheckValue = null;
            this.dataGridViewCheckBoxXColumn1.DataPropertyName = "選択";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewCheckBoxXColumn1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewCheckBoxXColumn1.HeaderText = "選択";
            this.dataGridViewCheckBoxXColumn1.MinimumWidth = 22;
            this.dataGridViewCheckBoxXColumn1.Name = "dataGridViewCheckBoxXColumn1";
            this.dataGridViewCheckBoxXColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxXColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxXColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewCheckBoxXColumn1.Width = 75;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "背景映像コード";
            this.dataGridViewTextBoxColumn1.HeaderText = "背景映像コード";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 22;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "素材ID";
            this.dataGridViewTextBoxColumn2.HeaderText = "素材ID";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 22;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "内容";
            this.dataGridViewTextBoxColumn3.HeaderText = "内容";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 22;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "素材終了日";
            this.dataGridViewTextBoxColumn4.HeaderText = "素材終了日";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 22;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "背景映像ロック";
            this.dataGridViewTextBoxColumn5.HeaderText = "背景映像ロック";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 22;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewTextBoxColumn5.Width = 150;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "UpdateDate";
            this.dataGridViewTextBoxColumn6.HeaderText = "colUpdateDate";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 22;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // colDelete
            // 
            this.colDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange;
            this.colDelete.DataPropertyName = "Delete";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = "削除";
            this.colDelete.DefaultCellStyle = dataGridViewCellStyle1;
            this.colDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colDelete.HeaderText = "";
            this.colDelete.MinimumWidth = 22;
            this.colDelete.Name = "colDelete";
            this.colDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colDelete.Text = null;
            this.colDelete.Width = 70;
            // 
            // colChoice
            // 
            this.colChoice.Checked = true;
            this.colChoice.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.colChoice.CheckValue = null;
            this.colChoice.DataPropertyName = "Choice";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colChoice.DefaultCellStyle = dataGridViewCellStyle2;
            this.colChoice.HeaderText = "選択";
            this.colChoice.MinimumWidth = 22;
            this.colChoice.Name = "colChoice";
            this.colChoice.ReadOnly = true;
            this.colChoice.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colChoice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colChoice.Width = 55;
            // 
            // colVideoCode
            // 
            this.colVideoCode.DataPropertyName = "VideoCode";
            this.colVideoCode.HeaderText = "背景映像コード";
            this.colVideoCode.MaxInputLength = 7;
            this.colVideoCode.MinimumWidth = 22;
            this.colVideoCode.Name = "colVideoCode";
            this.colVideoCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colVideoCode.Width = 150;
            // 
            // colMaterialID
            // 
            this.colMaterialID.DataPropertyName = "MaterialID";
            this.colMaterialID.HeaderText = "素材ID";
            this.colMaterialID.MaxInputLength = 15;
            this.colMaterialID.MaxValueInput = ((long)(9223372036854775807));
            this.colMaterialID.MinimumWidth = 22;
            this.colMaterialID.MinInputLength = 0;
            this.colMaterialID.Name = "colMaterialID";
            this.colMaterialID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colMaterialID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colMaterialID.Width = 150;
            // 
            // colContents
            // 
            this.colContents.DataPropertyName = "Contents";
            this.colContents.HeaderText = "内容";
            this.colContents.MaxInputLength = 250;
            this.colContents.MinimumWidth = 22;
            this.colContents.Name = "colContents";
            this.colContents.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colContents.Width = 150;
            // 
            // colMaterialEndDate
            // 
            // 
            // 
            // 
            this.colMaterialEndDate.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.colMaterialEndDate.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.colMaterialEndDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.colMaterialEndDate.BackgroundStyle.TextColor = System.Drawing.Color.Black;
            this.colMaterialEndDate.CustomFormat = "yyyy/MM/dd";
            this.colMaterialEndDate.DataPropertyName = "MaterialEndDate";
            dataGridViewCellStyle3.Format = "yyyy/MM/dd";
            this.colMaterialEndDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.colMaterialEndDate.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.colMaterialEndDate.HeaderText = "素材終了日";
            this.colMaterialEndDate.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.colMaterialEndDate.MinimumWidth = 22;
            // 
            // 
            // 
            // 
            // 
            // 
            this.colMaterialEndDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.colMaterialEndDate.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            // 
            // 
            // 
            this.colMaterialEndDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.colMaterialEndDate.MonthCalendar.DisplayMonth = new System.DateTime(2021, 5, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.colMaterialEndDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.colMaterialEndDate.Name = "colMaterialEndDate";
            this.colMaterialEndDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colMaterialEndDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colMaterialEndDate.Width = 130;
            // 
            // colBackgroundVideoLock
            // 
            this.colBackgroundVideoLock.DataPropertyName = "BackgroundVideoLock";
            this.colBackgroundVideoLock.DisplayMember = "Text";
            this.colBackgroundVideoLock.DropDownHeight = 106;
            this.colBackgroundVideoLock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colBackgroundVideoLock.DropDownWidth = 121;
            this.colBackgroundVideoLock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colBackgroundVideoLock.HeaderText = "背景映像ロック";
            this.colBackgroundVideoLock.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.colBackgroundVideoLock.IntegralHeight = false;
            this.colBackgroundVideoLock.ItemHeight = 15;
            this.colBackgroundVideoLock.MinimumWidth = 22;
            this.colBackgroundVideoLock.Name = "colBackgroundVideoLock";
            this.colBackgroundVideoLock.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colBackgroundVideoLock.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.colBackgroundVideoLock.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colBackgroundVideoLock.Width = 150;
            // 
            // colOldVideoCode
            // 
            this.colOldVideoCode.DataPropertyName = "OldVideoCode";
            this.colOldVideoCode.HeaderText = "col背景映像コードOld";
            this.colOldVideoCode.MinimumWidth = 22;
            this.colOldVideoCode.Name = "colOldVideoCode";
            this.colOldVideoCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colOldVideoCode.Visible = false;
            // 
            // colOldMaterialID
            // 
            this.colOldMaterialID.DataPropertyName = "OldMaterialID";
            this.colOldMaterialID.HeaderText = "col素材IDOld";
            this.colOldMaterialID.MinimumWidth = 22;
            this.colOldMaterialID.Name = "colOldMaterialID";
            this.colOldMaterialID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colOldMaterialID.Visible = false;
            // 
            // colOldContents
            // 
            this.colOldContents.DataPropertyName = "OldContents";
            this.colOldContents.HeaderText = "col内容Old";
            this.colOldContents.MinimumWidth = 22;
            this.colOldContents.Name = "colOldContents";
            this.colOldContents.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colOldContents.Visible = false;
            // 
            // colOldMaterialEndDate
            // 
            this.colOldMaterialEndDate.DataPropertyName = "OldMaterialEndDate";
            this.colOldMaterialEndDate.HeaderText = "col素材終了日Old";
            this.colOldMaterialEndDate.MinimumWidth = 22;
            this.colOldMaterialEndDate.Name = "colOldMaterialEndDate";
            this.colOldMaterialEndDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colOldMaterialEndDate.Visible = false;
            // 
            // colOldBackgroundVideoLock
            // 
            this.colOldBackgroundVideoLock.DataPropertyName = "OldBackgroundVideoLock";
            this.colOldBackgroundVideoLock.HeaderText = "col背景映像ロックOld";
            this.colOldBackgroundVideoLock.MinimumWidth = 22;
            this.colOldBackgroundVideoLock.Name = "colOldBackgroundVideoLock";
            this.colOldBackgroundVideoLock.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colOldBackgroundVideoLock.Visible = false;
            // 
            // colUpdateDate
            // 
            this.colUpdateDate.DataPropertyName = "UpdateDate";
            this.colUpdateDate.HeaderText = "colUpdateDate";
            this.colUpdateDate.MinimumWidth = 22;
            this.colUpdateDate.Name = "colUpdateDate";
            this.colUpdateDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colUpdateDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colUpdateDate.Visible = false;
            // 
            // colVideoCodeId
            // 
            this.colVideoCodeId.DataPropertyName = "VideoCodeId";
            this.colVideoCodeId.HeaderText = "VideoCodeId";
            this.colVideoCodeId.MinimumWidth = 22;
            this.colVideoCodeId.Name = "colVideoCodeId";
            this.colVideoCodeId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colVideoCodeId.Visible = false;
            // 
            // VideoMaintenanceMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(954, 511);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.advVideoMain);
            this.Controls.Add(this.dataGridViewFilter);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VideoMaintenanceMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "背景映像メンテ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VideoMaintenanceMain_FormClosing);
            this.Load += new System.EventHandler(this.VideoMaintenanceMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.advVideoMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnSave;
        private Zuby.ADGV.AdvancedDataGridView advVideoMain;
        private Base.DataGridViewFilter dataGridViewFilter;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn dataGridViewCheckBoxXColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn dataGridViewButtonXColumn1;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn colDelete;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn colChoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVideoCode;
        private Base.DataGridViewNumericColumn colMaterialID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContents;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn colMaterialEndDate;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn colBackgroundVideoLock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOldVideoCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOldMaterialID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOldContents;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOldMaterialEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOldBackgroundVideoLock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUpdateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVideoCodeId;
    }
}