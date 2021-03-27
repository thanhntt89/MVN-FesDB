using Zuby.ADGV;

namespace Festival.DiscVideoTab.FesVideoAssigment
{
    partial class FesVideoAssigmentMainAdvance
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
            Festival.Base.MenuMainCollection menuMainCollection1 = new Festival.Base.MenuMainCollection();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewFilter = new Festival.Base.DataGridViewFilter();
            this.advFesVideoAssigment = new Zuby.ADGV.AdvancedDataGridView();
            this.col選択 = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.colWiiデジドコ選曲番号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colカラオケ選曲番号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col楽曲名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col歌手名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col楽曲名検索用カナ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col曲名よみがな補正 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col歌手名検索用カナ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col背景映像コード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colアップ予定日 = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.colサービス発表日 = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.col取消フラグ = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.colJV映像区分背景映像区分 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col備考 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col削除 = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.col更新日時 = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.colデジドココンテンツID = new Festival.Base.DataGridViewNumericColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advFesVideoAssigment)).BeginInit();
            this.SuspendLayout();
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
            this.dataGridViewFilter.DataGridViewSource = null;
            this.dataGridViewFilter.DataSourceDisplay = null;
            this.dataGridViewFilter.DataTableSource = null;
            this.dataGridViewFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewFilter.IsFilterActive = false;
            this.dataGridViewFilter.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewFilter.MainMenuEditModeCollection = menuMainCollection1;
            this.dataGridViewFilter.Name = "dataGridViewFilter";
            this.dataGridViewFilter.SCREEN_TITLE = null;
            this.dataGridViewFilter.Size = new System.Drawing.Size(800, 400);
            this.dataGridViewFilter.TabIndex = 1;
            // 
            // advFesVideoAssigment
            // 
            this.advFesVideoAssigment.AllowUserToAddRows = false;
            this.advFesVideoAssigment.AllowUserToDeleteRows = false;
            this.advFesVideoAssigment.AllowUserToOrderColumns = true;
            this.advFesVideoAssigment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.advFesVideoAssigment.ColumnHeadersHeight = 24;
            this.advFesVideoAssigment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col選択,
            this.colWiiデジドコ選曲番号,
            this.colカラオケ選曲番号,
            this.col楽曲名,
            this.col歌手名,
            this.col楽曲名検索用カナ,
            this.col曲名よみがな補正,
            this.col歌手名検索用カナ,
            this.col背景映像コード,
            this.colアップ予定日,
            this.colサービス発表日,
            this.col取消フラグ,
            this.colJV映像区分背景映像区分,
            this.col備考,
            this.col削除,
            this.col更新日時,
            this.colデジドココンテンツID});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.advFesVideoAssigment.DefaultCellStyle = dataGridViewCellStyle4;
            this.advFesVideoAssigment.FilterAndSortEnabled = true;
            this.advFesVideoAssigment.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.advFesVideoAssigment.Location = new System.Drawing.Point(3, 3);
            this.advFesVideoAssigment.Name = "advFesVideoAssigment";
            this.advFesVideoAssigment.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advFesVideoAssigment.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.advFesVideoAssigment.ShowCellErrors = false;
            this.advFesVideoAssigment.Size = new System.Drawing.Size(794, 344);
            this.advFesVideoAssigment.TabIndex = 23;
            this.advFesVideoAssigment.Visible = false;
            // 
            // col選択
            // 
            this.col選択.Checked = true;
            this.col選択.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.col選択.CheckValue = "N";
            this.col選択.DataPropertyName = "選択";
            this.col選択.HeaderText = "選択";
            this.col選択.MinimumWidth = 22;
            this.col選択.Name = "col選択";
            this.col選択.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col選択.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.col選択.Width = 50;
            // 
            // colWiiデジドコ選曲番号
            // 
            this.colWiiデジドコ選曲番号.DataPropertyName = "Wiiデジドコ選曲番号";
            this.colWiiデジドコ選曲番号.HeaderText = "デジドコNo";
            this.colWiiデジドコ選曲番号.MaxInputLength = 8;
            this.colWiiデジドコ選曲番号.MinimumWidth = 22;
            this.colWiiデジドコ選曲番号.Name = "colWiiデジドコ選曲番号";
            this.colWiiデジドコ選曲番号.ReadOnly = true;
            this.colWiiデジドコ選曲番号.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // colカラオケ選曲番号
            // 
            this.colカラオケ選曲番号.DataPropertyName = "カラオケ選曲番号";
            this.colカラオケ選曲番号.HeaderText = "カラオケNo";
            this.colカラオケ選曲番号.MaxInputLength = 8;
            this.colカラオケ選曲番号.MinimumWidth = 22;
            this.colカラオケ選曲番号.Name = "colカラオケ選曲番号";
            this.colカラオケ選曲番号.ReadOnly = true;
            this.colカラオケ選曲番号.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // col楽曲名
            // 
            this.col楽曲名.DataPropertyName = "楽曲名";
            this.col楽曲名.HeaderText = "曲名(MARY)";
            this.col楽曲名.MaxInputLength = 150;
            this.col楽曲名.MinimumWidth = 22;
            this.col楽曲名.Name = "col楽曲名";
            this.col楽曲名.ReadOnly = true;
            this.col楽曲名.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.col楽曲名.Width = 250;
            // 
            // col歌手名
            // 
            this.col歌手名.DataPropertyName = "歌手名";
            this.col歌手名.HeaderText = "歌手名";
            this.col歌手名.MaxInputLength = 100;
            this.col歌手名.MinimumWidth = 22;
            this.col歌手名.Name = "col歌手名";
            this.col歌手名.ReadOnly = true;
            this.col歌手名.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.col歌手名.Width = 250;
            // 
            // col楽曲名検索用カナ
            // 
            this.col楽曲名検索用カナ.DataPropertyName = "楽曲名検索用カナ";
            this.col楽曲名検索用カナ.HeaderText = "楽曲名カナ";
            this.col楽曲名検索用カナ.MaxInputLength = 900;
            this.col楽曲名検索用カナ.MinimumWidth = 22;
            this.col楽曲名検索用カナ.Name = "col楽曲名検索用カナ";
            this.col楽曲名検索用カナ.ReadOnly = true;
            this.col楽曲名検索用カナ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.col楽曲名検索用カナ.Width = 130;
            // 
            // col曲名よみがな補正
            // 
            this.col曲名よみがな補正.DataPropertyName = "曲名よみがな補正";
            this.col曲名よみがな補正.HeaderText = "曲名カナ補正";
            this.col曲名よみがな補正.MaxInputLength = 256;
            this.col曲名よみがな補正.MinimumWidth = 22;
            this.col曲名よみがな補正.Name = "col曲名よみがな補正";
            this.col曲名よみがな補正.ReadOnly = true;
            this.col曲名よみがな補正.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.col曲名よみがな補正.Width = 130;
            // 
            // col歌手名検索用カナ
            // 
            this.col歌手名検索用カナ.DataPropertyName = "歌手名検索用カナ";
            this.col歌手名検索用カナ.HeaderText = "歌手名カナ";
            this.col歌手名検索用カナ.MaxInputLength = 450;
            this.col歌手名検索用カナ.MinimumWidth = 22;
            this.col歌手名検索用カナ.Name = "col歌手名検索用カナ";
            this.col歌手名検索用カナ.ReadOnly = true;
            this.col歌手名検索用カナ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.col歌手名検索用カナ.Width = 120;
            // 
            // col背景映像コード
            // 
            this.col背景映像コード.DataPropertyName = "背景映像コード";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Yellow;
            this.col背景映像コード.DefaultCellStyle = dataGridViewCellStyle1;
            this.col背景映像コード.HeaderText = "背景映像コード";
            this.col背景映像コード.MaxInputLength = 7;
            this.col背景映像コード.MinimumWidth = 22;
            this.col背景映像コード.Name = "col背景映像コード";
            this.col背景映像コード.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.col背景映像コード.Width = 150;
            // 
            // colアップ予定日
            // 
            // 
            // 
            // 
            this.colアップ予定日.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.colアップ予定日.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.colアップ予定日.CustomFormat = "yyyy/MM/dd";
            this.colアップ予定日.DataPropertyName = "アップ予定日";
            this.colアップ予定日.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.colアップ予定日.HeaderText = "Fes_アップ予定日";
            this.colアップ予定日.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.colアップ予定日.MinimumWidth = 22;
            // 
            // 
            // 
            // 
            // 
            // 
            this.colアップ予定日.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.colアップ予定日.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            // 
            // 
            // 
            this.colアップ予定日.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.colアップ予定日.MonthCalendar.DisplayMonth = new System.DateTime(2020, 7, 1, 0, 0, 0, 0);
            this.colアップ予定日.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.colアップ予定日.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.colアップ予定日.Name = "colアップ予定日";
            this.colアップ予定日.ReadOnly = true;
            this.colアップ予定日.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colアップ予定日.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colアップ予定日.Width = 110;
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
            this.colサービス発表日.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
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
            this.colサービス発表日.Width = 110;
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
            this.col取消フラグ.Width = 110;
            // 
            // colJV映像区分背景映像区分
            // 
            this.colJV映像区分背景映像区分.DataPropertyName = "JV映像区分背景映像区分";
            this.colJV映像区分背景映像区分.HeaderText = "JV映像区分(背景映像区分)";
            this.colJV映像区分背景映像区分.MaxInputLength = 100;
            this.colJV映像区分背景映像区分.MinimumWidth = 22;
            this.colJV映像区分背景映像区分.Name = "colJV映像区分背景映像区分";
            this.colJV映像区分背景映像区分.ReadOnly = true;
            this.colJV映像区分背景映像区分.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colJV映像区分背景映像区分.Width = 120;
            // 
            // col備考
            // 
            this.col備考.DataPropertyName = "備考";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Yellow;
            this.col備考.DefaultCellStyle = dataGridViewCellStyle2;
            this.col備考.HeaderText = "備考";
            this.col備考.MaxInputLength = 255;
            this.col備考.MinimumWidth = 22;
            this.col備考.Name = "col備考";
            this.col備考.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // col削除
            // 
            this.col削除.Checked = true;
            this.col削除.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.col削除.CheckValue = "N";
            this.col削除.DataPropertyName = "削除";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Yellow;
            this.col削除.DefaultCellStyle = dataGridViewCellStyle3;
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
            this.col更新日時.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
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
            this.col更新日時.MonthCalendar.DisplayMonth = new System.DateTime(2020, 7, 1, 0, 0, 0, 0);
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
            this.colデジドココンテンツID.MaxInputLength = 9;
            this.colデジドココンテンツID.MaxValueInput = ((long)(999999999));
            this.colデジドココンテンツID.MinimumWidth = 22;
            this.colデジドココンテンツID.MinInputLength = 0;
            this.colデジドココンテンツID.Name = "colデジドココンテンツID";
            this.colデジドココンテンツID.ReadOnly = true;
            this.colデジドココンテンツID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colデジドココンテンツID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colデジドココンテンツID.Visible = false;
            // 
            // FesVideoAssigmentMainAdvance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.advFesVideoAssigment);
            this.Controls.Add(this.dataGridViewFilter);
            this.Name = "FesVideoAssigmentMainAdvance";
            this.SCREEN_TITLE = "個別映像割付";
            this.Size = new System.Drawing.Size(800, 400);
            this.Load += new System.EventHandler(this.FesVideoAssigmentMainAdvance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advFesVideoAssigment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Base.DataGridViewFilter dataGridViewFilter;
        private AdvancedDataGridView advFesVideoAssigment;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn col選択;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWiiデジドコ選曲番号;
        private System.Windows.Forms.DataGridViewTextBoxColumn colカラオケ選曲番号;
        private System.Windows.Forms.DataGridViewTextBoxColumn col楽曲名;
        private System.Windows.Forms.DataGridViewTextBoxColumn col歌手名;
        private System.Windows.Forms.DataGridViewTextBoxColumn col楽曲名検索用カナ;
        private System.Windows.Forms.DataGridViewTextBoxColumn col曲名よみがな補正;
        private System.Windows.Forms.DataGridViewTextBoxColumn col歌手名検索用カナ;
        private System.Windows.Forms.DataGridViewTextBoxColumn col背景映像コード;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn colアップ予定日;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn colサービス発表日;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn col取消フラグ;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJV映像区分背景映像区分;
        private System.Windows.Forms.DataGridViewTextBoxColumn col備考;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn col削除;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn col更新日時;
        private Base.DataGridViewNumericColumn colデジドココンテンツID;
    }
}
