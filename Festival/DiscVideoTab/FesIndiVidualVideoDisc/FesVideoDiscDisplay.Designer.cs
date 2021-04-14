namespace Festival.DiscVideoTab.FesIndiVidualVideoDisc
{
    partial class FesVideoDiscDisplay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FesVideoDiscDisplay));
            this.dataGridViewFilter = new Festival.Base.DataGridViewFilter();
            this.advFesIndividualVideoDisc = new Zuby.ADGV.AdvancedDataGridView();
            this.col背景ファイル名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFesDISCID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.advFesIndividualVideoDisc)).BeginInit();
            this.SuspendLayout();
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
            this.dataGridViewFilter.DataGridViewSource = this.advFesIndividualVideoDisc;
            this.dataGridViewFilter.DataSourceDisplay = null;
            this.dataGridViewFilter.DataTableSource = null;
            this.dataGridViewFilter.IsFilterActive = false;
            this.dataGridViewFilter.Location = new System.Drawing.Point(7, 12);
            this.dataGridViewFilter.MainMenuEditModeCollection = menuMainCollection1;
            this.dataGridViewFilter.Name = "dataGridViewFilter";
            this.dataGridViewFilter.SCREEN_TITLE = null;
            this.dataGridViewFilter.Size = new System.Drawing.Size(773, 444);
            this.dataGridViewFilter.TabIndex = 0;
            // 
            // advFesIndividualVideoDisc
            // 
            this.advFesIndividualVideoDisc.AllowUserToAddRows = false;
            this.advFesIndividualVideoDisc.AllowUserToDeleteRows = false;
            this.advFesIndividualVideoDisc.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.advFesIndividualVideoDisc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advFesIndividualVideoDisc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col背景ファイル名,
            this.colFesDISCID});
            this.advFesIndividualVideoDisc.FilterAndSortEnabled = true;
            this.advFesIndividualVideoDisc.IsLoadConfig = false;
            this.advFesIndividualVideoDisc.Location = new System.Drawing.Point(12, 25);
            this.advFesIndividualVideoDisc.Name = "advFesIndividualVideoDisc";
            this.advFesIndividualVideoDisc.ReadOnly = true;
            this.advFesIndividualVideoDisc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advFesIndividualVideoDisc.Size = new System.Drawing.Size(729, 230);
            this.advFesIndividualVideoDisc.TabIndex = 1;
            this.advFesIndividualVideoDisc.Visible = false;
            // 
            // col背景ファイル名
            // 
            this.col背景ファイル名.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col背景ファイル名.DataPropertyName = "背景ファイル名";
            this.col背景ファイル名.HeaderText = "背景ファイル名";
            this.col背景ファイル名.MinimumWidth = 22;
            this.col背景ファイル名.Name = "col背景ファイル名";
            this.col背景ファイル名.ReadOnly = true;
            this.col背景ファイル名.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // colFesDISCID
            // 
            this.colFesDISCID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFesDISCID.DataPropertyName = "FesDISCID";
            this.colFesDISCID.HeaderText = "FesDISCID";
            this.colFesDISCID.MinimumWidth = 22;
            this.colFesDISCID.Name = "colFesDISCID";
            this.colFesDISCID.ReadOnly = true;
            this.colFesDISCID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // FesVideoDiscDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.advFesIndividualVideoDisc);
            this.Controls.Add(this.dataGridViewFilter);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FesVideoDiscDisplay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "個別映像DISC収録情報_追加削除管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FesVideoDiscDisplay_FormClosing);
            this.Load += new System.EventHandler(this.FesVideoDiscDisplay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.advFesIndividualVideoDisc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Base.DataGridViewFilter dataGridViewFilter;
        private Zuby.ADGV.AdvancedDataGridView advFesIndividualVideoDisc;
        private System.Windows.Forms.DataGridViewTextBoxColumn col背景ファイル名;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFesDISCID;
    }
}