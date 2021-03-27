using Zuby.ADGV;

namespace Festival.Base
{
    partial class DataGridViewFilter
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
            this.dtgAdvMain = new Zuby.ADGV.AdvancedDataGridView();
            this.navDataGridView = new Festival.Base.NavDataGridView();
            this.mnSearchToolBar = new Zuby.ADGV.AdvancedDataGridViewSearchToolBar();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAdvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgAdvMain
            // 
            this.dtgAdvMain.AllowUserToAddRows = false;
            this.dtgAdvMain.AllowUserToDeleteRows = false;
            this.dtgAdvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgAdvMain.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgAdvMain.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dtgAdvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgAdvMain.FilterAndSortEnabled = true;
            this.dtgAdvMain.Location = new System.Drawing.Point(0, 0);
            this.dtgAdvMain.Name = "dtgAdvMain";
            this.dtgAdvMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtgAdvMain.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dtgAdvMain.Size = new System.Drawing.Size(939, 440);
            this.dtgAdvMain.TabIndex = 0;
            // 
            // navDataGridView
            // 
            this.navDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.navDataGridView.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.navDataGridView.DataGridViewSource = this.dtgAdvMain;
            this.navDataGridView.Location = new System.Drawing.Point(0, 440);
            this.navDataGridView.Name = "navDataGridView";
            this.navDataGridView.Size = new System.Drawing.Size(936, 21);
            this.navDataGridView.TabIndex = 1;
            // 
            // mnSearchToolBar
            // 
            this.mnSearchToolBar.AllowMerge = false;
            this.mnSearchToolBar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.mnSearchToolBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.mnSearchToolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnSearchToolBar.Location = new System.Drawing.Point(0, 465);
            this.mnSearchToolBar.MaximumSize = new System.Drawing.Size(0, 27);
            this.mnSearchToolBar.MinimumSize = new System.Drawing.Size(0, 27);
            this.mnSearchToolBar.Name = "mnSearchToolBar";
            this.mnSearchToolBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnSearchToolBar.Size = new System.Drawing.Size(939, 27);
            this.mnSearchToolBar.TabIndex = 2;
            this.mnSearchToolBar.Text = "advancedDataGridViewSearchToolBar";
            this.mnSearchToolBar.Search += new Zuby.ADGV.AdvancedDataGridViewSearchToolBarSearchEventHandler(this.advancedDataGridViewSearchToolBar_Search);
            // 
            // DataGridViewFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.mnSearchToolBar);
            this.Controls.Add(this.navDataGridView);
            this.Controls.Add(this.dtgAdvMain);
            this.Name = "DataGridViewFilter";
            this.Size = new System.Drawing.Size(939, 492);
            this.Load += new System.EventHandler(this.DataGridViewFilter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAdvMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AdvancedDataGridView dtgAdvMain;
        private NavDataGridView navDataGridView;
        private AdvancedDataGridViewSearchToolBar mnSearchToolBar;
    }
}
