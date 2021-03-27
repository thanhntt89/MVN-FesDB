namespace Festival.DBTab.SingerIdChangeManagement
{
    partial class SingerIdChangeRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SingerIdChangeRegister));
            this.btnClearn = new DevComponents.DotNetBar.ButtonX();
            this.btnAddNew = new DevComponents.DotNetBar.ButtonX();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dt変更日時 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.txt変更利用者ID = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt変更後_歌手名ソート用カナ = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt変更後_歌手名検索用カナ = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt変更後_歌手名 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt変更後_歌手ID = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt変更前_歌手名ソート用カナ = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt変更前_歌手名検索用カナ = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt変更前_歌手名 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt変更前_歌手ID = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lbl変更利用者ID = new System.Windows.Forms.Label();
            this.lbl変更日時 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl変更前_歌手ID = new System.Windows.Forms.Label();
            this.lbl変更後_歌手ID = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt変更日時)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClearn
            // 
            this.btnClearn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClearn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClearn.Location = new System.Drawing.Point(443, 348);
            this.btnClearn.Name = "btnClearn";
            this.btnClearn.Size = new System.Drawing.Size(75, 23);
            this.btnClearn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClearn.TabIndex = 11;
            this.btnClearn.Text = "削除(&C)";
            this.btnClearn.Click += new System.EventHandler(this.btnClearn_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNew.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddNew.Location = new System.Drawing.Point(362, 348);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(75, 23);
            this.btnAddNew.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddNew.TabIndex = 10;
            this.btnAddNew.Text = "保存(&S)";
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Location = new System.Drawing.Point(524, 348);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "閉じる(&E)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.dt変更日時);
            this.groupBox1.Controls.Add(this.txt変更利用者ID);
            this.groupBox1.Controls.Add(this.txt変更後_歌手名ソート用カナ);
            this.groupBox1.Controls.Add(this.txt変更後_歌手名検索用カナ);
            this.groupBox1.Controls.Add(this.txt変更後_歌手名);
            this.groupBox1.Controls.Add(this.txt変更後_歌手ID);
            this.groupBox1.Controls.Add(this.txt変更前_歌手名ソート用カナ);
            this.groupBox1.Controls.Add(this.txt変更前_歌手名検索用カナ);
            this.groupBox1.Controls.Add(this.txt変更前_歌手名);
            this.groupBox1.Controls.Add(this.txt変更前_歌手ID);
            this.groupBox1.Controls.Add(this.lbl変更利用者ID);
            this.groupBox1.Controls.Add(this.lbl変更日時);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lbl変更前_歌手ID);
            this.groupBox1.Controls.Add(this.lbl変更後_歌手ID);
            this.groupBox1.Location = new System.Drawing.Point(2, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(597, 337);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(148, 274);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(11, 13);
            this.label14.TabIndex = 10;
            this.label14.Text = "*";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(148, 309);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(11, 13);
            this.label13.TabIndex = 10;
            this.label13.Text = "*";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(148, 144);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(11, 13);
            this.label12.TabIndex = 10;
            this.label12.Text = "*";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(148, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "*";
            // 
            // dt変更日時
            // 
            // 
            // 
            // 
            this.dt変更日時.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dt変更日時.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dt変更日時.ButtonClear.Text = "X";
            this.dt変更日時.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dt変更日時.ButtonDropDown.Visible = true;
            this.dt変更日時.CustomFormat = "yyyy/MM/dd";
            this.dt変更日時.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dt変更日時.IsPopupCalendarOpen = false;
            this.dt変更日時.Location = new System.Drawing.Point(171, 269);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dt変更日時.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dt変更日時.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dt変更日時.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dt変更日時.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dt変更日時.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dt変更日時.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dt変更日時.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dt変更日時.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dt変更日時.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dt変更日時.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dt変更日時.MonthCalendar.DisplayMonth = new System.DateTime(2020, 8, 1, 0, 0, 0, 0);
            this.dt変更日時.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.dt変更日時.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dt変更日時.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dt変更日時.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dt変更日時.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dt変更日時.MonthCalendar.TodayButtonVisible = true;
            this.dt変更日時.Name = "dt変更日時";
            this.dt変更日時.Size = new System.Drawing.Size(411, 20);
            this.dt変更日時.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dt変更日時.TabIndex = 8;
            // 
            // txt変更利用者ID
            // 
            this.txt変更利用者ID.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt変更利用者ID.Border.Class = "TextBoxBorder";
            this.txt変更利用者ID.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt変更利用者ID.DisabledBackColor = System.Drawing.Color.White;
            this.txt変更利用者ID.ForeColor = System.Drawing.Color.Black;
            this.txt変更利用者ID.Location = new System.Drawing.Point(171, 302);
            this.txt変更利用者ID.MaxLength = 50;
            this.txt変更利用者ID.Name = "txt変更利用者ID";
            this.txt変更利用者ID.PreventEnterBeep = true;
            this.txt変更利用者ID.Size = new System.Drawing.Size(411, 20);
            this.txt変更利用者ID.TabIndex = 9;
            // 
            // txt変更後_歌手名ソート用カナ
            // 
            this.txt変更後_歌手名ソート用カナ.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt変更後_歌手名ソート用カナ.Border.Class = "TextBoxBorder";
            this.txt変更後_歌手名ソート用カナ.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt変更後_歌手名ソート用カナ.DisabledBackColor = System.Drawing.Color.White;
            this.txt変更後_歌手名ソート用カナ.ForeColor = System.Drawing.Color.Black;
            this.txt変更後_歌手名ソート用カナ.Location = new System.Drawing.Point(171, 238);
            this.txt変更後_歌手名ソート用カナ.MaxLength = 255;
            this.txt変更後_歌手名ソート用カナ.Name = "txt変更後_歌手名ソート用カナ";
            this.txt変更後_歌手名ソート用カナ.PreventEnterBeep = true;
            this.txt変更後_歌手名ソート用カナ.Size = new System.Drawing.Size(411, 20);
            this.txt変更後_歌手名ソート用カナ.TabIndex = 7;
            // 
            // txt変更後_歌手名検索用カナ
            // 
            this.txt変更後_歌手名検索用カナ.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt変更後_歌手名検索用カナ.Border.Class = "TextBoxBorder";
            this.txt変更後_歌手名検索用カナ.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt変更後_歌手名検索用カナ.DisabledBackColor = System.Drawing.Color.White;
            this.txt変更後_歌手名検索用カナ.ForeColor = System.Drawing.Color.Black;
            this.txt変更後_歌手名検索用カナ.Location = new System.Drawing.Point(171, 206);
            this.txt変更後_歌手名検索用カナ.MaxLength = 255;
            this.txt変更後_歌手名検索用カナ.Name = "txt変更後_歌手名検索用カナ";
            this.txt変更後_歌手名検索用カナ.PreventEnterBeep = true;
            this.txt変更後_歌手名検索用カナ.Size = new System.Drawing.Size(411, 20);
            this.txt変更後_歌手名検索用カナ.TabIndex = 6;
            // 
            // txt変更後_歌手名
            // 
            this.txt変更後_歌手名.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt変更後_歌手名.Border.Class = "TextBoxBorder";
            this.txt変更後_歌手名.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt変更後_歌手名.DisabledBackColor = System.Drawing.Color.White;
            this.txt変更後_歌手名.ForeColor = System.Drawing.Color.Black;
            this.txt変更後_歌手名.Location = new System.Drawing.Point(171, 174);
            this.txt変更後_歌手名.MaxLength = 255;
            this.txt変更後_歌手名.Name = "txt変更後_歌手名";
            this.txt変更後_歌手名.PreventEnterBeep = true;
            this.txt変更後_歌手名.Size = new System.Drawing.Size(411, 20);
            this.txt変更後_歌手名.TabIndex = 5;
            // 
            // txt変更後_歌手ID
            // 
            this.txt変更後_歌手ID.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt変更後_歌手ID.Border.Class = "TextBoxBorder";
            this.txt変更後_歌手ID.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt変更後_歌手ID.DisabledBackColor = System.Drawing.Color.White;
            this.txt変更後_歌手ID.ForeColor = System.Drawing.Color.Black;
            this.txt変更後_歌手ID.Location = new System.Drawing.Point(171, 142);
            this.txt変更後_歌手ID.MaxLength = 8;
            this.txt変更後_歌手ID.Name = "txt変更後_歌手ID";
            this.txt変更後_歌手ID.PreventEnterBeep = true;
            this.txt変更後_歌手ID.Size = new System.Drawing.Size(411, 20);
            this.txt変更後_歌手ID.TabIndex = 4;
            this.txt変更後_歌手ID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtInputText_KeyPress);
            // 
            // txt変更前_歌手名ソート用カナ
            // 
            this.txt変更前_歌手名ソート用カナ.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt変更前_歌手名ソート用カナ.Border.Class = "TextBoxBorder";
            this.txt変更前_歌手名ソート用カナ.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt変更前_歌手名ソート用カナ.DisabledBackColor = System.Drawing.Color.White;
            this.txt変更前_歌手名ソート用カナ.ForeColor = System.Drawing.Color.Black;
            this.txt変更前_歌手名ソート用カナ.Location = new System.Drawing.Point(171, 110);
            this.txt変更前_歌手名ソート用カナ.MaxLength = 255;
            this.txt変更前_歌手名ソート用カナ.Name = "txt変更前_歌手名ソート用カナ";
            this.txt変更前_歌手名ソート用カナ.PreventEnterBeep = true;
            this.txt変更前_歌手名ソート用カナ.Size = new System.Drawing.Size(411, 20);
            this.txt変更前_歌手名ソート用カナ.TabIndex = 3;
            // 
            // txt変更前_歌手名検索用カナ
            // 
            this.txt変更前_歌手名検索用カナ.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt変更前_歌手名検索用カナ.Border.Class = "TextBoxBorder";
            this.txt変更前_歌手名検索用カナ.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt変更前_歌手名検索用カナ.DisabledBackColor = System.Drawing.Color.White;
            this.txt変更前_歌手名検索用カナ.ForeColor = System.Drawing.Color.Black;
            this.txt変更前_歌手名検索用カナ.Location = new System.Drawing.Point(171, 78);
            this.txt変更前_歌手名検索用カナ.MaxLength = 255;
            this.txt変更前_歌手名検索用カナ.Name = "txt変更前_歌手名検索用カナ";
            this.txt変更前_歌手名検索用カナ.PreventEnterBeep = true;
            this.txt変更前_歌手名検索用カナ.Size = new System.Drawing.Size(411, 20);
            this.txt変更前_歌手名検索用カナ.TabIndex = 2;
            // 
            // txt変更前_歌手名
            // 
            this.txt変更前_歌手名.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt変更前_歌手名.Border.Class = "TextBoxBorder";
            this.txt変更前_歌手名.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt変更前_歌手名.DisabledBackColor = System.Drawing.Color.White;
            this.txt変更前_歌手名.ForeColor = System.Drawing.Color.Black;
            this.txt変更前_歌手名.Location = new System.Drawing.Point(171, 46);
            this.txt変更前_歌手名.MaxLength = 255;
            this.txt変更前_歌手名.Name = "txt変更前_歌手名";
            this.txt変更前_歌手名.PreventEnterBeep = true;
            this.txt変更前_歌手名.Size = new System.Drawing.Size(411, 20);
            this.txt変更前_歌手名.TabIndex = 1;
            // 
            // txt変更前_歌手ID
            // 
            this.txt変更前_歌手ID.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt変更前_歌手ID.Border.Class = "TextBoxBorder";
            this.txt変更前_歌手ID.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt変更前_歌手ID.DisabledBackColor = System.Drawing.Color.White;
            this.txt変更前_歌手ID.ForeColor = System.Drawing.Color.Black;
            this.txt変更前_歌手ID.Location = new System.Drawing.Point(171, 14);
            this.txt変更前_歌手ID.MaxLength = 8;
            this.txt変更前_歌手ID.Name = "txt変更前_歌手ID";
            this.txt変更前_歌手ID.PreventEnterBeep = true;
            this.txt変更前_歌手ID.Size = new System.Drawing.Size(411, 20);
            this.txt変更前_歌手ID.TabIndex = 0;
            this.txt変更前_歌手ID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtInputText_KeyPress);
            // 
            // lbl変更利用者ID
            // 
            this.lbl変更利用者ID.AutoSize = true;
            this.lbl変更利用者ID.Location = new System.Drawing.Point(10, 306);
            this.lbl変更利用者ID.Name = "lbl変更利用者ID";
            this.lbl変更利用者ID.Size = new System.Drawing.Size(78, 13);
            this.lbl変更利用者ID.TabIndex = 0;
            this.lbl変更利用者ID.Text = "変更利用者ID";
            // 
            // lbl変更日時
            // 
            this.lbl変更日時.AutoSize = true;
            this.lbl変更日時.Location = new System.Drawing.Point(10, 274);
            this.lbl変更日時.Name = "lbl変更日時";
            this.lbl変更日時.Size = new System.Drawing.Size(55, 13);
            this.lbl変更日時.TabIndex = 0;
            this.lbl変更日時.Text = "変更日時";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 242);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "変更後_歌手名ソート用カナ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "変更後_歌手名検索用カナ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "変更後_歌手名";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "変更前_歌手名ソート用カナ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "変更前_歌手名検索用カナ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "変更前_歌手名";
            // 
            // lbl変更前_歌手ID
            // 
            this.lbl変更前_歌手ID.AutoSize = true;
            this.lbl変更前_歌手ID.Location = new System.Drawing.Point(10, 18);
            this.lbl変更前_歌手ID.Name = "lbl変更前_歌手ID";
            this.lbl変更前_歌手ID.Size = new System.Drawing.Size(84, 13);
            this.lbl変更前_歌手ID.TabIndex = 0;
            this.lbl変更前_歌手ID.Text = "変更前_歌手ID";
            // 
            // lbl変更後_歌手ID
            // 
            this.lbl変更後_歌手ID.AutoSize = true;
            this.lbl変更後_歌手ID.Location = new System.Drawing.Point(10, 146);
            this.lbl変更後_歌手ID.Name = "lbl変更後_歌手ID";
            this.lbl変更後_歌手ID.Size = new System.Drawing.Size(84, 13);
            this.lbl変更後_歌手ID.TabIndex = 0;
            this.lbl変更後_歌手ID.Text = "変更後_歌手ID";
            // 
            // SingerIdChangeRegister
            // 
            this.AcceptButton = this.btnAddNew;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 371);
            this.Controls.Add(this.btnClearn);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SingerIdChangeRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "歌手を新規に登録する";
            this.Load += new System.EventHandler(this.SingerRegister_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt変更日時)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.ButtonX btnAddNew;
        private DevComponents.DotNetBar.ButtonX btnClearn;
        private System.Windows.Forms.Label lbl変更利用者ID;
        private System.Windows.Forms.Label lbl変更日時;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl変更前_歌手ID;
        private System.Windows.Forms.Label lbl変更後_歌手ID;
        private DevComponents.DotNetBar.Controls.TextBoxX txt変更利用者ID;
        private DevComponents.DotNetBar.Controls.TextBoxX txt変更後_歌手名ソート用カナ;
        private DevComponents.DotNetBar.Controls.TextBoxX txt変更後_歌手名検索用カナ;
        private DevComponents.DotNetBar.Controls.TextBoxX txt変更後_歌手名;
        private DevComponents.DotNetBar.Controls.TextBoxX txt変更後_歌手ID;
        private DevComponents.DotNetBar.Controls.TextBoxX txt変更前_歌手名ソート用カナ;
        private DevComponents.DotNetBar.Controls.TextBoxX txt変更前_歌手名検索用カナ;
        private DevComponents.DotNetBar.Controls.TextBoxX txt変更前_歌手名;
        private DevComponents.DotNetBar.Controls.TextBoxX txt変更前_歌手ID;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dt変更日時;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
    }
}