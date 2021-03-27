namespace Festival.DiscVideoTab.FesSongWithDisc
{
    partial class FesSongWithDiscSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FesSongWithDiscSearch));
            this.btnSearch = new System.Windows.Forms.Button();
            this.grpSearchingCondition = new System.Windows.Forms.GroupBox();
            this.dtProductionDateTo = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            this.dtServiceDateTo = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            this.dtScheduleUpdateDateTo = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            this.dtCancelDateTo = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            this.dtProductionDateFrom = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            this.dtServiceDateFrom = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            this.dtScheduleUpdateDateFrom = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            this.dtCancelDateFrom = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radExclude = new System.Windows.Forms.RadioButton();
            this.radPartialMatch = new System.Windows.Forms.RadioButton();
            this.radFrontMatch = new System.Windows.Forms.RadioButton();
            this.radMatchingAll = new System.Windows.Forms.RadioButton();
            this.cboUsAgeFlag = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cboRegisteredCondition = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtSingerNameKana = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtSingerName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtSongNameTitleKanaCorrection = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtSongNamKana = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtSongName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtFes_DISCIDTo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtFes_DISCIDFrom = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtKaraokeNoTo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtKaraokeNoFrom = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtDigiDocoNoTo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtDigiDocoNoFrom = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblFes_NET利用フラグ = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblOrch_制作完了日 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblFes_アップ予定日 = new System.Windows.Forms.Label();
            this.lblFes_サービス発表日 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lbl取消日 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblFes_DISCID = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblカラオケNo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblデジドコNo = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnVideoCodeInput = new DevComponents.DotNetBar.ButtonX();
            this.btnKaraokeNoInput = new DevComponents.DotNetBar.ButtonX();
            this.btnDigiDokoNoInput = new DevComponents.DotNetBar.ButtonX();
            this.label10 = new System.Windows.Forms.Label();
            this.grpSearchingCondition.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.Location = new System.Drawing.Point(348, 479);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 23);
            this.btnSearch.TabIndex = 59;
            this.btnSearch.Text = "検索(F5)";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // grpSearchingCondition
            // 
            this.grpSearchingCondition.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSearchingCondition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grpSearchingCondition.Controls.Add(this.dtProductionDateTo);
            this.grpSearchingCondition.Controls.Add(this.dtServiceDateTo);
            this.grpSearchingCondition.Controls.Add(this.dtScheduleUpdateDateTo);
            this.grpSearchingCondition.Controls.Add(this.dtCancelDateTo);
            this.grpSearchingCondition.Controls.Add(this.dtProductionDateFrom);
            this.grpSearchingCondition.Controls.Add(this.dtServiceDateFrom);
            this.grpSearchingCondition.Controls.Add(this.dtScheduleUpdateDateFrom);
            this.grpSearchingCondition.Controls.Add(this.dtCancelDateFrom);
            this.grpSearchingCondition.Controls.Add(this.groupBox1);
            this.grpSearchingCondition.Controls.Add(this.cboUsAgeFlag);
            this.grpSearchingCondition.Controls.Add(this.cboRegisteredCondition);
            this.grpSearchingCondition.Controls.Add(this.txtSingerNameKana);
            this.grpSearchingCondition.Controls.Add(this.txtSingerName);
            this.grpSearchingCondition.Controls.Add(this.txtSongNameTitleKanaCorrection);
            this.grpSearchingCondition.Controls.Add(this.txtSongNamKana);
            this.grpSearchingCondition.Controls.Add(this.txtSongName);
            this.grpSearchingCondition.Controls.Add(this.txtFes_DISCIDTo);
            this.grpSearchingCondition.Controls.Add(this.txtFes_DISCIDFrom);
            this.grpSearchingCondition.Controls.Add(this.txtKaraokeNoTo);
            this.grpSearchingCondition.Controls.Add(this.txtKaraokeNoFrom);
            this.grpSearchingCondition.Controls.Add(this.txtDigiDocoNoTo);
            this.grpSearchingCondition.Controls.Add(this.txtDigiDocoNoFrom);
            this.grpSearchingCondition.Controls.Add(this.lblFes_NET利用フラグ);
            this.grpSearchingCondition.Controls.Add(this.label17);
            this.grpSearchingCondition.Controls.Add(this.label16);
            this.grpSearchingCondition.Controls.Add(this.lblOrch_制作完了日);
            this.grpSearchingCondition.Controls.Add(this.label15);
            this.grpSearchingCondition.Controls.Add(this.label12);
            this.grpSearchingCondition.Controls.Add(this.lblFes_アップ予定日);
            this.grpSearchingCondition.Controls.Add(this.lblFes_サービス発表日);
            this.grpSearchingCondition.Controls.Add(this.label13);
            this.grpSearchingCondition.Controls.Add(this.lbl取消日);
            this.grpSearchingCondition.Controls.Add(this.label11);
            this.grpSearchingCondition.Controls.Add(this.lblFes_DISCID);
            this.grpSearchingCondition.Controls.Add(this.label9);
            this.grpSearchingCondition.Controls.Add(this.label8);
            this.grpSearchingCondition.Controls.Add(this.label7);
            this.grpSearchingCondition.Controls.Add(this.label6);
            this.grpSearchingCondition.Controls.Add(this.label5);
            this.grpSearchingCondition.Controls.Add(this.label4);
            this.grpSearchingCondition.Controls.Add(this.lblカラオケNo);
            this.grpSearchingCondition.Controls.Add(this.label2);
            this.grpSearchingCondition.Controls.Add(this.lblデジドコNo);
            this.grpSearchingCondition.ForeColor = System.Drawing.Color.Black;
            this.grpSearchingCondition.Location = new System.Drawing.Point(7, 28);
            this.grpSearchingCondition.Name = "grpSearchingCondition";
            this.grpSearchingCondition.Size = new System.Drawing.Size(547, 445);
            this.grpSearchingCondition.TabIndex = 61;
            this.grpSearchingCondition.TabStop = false;
            // 
            // dtProductionDateTo
            // 
            this.dtProductionDateTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtProductionDateTo.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.dtProductionDateTo.BackgroundStyle.Class = "TextBoxBorder";
            this.dtProductionDateTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtProductionDateTo.ButtonClear.Text = "X";
            this.dtProductionDateTo.ButtonClear.Visible = true;
            this.dtProductionDateTo.Culture = new System.Globalization.CultureInfo("ja-JP");
            this.dtProductionDateTo.DisabledBackColor = System.Drawing.Color.White;
            this.dtProductionDateTo.ForeColor = System.Drawing.Color.Black;
            this.dtProductionDateTo.Location = new System.Drawing.Point(353, 322);
            this.dtProductionDateTo.Mask = "0000/00/00";
            this.dtProductionDateTo.Name = "dtProductionDateTo";
            this.dtProductionDateTo.Size = new System.Drawing.Size(184, 20);
            this.dtProductionDateTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtProductionDateTo.TabIndex = 49;
            this.dtProductionDateTo.Text = "";
            // 
            // dtServiceDateTo
            // 
            this.dtServiceDateTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtServiceDateTo.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.dtServiceDateTo.BackgroundStyle.Class = "TextBoxBorder";
            this.dtServiceDateTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtServiceDateTo.ButtonClear.Text = "X";
            this.dtServiceDateTo.ButtonClear.Visible = true;
            this.dtServiceDateTo.Culture = new System.Globalization.CultureInfo("ja-JP");
            this.dtServiceDateTo.DisabledBackColor = System.Drawing.Color.White;
            this.dtServiceDateTo.ForeColor = System.Drawing.Color.Black;
            this.dtServiceDateTo.Location = new System.Drawing.Point(353, 296);
            this.dtServiceDateTo.Mask = "0000/00/00";
            this.dtServiceDateTo.Name = "dtServiceDateTo";
            this.dtServiceDateTo.Size = new System.Drawing.Size(184, 20);
            this.dtServiceDateTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtServiceDateTo.TabIndex = 49;
            this.dtServiceDateTo.Text = "";
            // 
            // dtScheduleUpdateDateTo
            // 
            this.dtScheduleUpdateDateTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtScheduleUpdateDateTo.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.dtScheduleUpdateDateTo.BackgroundStyle.Class = "TextBoxBorder";
            this.dtScheduleUpdateDateTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtScheduleUpdateDateTo.ButtonClear.Text = "X";
            this.dtScheduleUpdateDateTo.ButtonClear.Visible = true;
            this.dtScheduleUpdateDateTo.Culture = new System.Globalization.CultureInfo("ja-JP");
            this.dtScheduleUpdateDateTo.DisabledBackColor = System.Drawing.Color.White;
            this.dtScheduleUpdateDateTo.ForeColor = System.Drawing.Color.Black;
            this.dtScheduleUpdateDateTo.Location = new System.Drawing.Point(353, 270);
            this.dtScheduleUpdateDateTo.Mask = "0000/00/00";
            this.dtScheduleUpdateDateTo.Name = "dtScheduleUpdateDateTo";
            this.dtScheduleUpdateDateTo.Size = new System.Drawing.Size(184, 20);
            this.dtScheduleUpdateDateTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtScheduleUpdateDateTo.TabIndex = 49;
            this.dtScheduleUpdateDateTo.Text = "";
            // 
            // dtCancelDateTo
            // 
            this.dtCancelDateTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtCancelDateTo.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.dtCancelDateTo.BackgroundStyle.Class = "TextBoxBorder";
            this.dtCancelDateTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtCancelDateTo.ButtonClear.Text = "X";
            this.dtCancelDateTo.ButtonClear.Visible = true;
            this.dtCancelDateTo.Culture = new System.Globalization.CultureInfo("ja-JP");
            this.dtCancelDateTo.DisabledBackColor = System.Drawing.Color.White;
            this.dtCancelDateTo.ForeColor = System.Drawing.Color.Black;
            this.dtCancelDateTo.Location = new System.Drawing.Point(353, 244);
            this.dtCancelDateTo.Mask = "0000/00/00";
            this.dtCancelDateTo.Name = "dtCancelDateTo";
            this.dtCancelDateTo.Size = new System.Drawing.Size(184, 20);
            this.dtCancelDateTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtCancelDateTo.TabIndex = 49;
            this.dtCancelDateTo.Text = "";
            // 
            // dtProductionDateFrom
            // 
            this.dtProductionDateFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtProductionDateFrom.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.dtProductionDateFrom.BackgroundStyle.Class = "TextBoxBorder";
            this.dtProductionDateFrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtProductionDateFrom.ButtonClear.Text = "X";
            this.dtProductionDateFrom.ButtonClear.Visible = true;
            this.dtProductionDateFrom.Culture = new System.Globalization.CultureInfo("ja-JP");
            this.dtProductionDateFrom.DisabledBackColor = System.Drawing.Color.White;
            this.dtProductionDateFrom.ForeColor = System.Drawing.Color.Black;
            this.dtProductionDateFrom.Location = new System.Drawing.Point(127, 322);
            this.dtProductionDateFrom.Mask = "0000/00/00";
            this.dtProductionDateFrom.Name = "dtProductionDateFrom";
            this.dtProductionDateFrom.Size = new System.Drawing.Size(184, 20);
            this.dtProductionDateFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtProductionDateFrom.TabIndex = 49;
            this.dtProductionDateFrom.Text = "";
            // 
            // dtServiceDateFrom
            // 
            this.dtServiceDateFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtServiceDateFrom.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.dtServiceDateFrom.BackgroundStyle.Class = "TextBoxBorder";
            this.dtServiceDateFrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtServiceDateFrom.ButtonClear.Text = "X";
            this.dtServiceDateFrom.ButtonClear.Visible = true;
            this.dtServiceDateFrom.Culture = new System.Globalization.CultureInfo("ja-JP");
            this.dtServiceDateFrom.DisabledBackColor = System.Drawing.Color.White;
            this.dtServiceDateFrom.ForeColor = System.Drawing.Color.Black;
            this.dtServiceDateFrom.Location = new System.Drawing.Point(127, 296);
            this.dtServiceDateFrom.Mask = "0000/00/00";
            this.dtServiceDateFrom.Name = "dtServiceDateFrom";
            this.dtServiceDateFrom.Size = new System.Drawing.Size(184, 20);
            this.dtServiceDateFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtServiceDateFrom.TabIndex = 49;
            this.dtServiceDateFrom.Text = "";
            // 
            // dtScheduleUpdateDateFrom
            // 
            this.dtScheduleUpdateDateFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtScheduleUpdateDateFrom.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.dtScheduleUpdateDateFrom.BackgroundStyle.Class = "TextBoxBorder";
            this.dtScheduleUpdateDateFrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtScheduleUpdateDateFrom.ButtonClear.Text = "X";
            this.dtScheduleUpdateDateFrom.ButtonClear.Visible = true;
            this.dtScheduleUpdateDateFrom.Culture = new System.Globalization.CultureInfo("ja-JP");
            this.dtScheduleUpdateDateFrom.DisabledBackColor = System.Drawing.Color.White;
            this.dtScheduleUpdateDateFrom.ForeColor = System.Drawing.Color.Black;
            this.dtScheduleUpdateDateFrom.Location = new System.Drawing.Point(127, 270);
            this.dtScheduleUpdateDateFrom.Mask = "0000/00/00";
            this.dtScheduleUpdateDateFrom.Name = "dtScheduleUpdateDateFrom";
            this.dtScheduleUpdateDateFrom.Size = new System.Drawing.Size(184, 20);
            this.dtScheduleUpdateDateFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtScheduleUpdateDateFrom.TabIndex = 49;
            this.dtScheduleUpdateDateFrom.Text = "";
            // 
            // dtCancelDateFrom
            // 
            this.dtCancelDateFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtCancelDateFrom.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.dtCancelDateFrom.BackgroundStyle.Class = "TextBoxBorder";
            this.dtCancelDateFrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtCancelDateFrom.ButtonClear.Text = "X";
            this.dtCancelDateFrom.ButtonClear.Visible = true;
            this.dtCancelDateFrom.Culture = new System.Globalization.CultureInfo("ja-JP");
            this.dtCancelDateFrom.DisabledBackColor = System.Drawing.Color.White;
            this.dtCancelDateFrom.ForeColor = System.Drawing.Color.Black;
            this.dtCancelDateFrom.Location = new System.Drawing.Point(127, 244);
            this.dtCancelDateFrom.Mask = "0000/00/00";
            this.dtCancelDateFrom.Name = "dtCancelDateFrom";
            this.dtCancelDateFrom.Size = new System.Drawing.Size(184, 20);
            this.dtCancelDateFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtCancelDateFrom.TabIndex = 49;
            this.dtCancelDateFrom.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox1.Controls.Add(this.radExclude);
            this.groupBox1.Controls.Add(this.radPartialMatch);
            this.groupBox1.Controls.Add(this.radFrontMatch);
            this.groupBox1.Controls.Add(this.radMatchingAll);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(127, 375);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 62);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "検索方法(Q)";
            // 
            // radExclude
            // 
            this.radExclude.AutoSize = true;
            this.radExclude.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.radExclude.ForeColor = System.Drawing.Color.Black;
            this.radExclude.Location = new System.Drawing.Point(329, 25);
            this.radExclude.Name = "radExclude";
            this.radExclude.Size = new System.Drawing.Size(66, 17);
            this.radExclude.TabIndex = 50;
            this.radExclude.Text = "含まない";
            this.radExclude.UseVisualStyleBackColor = false;
            // 
            // radPartialMatch
            // 
            this.radPartialMatch.AutoSize = true;
            this.radPartialMatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.radPartialMatch.Checked = true;
            this.radPartialMatch.ForeColor = System.Drawing.Color.Black;
            this.radPartialMatch.Location = new System.Drawing.Point(224, 25);
            this.radPartialMatch.Name = "radPartialMatch";
            this.radPartialMatch.Size = new System.Drawing.Size(73, 17);
            this.radPartialMatch.TabIndex = 49;
            this.radPartialMatch.TabStop = true;
            this.radPartialMatch.Text = "部分一致";
            this.radPartialMatch.UseVisualStyleBackColor = false;
            // 
            // radFrontMatch
            // 
            this.radFrontMatch.AutoSize = true;
            this.radFrontMatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.radFrontMatch.ForeColor = System.Drawing.Color.Black;
            this.radFrontMatch.Location = new System.Drawing.Point(119, 25);
            this.radFrontMatch.Name = "radFrontMatch";
            this.radFrontMatch.Size = new System.Drawing.Size(73, 17);
            this.radFrontMatch.TabIndex = 48;
            this.radFrontMatch.Text = "前方一致";
            this.radFrontMatch.UseVisualStyleBackColor = false;
            // 
            // radMatchingAll
            // 
            this.radMatchingAll.AutoSize = true;
            this.radMatchingAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.radMatchingAll.ForeColor = System.Drawing.Color.Black;
            this.radMatchingAll.Location = new System.Drawing.Point(14, 25);
            this.radMatchingAll.Name = "radMatchingAll";
            this.radMatchingAll.Size = new System.Drawing.Size(73, 17);
            this.radMatchingAll.TabIndex = 47;
            this.radMatchingAll.Text = "完全一致";
            this.radMatchingAll.UseVisualStyleBackColor = false;
            // 
            // cboUsAgeFlag
            // 
            this.cboUsAgeFlag.DisplayMember = "Text";
            this.cboUsAgeFlag.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboUsAgeFlag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUsAgeFlag.ForeColor = System.Drawing.Color.Black;
            this.cboUsAgeFlag.FormattingEnabled = true;
            this.cboUsAgeFlag.ItemHeight = 15;
            this.cboUsAgeFlag.Location = new System.Drawing.Point(127, 217);
            this.cboUsAgeFlag.Name = "cboUsAgeFlag";
            this.cboUsAgeFlag.Size = new System.Drawing.Size(410, 21);
            this.cboUsAgeFlag.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboUsAgeFlag.TabIndex = 3;
            // 
            // cboRegisteredCondition
            // 
            this.cboRegisteredCondition.DisplayMember = "Text";
            this.cboRegisteredCondition.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboRegisteredCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRegisteredCondition.ForeColor = System.Drawing.Color.Black;
            this.cboRegisteredCondition.FormattingEnabled = true;
            this.cboRegisteredCondition.ItemHeight = 15;
            this.cboRegisteredCondition.Location = new System.Drawing.Point(127, 349);
            this.cboRegisteredCondition.Name = "cboRegisteredCondition";
            this.cboRegisteredCondition.Size = new System.Drawing.Size(410, 21);
            this.cboRegisteredCondition.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboRegisteredCondition.TabIndex = 3;
            // 
            // txtSingerNameKana
            // 
            this.txtSingerNameKana.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtSingerNameKana.Border.Class = "TextBoxBorder";
            this.txtSingerNameKana.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSingerNameKana.DisabledBackColor = System.Drawing.Color.White;
            this.txtSingerNameKana.ForeColor = System.Drawing.Color.Black;
            this.txtSingerNameKana.Location = new System.Drawing.Point(127, 165);
            this.txtSingerNameKana.Name = "txtSingerNameKana";
            this.txtSingerNameKana.PreventEnterBeep = true;
            this.txtSingerNameKana.Size = new System.Drawing.Size(410, 20);
            this.txtSingerNameKana.TabIndex = 2;
            // 
            // txtSingerName
            // 
            this.txtSingerName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtSingerName.Border.Class = "TextBoxBorder";
            this.txtSingerName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSingerName.DisabledBackColor = System.Drawing.Color.White;
            this.txtSingerName.ForeColor = System.Drawing.Color.Black;
            this.txtSingerName.Location = new System.Drawing.Point(127, 139);
            this.txtSingerName.Name = "txtSingerName";
            this.txtSingerName.PreventEnterBeep = true;
            this.txtSingerName.Size = new System.Drawing.Size(410, 20);
            this.txtSingerName.TabIndex = 2;
            // 
            // txtSongNameTitleKanaCorrection
            // 
            this.txtSongNameTitleKanaCorrection.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtSongNameTitleKanaCorrection.Border.Class = "TextBoxBorder";
            this.txtSongNameTitleKanaCorrection.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSongNameTitleKanaCorrection.DisabledBackColor = System.Drawing.Color.White;
            this.txtSongNameTitleKanaCorrection.ForeColor = System.Drawing.Color.Black;
            this.txtSongNameTitleKanaCorrection.Location = new System.Drawing.Point(127, 113);
            this.txtSongNameTitleKanaCorrection.Name = "txtSongNameTitleKanaCorrection";
            this.txtSongNameTitleKanaCorrection.PreventEnterBeep = true;
            this.txtSongNameTitleKanaCorrection.Size = new System.Drawing.Size(410, 20);
            this.txtSongNameTitleKanaCorrection.TabIndex = 2;
            // 
            // txtSongNamKana
            // 
            this.txtSongNamKana.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtSongNamKana.Border.Class = "TextBoxBorder";
            this.txtSongNamKana.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSongNamKana.DisabledBackColor = System.Drawing.Color.White;
            this.txtSongNamKana.ForeColor = System.Drawing.Color.Black;
            this.txtSongNamKana.Location = new System.Drawing.Point(127, 87);
            this.txtSongNamKana.Name = "txtSongNamKana";
            this.txtSongNamKana.PreventEnterBeep = true;
            this.txtSongNamKana.Size = new System.Drawing.Size(410, 20);
            this.txtSongNamKana.TabIndex = 2;
            // 
            // txtSongName
            // 
            this.txtSongName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtSongName.Border.Class = "TextBoxBorder";
            this.txtSongName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSongName.DisabledBackColor = System.Drawing.Color.White;
            this.txtSongName.ForeColor = System.Drawing.Color.Black;
            this.txtSongName.Location = new System.Drawing.Point(127, 62);
            this.txtSongName.Name = "txtSongName";
            this.txtSongName.PreventEnterBeep = true;
            this.txtSongName.Size = new System.Drawing.Size(410, 20);
            this.txtSongName.TabIndex = 2;
            // 
            // txtFes_DISCIDTo
            // 
            this.txtFes_DISCIDTo.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtFes_DISCIDTo.Border.Class = "TextBoxBorder";
            this.txtFes_DISCIDTo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFes_DISCIDTo.DisabledBackColor = System.Drawing.Color.White;
            this.txtFes_DISCIDTo.ForeColor = System.Drawing.Color.Black;
            this.txtFes_DISCIDTo.Location = new System.Drawing.Point(353, 191);
            this.txtFes_DISCIDTo.MaxLength = 8;
            this.txtFes_DISCIDTo.Name = "txtFes_DISCIDTo";
            this.txtFes_DISCIDTo.PreventEnterBeep = true;
            this.txtFes_DISCIDTo.Size = new System.Drawing.Size(184, 20);
            this.txtFes_DISCIDTo.TabIndex = 2;
            this.txtFes_DISCIDTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            this.txtFes_DISCIDTo.Leave += new System.EventHandler(this.OnLeave);
            // 
            // txtFes_DISCIDFrom
            // 
            this.txtFes_DISCIDFrom.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtFes_DISCIDFrom.Border.Class = "TextBoxBorder";
            this.txtFes_DISCIDFrom.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFes_DISCIDFrom.DisabledBackColor = System.Drawing.Color.White;
            this.txtFes_DISCIDFrom.ForeColor = System.Drawing.Color.Black;
            this.txtFes_DISCIDFrom.Location = new System.Drawing.Point(127, 191);
            this.txtFes_DISCIDFrom.MaxLength = 8;
            this.txtFes_DISCIDFrom.Name = "txtFes_DISCIDFrom";
            this.txtFes_DISCIDFrom.PreventEnterBeep = true;
            this.txtFes_DISCIDFrom.Size = new System.Drawing.Size(184, 20);
            this.txtFes_DISCIDFrom.TabIndex = 2;
            this.txtFes_DISCIDFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            this.txtFes_DISCIDFrom.Leave += new System.EventHandler(this.OnLeave);
            // 
            // txtKaraokeNoTo
            // 
            this.txtKaraokeNoTo.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtKaraokeNoTo.Border.Class = "TextBoxBorder";
            this.txtKaraokeNoTo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtKaraokeNoTo.DisabledBackColor = System.Drawing.Color.White;
            this.txtKaraokeNoTo.ForeColor = System.Drawing.Color.Black;
            this.txtKaraokeNoTo.Location = new System.Drawing.Point(353, 37);
            this.txtKaraokeNoTo.MaxLength = 8;
            this.txtKaraokeNoTo.Name = "txtKaraokeNoTo";
            this.txtKaraokeNoTo.PreventEnterBeep = true;
            this.txtKaraokeNoTo.Size = new System.Drawing.Size(184, 20);
            this.txtKaraokeNoTo.TabIndex = 2;
            this.txtKaraokeNoTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            this.txtKaraokeNoTo.Leave += new System.EventHandler(this.OnLeave);
            // 
            // txtKaraokeNoFrom
            // 
            this.txtKaraokeNoFrom.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtKaraokeNoFrom.Border.Class = "TextBoxBorder";
            this.txtKaraokeNoFrom.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtKaraokeNoFrom.DisabledBackColor = System.Drawing.Color.White;
            this.txtKaraokeNoFrom.ForeColor = System.Drawing.Color.Black;
            this.txtKaraokeNoFrom.Location = new System.Drawing.Point(127, 37);
            this.txtKaraokeNoFrom.MaxLength = 8;
            this.txtKaraokeNoFrom.Name = "txtKaraokeNoFrom";
            this.txtKaraokeNoFrom.PreventEnterBeep = true;
            this.txtKaraokeNoFrom.Size = new System.Drawing.Size(184, 20);
            this.txtKaraokeNoFrom.TabIndex = 2;
            this.txtKaraokeNoFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            this.txtKaraokeNoFrom.Leave += new System.EventHandler(this.OnLeave);
            // 
            // txtDigiDocoNoTo
            // 
            this.txtDigiDocoNoTo.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtDigiDocoNoTo.Border.Class = "TextBoxBorder";
            this.txtDigiDocoNoTo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDigiDocoNoTo.DisabledBackColor = System.Drawing.Color.White;
            this.txtDigiDocoNoTo.ForeColor = System.Drawing.Color.Black;
            this.txtDigiDocoNoTo.Location = new System.Drawing.Point(353, 12);
            this.txtDigiDocoNoTo.MaxLength = 8;
            this.txtDigiDocoNoTo.Name = "txtDigiDocoNoTo";
            this.txtDigiDocoNoTo.PreventEnterBeep = true;
            this.txtDigiDocoNoTo.Size = new System.Drawing.Size(184, 20);
            this.txtDigiDocoNoTo.TabIndex = 2;
            this.txtDigiDocoNoTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            this.txtDigiDocoNoTo.Leave += new System.EventHandler(this.OnLeave);
            // 
            // txtDigiDocoNoFrom
            // 
            this.txtDigiDocoNoFrom.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtDigiDocoNoFrom.Border.Class = "TextBoxBorder";
            this.txtDigiDocoNoFrom.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDigiDocoNoFrom.DisabledBackColor = System.Drawing.Color.White;
            this.txtDigiDocoNoFrom.ForeColor = System.Drawing.Color.Black;
            this.txtDigiDocoNoFrom.Location = new System.Drawing.Point(127, 12);
            this.txtDigiDocoNoFrom.MaxLength = 8;
            this.txtDigiDocoNoFrom.Name = "txtDigiDocoNoFrom";
            this.txtDigiDocoNoFrom.PreventEnterBeep = true;
            this.txtDigiDocoNoFrom.Size = new System.Drawing.Size(184, 20);
            this.txtDigiDocoNoFrom.TabIndex = 2;
            this.txtDigiDocoNoFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            this.txtDigiDocoNoFrom.Leave += new System.EventHandler(this.OnLeave);
            // 
            // lblFes_NET利用フラグ
            // 
            this.lblFes_NET利用フラグ.AutoSize = true;
            this.lblFes_NET利用フラグ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblFes_NET利用フラグ.ForeColor = System.Drawing.Color.Black;
            this.lblFes_NET利用フラグ.Location = new System.Drawing.Point(5, 221);
            this.lblFes_NET利用フラグ.Name = "lblFes_NET利用フラグ";
            this.lblFes_NET利用フラグ.Size = new System.Drawing.Size(101, 13);
            this.lblFes_NET利用フラグ.TabIndex = 1;
            this.lblFes_NET利用フラグ.Text = "Fes_NET利用フラグ";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(325, 326);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(14, 13);
            this.label17.TabIndex = 1;
            this.label17.Text = "~";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(5, 353);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(78, 13);
            this.label16.TabIndex = 1;
            this.label16.Text = "登録済み条件";
            // 
            // lblOrch_制作完了日
            // 
            this.lblOrch_制作完了日.AutoSize = true;
            this.lblOrch_制作完了日.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblOrch_制作完了日.ForeColor = System.Drawing.Color.Black;
            this.lblOrch_制作完了日.Location = new System.Drawing.Point(5, 326);
            this.lblOrch_制作完了日.Name = "lblOrch_制作完了日";
            this.lblOrch_制作完了日.Size = new System.Drawing.Size(96, 13);
            this.lblOrch_制作完了日.TabIndex = 1;
            this.lblOrch_制作完了日.Text = "Orch_制作完了日";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(325, 274);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(14, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "~";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(325, 300);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(14, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "~";
            // 
            // lblFes_アップ予定日
            // 
            this.lblFes_アップ予定日.AutoSize = true;
            this.lblFes_アップ予定日.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblFes_アップ予定日.ForeColor = System.Drawing.Color.Black;
            this.lblFes_アップ予定日.Location = new System.Drawing.Point(5, 274);
            this.lblFes_アップ予定日.Name = "lblFes_アップ予定日";
            this.lblFes_アップ予定日.Size = new System.Drawing.Size(91, 13);
            this.lblFes_アップ予定日.TabIndex = 1;
            this.lblFes_アップ予定日.Text = "Fes_アップ予定日";
            // 
            // lblFes_サービス発表日
            // 
            this.lblFes_サービス発表日.AutoSize = true;
            this.lblFes_サービス発表日.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblFes_サービス発表日.ForeColor = System.Drawing.Color.Black;
            this.lblFes_サービス発表日.Location = new System.Drawing.Point(5, 300);
            this.lblFes_サービス発表日.Name = "lblFes_サービス発表日";
            this.lblFes_サービス発表日.Size = new System.Drawing.Size(103, 13);
            this.lblFes_サービス発表日.TabIndex = 1;
            this.lblFes_サービス発表日.Text = "Fes_サービス発表日";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(325, 248);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(14, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "~";
            // 
            // lbl取消日
            // 
            this.lbl取消日.AutoSize = true;
            this.lbl取消日.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbl取消日.ForeColor = System.Drawing.Color.Black;
            this.lbl取消日.Location = new System.Drawing.Point(5, 248);
            this.lbl取消日.Name = "lbl取消日";
            this.lbl取消日.Size = new System.Drawing.Size(62, 13);
            this.lbl取消日.TabIndex = 1;
            this.lbl取消日.Text = "取消日_V2";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(325, 195);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "~";
            // 
            // lblFes_DISCID
            // 
            this.lblFes_DISCID.AutoSize = true;
            this.lblFes_DISCID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblFes_DISCID.ForeColor = System.Drawing.Color.Black;
            this.lblFes_DISCID.Location = new System.Drawing.Point(5, 195);
            this.lblFes_DISCID.Name = "lblFes_DISCID";
            this.lblFes_DISCID.Size = new System.Drawing.Size(66, 13);
            this.lblFes_DISCID.TabIndex = 1;
            this.lblFes_DISCID.Text = "Fes_DISCID";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(5, 169);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "歌手名カナ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(5, 143);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "歌手名";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(5, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "曲名カナ補正";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(5, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "曲名カナ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(5, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "曲名(MARY)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(325, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "~";
            // 
            // lblカラオケNo
            // 
            this.lblカラオケNo.AutoSize = true;
            this.lblカラオケNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblカラオケNo.ForeColor = System.Drawing.Color.Black;
            this.lblカラオケNo.Location = new System.Drawing.Point(5, 41);
            this.lblカラオケNo.Name = "lblカラオケNo";
            this.lblカラオケNo.Size = new System.Drawing.Size(56, 13);
            this.lblカラオケNo.TabIndex = 1;
            this.lblカラオケNo.Text = "カラオケNo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(325, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "~";
            // 
            // lblデジドコNo
            // 
            this.lblデジドコNo.AutoSize = true;
            this.lblデジドコNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblデジドコNo.ForeColor = System.Drawing.Color.Black;
            this.lblデジドコNo.Location = new System.Drawing.Point(5, 16);
            this.lblデジドコNo.Name = "lblデジドコNo";
            this.lblデジドコNo.Size = new System.Drawing.Size(58, 13);
            this.lblデジドコNo.TabIndex = 1;
            this.lblデジドコNo.Text = "デジドコNo";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(454, 479);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 23);
            this.btnClose.TabIndex = 60;
            this.btnClose.Text = "閉じる";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Location = new System.Drawing.Point(242, 479);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 23);
            this.btnClear.TabIndex = 58;
            this.btnClear.Text = "クリア(Alt+C)";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnVideoCodeInput
            // 
            this.btnVideoCodeInput.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnVideoCodeInput.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnVideoCodeInput.Location = new System.Drawing.Point(364, 4);
            this.btnVideoCodeInput.Name = "btnVideoCodeInput";
            this.btnVideoCodeInput.Size = new System.Drawing.Size(189, 23);
            this.btnVideoCodeInput.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnVideoCodeInput.TabIndex = 0;
            this.btnVideoCodeInput.Text = "Fes_DISCID入力(Shift+F11)";
            this.btnVideoCodeInput.Click += new System.EventHandler(this.btnVideoCodeInput_Click);
            // 
            // btnKaraokeNoInput
            // 
            this.btnKaraokeNoInput.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnKaraokeNoInput.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnKaraokeNoInput.Location = new System.Drawing.Point(148, 4);
            this.btnKaraokeNoInput.Name = "btnKaraokeNoInput";
            this.btnKaraokeNoInput.Size = new System.Drawing.Size(198, 23);
            this.btnKaraokeNoInput.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnKaraokeNoInput.TabIndex = 0;
            this.btnKaraokeNoInput.Text = "カラオケNo入力(Shift+F12)";
            this.btnKaraokeNoInput.Click += new System.EventHandler(this.btnKaraokeNoInput_Click);
            // 
            // btnDigiDokoNoInput
            // 
            this.btnDigiDokoNoInput.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDigiDokoNoInput.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDigiDokoNoInput.Location = new System.Drawing.Point(7, 4);
            this.btnDigiDokoNoInput.Name = "btnDigiDokoNoInput";
            this.btnDigiDokoNoInput.Size = new System.Drawing.Size(120, 23);
            this.btnDigiDokoNoInput.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDigiDokoNoInput.TabIndex = 0;
            this.btnDigiDokoNoInput.Text = "デジドコNo入力(F12)";
            this.btnDigiDokoNoInput.Click += new System.EventHandler(this.btnDigiDokoNoInput_Click);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(4, 484);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(179, 13);
            this.label10.TabIndex = 62;
            this.label10.Text = "日付項目でCtrl+D　→　本日の日付";
            // 
            // FesSongWithDiscSearch
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 505);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.grpSearchingCondition);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnVideoCodeInput);
            this.Controls.Add(this.btnKaraokeNoInput);
            this.Controls.Add(this.btnDigiDokoNoInput);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FesSongWithDiscSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DISC搭載曲管理　検索条件";
            this.grpSearchingCondition.ResumeLayout(false);
            this.grpSearchingCondition.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevComponents.DotNetBar.ButtonX btnDigiDokoNoInput;
        private DevComponents.DotNetBar.ButtonX btnKaraokeNoInput;
        private DevComponents.DotNetBar.ButtonX btnVideoCodeInput;
        private System.Windows.Forms.Label lblデジドコNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblカラオケNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblFes_DISCID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbl取消日;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblFes_アップ予定日;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDigiDocoNoFrom;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboRegisteredCondition;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radExclude;
        private System.Windows.Forms.RadioButton radPartialMatch;
        private System.Windows.Forms.RadioButton radFrontMatch;
        private System.Windows.Forms.RadioButton radMatchingAll;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClear;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDigiDocoNoTo;
        private System.Windows.Forms.GroupBox grpSearchingCondition;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSingerNameKana;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSingerName;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSongNameTitleKanaCorrection;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSongNamKana;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSongName;
        private DevComponents.DotNetBar.Controls.TextBoxX txtKaraokeNoTo;
        private DevComponents.DotNetBar.Controls.TextBoxX txtKaraokeNoFrom;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFes_DISCIDTo;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFes_DISCIDFrom;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboUsAgeFlag;
        private System.Windows.Forms.Label lblFes_NET利用フラグ;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblOrch_制作完了日;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblFes_サービス発表日;
        private DevComponents.DotNetBar.Controls.MaskedTextBoxAdv dtProductionDateTo;
        private DevComponents.DotNetBar.Controls.MaskedTextBoxAdv dtServiceDateTo;
        private DevComponents.DotNetBar.Controls.MaskedTextBoxAdv dtScheduleUpdateDateTo;
        private DevComponents.DotNetBar.Controls.MaskedTextBoxAdv dtCancelDateTo;
        private DevComponents.DotNetBar.Controls.MaskedTextBoxAdv dtProductionDateFrom;
        private DevComponents.DotNetBar.Controls.MaskedTextBoxAdv dtServiceDateFrom;
        private DevComponents.DotNetBar.Controls.MaskedTextBoxAdv dtScheduleUpdateDateFrom;
        private DevComponents.DotNetBar.Controls.MaskedTextBoxAdv dtCancelDateFrom;
        private System.Windows.Forms.Label label10;
    }
}