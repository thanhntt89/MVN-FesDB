namespace Festival.DBTab.TieupConfirm
{
    partial class TieupConfirmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TieupConfirmMain));
            this.advTieup = new Zuby.ADGV.AdvancedDataGridView();
            this.colバージョンNO = new Festival.Base.DataGridViewNumericColumn();
            this.col選曲番号 = new Festival.Base.DataGridViewNumericColumn();
            this.colカラオケ選曲番号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colサービス発表日 = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.col楽曲名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col歌手ID = new Festival.Base.DataGridViewNumericColumn();
            this.col歌手名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colジャンル区分 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colジャンル名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colタイアップID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colタイアップ区分 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colタイアップ区分名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colタイアップ表示用 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colタイアップ検索用カナ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colタイアップソート用カナ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUpdateDate = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.dataGridViewFilter = new Festival.Base.DataGridViewFilter();
            ((System.ComponentModel.ISupportInitialize)(this.advTieup)).BeginInit();
            this.SuspendLayout();
            // 
            // advTieup
            // 
            this.advTieup.AllowUserToAddRows = false;
            this.advTieup.AllowUserToDeleteRows = false;
            this.advTieup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advTieup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colバージョンNO,
            this.col選曲番号,
            this.colカラオケ選曲番号,
            this.colサービス発表日,
            this.col楽曲名,
            this.col歌手ID,
            this.col歌手名,
            this.colジャンル区分,
            this.colジャンル名,
            this.colタイアップID,
            this.colタイアップ区分,
            this.colタイアップ区分名,
            this.colタイアップ表示用,
            this.colタイアップ検索用カナ,
            this.colタイアップソート用カナ,
            this.colUpdateDate});
            this.advTieup.FilterAndSortEnabled = true;
            this.advTieup.IsLoadConfig = false;
            this.advTieup.Location = new System.Drawing.Point(35, 36);
            this.advTieup.Name = "advTieup";
            this.advTieup.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advTieup.Size = new System.Drawing.Size(688, 224);
            this.advTieup.TabIndex = 2;
            this.advTieup.Visible = false;
            // 
            // colバージョンNO
            // 
            this.colバージョンNO.DataPropertyName = "バージョンNO";
            this.colバージョンNO.HeaderText = "バージョンNO";
            this.colバージョンNO.MaxInputLength = 32767;
            this.colバージョンNO.MaxValueInput = ((long)(2147483647));
            this.colバージョンNO.MinimumWidth = 22;
            this.colバージョンNO.MinInputLength = 0;
            this.colバージョンNO.Name = "colバージョンNO";
            this.colバージョンNO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colバージョンNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // col選曲番号
            // 
            this.col選曲番号.DataPropertyName = "選曲番号";
            this.col選曲番号.HeaderText = "選曲番号";
            this.col選曲番号.MaxInputLength = 32767;
            this.col選曲番号.MaxValueInput = ((long)(2147483647));
            this.col選曲番号.MinimumWidth = 22;
            this.col選曲番号.MinInputLength = 0;
            this.col選曲番号.Name = "col選曲番号";
            this.col選曲番号.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col選曲番号.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // colカラオケ選曲番号
            // 
            this.colカラオケ選曲番号.DataPropertyName = "カラオケ選曲番号";
            this.colカラオケ選曲番号.HeaderText = "カラオケ選曲番号";
            this.colカラオケ選曲番号.MinimumWidth = 22;
            this.colカラオケ選曲番号.Name = "colカラオケ選曲番号";
            this.colカラオケ選曲番号.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colカラオケ選曲番号.Width = 130;
            // 
            // colサービス発表日
            // 
            // 
            // 
            // 
            this.colサービス発表日.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.colサービス発表日.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.colサービス発表日.DataPropertyName = "サービス発表日";
            this.colサービス発表日.HeaderText = "サービス発表日";
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
            this.colサービス発表日.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colサービス発表日.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colサービス発表日.Width = 130;
            // 
            // col楽曲名
            // 
            this.col楽曲名.DataPropertyName = "楽曲名";
            this.col楽曲名.HeaderText = "楽曲名";
            this.col楽曲名.MinimumWidth = 22;
            this.col楽曲名.Name = "col楽曲名";
            this.col楽曲名.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // col歌手ID
            // 
            this.col歌手ID.DataPropertyName = "歌手ID";
            this.col歌手ID.HeaderText = "歌手ID";
            this.col歌手ID.MaxInputLength = 32767;
            this.col歌手ID.MaxValueInput = ((long)(2147483647));
            this.col歌手ID.MinimumWidth = 22;
            this.col歌手ID.MinInputLength = 0;
            this.col歌手ID.Name = "col歌手ID";
            this.col歌手ID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col歌手ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // col歌手名
            // 
            this.col歌手名.DataPropertyName = "歌手名";
            this.col歌手名.HeaderText = "歌手名";
            this.col歌手名.MinimumWidth = 22;
            this.col歌手名.Name = "col歌手名";
            this.col歌手名.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // colジャンル区分
            // 
            this.colジャンル区分.DataPropertyName = "ジャンル区分";
            this.colジャンル区分.HeaderText = "ジャンル区分";
            this.colジャンル区分.MinimumWidth = 22;
            this.colジャンル区分.Name = "colジャンル区分";
            this.colジャンル区分.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // colジャンル名
            // 
            this.colジャンル名.DataPropertyName = "ジャンル名";
            this.colジャンル名.HeaderText = "ジャンル名";
            this.colジャンル名.MinimumWidth = 22;
            this.colジャンル名.Name = "colジャンル名";
            this.colジャンル名.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // colタイアップID
            // 
            this.colタイアップID.DataPropertyName = "タイアップID";
            this.colタイアップID.HeaderText = "タイアップID";
            this.colタイアップID.MinimumWidth = 22;
            this.colタイアップID.Name = "colタイアップID";
            this.colタイアップID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // colタイアップ区分
            // 
            this.colタイアップ区分.DataPropertyName = "タイアップ区分";
            this.colタイアップ区分.HeaderText = "タイアップ区分";
            this.colタイアップ区分.MinimumWidth = 22;
            this.colタイアップ区分.Name = "colタイアップ区分";
            this.colタイアップ区分.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colタイアップ区分.Width = 130;
            // 
            // colタイアップ区分名
            // 
            this.colタイアップ区分名.DataPropertyName = "タイアップ区分名";
            this.colタイアップ区分名.HeaderText = "タイアップ区分名";
            this.colタイアップ区分名.MinimumWidth = 22;
            this.colタイアップ区分名.Name = "colタイアップ区分名";
            this.colタイアップ区分名.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colタイアップ区分名.Width = 140;
            // 
            // colタイアップ表示用
            // 
            this.colタイアップ表示用.DataPropertyName = "タイアップ表示用";
            this.colタイアップ表示用.HeaderText = "タイアップ表示用";
            this.colタイアップ表示用.MinimumWidth = 22;
            this.colタイアップ表示用.Name = "colタイアップ表示用";
            this.colタイアップ表示用.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colタイアップ表示用.Width = 140;
            // 
            // colタイアップ検索用カナ
            // 
            this.colタイアップ検索用カナ.DataPropertyName = "タイアップ検索用カナ";
            this.colタイアップ検索用カナ.HeaderText = "タイアップ検索用カナ";
            this.colタイアップ検索用カナ.MinimumWidth = 22;
            this.colタイアップ検索用カナ.Name = "colタイアップ検索用カナ";
            this.colタイアップ検索用カナ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colタイアップ検索用カナ.Width = 150;
            // 
            // colタイアップソート用カナ
            // 
            this.colタイアップソート用カナ.DataPropertyName = "タイアップソート用カナ";
            this.colタイアップソート用カナ.HeaderText = "タイアップソート用カナ";
            this.colタイアップソート用カナ.MinimumWidth = 22;
            this.colタイアップソート用カナ.Name = "colタイアップソート用カナ";
            this.colタイアップソート用カナ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colタイアップソート用カナ.Width = 150;
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
            this.colUpdateDate.MonthCalendar.DisplayMonth = new System.DateTime(2020, 7, 1, 0, 0, 0, 0);
            this.colUpdateDate.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.colUpdateDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.colUpdateDate.Name = "colUpdateDate";
            this.colUpdateDate.ReadOnly = true;
            this.colUpdateDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colUpdateDate.Visible = false;
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
            this.dataGridViewFilter.Location = new System.Drawing.Point(6, 12);
            this.dataGridViewFilter.MainMenuEditModeCollection = menuMainCollection1;
            this.dataGridViewFilter.Name = "dataGridViewFilter";
            this.dataGridViewFilter.SCREEN_TITLE = null;
            this.dataGridViewFilter.Size = new System.Drawing.Size(776, 347);
            this.dataGridViewFilter.TabIndex = 3;
            // 
            // TieupConfirmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.advTieup);
            this.Controls.Add(this.dataGridViewFilter);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TieupConfirmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ジャンルタイアップ確認";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TieupConfirmMain_FormClosing);
            this.Load += new System.EventHandler(this.TieupConfirmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.advTieup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Zuby.ADGV.AdvancedDataGridView advTieup;
        private Base.DataGridViewFilter dataGridViewFilter;
        private Base.DataGridViewNumericColumn colバージョンNO;
        private Base.DataGridViewNumericColumn col選曲番号;
        private System.Windows.Forms.DataGridViewTextBoxColumn colカラオケ選曲番号;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn colサービス発表日;
        private System.Windows.Forms.DataGridViewTextBoxColumn col楽曲名;
        private Base.DataGridViewNumericColumn col歌手ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col歌手名;
        private System.Windows.Forms.DataGridViewTextBoxColumn colジャンル区分;
        private System.Windows.Forms.DataGridViewTextBoxColumn colジャンル名;
        private System.Windows.Forms.DataGridViewTextBoxColumn colタイアップID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colタイアップ区分;
        private System.Windows.Forms.DataGridViewTextBoxColumn colタイアップ区分名;
        private System.Windows.Forms.DataGridViewTextBoxColumn colタイアップ表示用;
        private System.Windows.Forms.DataGridViewTextBoxColumn colタイアップ検索用カナ;
        private System.Windows.Forms.DataGridViewTextBoxColumn colタイアップソート用カナ;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn colUpdateDate;
    }
}