namespace Festival.DBTab
{
    partial class TabDatabase
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
            this.btnFestivalContent = new System.Windows.Forms.Button();
            this.btnFestivalTSVoutput = new System.Windows.Forms.Button();
            this.btnGenreTieUpConfirm = new System.Windows.Forms.Button();
            this.btnTieUpDuplicateConfirm = new System.Windows.Forms.Button();
            this.btnSingerIDChangeManage = new System.Windows.Forms.Button();
            this.btnFesOriginalSingerManage = new System.Windows.Forms.Button();
            this.btnRecommendSongmanage = new System.Windows.Forms.Button();
            this.btnRecommendProgramManage = new System.Windows.Forms.Button();
            this.btnServiceDeleteFlagCorrection = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_main)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFestivalContent
            // 
            this.btnFestivalContent.AccessibleName = "";
            this.btnFestivalContent.Location = new System.Drawing.Point(3, 3);
            this.btnFestivalContent.Name = "btnFestivalContent";
            this.btnFestivalContent.Size = new System.Drawing.Size(270, 30);
            this.btnFestivalContent.TabIndex = 0;
            this.btnFestivalContent.Tag = "110";
            this.btnFestivalContent.Text = "Festivalコンテンツ(A)";
            this.btnFestivalContent.UseVisualStyleBackColor = true;
            this.btnFestivalContent.Click += new System.EventHandler(this.btnFestivalContent_Click);
            // 
            // btnFestivalTSVoutput
            // 
            this.btnFestivalTSVoutput.Location = new System.Drawing.Point(3, 39);
            this.btnFestivalTSVoutput.Name = "btnFestivalTSVoutput";
            this.btnFestivalTSVoutput.Size = new System.Drawing.Size(270, 30);
            this.btnFestivalTSVoutput.TabIndex = 1;
            this.btnFestivalTSVoutput.Tag = "111";
            this.btnFestivalTSVoutput.Text = "FestivalTSV出力(B)";
            this.btnFestivalTSVoutput.UseVisualStyleBackColor = true;
            this.btnFestivalTSVoutput.Click += new System.EventHandler(this.btnFestivalTSVoutput_Click);
            // 
            // btnGenreTieUpConfirm
            // 
            this.btnGenreTieUpConfirm.Location = new System.Drawing.Point(3, 77);
            this.btnGenreTieUpConfirm.Name = "btnGenreTieUpConfirm";
            this.btnGenreTieUpConfirm.Size = new System.Drawing.Size(270, 30);
            this.btnGenreTieUpConfirm.TabIndex = 2;
            this.btnGenreTieUpConfirm.Tag = "112";
            this.btnGenreTieUpConfirm.Text = "ジャンルタイアップ確認(C)";
            this.btnGenreTieUpConfirm.UseVisualStyleBackColor = true;
            this.btnGenreTieUpConfirm.Click += new System.EventHandler(this.btnGenreTieUpConfirm_Click);
            // 
            // btnTieUpDuplicateConfirm
            // 
            this.btnTieUpDuplicateConfirm.Location = new System.Drawing.Point(3, 113);
            this.btnTieUpDuplicateConfirm.Name = "btnTieUpDuplicateConfirm";
            this.btnTieUpDuplicateConfirm.Size = new System.Drawing.Size(270, 30);
            this.btnTieUpDuplicateConfirm.TabIndex = 3;
            this.btnTieUpDuplicateConfirm.Tag = "113";
            this.btnTieUpDuplicateConfirm.Text = "タイアップ重複確認(D)";
            this.btnTieUpDuplicateConfirm.UseVisualStyleBackColor = true;
            this.btnTieUpDuplicateConfirm.Click += new System.EventHandler(this.btnTieUpDuplicateConfirm_Click);
            // 
            // btnSingerIDChangeManage
            // 
            this.btnSingerIDChangeManage.Location = new System.Drawing.Point(316, 3);
            this.btnSingerIDChangeManage.Name = "btnSingerIDChangeManage";
            this.btnSingerIDChangeManage.Size = new System.Drawing.Size(270, 30);
            this.btnSingerIDChangeManage.TabIndex = 4;
            this.btnSingerIDChangeManage.Tag = "114";
            this.btnSingerIDChangeManage.Text = "歌手ID変更管理(E)";
            this.btnSingerIDChangeManage.UseVisualStyleBackColor = true;
            this.btnSingerIDChangeManage.Click += new System.EventHandler(this.btnSingerIDChangeManage_Click);
            // 
            // btnFesOriginalSingerManage
            // 
            this.btnFesOriginalSingerManage.Location = new System.Drawing.Point(316, 39);
            this.btnFesOriginalSingerManage.Name = "btnFesOriginalSingerManage";
            this.btnFesOriginalSingerManage.Size = new System.Drawing.Size(270, 30);
            this.btnFesOriginalSingerManage.TabIndex = 5;
            this.btnFesOriginalSingerManage.Tag = "115";
            this.btnFesOriginalSingerManage.Text = "Fes独自歌手管理(F)";
            this.btnFesOriginalSingerManage.UseVisualStyleBackColor = true;
            this.btnFesOriginalSingerManage.Click += new System.EventHandler(this.btnFesOriginalSingerManage_Click);
            // 
            // btnRecommendSongmanage
            // 
            this.btnRecommendSongmanage.Location = new System.Drawing.Point(316, 75);
            this.btnRecommendSongmanage.Name = "btnRecommendSongmanage";
            this.btnRecommendSongmanage.Size = new System.Drawing.Size(270, 30);
            this.btnRecommendSongmanage.TabIndex = 6;
            this.btnRecommendSongmanage.Tag = "116";
            this.btnRecommendSongmanage.Text = "おすすめ曲管理(G)";
            this.btnRecommendSongmanage.UseVisualStyleBackColor = true;
            this.btnRecommendSongmanage.Click += new System.EventHandler(this.btnRecommendSongmanage_Click);
            // 
            // btnRecommendProgramManage
            // 
            this.btnRecommendProgramManage.Location = new System.Drawing.Point(316, 113);
            this.btnRecommendProgramManage.Name = "btnRecommendProgramManage";
            this.btnRecommendProgramManage.Size = new System.Drawing.Size(270, 30);
            this.btnRecommendProgramManage.TabIndex = 7;
            this.btnRecommendProgramManage.Tag = "118";
            this.btnRecommendProgramManage.Text = "おすすめプログラム管理(H)";
            this.btnRecommendProgramManage.UseVisualStyleBackColor = true;
            this.btnRecommendProgramManage.Click += new System.EventHandler(this.btnRecommendProgramManage_Click);
            // 
            // btnServiceDeleteFlagCorrection
            // 
            this.btnServiceDeleteFlagCorrection.Location = new System.Drawing.Point(316, 149);
            this.btnServiceDeleteFlagCorrection.Name = "btnServiceDeleteFlagCorrection";
            this.btnServiceDeleteFlagCorrection.Size = new System.Drawing.Size(270, 30);
            this.btnServiceDeleteFlagCorrection.TabIndex = 8;
            this.btnServiceDeleteFlagCorrection.Tag = "117";
            this.btnServiceDeleteFlagCorrection.Text = "サービス取消フラグ補正(I)";
            this.btnServiceDeleteFlagCorrection.UseVisualStyleBackColor = true;
            this.btnServiceDeleteFlagCorrection.Visible = false;
            // 
            // TabDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnServiceDeleteFlagCorrection);
            this.Controls.Add(this.btnRecommendProgramManage);
            this.Controls.Add(this.btnRecommendSongmanage);
            this.Controls.Add(this.btnFesOriginalSingerManage);
            this.Controls.Add(this.btnSingerIDChangeManage);
            this.Controls.Add(this.btnTieUpDuplicateConfirm);
            this.Controls.Add(this.btnGenreTieUpConfirm);
            this.Controls.Add(this.btnFestivalTSVoutput);
            this.Controls.Add(this.btnFestivalContent);
            this.Name = "TabDatabase";
            this.Size = new System.Drawing.Size(651, 275);
            this.Load += new System.EventHandler(this.TabDatabase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_main)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFestivalContent;
        private System.Windows.Forms.Button btnFestivalTSVoutput;
        private System.Windows.Forms.Button btnGenreTieUpConfirm;
        private System.Windows.Forms.Button btnTieUpDuplicateConfirm;
        private System.Windows.Forms.Button btnSingerIDChangeManage;
        private System.Windows.Forms.Button btnFesOriginalSingerManage;
        private System.Windows.Forms.Button btnRecommendSongmanage;
        private System.Windows.Forms.Button btnRecommendProgramManage;
        private System.Windows.Forms.Button btnServiceDeleteFlagCorrection;
    }
}
