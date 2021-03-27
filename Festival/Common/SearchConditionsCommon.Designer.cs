namespace Festival.Common
{
    partial class SearchConditionsCommon
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
            this.tabMain = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel0 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.tabCoditionDefault = new DevComponents.DotNetBar.SuperTabItem();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.tabMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            // 
            // 
            // 
            this.tabMain.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.tabMain.ControlBox.MenuBox.Name = "";
            this.tabMain.ControlBox.Name = "";
            this.tabMain.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tabMain.ControlBox.MenuBox,
            this.tabMain.ControlBox.CloseBox});
            this.tabMain.Controls.Add(this.superTabControlPanel0);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.ForeColor = System.Drawing.Color.Black;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.ReorderTabsEnabled = true;
            this.tabMain.SelectedTabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.tabMain.SelectedTabIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1062, 600);
            this.tabMain.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Bottom;
            this.tabMain.TabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMain.TabIndex = 0;
            this.tabMain.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tabCoditionDefault});
            this.tabMain.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue;
            // 
            // superTabControlPanel0
            // 
            this.superTabControlPanel0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel0.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel0.Name = "superTabControlPanel0";
            this.superTabControlPanel0.Size = new System.Drawing.Size(1062, 577);
            this.superTabControlPanel0.TabIndex = 1;
            this.superTabControlPanel0.TabItem = this.tabCoditionDefault;
            // 
            // tabCoditionDefault
            // 
            this.tabCoditionDefault.AttachedControl = this.superTabControlPanel0;
            this.tabCoditionDefault.GlobalItem = false;
            this.tabCoditionDefault.Name = "tabCoditionDefault";
            this.tabCoditionDefault.Text = "抽出条件";
            // 
            // SearchConditionsCommon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabMain);
            this.Name = "SearchConditionsCommon";
            this.Size = new System.Drawing.Size(1062, 600);
            this.Load += new System.EventHandler(this.SearchConditionsCommon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.SuperTabControl tabMain;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel0;
        private DevComponents.DotNetBar.SuperTabItem tabCoditionDefault;
    }
}
