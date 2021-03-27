namespace Festival.Common
{
    partial class FesDisplayCommonMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FesDisplayCommonMain));
            this.ribbonControl1 = new DevComponents.DotNetBar.RibbonControl();
            this.panelMainMenu = new DevComponents.DotNetBar.RibbonPanel();
            this.ribCommand = new DevComponents.DotNetBar.RibbonBar();
            this.btnExportFile = new DevComponents.DotNetBar.ButtonItem();
            this.ribFilter = new DevComponents.DotNetBar.RibbonBar();
            this.btnCreateFilter = new DevComponents.DotNetBar.ButtonItem();
            this.btnApplyFilter = new DevComponents.DotNetBar.ButtonItem();
            this.btnUnFilter = new DevComponents.DotNetBar.ButtonItem();
            this.ribSort = new DevComponents.DotNetBar.RibbonBar();
            this.btnAtoZ = new DevComponents.DotNetBar.ButtonItem();
            this.btnZToA = new DevComponents.DotNetBar.ButtonItem();
            this.btnDeleteSort = new DevComponents.DotNetBar.ButtonItem();
            this.ribFormat = new DevComponents.DotNetBar.RibbonBar();
            this.btnFreeze = new DevComponents.DotNetBar.ButtonItem();
            this.btnUnfreeze = new DevComponents.DotNetBar.ButtonItem();
            this.btnColumDisplayAgain = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonBar = new DevComponents.DotNetBar.RibbonBar();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnCut = new DevComponents.DotNetBar.ButtonItem();
            this.btnCopy = new DevComponents.DotNetBar.ButtonItem();
            this.btnPaste = new DevComponents.DotNetBar.ButtonItem();
            this.applicationButton1 = new DevComponents.DotNetBar.ApplicationButton();
            this.ribTabTitle = new DevComponents.DotNetBar.RibbonTabItem();
            this.ribbonTabItemGroup1 = new DevComponents.DotNetBar.RibbonTabItemGroup();
            this.metroStatusBar1 = new DevComponents.DotNetBar.Metro.MetroStatusBar();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.panelMain = new System.Windows.Forms.Panel();
            this.ribbonControl1.SuspendLayout();
            this.panelMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.ribbonControl1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonControl1.CaptionVisible = true;
            this.ribbonControl1.Controls.Add(this.panelMainMenu);
            this.ribbonControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbonControl1.ForeColor = System.Drawing.Color.Black;
            this.ribbonControl1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.applicationButton1,
            this.ribTabTitle});
            this.ribbonControl1.Location = new System.Drawing.Point(5, 1);
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Size = new System.Drawing.Size(902, 164);
            this.ribbonControl1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonControl1.SystemText.MaximizeRibbonText = "";
            this.ribbonControl1.SystemText.MinimizeRibbonText = "";
            this.ribbonControl1.SystemText.QatAddItemText = "";
            this.ribbonControl1.SystemText.QatCustomizeMenuLabel = "";
            this.ribbonControl1.SystemText.QatCustomizeText = "";
            this.ribbonControl1.SystemText.QatDialogAddButton = "";
            this.ribbonControl1.SystemText.QatDialogCancelButton = "";
            this.ribbonControl1.SystemText.QatDialogCaption = "";
            this.ribbonControl1.SystemText.QatDialogCategoriesLabel = "";
            this.ribbonControl1.SystemText.QatDialogOkButton = "";
            this.ribbonControl1.SystemText.QatDialogPlacementCheckbox = "";
            this.ribbonControl1.SystemText.QatDialogRemoveButton = "";
            this.ribbonControl1.SystemText.QatPlaceAboveRibbonText = "";
            this.ribbonControl1.SystemText.QatPlaceBelowRibbonText = "";
            this.ribbonControl1.SystemText.QatRemoveItemText = "";
            this.ribbonControl1.TabGroupHeight = 14;
            this.ribbonControl1.TabGroups.AddRange(new DevComponents.DotNetBar.RibbonTabItemGroup[] {
            this.ribbonTabItemGroup1});
            this.ribbonControl1.TabIndex = 0;
            this.ribbonControl1.Text = "フィルタ";
            // 
            // panelMainMenu
            // 
            this.panelMainMenu.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelMainMenu.Controls.Add(this.ribCommand);
            this.panelMainMenu.Controls.Add(this.ribFilter);
            this.panelMainMenu.Controls.Add(this.ribSort);
            this.panelMainMenu.Controls.Add(this.ribFormat);
            this.panelMainMenu.Controls.Add(this.ribbonBar);
            this.panelMainMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainMenu.Location = new System.Drawing.Point(0, 62);
            this.panelMainMenu.Name = "panelMainMenu";
            this.panelMainMenu.Padding = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.panelMainMenu.Size = new System.Drawing.Size(902, 102);
            // 
            // 
            // 
            this.panelMainMenu.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.panelMainMenu.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.panelMainMenu.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.panelMainMenu.TabIndex = 2;
            // 
            // ribCommand
            // 
            this.ribCommand.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribCommand.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribCommand.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribCommand.ContainerControlProcessDialogKey = true;
            this.ribCommand.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribCommand.DragDropSupport = true;
            this.ribCommand.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnExportFile});
            this.ribCommand.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.ribCommand.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribCommand.Location = new System.Drawing.Point(359, 0);
            this.ribCommand.Name = "ribCommand";
            this.ribCommand.Size = new System.Drawing.Size(79, 100);
            this.ribCommand.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribCommand.TabIndex = 4;
            this.ribCommand.Text = "コマンド";
            // 
            // 
            // 
            this.ribCommand.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribCommand.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btnExportFile
            // 
            this.btnExportFile.Name = "btnExportFile";
            this.btnExportFile.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlShiftE);
            this.btnExportFile.SubItemsExpandWidth = 14;
            this.btnExportFile.Text = "ファイル出力";
            this.btnExportFile.Tooltip = "Ctrl+Shift+E";
            this.btnExportFile.Click += new System.EventHandler(this.btnExportFile_Click);
            // 
            // ribFilter
            // 
            this.ribFilter.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribFilter.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribFilter.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribFilter.ContainerControlProcessDialogKey = true;
            this.ribFilter.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribFilter.DragDropSupport = true;
            this.ribFilter.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnCreateFilter,
            this.btnApplyFilter,
            this.btnUnFilter});
            this.ribFilter.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.ribFilter.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribFilter.Location = new System.Drawing.Point(265, 0);
            this.ribFilter.Name = "ribFilter";
            this.ribFilter.OverflowButtonText = "フィルタ";
            this.ribFilter.Size = new System.Drawing.Size(94, 100);
            this.ribFilter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribFilter.TabIndex = 3;
            this.ribFilter.Text = "フィルタ";
            // 
            // 
            // 
            this.ribFilter.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribFilter.TitleStyle.UseMnemonic = true;
            // 
            // 
            // 
            this.ribFilter.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribFilter.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle;
            // 
            // btnCreateFilter
            // 
            this.btnCreateFilter.Name = "btnCreateFilter";
            this.btnCreateFilter.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlShiftF);
            this.btnCreateFilter.SubItemsExpandWidth = 14;
            this.btnCreateFilter.Text = "フィルタ";
            this.btnCreateFilter.Tooltip = "Ctrl+Shift+F";
            this.btnCreateFilter.Click += new System.EventHandler(this.btnCreateFilter_Click);
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlShiftA);
            this.btnApplyFilter.SubItemsExpandWidth = 14;
            this.btnApplyFilter.Text = "フィルタの適用";
            this.btnApplyFilter.Tooltip = "Ctrl+Shift+A";
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            // 
            // btnUnFilter
            // 
            this.btnUnFilter.Name = "btnUnFilter";
            this.btnUnFilter.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlShiftU);
            this.btnUnFilter.SubItemsExpandWidth = 14;
            this.btnUnFilter.Text = "フィルタの解除";
            this.btnUnFilter.Tooltip = "Ctrl+Shift+U";
            this.btnUnFilter.Click += new System.EventHandler(this.btnUnFilter_Click);
            // 
            // ribSort
            // 
            this.ribSort.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribSort.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribSort.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribSort.ContainerControlProcessDialogKey = true;
            this.ribSort.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribSort.DragDropSupport = true;
            this.ribSort.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnAtoZ,
            this.btnZToA,
            this.btnDeleteSort});
            this.ribSort.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.ribSort.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribSort.Location = new System.Drawing.Point(170, 0);
            this.ribSort.Name = "ribSort";
            this.ribSort.Size = new System.Drawing.Size(95, 100);
            this.ribSort.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribSort.TabIndex = 2;
            this.ribSort.Text = "ソート";
            // 
            // 
            // 
            this.ribSort.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribSort.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btnAtoZ
            // 
            this.btnAtoZ.Name = "btnAtoZ";
            this.btnAtoZ.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.AltUp);
            this.btnAtoZ.SubItemsExpandWidth = 14;
            this.btnAtoZ.Text = "昇順で並べ替え";
            this.btnAtoZ.Tooltip = "(A->Z) Alt+UP";
            this.btnAtoZ.Click += new System.EventHandler(this.btnAtoZ_Click);
            // 
            // btnZToA
            // 
            this.btnZToA.Name = "btnZToA";
            this.btnZToA.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.AltDown);
            this.btnZToA.SubItemsExpandWidth = 14;
            this.btnZToA.Text = "降順で並べ替え";
            this.btnZToA.Tooltip = "(Z->A) Alt+Down";
            this.btnZToA.Click += new System.EventHandler(this.btnZtoA_Click);
            // 
            // btnDeleteSort
            // 
            this.btnDeleteSort.Name = "btnDeleteSort";
            this.btnDeleteSort.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.ShiftAltD);
            this.btnDeleteSort.SubItemsExpandWidth = 14;
            this.btnDeleteSort.Text = "並べ替えの解除";
            this.btnDeleteSort.Tooltip = "Shift+Alt+D";
            this.btnDeleteSort.Click += new System.EventHandler(this.btnDeleteSort_Click);
            // 
            // ribFormat
            // 
            this.ribFormat.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribFormat.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribFormat.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribFormat.ContainerControlProcessDialogKey = true;
            this.ribFormat.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribFormat.DragDropSupport = true;
            this.ribFormat.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnFreeze,
            this.btnUnfreeze,
            this.btnColumDisplayAgain});
            this.ribFormat.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.ribFormat.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribFormat.Location = new System.Drawing.Point(76, 0);
            this.ribFormat.Name = "ribFormat";
            this.ribFormat.Size = new System.Drawing.Size(94, 100);
            this.ribFormat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribFormat.TabIndex = 1;
            this.ribFormat.Text = "書式";
            // 
            // 
            // 
            this.ribFormat.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribFormat.TitleStyle.HideMnemonic = true;
            // 
            // 
            // 
            this.ribFormat.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btnFreeze
            // 
            this.btnFreeze.Name = "btnFreeze";
            this.btnFreeze.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlF);
            this.btnFreeze.SubItemsExpandWidth = 14;
            this.btnFreeze.Text = "列の固定";
            this.btnFreeze.Tooltip = "Ctrl+F";
            this.btnFreeze.Click += new System.EventHandler(this.btnFreeze_Click);
            // 
            // btnUnfreeze
            // 
            this.btnUnfreeze.Name = "btnUnfreeze";
            this.btnUnfreeze.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlU);
            this.btnUnfreeze.SubItemsExpandWidth = 14;
            this.btnUnfreeze.Text = "列固定の解除";
            this.btnUnfreeze.Tooltip = "Ctrl+U";
            this.btnUnfreeze.Click += new System.EventHandler(this.btnUnfreeze_Click);
            // 
            // btnColumDisplayAgain
            // 
            this.btnColumDisplayAgain.Name = "btnColumDisplayAgain";
            this.btnColumDisplayAgain.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlD);
            this.btnColumDisplayAgain.SubItemsExpandWidth = 14;
            this.btnColumDisplayAgain.Text = "列の再表示";
            this.btnColumDisplayAgain.Tooltip = "Ctrl+D";
            this.btnColumDisplayAgain.Click += new System.EventHandler(this.btnColumDisplayAgain_Click);
            // 
            // ribbonBar
            // 
            this.ribbonBar.AutoOverflowEnabled = true;
            this.ribbonBar.AutoSizeIncludesTitle = true;
            // 
            // 
            // 
            this.ribbonBar.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar.ContainerControlProcessDialogKey = true;
            this.ribbonBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar.DragDropSupport = true;
            this.ribbonBar.Images = this.imageList1;
            this.ribbonBar.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnCut,
            this.btnCopy,
            this.btnPaste});
            this.ribbonBar.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.ribbonBar.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar.Location = new System.Drawing.Point(3, 0);
            this.ribbonBar.Name = "ribbonBar";
            this.ribbonBar.OverflowButtonText = "編集";
            this.ribbonBar.ResizeItemsToFit = false;
            this.ribbonBar.Size = new System.Drawing.Size(73, 100);
            this.ribbonBar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar.TabIndex = 0;
            this.ribbonBar.Text = "編集";
            // 
            // 
            // 
            this.ribbonBar.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Copy.png");
            this.imageList1.Images.SetKeyName(1, "Cut.png");
            this.imageList1.Images.SetKeyName(2, "Paste.png");
            // 
            // btnCut
            // 
            this.btnCut.Name = "btnCut";
            this.btnCut.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlX);
            this.btnCut.SubItemsExpandWidth = 14;
            this.btnCut.Text = "切り取り";
            this.btnCut.Tooltip = "Ctrl+X";
            this.btnCut.Click += new System.EventHandler(this.btnCut_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlC);
            this.btnCopy.SubItemsExpandWidth = 14;
            this.btnCopy.Text = "コピー";
            this.btnCopy.Tooltip = "Ctrl+C";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnPaste
            // 
            this.btnPaste.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlP);
            this.btnPaste.SubItemsExpandWidth = 14;
            this.btnPaste.Text = "貼り付け";
            this.btnPaste.Tooltip = "Ctrl+P";
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // applicationButton1
            // 
            this.applicationButton1.BackstageTabEnabled = false;
            this.applicationButton1.CanCustomize = false;
            this.applicationButton1.FixedSize = new System.Drawing.Size(32, 32);
            this.applicationButton1.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Image;
            this.applicationButton1.Image = ((System.Drawing.Image)(resources.GetObject("applicationButton1.Image")));
            this.applicationButton1.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.applicationButton1.ImagePaddingHorizontal = 0;
            this.applicationButton1.ImagePaddingVertical = 1;
            this.applicationButton1.Name = "applicationButton1";
            this.applicationButton1.ShowSubItems = false;
            // 
            // ribTabTitle
            // 
            this.ribTabTitle.Checked = true;
            this.ribTabTitle.Name = "ribTabTitle";
            this.ribTabTitle.Panel = this.panelMainMenu;
            this.ribTabTitle.Text = "Wii Custom Ribbon";
            // 
            // ribbonTabItemGroup1
            // 
            this.ribbonTabItemGroup1.GroupTitle = "New Group";
            this.ribbonTabItemGroup1.Name = "ribbonTabItemGroup1";
            // 
            // 
            // 
            this.ribbonTabItemGroup1.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(109)))), ((int)(((byte)(148)))));
            this.ribbonTabItemGroup1.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(72)))), ((int)(((byte)(123)))));
            this.ribbonTabItemGroup1.Style.BackColorGradientAngle = 90;
            this.ribbonTabItemGroup1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ribbonTabItemGroup1.Style.BorderBottomWidth = 1;
            this.ribbonTabItemGroup1.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(58)))), ((int)(((byte)(59)))));
            this.ribbonTabItemGroup1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ribbonTabItemGroup1.Style.BorderLeftWidth = 1;
            this.ribbonTabItemGroup1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ribbonTabItemGroup1.Style.BorderRightWidth = 1;
            this.ribbonTabItemGroup1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ribbonTabItemGroup1.Style.BorderTopWidth = 1;
            this.ribbonTabItemGroup1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonTabItemGroup1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.ribbonTabItemGroup1.Style.TextColor = System.Drawing.Color.White;
            this.ribbonTabItemGroup1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.ribbonTabItemGroup1.Style.TextShadowColor = System.Drawing.Color.Black;
            this.ribbonTabItemGroup1.Style.TextShadowOffset = new System.Drawing.Point(1, 1);
            // 
            // metroStatusBar1
            // 
            // 
            // 
            // 
            this.metroStatusBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroStatusBar1.ContainerControlProcessDialogKey = true;
            this.metroStatusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroStatusBar1.DragDropSupport = true;
            this.metroStatusBar1.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroStatusBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem1});
            this.metroStatusBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.metroStatusBar1.Location = new System.Drawing.Point(5, 525);
            this.metroStatusBar1.Name = "metroStatusBar1";
            this.metroStatusBar1.Size = new System.Drawing.Size(902, 22);
            this.metroStatusBar1.TabIndex = 2;
            this.metroStatusBar1.Text = "Ready";
            // 
            // labelItem1
            // 
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Text = "Ready";
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2016;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199))))));
            // 
            // panelMain
            // 
            this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMain.Location = new System.Drawing.Point(5, 169);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(902, 354);
            this.panelMain.TabIndex = 1;
            // 
            // FesDisplayCommonMain
            // 
            this.ClientSize = new System.Drawing.Size(912, 549);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.metroStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FesDisplayCommonMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Wii ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WiiCommon_FormClosing);
            this.Load += new System.EventHandler(this.WiiCommon_Load);
            this.ribbonControl1.ResumeLayout(false);
            this.ribbonControl1.PerformLayout();
            this.panelMainMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.RibbonControl ribbonControl1;
        private DevComponents.DotNetBar.ApplicationButton applicationButton1;
        private DevComponents.DotNetBar.Metro.MetroStatusBar metroStatusBar1;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.RibbonTabItemGroup ribbonTabItemGroup1;
        private DevComponents.DotNetBar.RibbonPanel panelMainMenu;
        private DevComponents.DotNetBar.RibbonBar ribCommand;
        private DevComponents.DotNetBar.ButtonItem btnExportFile;
        private DevComponents.DotNetBar.RibbonBar ribFilter;
        private DevComponents.DotNetBar.ButtonItem btnCreateFilter;
        private DevComponents.DotNetBar.ButtonItem btnApplyFilter;
        private DevComponents.DotNetBar.ButtonItem btnUnFilter;
        private DevComponents.DotNetBar.RibbonBar ribSort;
        private DevComponents.DotNetBar.ButtonItem btnAtoZ;
        private DevComponents.DotNetBar.ButtonItem btnZToA;
        private DevComponents.DotNetBar.ButtonItem btnDeleteSort;
        private DevComponents.DotNetBar.RibbonBar ribFormat;
        private DevComponents.DotNetBar.ButtonItem btnFreeze;
        private DevComponents.DotNetBar.ButtonItem btnUnfreeze;
        private DevComponents.DotNetBar.ButtonItem btnColumDisplayAgain;
        private DevComponents.DotNetBar.RibbonBar ribbonBar;
        private DevComponents.DotNetBar.ButtonItem btnCut;
        private DevComponents.DotNetBar.ButtonItem btnCopy;
        private DevComponents.DotNetBar.RibbonTabItem ribTabTitle;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private System.Windows.Forms.Panel panelMain;
        private DevComponents.DotNetBar.ButtonItem btnPaste;
        private System.Windows.Forms.ImageList imageList1;
    }
}