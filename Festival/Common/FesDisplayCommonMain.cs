using FestivalCommon;
using FestivalObjects;
using System.Windows.Forms;
using System.ComponentModel;
using System;
using System.Threading;
using FestivalBusiness;

namespace Festival.Common
{
    public partial class FesDisplayCommonMain : DevComponents.DotNetBar.RibbonForm
    {
        private BackgroundWorker bgwDisplaySearchingCommon;

        //LayoutUC
        private LayOutEntity currentLayout;
        private FestivalEvents.ExportFileEventHandler ExportFileEvents;
        private FestivalEvents.CommonEventHandler CreateFilterEvent;
        private FestivalEvents.CommonEventHandler UnFilterEvent;
        private FestivalEvents.CommonEventHandler ApplyFilterEvent;
        private FestivalEvents.CommonEventHandler CutEvent;
        private FestivalEvents.CommonEventHandler CopyEvent;
        private FestivalEvents.CommonEventHandler PasteEvent;

        public FestivalEvents.StatusEventHandler FreezeEvent;
        public FestivalEvents.ColumnSortHandler ColumnSortEvent;
        public FestivalEvents.CommonEventHandler OpenColumnVisibleEvent;
        public FestivalEvents.CommonEventHandler CloseParentFormEvent;
        public FestivalEvents.CommonEventHandler ClosedAndSaveEvent;

        private LayoutCollection EnableButtonScreens = new LayoutCollection();
        private MenuCommonCollection menuCommon = null;
        private bool CancelClose = false;
        private ActiveMenuCollection activeMenusSearchMain;
        private CommonBusiness commonBusiness = new CommonBusiness();

        public FesDisplayCommonMain(LayOutEntity currentLayout)
        {
            InitializeComponent();

            menuCommon = new MenuCommonCollection();
            this.currentLayout = currentLayout;
            panelMain.Visible = false;
            activeMenusSearchMain = currentLayout.LayoutObjectAdvance.ActiveMenusSearchMain;

            this.Text = currentLayout.EditMode == EnumEditMode.Edit ? currentLayout.EditTitle : currentLayout.ReadOnlyTitle;

            bgwDisplaySearchingCommon = new BackgroundWorker();

            System.Drawing.Size screenSize = Screen.PrimaryScreen.Bounds.Size;

            if (this.Height > screenSize.Height)
            {
                this.Height = screenSize.Height;
            }
            if (this.Width > screenSize.Width)
            {
                this.Width = screenSize.Width;
            }

            panelMain.Location = new System.Drawing.Point(5, ribbonControl1.Height + 5);
        }

        private void LoadActiveMenus()
        {
            btnExportFile.Visible = false;
            btnExportFile.Enabled = false;
            ribCommand.Visible = false;

            if (activeMenusSearchMain != null)
            {
                var existExport = activeMenusSearchMain.GetMenuByName(btnExportFile.Name);
                if (existExport != null && existExport.MenuName != EnumMenusSearchMain.None)
                {
                    btnExportFile.Visible = true;
                    btnExportFile.Enabled = true;
                    ribCommand.Visible = true;
                }
            }

            btnUnfreeze.Enabled = false;
            ActiveMenuHasData(false);
        }

        public void ActiveMenuColumnStatus(bool? isColumnReadOnly)
        {
            if ((bool)isColumnReadOnly)
            {
                ActiveMenuColumnReadOnly();
            }
            else if (!(bool)isColumnReadOnly)
                ActiveMenuColumnNormal();
        }

        public void ActiveMenuFreeze(bool? isActived)
        {
            btnFreeze.Enabled = (bool)isActived;
            if (isActived == true)
                btnUnFilter.Enabled = false;
        }

        private void ActiveMenuColumnReadOnly()
        {
            if (btnCopy.Visible)
                btnCopy.Enabled = true;
            if (btnPaste.Visible)
                btnPaste.Enabled = false;
            if (btnCut.Visible)
                btnCut.Enabled = false;
        }

        private void ActiveMenuColumnNormal()
        {
            if (btnCopy.Visible)
                btnCopy.Enabled = true;
            if (btnPaste.Visible)
                btnPaste.Enabled = true;
            if (btnCut.Visible)
                btnCut.Enabled = true;
        }

        private void ActiveMenuHasData(bool? isActive)
        {
            if (btnCreateFilter.Visible)
                btnCreateFilter.Enabled = (bool)isActive;
            if (btnFreeze.Visible)
                btnFreeze.Enabled = (bool)isActive;
            if (btnZToA.Visible)
                btnZToA.Enabled = (bool)isActive;
            if (btnAtoZ.Visible)
                btnAtoZ.Enabled = (bool)isActive;
            if (btnDeleteSort.Visible)
                btnDeleteSort.Enabled = (bool)isActive;
            if (btnExportFile.Visible)
                btnExportFile.Enabled = (bool)isActive;
            if (btnCopy.Visible)
                btnCopy.Enabled = (bool)isActive;
            if (btnPaste.Visible)
                btnPaste.Enabled = (bool)isActive;
            if (btnCut.Visible)
                btnCut.Enabled = (bool)isActive;
            if (btnUnFilter.Visible)
                btnUnFilter.Enabled = false;
            if (btnApplyFilter.Visible)
                btnApplyFilter.Enabled = false;
        }

        private void InitSearchCommon(LayOutEntity currentLayout)
        {
            panelMain.Controls.Clear();

            FesDisplayCommon uCSearchCommon = new FesDisplayCommon(currentLayout);

            uCSearchCommon.LayoutEditMode(currentLayout.EditMode);
            // Save and closed
            ClosedAndSaveEvent += uCSearchCommon.CloseAndSave;
            uCSearchCommon.CancelCloseEvent += SetCancelClose;
            // Menu column active
            uCSearchCommon.ActiveMenuColumnEvent += ActiveMenuColumnStatus;

            //Active menu freeze
            uCSearchCommon.ActiveMenuFreezeEvent += ActiveMenuFreeze;

            // Active menu has data
            uCSearchCommon.ActiveMenuHasDataEvent += ActiveMenuHasData;

            // Set export file event
            ExportFileEvents += uCSearchCommon.ExportToFile;
            // Create filter row
            CreateFilterEvent += uCSearchCommon.CreateFilter;
            // Unfilter row
            UnFilterEvent += uCSearchCommon.UnFilter;
            // Apply filter
            ApplyFilterEvent += uCSearchCommon.Filter;
            // Freeze column
            FreezeEvent += uCSearchCommon.Frozen;
            // Sort column
            ColumnSortEvent += uCSearchCommon.Sort;
            // Column Visible
            OpenColumnVisibleEvent += uCSearchCommon.OpenColumnVisible;
            //Copy
            CopyEvent += uCSearchCommon.Copy;
            // Cut
            CutEvent += uCSearchCommon.Cut;
            // Paste
            PasteEvent += uCSearchCommon.Paste;

            uCSearchCommon.Dock = DockStyle.Fill;

            panelMain.Controls.Add(uCSearchCommon);
        }

        private void SetCancelClose(bool? cancelClose)
        {
            CancelClose = (bool)cancelClose;
        }

        private void WiiCommon_Load(object sender, System.EventArgs e)
        {
            InitSearchCommonProcess();
            if (CloseParentFormEvent != null)
                CloseParentFormEvent();
        }

        private void InitSearchCommonProcess()
        {
            if (bgwDisplaySearchingCommon == null)
                return;
            bgwDisplaySearchingCommon.RunWorkerCompleted += BgwDisplaySearchingCommon_RunWorkerCompleted;
            bgwDisplaySearchingCommon.DoWork += BgwDisplaySearchingCommon_DoWork;
            bgwDisplaySearchingCommon.RunWorkerAsync();
        }

        private void BgwDisplaySearchingCommon_DoWork(object sender, DoWorkEventArgs e)
        {
            Invoke(new Action(() =>
            {
                LoadActiveMenus();
                InitSearchCommon(this.currentLayout);
            }));
        }

        private void BgwDisplaySearchingCommon_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (bgwDisplaySearchingCommon != null)
            {
                bgwDisplaySearchingCommon.RunWorkerCompleted -= BgwDisplaySearchingCommon_RunWorkerCompleted;
                bgwDisplaySearchingCommon.DoWork -= BgwDisplaySearchingCommon_DoWork;
                bgwDisplaySearchingCommon.Dispose();
            }
            bgwDisplaySearchingCommon = null;
            GC.Collect();
            // Sleep to smooth display 
            Thread.Sleep(1000);
            Invoke(new Action(() =>
            {
                panelMain.Visible = true;
            }));
        }

        private void WiiCommon_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ClosedAndSaveEvent != null)
                ClosedAndSaveEvent();
            e.Cancel = CancelClose;
            SetEditLock();
        }

        private void SetEditLock()
        {
            try
            {
                commonBusiness.SetFesEditLock(currentLayout.TagId, false);
            }
            catch
            {

            }
        }

        private void btnExportFile_Click(object sender, System.EventArgs e)
        {
            if (!btnExportFile.Enabled)
                return;

            ExportSearchingFile exportFile = new ExportSearchingFile(currentLayout.LayoutName);
            exportFile.ShowDialog();

            if (exportFile.IsActive)
            {
                ExportFile(exportFile.fileExportInfo);
            }
        }

        private void ExportFile(FileExportEntity fileInfo)
        {
            if (ExportFileEvents != null)
                ExportFileEvents(fileInfo);
        }

        private void btnCreateFilter_Click(object sender, System.EventArgs e)
        {
            if (CreateFilterEvent == null)
                return;

            CreateFilterEvent();
            btnUnFilter.Enabled = true;
            btnCopy.Enabled = true;
            btnPaste.Enabled = true;
            btnCut.Enabled = true;
            btnApplyFilter.Enabled = true;
            btnUnFilter.Enabled = true;
            btnFreeze.Enabled = false;
            btnUnfreeze.Enabled = false;
            btnColumDisplayAgain.Enabled = false;
            btnPaste.Enabled = false;
            btnAtoZ.Enabled = false;
            btnZToA.Enabled = false;
            btnDeleteSort.Enabled = false;
            btnCreateFilter.Enabled = false;
        }

        private void btnApplyFilter_Click(object sender, System.EventArgs e)
        {
            if (ApplyFilterEvent != null)
                ApplyFilterEvent();

            btnApplyFilter.Enabled = false;
            btnCreateFilter.Enabled = true;
            btnUnFilter.Enabled = true;

            btnAtoZ.Enabled = false;
            btnZToA.Enabled = false;
            btnDeleteSort.Enabled = false;

            btnFreeze.Enabled = false;
            btnUnfreeze.Enabled = false;
            btnColumDisplayAgain.Enabled = true;

            btnCut.Enabled = false;
            btnCopy.Enabled = false;
            btnPaste.Enabled = false;
        }

        private void btnUnFilter_Click(object sender, System.EventArgs e)
        {
            if (UnFilterEvent == null)
            {
                return;
            }

            UnFilterEvent();

            btnUnFilter.Enabled = false;
            btnCut.Enabled = false;
            btnCopy.Enabled = false;
            btnPaste.Enabled = false;
            btnApplyFilter.Enabled = false;

            btnFreeze.Enabled = true;
            btnUnfreeze.Enabled = true;
            btnColumDisplayAgain.Enabled = true;

            btnAtoZ.Enabled = true;
            btnZToA.Enabled = true;
            btnDeleteSort.Enabled = true;
            btnCreateFilter.Enabled = true;
        }

        private void btnFreeze_Click(object sender, System.EventArgs e)
        {
            if (FreezeEvent != null)
            {
                //btnFreeze.Enabled = false;
                btnUnfreeze.Enabled = true;
                FreezeEvent(true);
            }
        }

        private void btnUnfreeze_Click(object sender, System.EventArgs e)
        {
            if (FreezeEvent != null)
            {
                btnUnfreeze.Enabled = false;
                btnFreeze.Enabled = true;
                FreezeEvent(false);
            }
        }

        private void btnCut_Click(object sender, System.EventArgs e)
        {
            if (!btnCut.Enabled || CutEvent == null)
                return;
            CutEvent();
        }

        private void btnCopy_Click(object sender, System.EventArgs e)
        {
            if (!btnCopy.Enabled || CopyEvent == null)
                return;
            CopyEvent();
        }

        private void btnPaste_Click(object sender, System.EventArgs e)
        {
            if (!btnPaste.Enabled || PasteEvent == null)
                return;
            PasteEvent();
        }

        private void btnColumDisplayAgain_Click(object sender, System.EventArgs e)
        {
            if (OpenColumnVisibleEvent != null)
                OpenColumnVisibleEvent();
        }

        private void btnAtoZ_Click(object sender, System.EventArgs e)
        {
            if (ColumnSortEvent == null)
                return;
            ColumnSortEvent(SortType.AtoZ);
        }

        private void btnZtoA_Click(object sender, System.EventArgs e)
        {
            if (ColumnSortEvent == null)
                return;
            ColumnSortEvent(SortType.ZtoA);
        }

        private void btnDeleteSort_Click(object sender, System.EventArgs e)
        {
            if (ColumnSortEvent == null)
                return;
            ColumnSortEvent(SortType.RemoveSort);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.C))
            {
                btnCopy_Click(null, null);
            }
            else if (keyData == (Keys.Control | Keys.X))
            {
                btnCut_Click(null, null);
            }
            else if (keyData == (Keys.Control | Keys.V))
            {
                btnPaste_Click(null, null);
            }
            else if (keyData == (Keys.Alt | Keys.Up))
            {
                btnZtoA_Click(null, null);
            }
            else if (keyData == (Keys.Alt | Keys.Down))
            {
                btnAtoZ_Click(null, null);
            }
            else if (keyData == (Keys.Alt | Keys.D))
            {
                btnDeleteSort_Click(null, null);
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}