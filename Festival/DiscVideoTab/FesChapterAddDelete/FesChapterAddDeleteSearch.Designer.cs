namespace Festival.DiscVideoTab.FesChapterAddDelete
{
    partial class FesChapterAddDeleteSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FesChapterAddDeleteSearch));
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.grpSearchingCondition = new System.Windows.Forms.GroupBox();
            this.dt登録日To = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            this.dt登録日From = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            this.txt選曲番号To = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtカラオケ選曲番号To = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt選曲番号From = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtカラオケ選曲番号From = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cbo登録済み条件 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFes_DISCIDTo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label3 = new System.Windows.Forms.Label();
            this.lblデジドコNo = new System.Windows.Forms.Label();
            this.txtFes_DISCIDFrom = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblカラオケNo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFes_DISCID = new System.Windows.Forms.Label();
            this.chk未出力フラグ = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cbo追加削除区分 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cboチャプターフラグ = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lbl追加削除区分 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl登録済み条件 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lbl登録日 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btn選曲番号入力カラオケ = new DevComponents.DotNetBar.ButtonX();
            this.btn選曲番号入力 = new DevComponents.DotNetBar.ButtonX();
            this.label10 = new System.Windows.Forms.Label();
            this.grpSearchingCondition.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.Location = new System.Drawing.Point(334, 279);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 23);
            this.btnSearch.TabIndex = 16;
            this.btnSearch.Text = "検索(F5)";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(455, 279);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 23);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "閉じる";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Location = new System.Drawing.Point(213, 279);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 23);
            this.btnClear.TabIndex = 15;
            this.btnClear.Text = "クリア(Alt+C)";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // grpSearchingCondition
            // 
            this.grpSearchingCondition.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSearchingCondition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grpSearchingCondition.Controls.Add(this.dt登録日To);
            this.grpSearchingCondition.Controls.Add(this.dt登録日From);
            this.grpSearchingCondition.Controls.Add(this.txt選曲番号To);
            this.grpSearchingCondition.Controls.Add(this.txtカラオケ選曲番号To);
            this.grpSearchingCondition.Controls.Add(this.txt選曲番号From);
            this.grpSearchingCondition.Controls.Add(this.txtカラオケ選曲番号From);
            this.grpSearchingCondition.Controls.Add(this.cbo登録済み条件);
            this.grpSearchingCondition.Controls.Add(this.label5);
            this.grpSearchingCondition.Controls.Add(this.txtFes_DISCIDTo);
            this.grpSearchingCondition.Controls.Add(this.label3);
            this.grpSearchingCondition.Controls.Add(this.lblデジドコNo);
            this.grpSearchingCondition.Controls.Add(this.txtFes_DISCIDFrom);
            this.grpSearchingCondition.Controls.Add(this.lblカラオケNo);
            this.grpSearchingCondition.Controls.Add(this.label2);
            this.grpSearchingCondition.Controls.Add(this.lblFes_DISCID);
            this.grpSearchingCondition.Controls.Add(this.chk未出力フラグ);
            this.grpSearchingCondition.Controls.Add(this.cbo追加削除区分);
            this.grpSearchingCondition.Controls.Add(this.cboチャプターフラグ);
            this.grpSearchingCondition.Controls.Add(this.lbl追加削除区分);
            this.grpSearchingCondition.Controls.Add(this.label1);
            this.grpSearchingCondition.Controls.Add(this.lbl登録済み条件);
            this.grpSearchingCondition.Controls.Add(this.label15);
            this.grpSearchingCondition.Controls.Add(this.lbl登録日);
            this.grpSearchingCondition.Controls.Add(this.label13);
            this.grpSearchingCondition.ForeColor = System.Drawing.Color.Black;
            this.grpSearchingCondition.Location = new System.Drawing.Point(12, 37);
            this.grpSearchingCondition.Name = "grpSearchingCondition";
            this.grpSearchingCondition.Size = new System.Drawing.Size(543, 236);
            this.grpSearchingCondition.TabIndex = 2;
            this.grpSearchingCondition.TabStop = false;
            // 
            // dt登録日To
            // 
            this.dt登録日To.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.dt登録日To.BackgroundStyle.Class = "TextBoxBorder";
            this.dt登録日To.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dt登録日To.ButtonClear.Text = "X";
            this.dt登録日To.ButtonClear.Visible = true;
            this.dt登録日To.Culture = new System.Globalization.CultureInfo("ja-JP");
            this.dt登録日To.Location = new System.Drawing.Point(350, 122);
            this.dt登録日To.Mask = "0000/00/00";
            this.dt登録日To.Name = "dt登録日To";
            this.dt登録日To.Size = new System.Drawing.Size(184, 20);
            this.dt登録日To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dt登録日To.TabIndex = 61;
            this.dt登録日To.Text = "";
            // 
            // dt登録日From
            // 
            this.dt登録日From.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.dt登録日From.BackgroundStyle.Class = "TextBoxBorder";
            this.dt登録日From.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dt登録日From.ButtonClear.Text = "X";
            this.dt登録日From.ButtonClear.Visible = true;
            this.dt登録日From.Culture = new System.Globalization.CultureInfo("ja-JP");
            this.dt登録日From.Location = new System.Drawing.Point(124, 122);
            this.dt登録日From.Mask = "0000/00/00";
            this.dt登録日From.Name = "dt登録日From";
            this.dt登録日From.Size = new System.Drawing.Size(184, 20);
            this.dt登録日From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dt登録日From.TabIndex = 60;
            this.dt登録日From.Text = "";
            // 
            // txt選曲番号To
            // 
            this.txt選曲番号To.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt選曲番号To.Border.Class = "TextBoxBorder";
            this.txt選曲番号To.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt選曲番号To.DisabledBackColor = System.Drawing.Color.White;
            this.txt選曲番号To.ForeColor = System.Drawing.Color.Black;
            this.txt選曲番号To.Location = new System.Drawing.Point(350, 15);
            this.txt選曲番号To.MaxLength = 8;
            this.txt選曲番号To.Name = "txt選曲番号To";
            this.txt選曲番号To.PreventEnterBeep = true;
            this.txt選曲番号To.Size = new System.Drawing.Size(184, 20);
            this.txt選曲番号To.TabIndex = 4;
            this.txt選曲番号To.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            this.txt選曲番号To.Leave += new System.EventHandler(this.OnLeave);
            // 
            // txtカラオケ選曲番号To
            // 
            this.txtカラオケ選曲番号To.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtカラオケ選曲番号To.Border.Class = "TextBoxBorder";
            this.txtカラオケ選曲番号To.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtカラオケ選曲番号To.DisabledBackColor = System.Drawing.Color.White;
            this.txtカラオケ選曲番号To.ForeColor = System.Drawing.Color.Black;
            this.txtカラオケ選曲番号To.Location = new System.Drawing.Point(350, 41);
            this.txtカラオケ選曲番号To.MaxLength = 8;
            this.txtカラオケ選曲番号To.Name = "txtカラオケ選曲番号To";
            this.txtカラオケ選曲番号To.PreventEnterBeep = true;
            this.txtカラオケ選曲番号To.Size = new System.Drawing.Size(184, 20);
            this.txtカラオケ選曲番号To.TabIndex = 6;
            this.txtカラオケ選曲番号To.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            this.txtカラオケ選曲番号To.Leave += new System.EventHandler(this.OnLeave);
            // 
            // txt選曲番号From
            // 
            this.txt選曲番号From.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt選曲番号From.Border.Class = "TextBoxBorder";
            this.txt選曲番号From.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt選曲番号From.DisabledBackColor = System.Drawing.Color.White;
            this.txt選曲番号From.ForeColor = System.Drawing.Color.Black;
            this.txt選曲番号From.Location = new System.Drawing.Point(124, 15);
            this.txt選曲番号From.MaxLength = 8;
            this.txt選曲番号From.Name = "txt選曲番号From";
            this.txt選曲番号From.PreventEnterBeep = true;
            this.txt選曲番号From.Size = new System.Drawing.Size(184, 20);
            this.txt選曲番号From.TabIndex = 3;
            this.txt選曲番号From.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            this.txt選曲番号From.Leave += new System.EventHandler(this.OnLeave);
            // 
            // txtカラオケ選曲番号From
            // 
            this.txtカラオケ選曲番号From.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtカラオケ選曲番号From.Border.Class = "TextBoxBorder";
            this.txtカラオケ選曲番号From.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtカラオケ選曲番号From.DisabledBackColor = System.Drawing.Color.White;
            this.txtカラオケ選曲番号From.ForeColor = System.Drawing.Color.Black;
            this.txtカラオケ選曲番号From.Location = new System.Drawing.Point(124, 41);
            this.txtカラオケ選曲番号From.MaxLength = 8;
            this.txtカラオケ選曲番号From.Name = "txtカラオケ選曲番号From";
            this.txtカラオケ選曲番号From.PreventEnterBeep = true;
            this.txtカラオケ選曲番号From.Size = new System.Drawing.Size(184, 20);
            this.txtカラオケ選曲番号From.TabIndex = 5;
            this.txtカラオケ選曲番号From.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            this.txtカラオケ選曲番号From.Leave += new System.EventHandler(this.OnLeave);
            // 
            // cbo登録済み条件
            // 
            this.cbo登録済み条件.DisplayMember = "Text";
            this.cbo登録済み条件.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo登録済み条件.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo登録済み条件.ForeColor = System.Drawing.Color.Black;
            this.cbo登録済み条件.FormattingEnabled = true;
            this.cbo登録済み条件.ItemHeight = 15;
            this.cbo登録済み条件.Location = new System.Drawing.Point(124, 205);
            this.cbo登録済み条件.Name = "cbo登録済み条件";
            this.cbo登録済み条件.Size = new System.Drawing.Size(410, 21);
            this.cbo登録済み条件.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbo登録済み条件.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(322, 19);
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
            this.txtFes_DISCIDTo.Location = new System.Drawing.Point(350, 96);
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
            this.label3.Location = new System.Drawing.Point(322, 45);
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
            this.txtFes_DISCIDFrom.Location = new System.Drawing.Point(124, 96);
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
            this.label2.Location = new System.Drawing.Point(322, 100);
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
            // chk未出力フラグ
            // 
            this.chk未出力フラグ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.chk未出力フラグ.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk未出力フラグ.ForeColor = System.Drawing.Color.Black;
            this.chk未出力フラグ.Location = new System.Drawing.Point(124, 176);
            this.chk未出力フラグ.Name = "chk未出力フラグ";
            this.chk未出力フラグ.Size = new System.Drawing.Size(410, 23);
            this.chk未出力フラグ.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk未出力フラグ.TabIndex = 13;
            this.chk未出力フラグ.Text = "初動データを含む";
            // 
            // cbo追加削除区分
            // 
            this.cbo追加削除区分.DisplayMember = "Text";
            this.cbo追加削除区分.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo追加削除区分.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo追加削除区分.ForeColor = System.Drawing.Color.Black;
            this.cbo追加削除区分.FormattingEnabled = true;
            this.cbo追加削除区分.ItemHeight = 15;
            this.cbo追加削除区分.Location = new System.Drawing.Point(124, 67);
            this.cbo追加削除区分.Name = "cbo追加削除区分";
            this.cbo追加削除区分.Size = new System.Drawing.Size(410, 21);
            this.cbo追加削除区分.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbo追加削除区分.TabIndex = 7;
            // 
            // cboチャプターフラグ
            // 
            this.cboチャプターフラグ.DisplayMember = "Text";
            this.cboチャプターフラグ.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboチャプターフラグ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboチャプターフラグ.ForeColor = System.Drawing.Color.Black;
            this.cboチャプターフラグ.FormattingEnabled = true;
            this.cboチャプターフラグ.ItemHeight = 15;
            this.cboチャプターフラグ.Location = new System.Drawing.Point(124, 149);
            this.cboチャプターフラグ.Name = "cboチャプターフラグ";
            this.cboチャプターフラグ.Size = new System.Drawing.Size(410, 21);
            this.cboチャプターフラグ.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboチャプターフラグ.TabIndex = 12;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "登録済み条件";
            // 
            // lbl登録済み条件
            // 
            this.lbl登録済み条件.AutoSize = true;
            this.lbl登録済み条件.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbl登録済み条件.ForeColor = System.Drawing.Color.Black;
            this.lbl登録済み条件.Location = new System.Drawing.Point(5, 153);
            this.lbl登録済み条件.Name = "lbl登録済み条件";
            this.lbl登録済み条件.Size = new System.Drawing.Size(99, 13);
            this.lbl登録済み条件.TabIndex = 1;
            this.lbl登録済み条件.Text = "Fes_チャプターフラグ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(322, 126);
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
            this.label13.Location = new System.Drawing.Point(322, 98);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(14, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "~";
            // 
            // btn選曲番号入力カラオケ
            // 
            this.btn選曲番号入力カラオケ.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn選曲番号入力カラオケ.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn選曲番号入力カラオケ.Location = new System.Drawing.Point(153, 12);
            this.btn選曲番号入力カラオケ.Name = "btn選曲番号入力カラオケ";
            this.btn選曲番号入力カラオケ.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.ShiftF12);
            this.btn選曲番号入力カラオケ.Size = new System.Drawing.Size(135, 23);
            this.btn選曲番号入力カラオケ.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn選曲番号入力カラオケ.TabIndex = 1;
            this.btn選曲番号入力カラオケ.Text = "カラオケNo入力(Shift+&F12)";
            this.btn選曲番号入力カラオケ.Tooltip = "Shift+F12";
            this.btn選曲番号入力カラオケ.Click += new System.EventHandler(this.btn選曲番号入力カラオケ_Click);
            // 
            // btn選曲番号入力
            // 
            this.btn選曲番号入力.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn選曲番号入力.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn選曲番号入力.Location = new System.Drawing.Point(12, 12);
            this.btn選曲番号入力.Name = "btn選曲番号入力";
            this.btn選曲番号入力.Size = new System.Drawing.Size(135, 23);
            this.btn選曲番号入力.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn選曲番号入力.TabIndex = 0;
            this.btn選曲番号入力.Text = "デジドコNo入力(&F12)";
            this.btn選曲番号入力.Click += new System.EventHandler(this.btnInputFile_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label10.ForeColor = System.Drawing.Color.Green;
            this.label10.Location = new System.Drawing.Point(12, 284);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(179, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "日付項目でCtrl+D　→　本日の日付";
            // 
            // FesChapterAddDeleteSearch
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 304);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.grpSearchingCondition);
            this.Controls.Add(this.btn選曲番号入力カラオケ);
            this.Controls.Add(this.btn選曲番号入力);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnClear);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FesChapterAddDeleteSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "チャプター管理　検索条件";
            this.grpSearchingCondition.ResumeLayout(false);
            this.grpSearchingCondition.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox grpSearchingCondition;
        private DevComponents.DotNetBar.Controls.TextBoxX txt選曲番号To;
        private DevComponents.DotNetBar.Controls.TextBoxX txtカラオケ選曲番号To;
        private DevComponents.DotNetBar.Controls.TextBoxX txt選曲番号From;
        private DevComponents.DotNetBar.Controls.TextBoxX txtカラオケ選曲番号From;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbo登録済み条件;
        private System.Windows.Forms.Label label5;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFes_DISCIDTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblデジドコNo;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFes_DISCIDFrom;
        private System.Windows.Forms.Label lblカラオケNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFes_DISCID;
        private DevComponents.DotNetBar.Controls.CheckBoxX chk未出力フラグ;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbo追加削除区分;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboチャプターフラグ;
        private System.Windows.Forms.Label lbl追加削除区分;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl登録済み条件;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lbl登録日;
        private System.Windows.Forms.Label label13;
        private DevComponents.DotNetBar.ButtonX btn選曲番号入力カラオケ;
        private DevComponents.DotNetBar.ButtonX btn選曲番号入力;
        private DevComponents.DotNetBar.Controls.MaskedTextBoxAdv dt登録日To;
        private DevComponents.DotNetBar.Controls.MaskedTextBoxAdv dt登録日From;
        private System.Windows.Forms.Label label10;
    }
}