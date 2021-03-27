namespace Festival
{
    partial class FestivalMain
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
            Festival.Base.MenuMainCollection menuMainCollection1 = new Festival.Base.MenuMainCollection();
            Festival.Base.MenuMainCollection menuMainCollection2 = new Festival.Base.MenuMainCollection();
            Festival.Base.MenuMainCollection menuMainCollection3 = new Festival.Base.MenuMainCollection();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FestivalMain));
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.lblCurrentVersion = new System.Windows.Forms.Label();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabDatabase = new System.Windows.Forms.TabPage();
            this.menuDataBaseTab = new Festival.DBTab.TabDatabase();
            this.tabDISCvideo = new System.Windows.Forms.TabPage();
            this.menuDisTab = new Festival.DiscVideoTab.TabDis();
            this.tabManagement = new System.Windows.Forms.TabPage();
            this.menuManagementTab = new Festival.ManagementTab.TabManagement();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelSqlChecking = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.tabMain.SuspendLayout();
            this.tabDatabase.SuspendLayout();
            this.tabDISCvideo.SuspendLayout();
            this.tabManagement.SuspendLayout();
            this.panelSqlChecking.SuspendLayout();
            this.SuspendLayout();
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2016;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199))))));
            // 
            // lblCurrentVersion
            // 
            this.lblCurrentVersion.AutoSize = true;
            this.lblCurrentVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblCurrentVersion.ForeColor = System.Drawing.Color.Black;
            this.lblCurrentVersion.Location = new System.Drawing.Point(2, 4);
            this.lblCurrentVersion.Name = "lblCurrentVersion";
            this.lblCurrentVersion.Size = new System.Drawing.Size(76, 13);
            this.lblCurrentVersion.TabIndex = 11;
            this.lblCurrentVersion.Text = "CurrentVersion";
            // 
            // tabMain
            // 
            this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMain.Controls.Add(this.tabDatabase);
            this.tabMain.Controls.Add(this.tabDISCvideo);
            this.tabMain.Controls.Add(this.tabManagement);
            this.tabMain.ForeColor = System.Drawing.Color.Black;
            this.tabMain.Location = new System.Drawing.Point(2, 20);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(723, 359);
            this.tabMain.TabIndex = 9;
            // 
            // tabDatabase
            // 
            this.tabDatabase.Controls.Add(this.menuDataBaseTab);
            this.tabDatabase.ForeColor = System.Drawing.Color.Black;
            this.tabDatabase.Location = new System.Drawing.Point(4, 22);
            this.tabDatabase.Name = "tabDatabase";
            this.tabDatabase.Padding = new System.Windows.Forms.Padding(3);
            this.tabDatabase.Size = new System.Drawing.Size(715, 333);
            this.tabDatabase.TabIndex = 0;
            this.tabDatabase.Text = "DB(S)";
            this.tabDatabase.UseVisualStyleBackColor = true;
            // 
            // menuDataBaseTab
            // 
            this.menuDataBaseTab.CancelClose = false;
            this.menuDataBaseTab.ColChoiseIndex = 0;
            this.menuDataBaseTab.ColDeletedIndex = 0;
            this.menuDataBaseTab.ColKeyIndex = 0;
            this.menuDataBaseTab.ColumnChoiseDataPropertyName = null;
            this.menuDataBaseTab.ColumnChoiseName = null;
            this.menuDataBaseTab.ColumnCollection = null;
            this.menuDataBaseTab.ColumnComboxChangeName = null;
            this.menuDataBaseTab.ColumnDeletedDataPropertyName = null;
            this.menuDataBaseTab.ColumnDeletedName = null;
            this.menuDataBaseTab.ColumnKeyDataPropertyName = null;
            this.menuDataBaseTab.ColumnKeyName = null;
            this.menuDataBaseTab.ColumnUpdateName = null;
            this.menuDataBaseTab.ColumnUpdateTimeDataPropertyName = null;
            this.menuDataBaseTab.ColumnUpdateTimeName = null;
            this.menuDataBaseTab.ColUpdatedIndex = 0;
            this.menuDataBaseTab.DataGridViewSource = null;
            this.menuDataBaseTab.DataSourceDisplay = null;
            this.menuDataBaseTab.DataTableSource = null;
            this.menuDataBaseTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuDataBaseTab.ForeColor = System.Drawing.Color.Black;
            this.menuDataBaseTab.IsFilterActive = false;
            this.menuDataBaseTab.Location = new System.Drawing.Point(3, 3);
            this.menuDataBaseTab.MainMenuEditModeCollection = menuMainCollection1;
            this.menuDataBaseTab.Margin = new System.Windows.Forms.Padding(4);
            this.menuDataBaseTab.Name = "menuDataBaseTab";
            this.menuDataBaseTab.SCREEN_TITLE = null;
            this.menuDataBaseTab.Size = new System.Drawing.Size(709, 327);
            this.menuDataBaseTab.TabIndex = 0;
            // 
            // tabDISCvideo
            // 
            this.tabDISCvideo.Controls.Add(this.menuDisTab);
            this.tabDISCvideo.ForeColor = System.Drawing.Color.Black;
            this.tabDISCvideo.Location = new System.Drawing.Point(4, 22);
            this.tabDISCvideo.Name = "tabDISCvideo";
            this.tabDISCvideo.Padding = new System.Windows.Forms.Padding(3);
            this.tabDISCvideo.Size = new System.Drawing.Size(715, 333);
            this.tabDISCvideo.TabIndex = 1;
            this.tabDISCvideo.Text = "DISC映像(U)";
            this.tabDISCvideo.UseVisualStyleBackColor = true;
            // 
            // menuDisTab
            // 
            this.menuDisTab.CancelClose = false;
            this.menuDisTab.ColChoiseIndex = 0;
            this.menuDisTab.ColDeletedIndex = 0;
            this.menuDisTab.ColKeyIndex = 0;
            this.menuDisTab.ColumnChoiseDataPropertyName = null;
            this.menuDisTab.ColumnChoiseName = null;
            this.menuDisTab.ColumnCollection = null;
            this.menuDisTab.ColumnComboxChangeName = null;
            this.menuDisTab.ColumnDeletedDataPropertyName = null;
            this.menuDisTab.ColumnDeletedName = null;
            this.menuDisTab.ColumnKeyDataPropertyName = null;
            this.menuDisTab.ColumnKeyName = null;
            this.menuDisTab.ColumnUpdateName = null;
            this.menuDisTab.ColumnUpdateTimeDataPropertyName = null;
            this.menuDisTab.ColumnUpdateTimeName = null;
            this.menuDisTab.ColUpdatedIndex = 0;
            this.menuDisTab.DataGridViewSource = null;
            this.menuDisTab.DataSourceDisplay = null;
            this.menuDisTab.DataTableSource = null;
            this.menuDisTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuDisTab.ForeColor = System.Drawing.Color.Black;
            this.menuDisTab.IsFilterActive = false;
            this.menuDisTab.Location = new System.Drawing.Point(3, 3);
            this.menuDisTab.MainMenuEditModeCollection = menuMainCollection2;
            this.menuDisTab.Margin = new System.Windows.Forms.Padding(4);
            this.menuDisTab.Name = "menuDisTab";
            this.menuDisTab.SCREEN_TITLE = null;
            this.menuDisTab.Size = new System.Drawing.Size(709, 327);
            this.menuDisTab.TabIndex = 0;
            // 
            // tabManagement
            // 
            this.tabManagement.Controls.Add(this.menuManagementTab);
            this.tabManagement.ForeColor = System.Drawing.Color.Black;
            this.tabManagement.Location = new System.Drawing.Point(4, 22);
            this.tabManagement.Name = "tabManagement";
            this.tabManagement.Padding = new System.Windows.Forms.Padding(3);
            this.tabManagement.Size = new System.Drawing.Size(715, 333);
            this.tabManagement.TabIndex = 3;
            this.tabManagement.Text = "管理(Z)";
            this.tabManagement.UseVisualStyleBackColor = true;
            // 
            // menuManagementTab
            // 
            this.menuManagementTab.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.menuManagementTab.CancelClose = false;
            this.menuManagementTab.ColChoiseIndex = 0;
            this.menuManagementTab.ColDeletedIndex = 0;
            this.menuManagementTab.ColKeyIndex = 0;
            this.menuManagementTab.ColumnChoiseDataPropertyName = null;
            this.menuManagementTab.ColumnChoiseName = null;
            this.menuManagementTab.ColumnCollection = null;
            this.menuManagementTab.ColumnComboxChangeName = null;
            this.menuManagementTab.ColumnDeletedDataPropertyName = null;
            this.menuManagementTab.ColumnDeletedName = null;
            this.menuManagementTab.ColumnKeyDataPropertyName = null;
            this.menuManagementTab.ColumnKeyName = null;
            this.menuManagementTab.ColumnUpdateName = null;
            this.menuManagementTab.ColumnUpdateTimeDataPropertyName = null;
            this.menuManagementTab.ColumnUpdateTimeName = null;
            this.menuManagementTab.ColUpdatedIndex = 0;
            this.menuManagementTab.DataGridViewSource = null;
            this.menuManagementTab.DataSourceDisplay = null;
            this.menuManagementTab.DataTableSource = null;
            this.menuManagementTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuManagementTab.ForeColor = System.Drawing.Color.Black;
            this.menuManagementTab.IsFilterActive = false;
            this.menuManagementTab.Location = new System.Drawing.Point(3, 3);
            this.menuManagementTab.MainMenuEditModeCollection = menuMainCollection3;
            this.menuManagementTab.Margin = new System.Windows.Forms.Padding(2);
            this.menuManagementTab.Name = "menuManagementTab";
            this.menuManagementTab.SCREEN_TITLE = null;
            this.menuManagementTab.Size = new System.Drawing.Size(709, 327);
            this.menuManagementTab.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(635, 385);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 30);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panelSqlChecking
            // 
            this.panelSqlChecking.BackColor = System.Drawing.Color.Transparent;
            this.panelSqlChecking.Controls.Add(this.label2);
            this.panelSqlChecking.ForeColor = System.Drawing.Color.Black;
            this.panelSqlChecking.Location = new System.Drawing.Point(250, 45);
            this.panelSqlChecking.Name = "panelSqlChecking";
            this.panelSqlChecking.Size = new System.Drawing.Size(199, 181);
            this.panelSqlChecking.TabIndex = 8;
            this.panelSqlChecking.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(25, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "データーベース接続中";
            // 
            // FestivalMain
            // 
            this.ClientSize = new System.Drawing.Size(728, 422);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.panelSqlChecking);
            this.Controls.Add(this.lblCurrentVersion);
            this.Controls.Add(this.btnClose);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FestivalMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FestivalMain_FormClosing);
            this.Load += new System.EventHandler(this.FestivalMain_Load);
            this.tabMain.ResumeLayout(false);
            this.tabDatabase.ResumeLayout(false);
            this.tabDISCvideo.ResumeLayout(false);
            this.tabManagement.ResumeLayout(false);
            this.panelSqlChecking.ResumeLayout(false);
            this.panelSqlChecking.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelSqlChecking;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabDISCvideo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabPage tabManagement;
        private DiscVideoTab.TabDis menuDisTab;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private System.Windows.Forms.Label lblCurrentVersion;
        private System.Windows.Forms.TabPage tabDatabase;
        private DBTab.TabDatabase menuDataBaseTab;
        private ManagementTab.TabManagement menuManagementTab;
    }
}

