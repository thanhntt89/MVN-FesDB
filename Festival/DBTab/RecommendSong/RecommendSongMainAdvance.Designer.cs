using Zuby.ADGV;

namespace Festival.DBTab.RecommendSong
{
    partial class RecommendSongMainAdvance
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            Festival.Base.MenuMainCollection menuMainCollection1 = new Festival.Base.MenuMainCollection();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtgFestContent = new Zuby.ADGV.AdvancedDataGridView();
            this.dataGridViewFilter = new Festival.Base.DataGridViewFilter();
            this.col選択 = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.colプログラムID = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.colプログラム名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWiiデジドコ選曲番号 = new Festival.Base.DataGridViewNumericColumn();
            this.colカラオケ選曲番号 = new Festival.Base.DataGridViewNumericColumn();
            this.col楽曲名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col歌手名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFes_DISCID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col有料コンテンツフラグ = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.col有償情報フラグ = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.colサービス発表日 = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.col取消フラグ = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.col表示順 = new Festival.Base.DataGridViewNumericColumn();
            this.col削除 = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.col更新日時 = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.colデジドココンテンツID = new Festival.Base.DataGridViewNumericColumn();
            this.colId = new Festival.Base.DataGridViewNumericColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFestContent)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgFestContent
            // 
            this.dtgFestContent.AllowUserToAddRows = false;
            this.dtgFestContent.AllowUserToDeleteRows = false;
            this.dtgFestContent.AllowUserToOrderColumns = true;
            this.dtgFestContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgFestContent.ColumnHeadersHeight = 24;
            this.dtgFestContent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col選択,
            this.colプログラムID,
            this.colプログラム名,
            this.colWiiデジドコ選曲番号,
            this.colカラオケ選曲番号,
            this.col楽曲名,
            this.col歌手名,
            this.colFes_DISCID,
            this.col有料コンテンツフラグ,
            this.col有償情報フラグ,
            this.colサービス発表日,
            this.col取消フラグ,
            this.col表示順,
            this.col削除,
            this.col更新日時,
            this.colデジドココンテンツID,
            this.colId});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgFestContent.DefaultCellStyle = dataGridViewCellStyle6;
            this.dtgFestContent.FilterAndSortEnabled = true;
            this.dtgFestContent.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.dtgFestContent.Location = new System.Drawing.Point(14, 22);
            this.dtgFestContent.Name = "dtgFestContent";
            this.dtgFestContent.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtgFestContent.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dtgFestContent.ShowCellErrors = false;
            this.dtgFestContent.Size = new System.Drawing.Size(936, 465);
            this.dtgFestContent.TabIndex = 19;
            this.dtgFestContent.Visible = false;
            // 
            // dataGridViewFilter
            // 
            this.dataGridViewFilter.AllowUserEdit = false;
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
            this.dataGridViewFilter.DataGridViewSource = this.dtgFestContent;
            this.dataGridViewFilter.DataSourceDisplay = null;
            this.dataGridViewFilter.DataTableSource = null;
            this.dataGridViewFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewFilter.IsFilterActive = false;
            this.dataGridViewFilter.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewFilter.MainMenuEditModeCollection = menuMainCollection1;
            this.dataGridViewFilter.Name = "dataGridViewFilter";
            this.dataGridViewFilter.SCREEN_TITLE = null;
            this.dataGridViewFilter.Size = new System.Drawing.Size(970, 547);
            this.dataGridViewFilter.TabIndex = 1;
            // 
            // col選択
            // 
            this.col選択.Checked = true;
            this.col選択.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.col選択.CheckValue = null;
            this.col選択.DataPropertyName = "選択";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col選択.DefaultCellStyle = dataGridViewCellStyle1;
            this.col選択.HeaderText = "選択";
            this.col選択.MinimumWidth = 22;
            this.col選択.Name = "col選択";
            this.col選択.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.col選択.Width = 50;
            // 
            // colプログラムID
            // 
            this.colプログラムID.DataPropertyName = "プログラムID";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Yellow;
            this.colプログラムID.DefaultCellStyle = dataGridViewCellStyle2;
            this.colプログラムID.DisplayMember = "Text";
            this.colプログラムID.DropDownHeight = 106;
            this.colプログラムID.DropDownWidth = 121;
            this.colプログラムID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colプログラムID.HeaderText = "おすすめプログラム";
            this.colプログラムID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.colプログラムID.IntegralHeight = false;
            this.colプログラムID.ItemHeight = 15;
            this.colプログラムID.MinimumWidth = 22;
            this.colプログラムID.Name = "colプログラムID";
            this.colプログラムID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colプログラムID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.colプログラムID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // colプログラム名
            // 
            this.colプログラム名.DataPropertyName = "プログラム名";
            this.colプログラム名.HeaderText = "おすすめプログラム名";
            this.colプログラム名.MinimumWidth = 22;
            this.colプログラム名.Name = "colプログラム名";
            this.colプログラム名.ReadOnly = true;
            this.colプログラム名.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // colWiiデジドコ選曲番号
            // 
            this.colWiiデジドコ選曲番号.DataPropertyName = "Wiiデジドコ選曲番号";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Yellow;
            this.colWiiデジドコ選曲番号.DefaultCellStyle = dataGridViewCellStyle3;
            this.colWiiデジドコ選曲番号.HeaderText = "デジドコNo";
            this.colWiiデジドコ選曲番号.MaxInputLength = 6;
            this.colWiiデジドコ選曲番号.MaxValueInput = ((long)(2147483647));
            this.colWiiデジドコ選曲番号.MinimumWidth = 22;
            this.colWiiデジドコ選曲番号.MinInputLength = 0;
            this.colWiiデジドコ選曲番号.Name = "colWiiデジドコ選曲番号";
            this.colWiiデジドコ選曲番号.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colWiiデジドコ選曲番号.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // colカラオケ選曲番号
            // 
            this.colカラオケ選曲番号.DataPropertyName = "カラオケ選曲番号";
            this.colカラオケ選曲番号.HeaderText = "カラオケNo";
            this.colカラオケ選曲番号.MaxInputLength = 8;
            this.colカラオケ選曲番号.MaxValueInput = ((long)(2147483647));
            this.colカラオケ選曲番号.MinimumWidth = 22;
            this.colカラオケ選曲番号.MinInputLength = 0;
            this.colカラオケ選曲番号.Name = "colカラオケ選曲番号";
            this.colカラオケ選曲番号.ReadOnly = true;
            this.colカラオケ選曲番号.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // col楽曲名
            // 
            this.col楽曲名.DataPropertyName = "楽曲名";
            this.col楽曲名.HeaderText = "曲名(MARY)";
            this.col楽曲名.MinimumWidth = 22;
            this.col楽曲名.Name = "col楽曲名";
            this.col楽曲名.ReadOnly = true;
            this.col楽曲名.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.col楽曲名.Width = 150;
            // 
            // col歌手名
            // 
            this.col歌手名.DataPropertyName = "歌手名";
            this.col歌手名.HeaderText = "歌手名";
            this.col歌手名.MinimumWidth = 22;
            this.col歌手名.Name = "col歌手名";
            this.col歌手名.ReadOnly = true;
            this.col歌手名.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.col歌手名.Width = 150;
            // 
            // colFes_DISCID
            // 
            this.colFes_DISCID.DataPropertyName = "FesDISCID";
            this.colFes_DISCID.HeaderText = "Fes_DISCID";
            this.colFes_DISCID.MinimumWidth = 22;
            this.colFes_DISCID.Name = "colFes_DISCID";
            this.colFes_DISCID.ReadOnly = true;
            this.colFes_DISCID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // col有料コンテンツフラグ
            // 
            this.col有料コンテンツフラグ.DataPropertyName = "有料コンテンツフラグ";
            this.col有料コンテンツフラグ.DropDownHeight = 106;
            this.col有料コンテンツフラグ.DropDownWidth = 121;
            this.col有料コンテンツフラグ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.col有料コンテンツフラグ.HeaderText = "Fes_有料コンテンツフラグ";
            this.col有料コンテンツフラグ.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.col有料コンテンツフラグ.IntegralHeight = false;
            this.col有料コンテンツフラグ.ItemHeight = 15;
            this.col有料コンテンツフラグ.MinimumWidth = 22;
            this.col有料コンテンツフラグ.Name = "col有料コンテンツフラグ";
            this.col有料コンテンツフラグ.ReadOnly = true;
            this.col有料コンテンツフラグ.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.col有料コンテンツフラグ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // col有償情報フラグ
            // 
            this.col有償情報フラグ.DataPropertyName = "有償情報フラグ";
            this.col有償情報フラグ.DropDownHeight = 106;
            this.col有償情報フラグ.DropDownWidth = 121;
            this.col有償情報フラグ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.col有償情報フラグ.HeaderText = "Fes_有償フラグ";
            this.col有償情報フラグ.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.col有償情報フラグ.IntegralHeight = false;
            this.col有償情報フラグ.ItemHeight = 15;
            this.col有償情報フラグ.MinimumWidth = 22;
            this.col有償情報フラグ.Name = "col有償情報フラグ";
            this.col有償情報フラグ.ReadOnly = true;
            this.col有償情報フラグ.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.col有償情報フラグ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // colサービス発表日
            // 
            // 
            // 
            // 
            this.colサービス発表日.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.colサービス発表日.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.colサービス発表日.CustomFormat = "yyyy/MM/dd";
            this.colサービス発表日.DataPropertyName = "サービス発表日";
            this.colサービス発表日.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.colサービス発表日.HeaderText = "Fes_サービス発表日";
            this.colサービス発表日.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.colサービス発表日.MinimumWidth = 22;
            // 
            // 
            // 
            // 
            // 
            // 
            this.colサービス発表日.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.colサービス発表日.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            // 
            // 
            // 
            this.colサービス発表日.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.colサービス発表日.MonthCalendar.DisplayMonth = new System.DateTime(2020, 7, 1, 0, 0, 0, 0);
            this.colサービス発表日.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.colサービス発表日.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.colサービス発表日.Name = "colサービス発表日";
            this.colサービス発表日.ReadOnly = true;
            this.colサービス発表日.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colサービス発表日.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // col取消フラグ
            // 
            this.col取消フラグ.DataPropertyName = "取消フラグ";
            this.col取消フラグ.DropDownHeight = 106;
            this.col取消フラグ.DropDownWidth = 121;
            this.col取消フラグ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.col取消フラグ.HeaderText = "Fes_取消フラグ";
            this.col取消フラグ.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.col取消フラグ.IntegralHeight = false;
            this.col取消フラグ.ItemHeight = 15;
            this.col取消フラグ.MinimumWidth = 22;
            this.col取消フラグ.Name = "col取消フラグ";
            this.col取消フラグ.ReadOnly = true;
            this.col取消フラグ.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col取消フラグ.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.col取消フラグ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // col表示順
            // 
            this.col表示順.DataPropertyName = "表示順";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Yellow;
            this.col表示順.DefaultCellStyle = dataGridViewCellStyle4;
            this.col表示順.HeaderText = "表示順";
            this.col表示順.MaxInputLength = 8;
            this.col表示順.MaxValueInput = ((long)(2147483647));
            this.col表示順.MinimumWidth = 22;
            this.col表示順.MinInputLength = 0;
            this.col表示順.Name = "col表示順";
            this.col表示順.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col表示順.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // col削除
            // 
            this.col削除.Checked = true;
            this.col削除.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.col削除.CheckValue = "N";
            this.col削除.DataPropertyName = "削除";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Yellow;
            this.col削除.DefaultCellStyle = dataGridViewCellStyle5;
            this.col削除.HeaderText = "削除";
            this.col削除.MinimumWidth = 22;
            this.col削除.Name = "col削除";
            this.col削除.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col削除.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.col削除.Width = 50;
            // 
            // col更新日時
            // 
            // 
            // 
            // 
            this.col更新日時.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.col更新日時.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.col更新日時.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.col更新日時.DataPropertyName = "更新日時";
            this.col更新日時.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.col更新日時.HeaderText = "更新日時";
            this.col更新日時.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.col更新日時.MinimumWidth = 22;
            // 
            // 
            // 
            // 
            // 
            // 
            this.col更新日時.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.col更新日時.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            // 
            // 
            // 
            this.col更新日時.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.col更新日時.MonthCalendar.DisplayMonth = new System.DateTime(2020, 8, 1, 0, 0, 0, 0);
            this.col更新日時.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.col更新日時.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.col更新日時.Name = "col更新日時";
            this.col更新日時.ReadOnly = true;
            this.col更新日時.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col更新日時.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.col更新日時.Visible = false;
            // 
            // colデジドココンテンツID
            // 
            this.colデジドココンテンツID.DataPropertyName = "デジドココンテンツID";
            this.colデジドココンテンツID.HeaderText = "デジドココンテンツID";
            this.colデジドココンテンツID.MaxInputLength = 8;
            this.colデジドココンテンツID.MaxValueInput = ((long)(2147483647));
            this.colデジドココンテンツID.MinimumWidth = 22;
            this.colデジドココンテンツID.MinInputLength = 0;
            this.colデジドココンテンツID.Name = "colデジドココンテンツID";
            this.colデジドココンテンツID.ReadOnly = true;
            this.colデジドココンテンツID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colデジドココンテンツID.Visible = false;
            this.colデジドココンテンツID.Width = 22;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "ID";
            this.colId.HeaderText = "ID";
            this.colId.MaxInputLength = 8;
            this.colId.MaxValueInput = ((long)(2147483647));
            this.colId.MinimumWidth = 22;
            this.colId.MinInputLength = 0;
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colId.Visible = false;
            // 
            // RecommendSongMainAdvance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.dtgFestContent);
            this.Controls.Add(this.dataGridViewFilter);
            this.Name = "RecommendSongMainAdvance";
            this.SCREEN_TITLE = "おすすめ曲管理";
            this.Size = new System.Drawing.Size(970, 547);
            this.Load += new System.EventHandler(this.DisVideoSearchMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFestContent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Base.DataGridViewFilter dataGridViewFilter;
        private AdvancedDataGridView dtgFestContent;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn col選択;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn colプログラムID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colプログラム名;
        private Base.DataGridViewNumericColumn colWiiデジドコ選曲番号;
        private Base.DataGridViewNumericColumn colカラオケ選曲番号;
        private System.Windows.Forms.DataGridViewTextBoxColumn col楽曲名;
        private System.Windows.Forms.DataGridViewTextBoxColumn col歌手名;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFes_DISCID;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn col有料コンテンツフラグ;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn col有償情報フラグ;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn colサービス発表日;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn col取消フラグ;
        private Base.DataGridViewNumericColumn col表示順;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn col削除;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn col更新日時;
        private Base.DataGridViewNumericColumn colデジドココンテンツID;
        private Base.DataGridViewNumericColumn colId;
    }
}
