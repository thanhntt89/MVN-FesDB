using Zuby.ADGV;

namespace Festival.DiscVideoTab.FesSongAddDelete
{
    partial class FesSongAddDeleteMainAdvance
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewFilter = new Festival.Base.DataGridViewFilter();
            this.advFesSongAddDelete = new Zuby.ADGV.AdvancedDataGridView();
            this.col選択 = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.col通番 = new Festival.Base.DataGridViewNumericColumn();
            this.col追加削除区分 = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.colWiiデジドコ選曲番号 = new Festival.Base.DataGridViewNumericColumn();
            this.colカラオケ選曲番号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col楽曲名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col歌手名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFesDISCID = new Festival.Base.DataGridViewNumericColumn();
            this.colデータサイズ = new Festival.Base.DataGridViewNumericColumn();
            this.col有料コンテンツフラグ = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.col有償情報フラグ = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.col備考 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col登録日 = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.colアップ予定日 = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.colサービス発表日 = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.col取消フラグ = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.col削除 = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.col更新日時 = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.colID = new Festival.Base.DataGridViewNumericColumn();
           
            ((System.ComponentModel.ISupportInitialize)(this.advFesSongAddDelete)).BeginInit();
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
            // advFesSongAddDelete
            // 
            this.advFesSongAddDelete.AllowUserToAddRows = false;
            this.advFesSongAddDelete.AllowUserToDeleteRows = false;
            this.advFesSongAddDelete.AllowUserToOrderColumns = true;
            this.advFesSongAddDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.advFesSongAddDelete.ColumnHeadersHeight = 24;
            this.advFesSongAddDelete.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col選択,
            this.col通番,
            this.col追加削除区分,
            this.colWiiデジドコ選曲番号,
            this.colカラオケ選曲番号,
            this.col楽曲名,
            this.col歌手名,
            this.colFesDISCID,
            this.colデータサイズ,
            this.col有料コンテンツフラグ,
            this.col有償情報フラグ,
            this.col備考,
            this.col登録日,
            this.colアップ予定日,
            this.colサービス発表日,
            this.col取消フラグ,
            this.col削除,
            this.col更新日時,
            this.colID});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.advFesSongAddDelete.DefaultCellStyle = dataGridViewCellStyle10;
            this.advFesSongAddDelete.FilterAndSortEnabled = true;
            this.advFesSongAddDelete.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.advFesSongAddDelete.IsLoadConfig = false;
            this.advFesSongAddDelete.Location = new System.Drawing.Point(3, 3);
            this.advFesSongAddDelete.Name = "advFesSongAddDelete";
            this.advFesSongAddDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advFesSongAddDelete.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.advFesSongAddDelete.ShowCellErrors = false;
            this.advFesSongAddDelete.Size = new System.Drawing.Size(794, 344);
            this.advFesSongAddDelete.TabIndex = 23;
            this.advFesSongAddDelete.Visible = false;
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
            // col通番
            // 
            this.col通番.DataPropertyName = "通番";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Yellow;
            this.col通番.DefaultCellStyle = dataGridViewCellStyle1;
            this.col通番.HeaderText = "通番";
            this.col通番.MaxInputLength = 9;
            this.col通番.MaxValueInput = ((long)(2147483647));
            this.col通番.MinimumWidth = 22;
            this.col通番.MinInputLength = 0;
            this.col通番.Name = "col通番";
            this.col通番.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col通番.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.col通番.Width = 150;
            // 
            // col追加削除区分
            // 
            this.col追加削除区分.DataPropertyName = "追加削除区分";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Yellow;
            this.col追加削除区分.DefaultCellStyle = dataGridViewCellStyle2;
            this.col追加削除区分.DropDownHeight = 106;
            this.col追加削除区分.DropDownWidth = 121;
            this.col追加削除区分.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.col追加削除区分.HeaderText = "追加削除区分";
            this.col追加削除区分.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.col追加削除区分.IntegralHeight = false;
            this.col追加削除区分.ItemHeight = 15;
            this.col追加削除区分.MinimumWidth = 22;
            this.col追加削除区分.Name = "col追加削除区分";
            this.col追加削除区分.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col追加削除区分.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.col追加削除区分.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.col追加削除区分.Width = 150;
            // 
            // colWiiデジドコ選曲番号
            // 
            this.colWiiデジドコ選曲番号.DataPropertyName = "Wiiデジドコ選曲番号";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Yellow;
            this.colWiiデジドコ選曲番号.DefaultCellStyle = dataGridViewCellStyle3;
            this.colWiiデジドコ選曲番号.HeaderText = "デジドコNo";
            this.colWiiデジドコ選曲番号.MaxInputLength = 8;
            this.colWiiデジドコ選曲番号.MaxValueInput = ((long)(2147483647));
            this.colWiiデジドコ選曲番号.MinimumWidth = 22;
            this.colWiiデジドコ選曲番号.MinInputLength = 0;
            this.colWiiデジドコ選曲番号.Name = "colWiiデジドコ選曲番号";
            this.colWiiデジドコ選曲番号.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colWiiデジドコ選曲番号.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colWiiデジドコ選曲番号.Width = 120;
            // 
            // colカラオケ選曲番号
            // 
            this.colカラオケ選曲番号.DataPropertyName = "カラオケ選曲番号";
            this.colカラオケ選曲番号.HeaderText = "カラオケNo";
            this.colカラオケ選曲番号.MaxInputLength = 10;
            this.colカラオケ選曲番号.MinimumWidth = 22;
            this.colカラオケ選曲番号.Name = "colカラオケ選曲番号";
            this.colカラオケ選曲番号.ReadOnly = true;
            this.colカラオケ選曲番号.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colカラオケ選曲番号.Width = 200;
            // 
            // col楽曲名
            // 
            this.col楽曲名.DataPropertyName = "楽曲名";
            this.col楽曲名.HeaderText = "曲名(MARY)";
            this.col楽曲名.MinimumWidth = 22;
            this.col楽曲名.Name = "col楽曲名";
            this.col楽曲名.ReadOnly = true;
            this.col楽曲名.Resizable = System.Windows.Forms.DataGridViewTriState.True;
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
            this.col歌手名.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col歌手名.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.col歌手名.Width = 150;
            // 
            // colFesDISCID
            // 
            this.colFesDISCID.DataPropertyName = "FesDISCID";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Yellow;
            this.colFesDISCID.DefaultCellStyle = dataGridViewCellStyle4;
            this.colFesDISCID.HeaderText = "Fes_DISCID";
            this.colFesDISCID.MaxInputLength = 8;
            this.colFesDISCID.MaxValueInput = ((long)(2147483647));
            this.colFesDISCID.MinimumWidth = 22;
            this.colFesDISCID.MinInputLength = 0;
            this.colFesDISCID.Name = "colFesDISCID";
            this.colFesDISCID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colFesDISCID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colFesDISCID.Width = 150;
            // 
            // colデータサイズ
            // 
            this.colデータサイズ.DataPropertyName = "データサイズ";
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Yellow;
            this.colデータサイズ.DefaultCellStyle = dataGridViewCellStyle5;
            this.colデータサイズ.HeaderText = "Fes_データサイズ";
            this.colデータサイズ.MaxInputLength = 9;
            this.colデータサイズ.MaxValueInput = ((long)(2147483647));
            this.colデータサイズ.MinimumWidth = 22;
            this.colデータサイズ.MinInputLength = 0;
            this.colデータサイズ.Name = "colデータサイズ";
            this.colデータサイズ.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colデータサイズ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
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
            this.col有料コンテンツフラグ.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col有料コンテンツフラグ.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.col有料コンテンツフラグ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // col有償情報フラグ
            // 
            this.col有償情報フラグ.DataPropertyName = "有償情報フラグ";
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Yellow;
            this.col有償情報フラグ.DefaultCellStyle = dataGridViewCellStyle6;
            this.col有償情報フラグ.DropDownHeight = 106;
            this.col有償情報フラグ.DropDownWidth = 121;
            this.col有償情報フラグ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.col有償情報フラグ.HeaderText = "Fes_有償フラグ";
            this.col有償情報フラグ.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.col有償情報フラグ.IntegralHeight = false;
            this.col有償情報フラグ.ItemHeight = 15;
            this.col有償情報フラグ.MinimumWidth = 22;
            this.col有償情報フラグ.Name = "col有償情報フラグ";
            this.col有償情報フラグ.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col有償情報フラグ.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.col有償情報フラグ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // col備考
            // 
            this.col備考.DataPropertyName = "備考";
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Yellow;
            this.col備考.DefaultCellStyle = dataGridViewCellStyle7;
            this.col備考.HeaderText = "備考";
            this.col備考.MinimumWidth = 22;
            this.col備考.Name = "col備考";
            this.col備考.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col備考.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // col登録日
            // 
            // 
            // 
            // 
            this.col登録日.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.col登録日.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.col登録日.CustomFormat = "yyyy/MM/dd";
            this.col登録日.DataPropertyName = "登録日";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col登録日.DefaultCellStyle = dataGridViewCellStyle8;
            this.col登録日.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.col登録日.HeaderText = "登録日";
            this.col登録日.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.col登録日.MinimumWidth = 22;
            // 
            // 
            // 
            // 
            // 
            // 
            this.col登録日.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.col登録日.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            // 
            // 
            // 
            this.col登録日.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.col登録日.MonthCalendar.DisplayMonth = new System.DateTime(2020, 8, 1, 0, 0, 0, 0);
            this.col登録日.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.col登録日.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.col登録日.Name = "col登録日";
            this.col登録日.ReadOnly = true;
            this.col登録日.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col登録日.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.col登録日.Width = 120;
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
            this.colアップ予定日.MonthCalendar.DisplayMonth = new System.DateTime(2020, 8, 1, 0, 0, 0, 0);
            this.colアップ予定日.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.colアップ予定日.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.colアップ予定日.Name = "colアップ予定日";
            this.colアップ予定日.ReadOnly = true;
            this.colアップ予定日.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
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
            this.colサービス発表日.MonthCalendar.DisplayMonth = new System.DateTime(2020, 8, 1, 0, 0, 0, 0);
            this.colサービス発表日.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.colサービス発表日.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.colサービス発表日.Name = "colサービス発表日";
            this.colサービス発表日.ReadOnly = true;
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
            this.col取消フラグ.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.col取消フラグ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // col削除
            // 
            this.col削除.Checked = true;
            this.col削除.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.col削除.CheckValue = "N";
            this.col削除.DataPropertyName = "削除";
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.Yellow;
            this.col削除.DefaultCellStyle = dataGridViewCellStyle9;
            this.col削除.HeaderText = "削除";
            this.col削除.MinimumWidth = 22;
            this.col削除.Name = "col削除";
            this.col削除.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col削除.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.col削除.Visible = false;
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
            // colID
            // 
            this.colID.DataPropertyName = "ID";
            this.colID.HeaderText = "ID";
            this.colID.MaxInputLength = 32767;
            this.colID.MaxValueInput = ((long)(2147483647));
            this.colID.MinimumWidth = 22;
            this.colID.MinInputLength = 0;
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colID.Visible = false;
            // 
            // FesSongAddDeleteMainAdvance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.advFesSongAddDelete);
            this.Controls.Add(this.dataGridViewFilter);
            this.Name = "FesSongAddDeleteMainAdvance";
            this.SCREEN_TITLE = "DISC搭載曲追加削除管理";
            this.Size = new System.Drawing.Size(800, 400);
            this.Load += new System.EventHandler(this.FesVideoAssigmentMainAdvance_Load);
            
            ((System.ComponentModel.ISupportInitialize)(this.advFesSongAddDelete)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Base.DataGridViewFilter dataGridViewFilter;
        private AdvancedDataGridView advFesSongAddDelete;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn col選択;
        private Base.DataGridViewNumericColumn col通番;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn col追加削除区分;
        private Base.DataGridViewNumericColumn colWiiデジドコ選曲番号;
        private System.Windows.Forms.DataGridViewTextBoxColumn colカラオケ選曲番号;
        private System.Windows.Forms.DataGridViewTextBoxColumn col楽曲名;
        private System.Windows.Forms.DataGridViewTextBoxColumn col歌手名;
        private Base.DataGridViewNumericColumn colFesDISCID;
        private Base.DataGridViewNumericColumn colデータサイズ;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn col有料コンテンツフラグ;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn col有償情報フラグ;
        private System.Windows.Forms.DataGridViewTextBoxColumn col備考;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn col登録日;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn colアップ予定日;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn colサービス発表日;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn col取消フラグ;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn col削除;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn col更新日時;
        private Base.DataGridViewNumericColumn colID;
    }
}
