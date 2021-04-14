namespace Festival.DBTab.TieupDuplicate
{
    partial class TieupDuplicateMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TieupDuplicateMain));
            this.advTieupDuplicate = new Zuby.ADGV.AdvancedDataGridView();
            this.colバージョンNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colタイアップID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colタイアップ区分 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colタイアップ表示用 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colタイアップ検索用カナ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colタイアップソート用カナ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewFilter = new Festival.Base.DataGridViewFilter();
            ((System.ComponentModel.ISupportInitialize)(this.advTieupDuplicate)).BeginInit();
            this.SuspendLayout();
            // 
            // advTieupDuplicate
            // 
            this.advTieupDuplicate.AllowUserToAddRows = false;
            this.advTieupDuplicate.AllowUserToDeleteRows = false;
            this.advTieupDuplicate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advTieupDuplicate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colバージョンNO,
            this.colタイアップID,
            this.colタイアップ区分,
            this.colタイアップ表示用,
            this.colタイアップ検索用カナ,
            this.colタイアップソート用カナ});
            this.advTieupDuplicate.FilterAndSortEnabled = true;
            this.advTieupDuplicate.IsLoadConfig = false;
            this.advTieupDuplicate.Location = new System.Drawing.Point(12, 45);
            this.advTieupDuplicate.Name = "advTieupDuplicate";
            this.advTieupDuplicate.ReadOnly = true;
            this.advTieupDuplicate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advTieupDuplicate.Size = new System.Drawing.Size(721, 215);
            this.advTieupDuplicate.TabIndex = 0;
            this.advTieupDuplicate.Visible = false;
            // 
            // colバージョンNO
            // 
            this.colバージョンNO.DataPropertyName = "バージョンNO";
            this.colバージョンNO.HeaderText = "バージョンNO";
            this.colバージョンNO.MinimumWidth = 22;
            this.colバージョンNO.Name = "colバージョンNO";
            this.colバージョンNO.ReadOnly = true;
            this.colバージョンNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // colタイアップID
            // 
            this.colタイアップID.DataPropertyName = "タイアップID";
            this.colタイアップID.HeaderText = "タイアップID";
            this.colタイアップID.MinimumWidth = 22;
            this.colタイアップID.Name = "colタイアップID";
            this.colタイアップID.ReadOnly = true;
            this.colタイアップID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // colタイアップ区分
            // 
            this.colタイアップ区分.DataPropertyName = "タイアップ区分";
            this.colタイアップ区分.HeaderText = "タイアップ区分";
            this.colタイアップ区分.MinimumWidth = 22;
            this.colタイアップ区分.Name = "colタイアップ区分";
            this.colタイアップ区分.ReadOnly = true;
            this.colタイアップ区分.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // colタイアップ表示用
            // 
            this.colタイアップ表示用.DataPropertyName = "タイアップ表示用";
            this.colタイアップ表示用.HeaderText = "タイアップ表示用";
            this.colタイアップ表示用.MinimumWidth = 22;
            this.colタイアップ表示用.Name = "colタイアップ表示用";
            this.colタイアップ表示用.ReadOnly = true;
            this.colタイアップ表示用.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // colタイアップ検索用カナ
            // 
            this.colタイアップ検索用カナ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colタイアップ検索用カナ.DataPropertyName = "タイアップ検索用カナ";
            this.colタイアップ検索用カナ.HeaderText = "タイアップ検索用カナ";
            this.colタイアップ検索用カナ.MinimumWidth = 22;
            this.colタイアップ検索用カナ.Name = "colタイアップ検索用カナ";
            this.colタイアップ検索用カナ.ReadOnly = true;
            this.colタイアップ検索用カナ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // colタイアップソート用カナ
            // 
            this.colタイアップソート用カナ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colタイアップソート用カナ.DataPropertyName = "タイアップソート用カナ";
            this.colタイアップソート用カナ.HeaderText = "タイアップソート用カナ";
            this.colタイアップソート用カナ.MinimumWidth = 22;
            this.colタイアップソート用カナ.Name = "colタイアップソート用カナ";
            this.colタイアップソート用カナ.ReadOnly = true;
            this.colタイアップソート用カナ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
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
            this.dataGridViewFilter.Location = new System.Drawing.Point(5, 12);
            this.dataGridViewFilter.MainMenuEditModeCollection = menuMainCollection1;
            this.dataGridViewFilter.Name = "dataGridViewFilter";
            this.dataGridViewFilter.SCREEN_TITLE = null;
            this.dataGridViewFilter.Size = new System.Drawing.Size(778, 346);
            this.dataGridViewFilter.TabIndex = 1;
            // 
            // TieupDuplicateMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.advTieupDuplicate);
            this.Controls.Add(this.dataGridViewFilter);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TieupDuplicateMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "タイアップ重複確認";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TieupDuplicateMain_FormClosing);
            this.Load += new System.EventHandler(this.TieupDuplicateMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.advTieupDuplicate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Zuby.ADGV.AdvancedDataGridView advTieupDuplicate;
        private Base.DataGridViewFilter dataGridViewFilter;
        private System.Windows.Forms.DataGridViewTextBoxColumn colバージョンNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colタイアップID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colタイアップ区分;
        private System.Windows.Forms.DataGridViewTextBoxColumn colタイアップ表示用;
        private System.Windows.Forms.DataGridViewTextBoxColumn colタイアップ検索用カナ;
        private System.Windows.Forms.DataGridViewTextBoxColumn colタイアップソート用カナ;
    }
}