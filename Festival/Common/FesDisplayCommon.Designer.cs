namespace Festival.Common
{
    partial class FesDisplayCommon
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
            this.dateInput = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.txtEditCell = new System.Windows.Forms.TextBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.lblColumnText = new System.Windows.Forms.Label();
            this.labelFunction = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.line1 = new DevComponents.DotNetBar.Controls.Line();
            this.btnSearchCondition = new DevComponents.DotNetBar.ButtonX();
            this.btnRowSelectUnselect = new DevComponents.DotNetBar.ButtonX();
            this.btnAllOn = new DevComponents.DotNetBar.ButtonX();
            this.btnAllOff = new DevComponents.DotNetBar.ButtonX();
            this.btnAllInPut = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnImportData = new DevComponents.DotNetBar.ButtonX();
            this.btnAddNew = new DevComponents.DotNetBar.ButtonX();
           
            ((System.ComponentModel.ISupportInitialize)(this.dateInput)).BeginInit();
            this.SuspendLayout();
            // 
            // dateInput
            // 
            // 
            // 
            // 
            this.dateInput.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateInput.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateInput.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateInput.CustomFormat = "yyyy/MM/dd";
            this.dateInput.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dateInput.IsPopupCalendarOpen = false;
            this.dateInput.Location = new System.Drawing.Point(605, 564);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dateInput.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateInput.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dateInput.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dateInput.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dateInput.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dateInput.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dateInput.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dateInput.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dateInput.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dateInput.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateInput.MonthCalendar.DisplayMonth = new System.DateTime(2020, 6, 1, 0, 0, 0, 0);
            this.dateInput.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.dateInput.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dateInput.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dateInput.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dateInput.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateInput.MonthCalendar.TodayButtonVisible = true;
            this.dateInput.Name = "dateInput";
            this.dateInput.Size = new System.Drawing.Size(200, 20);
            this.dateInput.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateInput.TabIndex = 9;
            this.dateInput.Visible = false;
            this.dateInput.Enter += new System.EventHandler(this.dateInput_Enter);
            // 
            // txtEditCell
            // 
            this.txtEditCell.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEditCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEditCell.Location = new System.Drawing.Point(3, 478);
            this.txtEditCell.Name = "txtEditCell";
            this.txtEditCell.Size = new System.Drawing.Size(892, 23);
            this.txtEditCell.TabIndex = 8;
            this.txtEditCell.Enter += new System.EventHandler(this.txtEditCell_Enter);
            this.txtEditCell.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEditCell_KeyDown);
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.ItemHeight = 13;
            this.cboStatus.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cboStatus.Location = new System.Drawing.Point(811, 563);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(177, 21);
            this.cboStatus.TabIndex = 10;
            this.cboStatus.Visible = false;
            // 
            // lblColumnText
            // 
            this.lblColumnText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblColumnText.AutoSize = true;
            this.lblColumnText.Location = new System.Drawing.Point(3, 461);
            this.lblColumnText.Name = "lblColumnText";
            this.lblColumnText.Size = new System.Drawing.Size(55, 13);
            this.lblColumnText.TabIndex = 31;
            this.lblColumnText.Text = "入力確定";
            // 
            // labelFunction
            // 
            this.labelFunction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelFunction.AutoSize = true;
            this.labelFunction.ForeColor = System.Drawing.Color.OliveDrab;
            this.labelFunction.Location = new System.Drawing.Point(197, 458);
            this.labelFunction.Name = "labelFunction";
            this.labelFunction.Size = new System.Drawing.Size(212, 13);
            this.labelFunction.TabIndex = 29;
            this.labelFunction.Text = "「Space」または 「F2」を押すとセル編集可能";
            // 
            // panelMain
            // 
            this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMain.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelMain.Location = new System.Drawing.Point(3, 65);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(892, 390);
            this.panelMain.TabIndex = 7;
            // 
            // line1
            // 
            this.line1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.line1.Location = new System.Drawing.Point(2, 25);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(893, 10);
            this.line1.TabIndex = 20;
            this.line1.Text = "line1";
            // 
            // btnSearchCondition
            // 
            this.btnSearchCondition.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearchCondition.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearchCondition.Location = new System.Drawing.Point(2, 3);
            this.btnSearchCondition.Name = "btnSearchCondition";
            this.btnSearchCondition.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5);
            this.btnSearchCondition.Size = new System.Drawing.Size(89, 23);
            this.btnSearchCondition.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSearchCondition.TabIndex = 0;
            this.btnSearchCondition.Text = "検索条件(&F5)";
            this.btnSearchCondition.Tooltip = "F5";
            this.btnSearchCondition.Click += new System.EventHandler(this.btnSearchCondition_Click);
            // 
            // btnRowSelectUnselect
            // 
            this.btnRowSelectUnselect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRowSelectUnselect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRowSelectUnselect.Location = new System.Drawing.Point(99, 3);
            this.btnRowSelectUnselect.Name = "btnRowSelectUnselect";
            this.btnRowSelectUnselect.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F10);
            this.btnRowSelectUnselect.Size = new System.Drawing.Size(116, 23);
            this.btnRowSelectUnselect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnRowSelectUnselect.TabIndex = 1;
            this.btnRowSelectUnselect.Text = "行選択/解除(&F10)";
            this.btnRowSelectUnselect.Tooltip = "F10";
            this.btnRowSelectUnselect.Click += new System.EventHandler(this.btnRowSelectUnselect_Click);
            // 
            // btnAllOn
            // 
            this.btnAllOn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAllOn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAllOn.Location = new System.Drawing.Point(221, 3);
            this.btnAllOn.Name = "btnAllOn";
            this.btnAllOn.Size = new System.Drawing.Size(89, 23);
            this.btnAllOn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAllOn.TabIndex = 2;
            this.btnAllOn.Text = "All On(&1)";
            this.btnAllOn.Tooltip = "Alt + 1";
            this.btnAllOn.Click += new System.EventHandler(this.btnAllOn_Click);
            // 
            // btnAllOff
            // 
            this.btnAllOff.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAllOff.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAllOff.Location = new System.Drawing.Point(316, 3);
            this.btnAllOff.Name = "btnAllOff";
            this.btnAllOff.Size = new System.Drawing.Size(89, 23);
            this.btnAllOff.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAllOff.TabIndex = 3;
            this.btnAllOff.Text = "All Off(&0)";
            this.btnAllOff.Tooltip = "Alt + 0";
            this.btnAllOff.Click += new System.EventHandler(this.btnAllOff_Click);
            // 
            // btnAllInPut
            // 
            this.btnAllInPut.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAllInPut.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAllInPut.Location = new System.Drawing.Point(411, 3);
            this.btnAllInPut.Name = "btnAllInPut";
            this.btnAllInPut.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F11);
            this.btnAllInPut.Size = new System.Drawing.Size(89, 23);
            this.btnAllInPut.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAllInPut.TabIndex = 4;
            this.btnAllInPut.Text = "一括入力(&F11)";
            this.btnAllInPut.Tooltip = "F11";
            this.btnAllInPut.Click += new System.EventHandler(this.btnAllInPut_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(806, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlS);
            this.btnSave.Size = new System.Drawing.Size(89, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "登録(&S)";
            this.btnSave.Tooltip = "Ctrl+S";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnImportData
            // 
            this.btnImportData.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnImportData.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnImportData.Location = new System.Drawing.Point(3, 36);
            this.btnImportData.Name = "btnImportData";
            this.btnImportData.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlShiftA);
            this.btnImportData.Size = new System.Drawing.Size(176, 23);
            this.btnImportData.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnImportData.TabIndex = 6;
            this.btnImportData.Text = "DISCID割付リスト取込(&A)";
            this.btnImportData.Tooltip = "Ctrl+Shift+A";
            this.btnImportData.Click += new System.EventHandler(this.btnImportData_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddNew.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddNew.Location = new System.Drawing.Point(185, 36);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlShiftN);
            this.btnAddNew.Size = new System.Drawing.Size(89, 23);
            this.btnAddNew.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddNew.TabIndex = 7;
            this.btnAddNew.Text = "新規追加(&N)";
            this.btnAddNew.Tooltip = "Ctrl+Shift+N";
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // FesDisplayCommon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.txtEditCell);
            this.Controls.Add(this.btnImportData);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.dateInput);
            this.Controls.Add(this.btnAllInPut);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAllOff);
            this.Controls.Add(this.lblColumnText);
            this.Controls.Add(this.btnAllOn);
            this.Controls.Add(this.labelFunction);
            this.Controls.Add(this.btnRowSelectUnselect);
            this.Controls.Add(this.btnSearchCondition);
            this.Controls.Add(this.line1);
            this.Name = "FesDisplayCommon";
            this.Size = new System.Drawing.Size(898, 503);
            this.Load += new System.EventHandler(this.UCSearchCommon_Load);
            
            ((System.ComponentModel.ISupportInitialize)(this.dateInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.Line line1;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.TextBox txtEditCell;
        private System.Windows.Forms.Label labelFunction;
        private System.Windows.Forms.Label lblColumnText;
        private System.Windows.Forms.ComboBox cboStatus;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateInput;
        private DevComponents.DotNetBar.ButtonX btnSearchCondition;
        private DevComponents.DotNetBar.ButtonX btnRowSelectUnselect;
        private DevComponents.DotNetBar.ButtonX btnAllOn;
        private DevComponents.DotNetBar.ButtonX btnAllOff;
        private DevComponents.DotNetBar.ButtonX btnAllInPut;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnImportData;
        private DevComponents.DotNetBar.ButtonX btnAddNew;
    }
}
