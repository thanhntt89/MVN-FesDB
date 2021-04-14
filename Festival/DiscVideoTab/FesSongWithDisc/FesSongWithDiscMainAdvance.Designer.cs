using Zuby.ADGV;

namespace Festival.DiscVideoTab.FesSongWithDisc
{
    partial class FesSongWithDiscMainAdvance
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewFilter = new Festival.Base.DataGridViewFilter();
            this.advSongWithDisc = new Zuby.ADGV.AdvancedDataGridView();
            this.col選択 = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.colWiiデジドコ選曲番号 = new Festival.Base.DataGridViewNumericColumn();
            this.colカラオケ選曲番号 = new Festival.Base.DataGridViewNumericColumn();
            this.col楽曲名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col歌手名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col楽曲名検索用カナ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col曲名よみがな補正 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col歌手名検索用カナ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFesDISCID = new Festival.Base.DataGridViewNumericColumn();
            this.colFesDISCIDVer2 = new Festival.Base.DataGridViewNumericColumn();
            this.colNET利用フラグ = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.colNET利用フラグVer2 = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.col取消日 = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.col取消日Ver2 = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.colデータサイズ = new Festival.Base.DataGridViewNumericColumn();
            this.colデータサイズVer2 = new Festival.Base.DataGridViewNumericColumn();
            this.colアップ予定日 = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.colサービス発表日 = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.col取消フラグ = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.colWii_U_制作完了日 = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.colJV映像区分背景映像区分 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col備考 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col備考Ver2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col削除 = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.col更新日時 = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.colデジドココンテンツID = new Festival.Base.DataGridViewNumericColumn();
           
            ((System.ComponentModel.ISupportInitialize)(this.advSongWithDisc)).BeginInit();
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
            this.dataGridViewFilter.Size = new System.Drawing.Size(970, 547);
            this.dataGridViewFilter.TabIndex = 1;
            // 
            // advSongWithDisc
            // 
            this.advSongWithDisc.AllowUserToAddRows = false;
            this.advSongWithDisc.AllowUserToDeleteRows = false;
            this.advSongWithDisc.AllowUserToOrderColumns = true;
            this.advSongWithDisc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.advSongWithDisc.ColumnHeadersHeight = 24;
            this.advSongWithDisc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col選択,
            this.colWiiデジドコ選曲番号,
            this.colカラオケ選曲番号,
            this.col楽曲名,
            this.col歌手名,
            this.col楽曲名検索用カナ,
            this.col曲名よみがな補正,
            this.col歌手名検索用カナ,
            this.colFesDISCID,
            this.colFesDISCIDVer2,
            this.colNET利用フラグ,
            this.colNET利用フラグVer2,
            this.col取消日,
            this.col取消日Ver2,
            this.colデータサイズ,
            this.colデータサイズVer2,
            this.colアップ予定日,
            this.colサービス発表日,
            this.col取消フラグ,
            this.colWii_U_制作完了日,
            this.colJV映像区分背景映像区分,
            this.col備考,
            this.col備考Ver2,
            this.col削除,
            this.col更新日時,
            this.colデジドココンテンツID});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.advSongWithDisc.DefaultCellStyle = dataGridViewCellStyle5;
            this.advSongWithDisc.FilterAndSortEnabled = true;
            this.advSongWithDisc.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.advSongWithDisc.IsLoadConfig = false;
            this.advSongWithDisc.Location = new System.Drawing.Point(3, 3);
            this.advSongWithDisc.Name = "advSongWithDisc";
            this.advSongWithDisc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advSongWithDisc.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.advSongWithDisc.ShowCellErrors = false;
            this.advSongWithDisc.Size = new System.Drawing.Size(964, 491);
            this.advSongWithDisc.TabIndex = 23;
            this.advSongWithDisc.Visible = false;
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
            this.colWiiデジドコ選曲番号.MaxInputLength = 32767;
            this.colWiiデジドコ選曲番号.MaxValueInput = ((long)(2147483647));
            this.colWiiデジドコ選曲番号.MinimumWidth = 22;
            this.colWiiデジドコ選曲番号.MinInputLength = 0;
            this.colWiiデジドコ選曲番号.Name = "colWiiデジドコ選曲番号";
            this.colWiiデジドコ選曲番号.ReadOnly = true;
            this.colWiiデジドコ選曲番号.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colWiiデジドコ選曲番号.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // colカラオケ選曲番号
            // 
            this.colカラオケ選曲番号.DataPropertyName = "カラオケ選曲番号";
            this.colカラオケ選曲番号.HeaderText = "カラオケNo";
            this.colカラオケ選曲番号.MaxInputLength = 32767;
            this.colカラオケ選曲番号.MaxValueInput = ((long)(2147483647));
            this.colカラオケ選曲番号.MinimumWidth = 22;
            this.colカラオケ選曲番号.MinInputLength = 0;
            this.colカラオケ選曲番号.Name = "colカラオケ選曲番号";
            this.colカラオケ選曲番号.ReadOnly = true;
            this.colカラオケ選曲番号.Resizable = System.Windows.Forms.DataGridViewTriState.True;
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
            this.col楽曲名.Width = 200;
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
            this.col歌手名.Width = 200;
            // 
            // col楽曲名検索用カナ
            // 
            this.col楽曲名検索用カナ.DataPropertyName = "楽曲名検索用カナ";
            this.col楽曲名検索用カナ.HeaderText = "曲名カナ";
            this.col楽曲名検索用カナ.MaxInputLength = 900;
            this.col楽曲名検索用カナ.MinimumWidth = 22;
            this.col楽曲名検索用カナ.Name = "col楽曲名検索用カナ";
            this.col楽曲名検索用カナ.ReadOnly = true;
            this.col楽曲名検索用カナ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
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
            // 
            // colFesDISCID
            // 
            this.colFesDISCID.DataPropertyName = "FesDISCID";
            this.colFesDISCID.HeaderText = "Fes_DISCID_V1";
            this.colFesDISCID.MaxInputLength = 8;
            this.colFesDISCID.MaxValueInput = ((long)(2147483647));
            this.colFesDISCID.MinimumWidth = 22;
            this.colFesDISCID.MinInputLength = 0;
            this.colFesDISCID.Name = "colFesDISCID";
            this.colFesDISCID.ReadOnly = true;
            this.colFesDISCID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colFesDISCID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // colFesDISCIDVer2
            // 
            this.colFesDISCIDVer2.DataPropertyName = "FesDISCIDVer2";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Yellow;
            this.colFesDISCIDVer2.DefaultCellStyle = dataGridViewCellStyle1;
            this.colFesDISCIDVer2.HeaderText = "Fes_DISCID_V2";
            this.colFesDISCIDVer2.MaxInputLength = 8;
            this.colFesDISCIDVer2.MaxValueInput = ((long)(2147483647));
            this.colFesDISCIDVer2.MinimumWidth = 22;
            this.colFesDISCIDVer2.MinInputLength = 0;
            this.colFesDISCIDVer2.Name = "colFesDISCIDVer2";
            this.colFesDISCIDVer2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colFesDISCIDVer2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // colNET利用フラグ
            // 
            this.colNET利用フラグ.DataPropertyName = "NET利用フラグ";
            this.colNET利用フラグ.DropDownHeight = 106;
            this.colNET利用フラグ.DropDownWidth = 121;
            this.colNET利用フラグ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colNET利用フラグ.HeaderText = "Fes_NET利用フラグ_V1";
            this.colNET利用フラグ.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.colNET利用フラグ.IntegralHeight = false;
            this.colNET利用フラグ.ItemHeight = 15;
            this.colNET利用フラグ.MinimumWidth = 22;
            this.colNET利用フラグ.Name = "colNET利用フラグ";
            this.colNET利用フラグ.ReadOnly = true;
            this.colNET利用フラグ.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colNET利用フラグ.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.colNET利用フラグ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // colNET利用フラグVer2
            // 
            this.colNET利用フラグVer2.DataPropertyName = "NET利用フラグVer2";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Yellow;
            this.colNET利用フラグVer2.DefaultCellStyle = dataGridViewCellStyle2;
            this.colNET利用フラグVer2.DropDownHeight = 106;
            this.colNET利用フラグVer2.DropDownWidth = 121;
            this.colNET利用フラグVer2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colNET利用フラグVer2.HeaderText = "Fes_NET利用フラグ_V2";
            this.colNET利用フラグVer2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.colNET利用フラグVer2.IntegralHeight = false;
            this.colNET利用フラグVer2.ItemHeight = 15;
            this.colNET利用フラグVer2.MinimumWidth = 22;
            this.colNET利用フラグVer2.Name = "colNET利用フラグVer2";
            this.colNET利用フラグVer2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colNET利用フラグVer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.colNET利用フラグVer2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // col取消日
            // 
            // 
            // 
            // 
            this.col取消日.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.col取消日.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.col取消日.CustomFormat = "yyyy/MM/dd";
            this.col取消日.DataPropertyName = "取消日";
            this.col取消日.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.col取消日.HeaderText = "取消日_V1";
            this.col取消日.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.col取消日.MinimumWidth = 22;
            // 
            // 
            // 
            // 
            // 
            // 
            this.col取消日.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.col取消日.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            // 
            // 
            // 
            this.col取消日.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.col取消日.MonthCalendar.DisplayMonth = new System.DateTime(2020, 7, 1, 0, 0, 0, 0);
            this.col取消日.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.col取消日.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.col取消日.Name = "col取消日";
            this.col取消日.ReadOnly = true;
            this.col取消日.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col取消日.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // col取消日Ver2
            // 
            // 
            // 
            // 
            this.col取消日Ver2.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.col取消日Ver2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.col取消日Ver2.CustomFormat = "yyyy/MM/dd";
            this.col取消日Ver2.DataPropertyName = "取消日Ver2";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Yellow;
            this.col取消日Ver2.DefaultCellStyle = dataGridViewCellStyle3;
            this.col取消日Ver2.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.col取消日Ver2.HeaderText = "取消日_V2";
            this.col取消日Ver2.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.col取消日Ver2.MinimumWidth = 22;
            // 
            // 
            // 
            // 
            // 
            // 
            this.col取消日Ver2.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.col取消日Ver2.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            // 
            // 
            // 
            this.col取消日Ver2.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.col取消日Ver2.MonthCalendar.DisplayMonth = new System.DateTime(2020, 7, 1, 0, 0, 0, 0);
            this.col取消日Ver2.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.col取消日Ver2.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.col取消日Ver2.Name = "col取消日Ver2";
            this.col取消日Ver2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col取消日Ver2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // colデータサイズ
            // 
            this.colデータサイズ.DataPropertyName = "データサイズ";
            this.colデータサイズ.HeaderText = "Fes_データサイズ_V1";
            this.colデータサイズ.MaxInputLength = 32767;
            this.colデータサイズ.MaxValueInput = ((long)(2147483647));
            this.colデータサイズ.MinimumWidth = 22;
            this.colデータサイズ.MinInputLength = 0;
            this.colデータサイズ.Name = "colデータサイズ";
            this.colデータサイズ.ReadOnly = true;
            this.colデータサイズ.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colデータサイズ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // colデータサイズVer2
            // 
            this.colデータサイズVer2.DataPropertyName = "データサイズVer2";
            this.colデータサイズVer2.HeaderText = "Fes_データサイズ_V2";
            this.colデータサイズVer2.MaxInputLength = 32767;
            this.colデータサイズVer2.MaxValueInput = ((long)(2147483647));
            this.colデータサイズVer2.MinimumWidth = 22;
            this.colデータサイズVer2.MinInputLength = 0;
            this.colデータサイズVer2.Name = "colデータサイズVer2";
            this.colデータサイズVer2.ReadOnly = true;
            this.colデータサイズVer2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colデータサイズVer2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
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
            // colWii_U_制作完了日
            // 
            // 
            // 
            // 
            this.colWii_U_制作完了日.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.colWii_U_制作完了日.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.colWii_U_制作完了日.CustomFormat = "yyyy/MM/dd";
            this.colWii_U_制作完了日.DataPropertyName = "Wii_U_制作完了日";
            this.colWii_U_制作完了日.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.colWii_U_制作完了日.HeaderText = "Orch_制作完了日";
            this.colWii_U_制作完了日.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.colWii_U_制作完了日.MinimumWidth = 22;
            // 
            // 
            // 
            // 
            // 
            // 
            this.colWii_U_制作完了日.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.colWii_U_制作完了日.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            // 
            // 
            // 
            this.colWii_U_制作完了日.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.colWii_U_制作完了日.MonthCalendar.DisplayMonth = new System.DateTime(2020, 7, 1, 0, 0, 0, 0);
            this.colWii_U_制作完了日.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.colWii_U_制作完了日.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.colWii_U_制作完了日.Name = "colWii_U_制作完了日";
            this.colWii_U_制作完了日.ReadOnly = true;
            this.colWii_U_制作完了日.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colWii_U_制作完了日.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
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
            // 
            // col備考
            // 
            this.col備考.DataPropertyName = "備考";
            this.col備考.HeaderText = "備考_V1";
            this.col備考.MaxInputLength = 255;
            this.col備考.MinimumWidth = 22;
            this.col備考.Name = "col備考";
            this.col備考.ReadOnly = true;
            this.col備考.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // col備考Ver2
            // 
            this.col備考Ver2.DataPropertyName = "備考Ver2";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Yellow;
            this.col備考Ver2.DefaultCellStyle = dataGridViewCellStyle4;
            this.col備考Ver2.HeaderText = "備考(Ver2)";
            this.col備考Ver2.MaxInputLength = 255;
            this.col備考Ver2.MinimumWidth = 22;
            this.col備考Ver2.Name = "col備考Ver2";
            this.col備考Ver2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // col削除
            // 
            this.col削除.Checked = true;
            this.col削除.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.col削除.CheckValue = "N";
            this.col削除.DataPropertyName = "削除";
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
            this.colデジドココンテンツID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colデジドココンテンツID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colデジドココンテンツID.Visible = false;
            // 
            // FesSongWithDiscMainAdvance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.advSongWithDisc);
            this.Controls.Add(this.dataGridViewFilter);
            this.Name = "FesSongWithDiscMainAdvance";
            this.SCREEN_TITLE = "DISC搭載曲管理V";
            this.Size = new System.Drawing.Size(970, 547);
            this.Load += new System.EventHandler(this.DisVideoSearchMain_Load);
            
            ((System.ComponentModel.ISupportInitialize)(this.advSongWithDisc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Base.DataGridViewFilter dataGridViewFilter;
        private AdvancedDataGridView advSongWithDisc;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn col選択;
        private Base.DataGridViewNumericColumn colWiiデジドコ選曲番号;
        private Base.DataGridViewNumericColumn colカラオケ選曲番号;
        private System.Windows.Forms.DataGridViewTextBoxColumn col楽曲名;
        private System.Windows.Forms.DataGridViewTextBoxColumn col歌手名;
        private System.Windows.Forms.DataGridViewTextBoxColumn col楽曲名検索用カナ;
        private System.Windows.Forms.DataGridViewTextBoxColumn col曲名よみがな補正;
        private System.Windows.Forms.DataGridViewTextBoxColumn col歌手名検索用カナ;
        private Base.DataGridViewNumericColumn colFesDISCID;
        private Base.DataGridViewNumericColumn colFesDISCIDVer2;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn colNET利用フラグ;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn colNET利用フラグVer2;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn col取消日;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn col取消日Ver2;
        private Base.DataGridViewNumericColumn colデータサイズ;
        private Base.DataGridViewNumericColumn colデータサイズVer2;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn colアップ予定日;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn colサービス発表日;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn col取消フラグ;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn colWii_U_制作完了日;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJV映像区分背景映像区分;
        private System.Windows.Forms.DataGridViewTextBoxColumn col備考;
        private System.Windows.Forms.DataGridViewTextBoxColumn col備考Ver2;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn col削除;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn col更新日時;
        private Base.DataGridViewNumericColumn colデジドココンテンツID;
    }
}
