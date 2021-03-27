namespace Festival.UC
{
    partial class UCSearchWiiProduct
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
            this.dtgSearchData = new System.Windows.Forms.DataGridView();
            this.select = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SongNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SongCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WhyNotRelease = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReleaseDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SongName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SingerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SearchForSongName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SortSongName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SingerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOutPutUtabonList = new System.Windows.Forms.Button();
            this.btnEnkaFlagSetting = new System.Windows.Forms.Button();
            this.btnWiiTSVOutPut = new System.Windows.Forms.Button();
            this.btnListAllDeliveredItem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSearchData)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgSearchData
            // 
            this.dtgSearchData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgSearchData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSearchData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.select,
            this.SongNumber,
            this.SongCategory,
            this.WhyNotRelease,
            this.ReleaseDay,
            this.SongName,
            this.SingerName,
            this.SearchForSongName,
            this.SortSongName,
            this.SingerID,
            this.Column11});
            this.dtgSearchData.Location = new System.Drawing.Point(2, 36);
            this.dtgSearchData.Margin = new System.Windows.Forms.Padding(2);
            this.dtgSearchData.Name = "dtgSearchData";
            this.dtgSearchData.RowHeadersWidth = 20;
            this.dtgSearchData.RowTemplate.Height = 24;
            this.dtgSearchData.Size = new System.Drawing.Size(1078, 565);
            this.dtgSearchData.TabIndex = 0;
            // 
            // select
            // 
            this.select.HeaderText = "選択";
            this.select.MinimumWidth = 6;
            this.select.Name = "select";
            this.select.Width = 125;
            // 
            // SongNumber
            // 
            this.SongNumber.HeaderText = "選曲番号";
            this.SongNumber.MinimumWidth = 6;
            this.SongNumber.Name = "SongNumber";
            this.SongNumber.Width = 125;
            // 
            // SongCategory
            // 
            this.SongCategory.HeaderText = "楽曲分類区分";
            this.SongCategory.MinimumWidth = 6;
            this.SongCategory.Name = "SongCategory";
            this.SongCategory.Width = 125;
            // 
            // WhyNotRelease
            // 
            this.WhyNotRelease.HeaderText = "非公開理由";
            this.WhyNotRelease.MinimumWidth = 6;
            this.WhyNotRelease.Name = "WhyNotRelease";
            this.WhyNotRelease.Width = 125;
            // 
            // ReleaseDay
            // 
            this.ReleaseDay.HeaderText = "発売日";
            this.ReleaseDay.MinimumWidth = 6;
            this.ReleaseDay.Name = "ReleaseDay";
            this.ReleaseDay.Width = 125;
            // 
            // SongName
            // 
            this.SongName.HeaderText = "楽曲名";
            this.SongName.MinimumWidth = 6;
            this.SongName.Name = "SongName";
            this.SongName.Width = 125;
            // 
            // SingerName
            // 
            this.SingerName.HeaderText = "歌手名";
            this.SingerName.MinimumWidth = 6;
            this.SingerName.Name = "SingerName";
            this.SingerName.Width = 125;
            // 
            // SearchForSongName
            // 
            this.SearchForSongName.HeaderText = "楽曲名検索用力";
            this.SearchForSongName.MinimumWidth = 6;
            this.SearchForSongName.Name = "SearchForSongName";
            this.SearchForSongName.Width = 125;
            // 
            // SortSongName
            // 
            this.SortSongName.HeaderText = "楽曲名ソート";
            this.SortSongName.MinimumWidth = 6;
            this.SortSongName.Name = "SortSongName";
            this.SortSongName.Width = 125;
            // 
            // SingerID
            // 
            this.SingerID.HeaderText = "歌手ID";
            this.SingerID.MinimumWidth = 6;
            this.SingerID.Name = "SingerID";
            this.SingerID.Width = 125;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Column11";
            this.Column11.MinimumWidth = 6;
            this.Column11.Name = "Column11";
            this.Column11.Width = 125;
            // 
            // btnOutPutUtabonList
            // 
            this.btnOutPutUtabonList.Location = new System.Drawing.Point(383, 2);
            this.btnOutPutUtabonList.Margin = new System.Windows.Forms.Padding(2);
            this.btnOutPutUtabonList.Name = "btnOutPutUtabonList";
            this.btnOutPutUtabonList.Size = new System.Drawing.Size(134, 30);
            this.btnOutPutUtabonList.TabIndex = 8;
            this.btnOutPutUtabonList.Text = "うたぼん用リスト出力(J)";
            this.btnOutPutUtabonList.UseVisualStyleBackColor = true;
            // 
            // btnEnkaFlagSetting
            // 
            this.btnEnkaFlagSetting.Location = new System.Drawing.Point(263, 2);
            this.btnEnkaFlagSetting.Margin = new System.Windows.Forms.Padding(2);
            this.btnEnkaFlagSetting.Name = "btnEnkaFlagSetting";
            this.btnEnkaFlagSetting.Size = new System.Drawing.Size(116, 30);
            this.btnEnkaFlagSetting.TabIndex = 6;
            this.btnEnkaFlagSetting.Text = "演歌フラグ設定(I)";
            this.btnEnkaFlagSetting.UseVisualStyleBackColor = true;
            this.btnEnkaFlagSetting.Click += new System.EventHandler(this.btnEnkaFlagSetting_Click);
            // 
            // btnWiiTSVOutPut
            // 
            this.btnWiiTSVOutPut.Location = new System.Drawing.Point(140, 2);
            this.btnWiiTSVOutPut.Margin = new System.Windows.Forms.Padding(2);
            this.btnWiiTSVOutPut.Name = "btnWiiTSVOutPut";
            this.btnWiiTSVOutPut.Size = new System.Drawing.Size(116, 30);
            this.btnWiiTSVOutPut.TabIndex = 4;
            this.btnWiiTSVOutPut.Text = "Wii　TSV出力(H)";
            this.btnWiiTSVOutPut.UseVisualStyleBackColor = true;
            // 
            // btnListAllDeliveredItem
            // 
            this.btnListAllDeliveredItem.Location = new System.Drawing.Point(1, 2);
            this.btnListAllDeliveredItem.Margin = new System.Windows.Forms.Padding(2);
            this.btnListAllDeliveredItem.Name = "btnListAllDeliveredItem";
            this.btnListAllDeliveredItem.Size = new System.Drawing.Size(135, 30);
            this.btnListAllDeliveredItem.TabIndex = 2;
            this.btnListAllDeliveredItem.Text = "配信済み全件リスト(G)";
            this.btnListAllDeliveredItem.UseVisualStyleBackColor = true;
            // 
            // UCSearchWiiProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnListAllDeliveredItem);
            this.Controls.Add(this.btnWiiTSVOutPut);
            this.Controls.Add(this.btnEnkaFlagSetting);
            this.Controls.Add(this.btnOutPutUtabonList);
            this.Controls.Add(this.dtgSearchData);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UCSearchWiiProduct";
            this.Size = new System.Drawing.Size(1083, 603);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSearchData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgSearchData;
        private System.Windows.Forms.DataGridViewTextBoxColumn select;
        private System.Windows.Forms.DataGridViewTextBoxColumn SongNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn SongCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn WhyNotRelease;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReleaseDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn SongName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SingerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SearchForSongName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SortSongName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SingerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.Button btnOutPutUtabonList;
        private System.Windows.Forms.Button btnEnkaFlagSetting;
        private System.Windows.Forms.Button btnWiiTSVOutPut;
        private System.Windows.Forms.Button btnListAllDeliveredItem;
    }
}
