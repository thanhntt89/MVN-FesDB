namespace Festival.DiscVideoTab.FesVideoAddDelete
{
    partial class FesVideoAddDeleteSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FesVideoAddDeleteSearch));
            this.btnSearch = new System.Windows.Forms.Button();
            this.grpSearchingCondition = new System.Windows.Forms.GroupBox();
            this.dtRegisterDateTo = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            this.dtRegisterDateFrom = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            this.txtFes_DISCIDTo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtFes_DISCIDFrom = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFes_DISCID = new System.Windows.Forms.Label();
            this.chkIncludeInitData = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radExclude = new System.Windows.Forms.RadioButton();
            this.radPartialMatch = new System.Windows.Forms.RadioButton();
            this.radFrontMatch = new System.Windows.Forms.RadioButton();
            this.radMatchingAll = new System.Windows.Forms.RadioButton();
            this.cbo追加削除区分 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cboRegisteredCondition = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lbl追加削除区分 = new System.Windows.Forms.Label();
            this.txtFileName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lbl登録済み条件 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lbl登録日 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lbl背景ファイル名 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnInputFile = new DevComponents.DotNetBar.ButtonX();
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
            this.btnSearch.Location = new System.Drawing.Point(334, 290);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 23);
            this.btnSearch.TabIndex = 17;
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
            this.grpSearchingCondition.Controls.Add(this.dtRegisterDateTo);
            this.grpSearchingCondition.Controls.Add(this.dtRegisterDateFrom);
            this.grpSearchingCondition.Controls.Add(this.txtFes_DISCIDTo);
            this.grpSearchingCondition.Controls.Add(this.txtFes_DISCIDFrom);
            this.grpSearchingCondition.Controls.Add(this.label2);
            this.grpSearchingCondition.Controls.Add(this.lblFes_DISCID);
            this.grpSearchingCondition.Controls.Add(this.chkIncludeInitData);
            this.grpSearchingCondition.Controls.Add(this.groupBox1);
            this.grpSearchingCondition.Controls.Add(this.cbo追加削除区分);
            this.grpSearchingCondition.Controls.Add(this.cboRegisteredCondition);
            this.grpSearchingCondition.Controls.Add(this.lbl追加削除区分);
            this.grpSearchingCondition.Controls.Add(this.txtFileName);
            this.grpSearchingCondition.Controls.Add(this.lbl登録済み条件);
            this.grpSearchingCondition.Controls.Add(this.label15);
            this.grpSearchingCondition.Controls.Add(this.lbl登録日);
            this.grpSearchingCondition.Controls.Add(this.label13);
            this.grpSearchingCondition.Controls.Add(this.lbl背景ファイル名);
            this.grpSearchingCondition.ForeColor = System.Drawing.Color.Black;
            this.grpSearchingCondition.Location = new System.Drawing.Point(7, 31);
            this.grpSearchingCondition.Name = "grpSearchingCondition";
            this.grpSearchingCondition.Size = new System.Drawing.Size(548, 253);
            this.grpSearchingCondition.TabIndex = 2;
            this.grpSearchingCondition.TabStop = false;
            // 
            // dtRegisterDateTo
            // 
            this.dtRegisterDateTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtRegisterDateTo.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.dtRegisterDateTo.BackgroundStyle.Class = "TextBoxBorder";
            this.dtRegisterDateTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtRegisterDateTo.ButtonClear.Text = "X";
            this.dtRegisterDateTo.ButtonClear.Visible = true;
            this.dtRegisterDateTo.Culture = new System.Globalization.CultureInfo("ja-JP");
            this.dtRegisterDateTo.DisabledBackColor = System.Drawing.Color.White;
            this.dtRegisterDateTo.ForeColor = System.Drawing.Color.Black;
            this.dtRegisterDateTo.Location = new System.Drawing.Point(351, 101);
            this.dtRegisterDateTo.Mask = "0000/00/00";
            this.dtRegisterDateTo.Name = "dtRegisterDateTo";
            this.dtRegisterDateTo.Size = new System.Drawing.Size(184, 20);
            this.dtRegisterDateTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtRegisterDateTo.TabIndex = 8;
            this.dtRegisterDateTo.Text = "";
            // 
            // dtRegisterDateFrom
            // 
            this.dtRegisterDateFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtRegisterDateFrom.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.dtRegisterDateFrom.BackgroundStyle.Class = "TextBoxBorder";
            this.dtRegisterDateFrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtRegisterDateFrom.ButtonClear.Text = "X";
            this.dtRegisterDateFrom.ButtonClear.Visible = true;
            this.dtRegisterDateFrom.Culture = new System.Globalization.CultureInfo("ja-JP");
            this.dtRegisterDateFrom.DisabledBackColor = System.Drawing.Color.White;
            this.dtRegisterDateFrom.ForeColor = System.Drawing.Color.Black;
            this.dtRegisterDateFrom.Location = new System.Drawing.Point(125, 101);
            this.dtRegisterDateFrom.Mask = "0000/00/00";
            this.dtRegisterDateFrom.Name = "dtRegisterDateFrom";
            this.dtRegisterDateFrom.Size = new System.Drawing.Size(184, 20);
            this.dtRegisterDateFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtRegisterDateFrom.TabIndex = 7;
            this.dtRegisterDateFrom.Text = "";
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
            this.txtFes_DISCIDTo.Location = new System.Drawing.Point(351, 74);
            this.txtFes_DISCIDTo.MaxLength = 8;
            this.txtFes_DISCIDTo.Name = "txtFes_DISCIDTo";
            this.txtFes_DISCIDTo.PreventEnterBeep = true;
            this.txtFes_DISCIDTo.Size = new System.Drawing.Size(184, 20);
            this.txtFes_DISCIDTo.TabIndex = 6;
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
            this.txtFes_DISCIDFrom.Location = new System.Drawing.Point(125, 74);
            this.txtFes_DISCIDFrom.MaxLength = 8;
            this.txtFes_DISCIDFrom.Name = "txtFes_DISCIDFrom";
            this.txtFes_DISCIDFrom.PreventEnterBeep = true;
            this.txtFes_DISCIDFrom.Size = new System.Drawing.Size(184, 20);
            this.txtFes_DISCIDFrom.TabIndex = 5;
            this.txtFes_DISCIDFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            this.txtFes_DISCIDFrom.Leave += new System.EventHandler(this.OnLeave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(323, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 50;
            this.label2.Text = "~";
            // 
            // lblFes_DISCID
            // 
            this.lblFes_DISCID.AutoSize = true;
            this.lblFes_DISCID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblFes_DISCID.ForeColor = System.Drawing.Color.Black;
            this.lblFes_DISCID.Location = new System.Drawing.Point(3, 78);
            this.lblFes_DISCID.Name = "lblFes_DISCID";
            this.lblFes_DISCID.Size = new System.Drawing.Size(66, 13);
            this.lblFes_DISCID.TabIndex = 51;
            this.lblFes_DISCID.Text = "Fes_DISCID";
            // 
            // chkIncludeInitData
            // 
            this.chkIncludeInitData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.chkIncludeInitData.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkIncludeInitData.ForeColor = System.Drawing.Color.Black;
            this.chkIncludeInitData.Location = new System.Drawing.Point(125, 125);
            this.chkIncludeInitData.Name = "chkIncludeInitData";
            this.chkIncludeInitData.Size = new System.Drawing.Size(412, 23);
            this.chkIncludeInitData.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkIncludeInitData.TabIndex = 9;
            this.chkIncludeInitData.Text = "初動データを含む";
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
            this.groupBox1.Location = new System.Drawing.Point(127, 178);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 62);
            this.groupBox1.TabIndex = 11;
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
            this.radExclude.TabIndex = 15;
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
            this.radPartialMatch.TabIndex = 14;
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
            this.radFrontMatch.TabIndex = 13;
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
            this.radMatchingAll.TabIndex = 12;
            this.radMatchingAll.Text = "完全一致";
            this.radMatchingAll.UseVisualStyleBackColor = false;
            // 
            // cbo追加削除区分
            // 
            this.cbo追加削除区分.DisplayMember = "Text";
            this.cbo追加削除区分.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo追加削除区分.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo追加削除区分.ForeColor = System.Drawing.Color.Black;
            this.cbo追加削除区分.FormattingEnabled = true;
            this.cbo追加削除区分.ItemHeight = 15;
            this.cbo追加削除区分.Location = new System.Drawing.Point(125, 45);
            this.cbo追加削除区分.Name = "cbo追加削除区分";
            this.cbo追加削除区分.Size = new System.Drawing.Size(410, 21);
            this.cbo追加削除区分.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbo追加削除区分.TabIndex = 4;
            // 
            // cboRegisteredCondition
            // 
            this.cboRegisteredCondition.DisplayMember = "Text";
            this.cboRegisteredCondition.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboRegisteredCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRegisteredCondition.ForeColor = System.Drawing.Color.Black;
            this.cboRegisteredCondition.FormattingEnabled = true;
            this.cboRegisteredCondition.ItemHeight = 15;
            this.cboRegisteredCondition.Location = new System.Drawing.Point(125, 152);
            this.cboRegisteredCondition.Name = "cboRegisteredCondition";
            this.cboRegisteredCondition.Size = new System.Drawing.Size(410, 21);
            this.cboRegisteredCondition.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboRegisteredCondition.TabIndex = 10;
            // 
            // lbl追加削除区分
            // 
            this.lbl追加削除区分.AutoSize = true;
            this.lbl追加削除区分.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbl追加削除区分.ForeColor = System.Drawing.Color.Black;
            this.lbl追加削除区分.Location = new System.Drawing.Point(3, 49);
            this.lbl追加削除区分.Name = "lbl追加削除区分";
            this.lbl追加削除区分.Size = new System.Drawing.Size(79, 13);
            this.lbl追加削除区分.TabIndex = 1;
            this.lbl追加削除区分.Text = "追加削除区分";
            // 
            // txtFileName
            // 
            this.txtFileName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtFileName.Border.Class = "TextBoxBorder";
            this.txtFileName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFileName.DisabledBackColor = System.Drawing.Color.White;
            this.txtFileName.ForeColor = System.Drawing.Color.Black;
            this.txtFileName.Location = new System.Drawing.Point(125, 19);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.PreventEnterBeep = true;
            this.txtFileName.Size = new System.Drawing.Size(410, 20);
            this.txtFileName.TabIndex = 3;
            // 
            // lbl登録済み条件
            // 
            this.lbl登録済み条件.AutoSize = true;
            this.lbl登録済み条件.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbl登録済み条件.ForeColor = System.Drawing.Color.Black;
            this.lbl登録済み条件.Location = new System.Drawing.Point(3, 156);
            this.lbl登録済み条件.Name = "lbl登録済み条件";
            this.lbl登録済み条件.Size = new System.Drawing.Size(78, 13);
            this.lbl登録済み条件.TabIndex = 1;
            this.lbl登録済み条件.Text = "登録済み条件";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(323, 105);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(14, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "~";
            // 
            // lbl登録日
            // 
            this.lbl登録日.AutoSize = true;
            this.lbl登録日.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbl登録日.ForeColor = System.Drawing.Color.Black;
            this.lbl登録日.Location = new System.Drawing.Point(3, 105);
            this.lbl登録日.Name = "lbl登録日";
            this.lbl登録日.Size = new System.Drawing.Size(43, 13);
            this.lbl登録日.TabIndex = 1;
            this.lbl登録日.Text = "登録日";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(323, 76);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(14, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "~";
            // 
            // lbl背景ファイル名
            // 
            this.lbl背景ファイル名.AutoSize = true;
            this.lbl背景ファイル名.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbl背景ファイル名.ForeColor = System.Drawing.Color.Black;
            this.lbl背景ファイル名.Location = new System.Drawing.Point(5, 23);
            this.lbl背景ファイル名.Name = "lbl背景ファイル名";
            this.lbl背景ファイル名.Size = new System.Drawing.Size(77, 13);
            this.lbl背景ファイル名.TabIndex = 1;
            this.lbl背景ファイル名.Text = "背景ファイル名";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(455, 290);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 23);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "閉じる";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Location = new System.Drawing.Point(213, 290);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 23);
            this.btnClear.TabIndex = 16;
            this.btnClear.Text = "クリア(Alt+C)";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnInputFile
            // 
            this.btnInputFile.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnInputFile.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnInputFile.Location = new System.Drawing.Point(7, 6);
            this.btnInputFile.Name = "btnInputFile";
            this.btnInputFile.Size = new System.Drawing.Size(198, 23);
            this.btnInputFile.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnInputFile.TabIndex = 1;
            this.btnInputFile.Text = "背景ファイル名入力(F12)";
            this.btnInputFile.Click += new System.EventHandler(this.btnInputFile_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label10.ForeColor = System.Drawing.Color.Green;
            this.label10.Location = new System.Drawing.Point(4, 295);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(179, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "日付項目でCtrl+D　→　本日の日付";
            // 
            // FesVideoAddDeleteSearch
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 315);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.grpSearchingCondition);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnInputFile);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FesVideoAddDeleteSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "個別映像割付　検索条件";
            this.Load += new System.EventHandler(this.IndividualVideoDiscManagementSearch_Load);
            this.grpSearchingCondition.ResumeLayout(false);
            this.grpSearchingCondition.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lbl背景ファイル名;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lbl登録日;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lbl登録済み条件;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFileName;
        private System.Windows.Forms.Label lbl追加削除区分;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboRegisteredCondition;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbo追加削除区分;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radExclude;
        private System.Windows.Forms.RadioButton radPartialMatch;
        private System.Windows.Forms.RadioButton radFrontMatch;
        private System.Windows.Forms.RadioButton radMatchingAll;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkIncludeInitData;
        private System.Windows.Forms.Label lblFes_DISCID;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFes_DISCIDFrom;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFes_DISCIDTo;
        private System.Windows.Forms.GroupBox grpSearchingCondition;
        private DevComponents.DotNetBar.ButtonX btnInputFile;
        private DevComponents.DotNetBar.Controls.MaskedTextBoxAdv dtRegisterDateTo;
        private DevComponents.DotNetBar.Controls.MaskedTextBoxAdv dtRegisterDateFrom;
        private System.Windows.Forms.Label label10;
    }
}