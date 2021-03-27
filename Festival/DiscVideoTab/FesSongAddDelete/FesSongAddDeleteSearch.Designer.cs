namespace Festival.DiscVideoTab.FesSongAddDelete
{
    partial class FesSongAddDeleteSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FesSongAddDeleteSearch));
            this.btnSearch = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.grpSearchingCondition = new System.Windows.Forms.GroupBox();
            this.dtRegisterDateTo = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            this.dtRegisterDateFrom = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            this.txtデジドコNoTo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtカラオケNoTo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtデジドコNoFrom = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtカラオケNoFrom = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFes_DISCIDTo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label3 = new System.Windows.Forms.Label();
            this.lblデジドコNo = new System.Windows.Forms.Label();
            this.txtFes_DISCIDFrom = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblカラオケNo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFes_DISCID = new System.Windows.Forms.Label();
            this.chkIncludeInitData = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cbo追加削除区分 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cboRegisteredCondition = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lbl追加削除区分 = new System.Windows.Forms.Label();
            this.lbl登録済み条件 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lbl登録日 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnKaraokeNumberInput = new DevComponents.DotNetBar.ButtonX();
            this.btnInputFile = new DevComponents.DotNetBar.ButtonX();
            this.grpSearchingCondition.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.Location = new System.Drawing.Point(334, 251);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 23);
            this.btnSearch.TabIndex = 20;
            this.btnSearch.Text = "検索(F5)";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label10.ForeColor = System.Drawing.Color.Green;
            this.label10.Location = new System.Drawing.Point(4, 256);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(179, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "日付項目でCtrl+D　→　本日の日付";
            // 
            // grpSearchingCondition
            // 
            this.grpSearchingCondition.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSearchingCondition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grpSearchingCondition.Controls.Add(this.dtRegisterDateTo);
            this.grpSearchingCondition.Controls.Add(this.dtRegisterDateFrom);
            this.grpSearchingCondition.Controls.Add(this.txtデジドコNoTo);
            this.grpSearchingCondition.Controls.Add(this.txtカラオケNoTo);
            this.grpSearchingCondition.Controls.Add(this.txtデジドコNoFrom);
            this.grpSearchingCondition.Controls.Add(this.txtカラオケNoFrom);
            this.grpSearchingCondition.Controls.Add(this.label5);
            this.grpSearchingCondition.Controls.Add(this.txtFes_DISCIDTo);
            this.grpSearchingCondition.Controls.Add(this.label3);
            this.grpSearchingCondition.Controls.Add(this.lblデジドコNo);
            this.grpSearchingCondition.Controls.Add(this.txtFes_DISCIDFrom);
            this.grpSearchingCondition.Controls.Add(this.lblカラオケNo);
            this.grpSearchingCondition.Controls.Add(this.label2);
            this.grpSearchingCondition.Controls.Add(this.lblFes_DISCID);
            this.grpSearchingCondition.Controls.Add(this.chkIncludeInitData);
            this.grpSearchingCondition.Controls.Add(this.cbo追加削除区分);
            this.grpSearchingCondition.Controls.Add(this.cboRegisteredCondition);
            this.grpSearchingCondition.Controls.Add(this.lbl追加削除区分);
            this.grpSearchingCondition.Controls.Add(this.lbl登録済み条件);
            this.grpSearchingCondition.Controls.Add(this.label15);
            this.grpSearchingCondition.Controls.Add(this.lbl登録日);
            this.grpSearchingCondition.Controls.Add(this.label13);
            this.grpSearchingCondition.ForeColor = System.Drawing.Color.Black;
            this.grpSearchingCondition.Location = new System.Drawing.Point(7, 31);
            this.grpSearchingCondition.Name = "grpSearchingCondition";
            this.grpSearchingCondition.Size = new System.Drawing.Size(548, 212);
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
            this.dtRegisterDateTo.Location = new System.Drawing.Point(353, 122);
            this.dtRegisterDateTo.Mask = "0000/00/00";
            this.dtRegisterDateTo.Name = "dtRegisterDateTo";
            this.dtRegisterDateTo.Size = new System.Drawing.Size(184, 20);
            this.dtRegisterDateTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtRegisterDateTo.TabIndex = 11;
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
            this.dtRegisterDateFrom.Location = new System.Drawing.Point(127, 122);
            this.dtRegisterDateFrom.Mask = "0000/00/00";
            this.dtRegisterDateFrom.Name = "dtRegisterDateFrom";
            this.dtRegisterDateFrom.Size = new System.Drawing.Size(184, 20);
            this.dtRegisterDateFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtRegisterDateFrom.TabIndex = 10;
            this.dtRegisterDateFrom.Text = "";
            // 
            // txtデジドコNoTo
            // 
            this.txtデジドコNoTo.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtデジドコNoTo.Border.Class = "TextBoxBorder";
            this.txtデジドコNoTo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtデジドコNoTo.DisabledBackColor = System.Drawing.Color.White;
            this.txtデジドコNoTo.ForeColor = System.Drawing.Color.Black;
            this.txtデジドコNoTo.Location = new System.Drawing.Point(353, 15);
            this.txtデジドコNoTo.MaxLength = 8;
            this.txtデジドコNoTo.Name = "txtデジドコNoTo";
            this.txtデジドコNoTo.PreventEnterBeep = true;
            this.txtデジドコNoTo.Size = new System.Drawing.Size(184, 20);
            this.txtデジドコNoTo.TabIndex = 4;
            this.txtデジドコNoTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            this.txtデジドコNoTo.Leave += new System.EventHandler(this.OnLeave);
            // 
            // txtカラオケNoTo
            // 
            this.txtカラオケNoTo.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtカラオケNoTo.Border.Class = "TextBoxBorder";
            this.txtカラオケNoTo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtカラオケNoTo.DisabledBackColor = System.Drawing.Color.White;
            this.txtカラオケNoTo.ForeColor = System.Drawing.Color.Black;
            this.txtカラオケNoTo.Location = new System.Drawing.Point(353, 41);
            this.txtカラオケNoTo.MaxLength = 8;
            this.txtカラオケNoTo.Name = "txtカラオケNoTo";
            this.txtカラオケNoTo.PreventEnterBeep = true;
            this.txtカラオケNoTo.Size = new System.Drawing.Size(184, 20);
            this.txtカラオケNoTo.TabIndex = 6;
            this.txtカラオケNoTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            this.txtカラオケNoTo.Leave += new System.EventHandler(this.OnLeave);
            // 
            // txtデジドコNoFrom
            // 
            this.txtデジドコNoFrom.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtデジドコNoFrom.Border.Class = "TextBoxBorder";
            this.txtデジドコNoFrom.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtデジドコNoFrom.DisabledBackColor = System.Drawing.Color.White;
            this.txtデジドコNoFrom.ForeColor = System.Drawing.Color.Black;
            this.txtデジドコNoFrom.Location = new System.Drawing.Point(127, 15);
            this.txtデジドコNoFrom.MaxLength = 8;
            this.txtデジドコNoFrom.Name = "txtデジドコNoFrom";
            this.txtデジドコNoFrom.PreventEnterBeep = true;
            this.txtデジドコNoFrom.Size = new System.Drawing.Size(184, 20);
            this.txtデジドコNoFrom.TabIndex = 3;
            this.txtデジドコNoFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            this.txtデジドコNoFrom.Leave += new System.EventHandler(this.OnLeave);
            // 
            // txtカラオケNoFrom
            // 
            this.txtカラオケNoFrom.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtカラオケNoFrom.Border.Class = "TextBoxBorder";
            this.txtカラオケNoFrom.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtカラオケNoFrom.DisabledBackColor = System.Drawing.Color.White;
            this.txtカラオケNoFrom.ForeColor = System.Drawing.Color.Black;
            this.txtカラオケNoFrom.Location = new System.Drawing.Point(127, 41);
            this.txtカラオケNoFrom.MaxLength = 8;
            this.txtカラオケNoFrom.Name = "txtカラオケNoFrom";
            this.txtカラオケNoFrom.PreventEnterBeep = true;
            this.txtカラオケNoFrom.Size = new System.Drawing.Size(184, 20);
            this.txtカラオケNoFrom.TabIndex = 5;
            this.txtカラオケNoFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            this.txtカラオケNoFrom.Leave += new System.EventHandler(this.OnLeave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(325, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 50;
            this.label5.Text = "~";
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
            this.txtFes_DISCIDTo.Location = new System.Drawing.Point(353, 96);
            this.txtFes_DISCIDTo.MaxLength = 8;
            this.txtFes_DISCIDTo.Name = "txtFes_DISCIDTo";
            this.txtFes_DISCIDTo.PreventEnterBeep = true;
            this.txtFes_DISCIDTo.Size = new System.Drawing.Size(184, 20);
            this.txtFes_DISCIDTo.TabIndex = 9;
            this.txtFes_DISCIDTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            this.txtFes_DISCIDTo.Leave += new System.EventHandler(this.OnLeave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(325, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 50;
            this.label3.Text = "~";
            // 
            // lblデジドコNo
            // 
            this.lblデジドコNo.AutoSize = true;
            this.lblデジドコNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblデジドコNo.ForeColor = System.Drawing.Color.Black;
            this.lblデジドコNo.Location = new System.Drawing.Point(5, 19);
            this.lblデジドコNo.Name = "lblデジドコNo";
            this.lblデジドコNo.Size = new System.Drawing.Size(58, 13);
            this.lblデジドコNo.TabIndex = 51;
            this.lblデジドコNo.Text = "デジドコNo";
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
            this.txtFes_DISCIDFrom.Location = new System.Drawing.Point(127, 96);
            this.txtFes_DISCIDFrom.MaxLength = 8;
            this.txtFes_DISCIDFrom.Name = "txtFes_DISCIDFrom";
            this.txtFes_DISCIDFrom.PreventEnterBeep = true;
            this.txtFes_DISCIDFrom.Size = new System.Drawing.Size(184, 20);
            this.txtFes_DISCIDFrom.TabIndex = 8;
            this.txtFes_DISCIDFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            this.txtFes_DISCIDFrom.Leave += new System.EventHandler(this.OnLeave);
            // 
            // lblカラオケNo
            // 
            this.lblカラオケNo.AutoSize = true;
            this.lblカラオケNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblカラオケNo.ForeColor = System.Drawing.Color.Black;
            this.lblカラオケNo.Location = new System.Drawing.Point(5, 45);
            this.lblカラオケNo.Name = "lblカラオケNo";
            this.lblカラオケNo.Size = new System.Drawing.Size(56, 13);
            this.lblカラオケNo.TabIndex = 51;
            this.lblカラオケNo.Text = "カラオケNo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(325, 100);
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
            this.lblFes_DISCID.Location = new System.Drawing.Point(5, 100);
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
            this.chkIncludeInitData.Location = new System.Drawing.Point(127, 147);
            this.chkIncludeInitData.Name = "chkIncludeInitData";
            this.chkIncludeInitData.Size = new System.Drawing.Size(410, 23);
            this.chkIncludeInitData.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkIncludeInitData.TabIndex = 12;
            this.chkIncludeInitData.Text = "初動データを含む";
            // 
            // cbo追加削除区分
            // 
            this.cbo追加削除区分.DisplayMember = "Text";
            this.cbo追加削除区分.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo追加削除区分.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo追加削除区分.ForeColor = System.Drawing.Color.Black;
            this.cbo追加削除区分.FormattingEnabled = true;
            this.cbo追加削除区分.ItemHeight = 15;
            this.cbo追加削除区分.Location = new System.Drawing.Point(127, 67);
            this.cbo追加削除区分.Name = "cbo追加削除区分";
            this.cbo追加削除区分.Size = new System.Drawing.Size(410, 21);
            this.cbo追加削除区分.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbo追加削除区分.TabIndex = 7;
            // 
            // cboRegisteredCondition
            // 
            this.cboRegisteredCondition.DisplayMember = "Text";
            this.cboRegisteredCondition.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboRegisteredCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRegisteredCondition.ForeColor = System.Drawing.Color.Black;
            this.cboRegisteredCondition.FormattingEnabled = true;
            this.cboRegisteredCondition.ItemHeight = 15;
            this.cboRegisteredCondition.Location = new System.Drawing.Point(127, 175);
            this.cboRegisteredCondition.Name = "cboRegisteredCondition";
            this.cboRegisteredCondition.Size = new System.Drawing.Size(410, 21);
            this.cboRegisteredCondition.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboRegisteredCondition.TabIndex = 13;
            // 
            // lbl追加削除区分
            // 
            this.lbl追加削除区分.AutoSize = true;
            this.lbl追加削除区分.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbl追加削除区分.ForeColor = System.Drawing.Color.Black;
            this.lbl追加削除区分.Location = new System.Drawing.Point(5, 71);
            this.lbl追加削除区分.Name = "lbl追加削除区分";
            this.lbl追加削除区分.Size = new System.Drawing.Size(79, 13);
            this.lbl追加削除区分.TabIndex = 1;
            this.lbl追加削除区分.Text = "追加削除区分";
            // 
            // lbl登録済み条件
            // 
            this.lbl登録済み条件.AutoSize = true;
            this.lbl登録済み条件.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbl登録済み条件.ForeColor = System.Drawing.Color.Black;
            this.lbl登録済み条件.Location = new System.Drawing.Point(5, 179);
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
            this.label15.Location = new System.Drawing.Point(325, 127);
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
            this.lbl登録日.Location = new System.Drawing.Point(5, 127);
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
            this.label13.Location = new System.Drawing.Point(325, 98);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(14, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "~";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(455, 251);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 23);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "閉じる";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Location = new System.Drawing.Point(213, 251);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 23);
            this.btnClear.TabIndex = 19;
            this.btnClear.Text = "クリア(Alt+C)";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnKaraokeNumberInput
            // 
            this.btnKaraokeNumberInput.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnKaraokeNumberInput.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnKaraokeNumberInput.Location = new System.Drawing.Point(148, 6);
            this.btnKaraokeNumberInput.Name = "btnKaraokeNumberInput";
            this.btnKaraokeNumberInput.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.ShiftF12);
            this.btnKaraokeNumberInput.Size = new System.Drawing.Size(136, 23);
            this.btnKaraokeNumberInput.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnKaraokeNumberInput.TabIndex = 1;
            this.btnKaraokeNumberInput.Text = "カラオケNo入力(Shift+F12)";
            this.btnKaraokeNumberInput.Tooltip = "Shift+F12";
            this.btnKaraokeNumberInput.Click += new System.EventHandler(this.btnKaraokeNumberInput_Click);
            // 
            // btnInputFile
            // 
            this.btnInputFile.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnInputFile.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnInputFile.Location = new System.Drawing.Point(7, 6);
            this.btnInputFile.Name = "btnInputFile";
            this.btnInputFile.Size = new System.Drawing.Size(135, 23);
            this.btnInputFile.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnInputFile.TabIndex = 0;
            this.btnInputFile.Text = "デジドコNo入力(F12)";
            this.btnInputFile.Click += new System.EventHandler(this.btnInputFile_Click);
            // 
            // FesSongAddDeleteSearch
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 274);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.grpSearchingCondition);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnKaraokeNumberInput);
            this.Controls.Add(this.btnInputFile);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FesSongAddDeleteSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DISC搭載曲管理　検索条件";
            this.grpSearchingCondition.ResumeLayout(false);
            this.grpSearchingCondition.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lbl登録日;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lbl登録済み条件;
        private System.Windows.Forms.Label lbl追加削除区分;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboRegisteredCondition;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbo追加削除区分;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkIncludeInitData;
        private System.Windows.Forms.Label lblFes_DISCID;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFes_DISCIDFrom;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFes_DISCIDTo;
        private System.Windows.Forms.GroupBox grpSearchingCondition;
        private DevComponents.DotNetBar.ButtonX btnInputFile;
        private DevComponents.DotNetBar.ButtonX btnKaraokeNumberInput;
        private DevComponents.DotNetBar.Controls.TextBoxX txtデジドコNoTo;
        private DevComponents.DotNetBar.Controls.TextBoxX txtカラオケNoTo;
        private DevComponents.DotNetBar.Controls.TextBoxX txtデジドコNoFrom;
        private DevComponents.DotNetBar.Controls.TextBoxX txtカラオケNoFrom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblデジドコNo;
        private System.Windows.Forms.Label lblカラオケNo;
        private DevComponents.DotNetBar.Controls.MaskedTextBoxAdv dtRegisterDateTo;
        private DevComponents.DotNetBar.Controls.MaskedTextBoxAdv dtRegisterDateFrom;
        private System.Windows.Forms.Label label10;
    }
}