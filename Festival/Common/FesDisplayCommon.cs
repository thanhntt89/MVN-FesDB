using System;
using System.Windows.Forms;
using Festival.Base;
using FestivalObjects;
using DevComponents.DotNetBar.Controls;
using FestivalCommon;
using System.ComponentModel;
using FestivalUtilities;
using System.Reflection;
using System.Data;
using System.Linq;
using DevComponents.DotNetBar;
using System.Drawing;

namespace Festival.Common
{
    public partial class FesDisplayCommon : UserControlBaseAdvance
    {
        //Search condition layout
        public SearchConditionsCommon searchConditionsCommon;

        private DataGridViewCell currentCell;
        private FileExportEntity fileExportInfo;
        private int xPanel = 0;
        private int yPanel = 0;
        private int widthPanel = 0;
        private int heightPanel = 0;
        private bool IsUpdateColumn = true;

        public FesDisplayCommon(LayOutEntity currentLayout)
        {
            InitializeComponent();
            CurrentLayout = currentLayout;
        }

        private void UCSearchCommon_Load(object sender, EventArgs e)
        {
            //Set hieght textbox
            txtEditCell.Height = 30;

            xPanel = panelMain.Location.X;
            yPanel = panelMain.Location.Y;
            widthPanel = panelMain.Width;
            heightPanel = panelMain.Height;
            LoadLayOut(CurrentLayout);

            LoadInitLayoutPosition();
        }

        private void LoadActiveMenus()
        {
            this.ActiveMenusSearchMain = CurrentLayout.LayoutObjectAdvance.ActiveMenusSearchMain;
            foreach (Control ctrl in this.Controls)
            {
                ButtonX btn = ctrl as ButtonX;
                if (btn != null)
                {
                    btn.Visible = false;
                    btn.Enabled = false;
                    var exist = this.ActiveMenusSearchMain.GetMenuByName(btn.Name);
                    if (exist != null && exist.MenuName != EnumMenusSearchMain.None)
                    {
                        btn.Text = string.IsNullOrWhiteSpace(exist.MenuText) ? btn.Text : exist.MenuText;

                        btn.Visible = true;
                        btn.Enabled = true;

                        if (CurrentLayout.EditMode == EnumEditMode.None || CurrentLayout.EditMode == EnumEditMode.ReadOnly)
                        {
                            if (btn.Name == btnAllInPut.Name || btn.Name == btnImportData.Name || btn.Name == btnAddNew.Name || btn.Name == btnSave.Name)
                            {
                                btn.Visible = false;
                                btn.Enabled = false;
                            }
                        }
                    }
                }
            }

            if (!btnSearchCondition.Visible)
            {
                btnRowSelectUnselect.Location = new System.Drawing.Point(2, 3);
                btnAllOn.Location = new System.Drawing.Point(124, 3);
                btnAllOff.Location = new System.Drawing.Point(219, 3);
                btnAllInPut.Location = new System.Drawing.Point(314, 3);
            }

            if (!btnImportData.Visible && btnAddNew.Visible)
            {
                btnAddNew.Location = new System.Drawing.Point(3, 36);
            }
        }

        public override void LayoutEditMode(EnumEditMode currentEditMode)
        {
            LoadActiveMenus();
            ActiveMenuHasData(false);
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (CurrentLayout.LayoutObjectAdvance == null || !btnAddNew.Enabled || !btnAddNew.Visible)
            {
                return;
            }
            CurrentLayout.LayoutObjectAdvance.AddNewRow();
        }

        public override void ExportToFile(FileExportEntity fileInfo)
        {
            if (CurrentLayout.LayoutObjectAdvance == null)
            {
                return;
            }

            fileExportInfo = fileInfo;
            bgwProcess = CreateThread();
            bgwProcess.DoWork += Export_DoWork;
            bgwProcess.RunWorkerCompleted += Export_RunWorkerCompleted;
            bgwProcess.RunWorkerAsync();

            this.ShowWating();
        }

        private void Export_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                int rst = CurrentLayout.LayoutObjectAdvance.ExportExecute(fileExportInfo);

                this.ClosedWaiting();

                Invoke(new Action(() =>
                {
                    if (rst == 0)
                    {
                        MessageBox.Show(GetResources.GetResourceMesssage(Constants.MESSAGE_ERROR_NO_DATA), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (rst == 1)
                        MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGI003), fileExportInfo.FilePath), GetResources.GetResourceMesssage(Constants.INFO_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }));
            }
            catch (Exception ex)
            {
                this.ClosedWaiting();
                ErrorEntity error = new ErrorEntity()
                {
                    LogTime = DateTime.Now.ToString(Constants.LOG_DATE_TIME_FORMAT),
                    ErrorMessage = ex.Message,
                    ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                    FilePath = Constants.LOG_FILE_PATH_ERROR
                };

                LogException(error);

                Invoke(new Action(() =>
                {
                    MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MESSAGE_ERROR_OUTPUT_FAILED), error.LogTime, error.ModuleName, error.ErrorMessage, error.FilePath), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }
        }

        private void Export_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.ClosedWaiting();
            if (bgwProcess != null)
            {
                bgwProcess.RunWorkerCompleted -= Export_RunWorkerCompleted;
                bgwProcess.DoWork -= Export_DoWork;
            }
            bgwProcess = null;
            GC.Collect();
        }

        public override void CreateFilter()
        {
            // Disable common menu
            // Hide result module search
            if (CurrentLayout != null)
                CurrentLayout.LayoutObjectAdvance.Visible = false;

            HideMain(true);

            // Display search condition common
            if (searchConditionsCommon == null)
            {
                searchConditionsCommon = new SearchConditionsCommon(CurrentLayout.LayoutObjectAdvance.GetDataGridViewColumns(), CurrentLayout.LayoutObjectAdvance.GetHideColumns());
                searchConditionsCommon.Dock = DockStyle.Fill;
                panelMain.Controls.Add(searchConditionsCommon);

                // Create search condition common
                CreateSearchCondition();
            }
            else
            {
                searchConditionsCommon.Visible = true;
                searchConditionsCommon.ChangeColumnDisplayIndex(CurrentLayout.LayoutObjectAdvance.GetDataGridViewColumns());
            }
        }

        private void HideMain(bool isHide)
        {
            foreach (Control ctrl in this.Controls)
            {
                Panel panl = ctrl as Panel;
                if (panl != null && panl.Name == panelMain.Name)
                {
                    if (isHide)
                        panelMain.Dock = DockStyle.Fill;
                    else
                    {
                        panelMain.Location = new System.Drawing.Point(xPanel, yPanel);
                        panelMain.Size = new System.Drawing.Size(widthPanel, heightPanel);
                        panelMain.Anchor = AnchorStyles.Left;
                        panelMain.Anchor = AnchorStyles.Top;
                        panelMain.Anchor = AnchorStyles.Right;
                        panelMain.Anchor = AnchorStyles.Bottom;
                    }
                    continue;
                }

                ctrl.Visible = !isHide;
                ctrl.Enabled = !isHide;
            }

            if (currentCell == null || isHide)
                return;
            txtEditCell.Visible = false;
            dateInput.Visible = false;
            cboStatus.Visible = false;
            if (currentCell.GetType().Equals(typeof(DataGridViewTextBoxCell)) || currentCell.GetType().Equals(typeof(DataGridViewNumericCell)))
            {
                // Set data for cell
                txtEditCell.Visible = !isHide;
            }
            else if (currentCell.GetType().Equals(typeof(DataGridViewDateTimeInputCell)) || currentCell.GetType().Equals(typeof(DataGridViewMaskedTextBoxAdvCell)))
            {
                dateInput.Visible = !isHide;
            }
            else if (currentCell.GetType().Equals(typeof(DataGridViewCheckBoxXCell)) || currentCell.GetType().Equals(typeof(DataGridViewComboBoxExCell)))
            {
                cboStatus.Visible = !isHide;
            }
        }

        public override void UnFilter()
        {
            // Display search filter
            if (CurrentLayout.LayoutObjectAdvance != null)
            {
                CurrentLayout.LayoutObjectAdvance.Visible = true;
            }

            // Hide search codition common
            if (searchConditionsCommon != null)
            {
                searchConditionsCommon.Visible = false;
            }

            CurrentLayout.LayoutObjectAdvance.UnFilter();

            HideMain(false);
        }

        public override void Filter()
        {
            // Filter in main search
            if (CurrentLayout != null && searchConditionsCommon != null)
            {
                HideMain(false);
                // Hide filter layout
                searchConditionsCommon.Visible = false;
                CurrentLayout.LayoutObjectAdvance.Visible = true;
                FilterProcess();
            }
        }

        private void FilterProcess()
        {
            bgwProcess = CreateThread();
            bgwProcess.RunWorkerCompleted += Filter_RunWorkerCompleted;
            bgwProcess.DoWork += Filter_DoWork;
            bgwProcess.RunWorkerAsync();
            this.ShowWating();
        }

        private void Filter_DoWork(object sender, DoWorkEventArgs e)
        {
            Invoke(new Action(() =>
            {
                try
                {
                    CurrentLayout.LayoutObjectAdvance.ApplyFilter(searchConditionsCommon.GetDataFilter());
                }
                catch (Exception ex)
                {
                    this.ClosedWaiting();
                    ErrorEntity error = new ErrorEntity()
                    {
                        LogTime = DateTime.Now.ToString(Constants.LOG_DATE_TIME_FORMAT),
                        ErrorMessage = ex.Message,
                        ModuleName = this.GetClassName() + " " + MethodBase.GetCurrentMethod().Name,
                        FilePath = Constants.LOG_FILE_PATH_ERROR
                    };

                    LogException(error);
                }
            }));
        }

        private void Filter_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.ClosedWaiting();
            if (bgwProcess != null)
            {
                bgwProcess.RunWorkerCompleted -= Filter_RunWorkerCompleted;
                bgwProcess.DoWork -= Filter_DoWork;
                bgwProcess.Dispose();
            }
            bgwProcess = null;
        }

        public override void Frozen(bool? isFrozen)
        {
            // Filter in main search
            if (CurrentLayout.LayoutObjectAdvance != null)
            {
                CurrentLayout.LayoutObjectAdvance.Frozen(isFrozen);
            }
        }

        public override void Sort(SortType sortType)
        {
            if (CurrentLayout.LayoutObjectAdvance != null)
            {
                CurrentLayout.LayoutObjectAdvance.Sort(sortType);
            }
        }

        public override void OpenColumnVisible()
        {
            if (CurrentLayout == null || CurrentLayout.LayoutObjectAdvance == null)
            {
                return;
            }

            LoadColumnHideCommon loadColumnHideCommon = new LoadColumnHideCommon(CurrentLayout.LayoutObjectAdvance.GetDataGridViewColumns(), CurrentLayout.LayoutObjectAdvance.GetHideColumns());
            loadColumnHideCommon.SetColumnVisibleEvent += CurrentLayout.LayoutObjectAdvance.SetColumnVisible;

            if (searchConditionsCommon != null)
            {
                loadColumnHideCommon.SetColumnVisibleEvent += searchConditionsCommon.ColumnVisible;
            }

            loadColumnHideCommon.ShowDialog();
        }

        private void CreateSearchCondition()
        {
            if (searchConditionsCommon != null)
            {
                searchConditionsCommon.CreateFilter();
            }
        }

        private void LoadLayOut(LayOutEntity currentLayout)
        {
            panelMain.Controls.Clear();

            if (currentLayout == null)
            {
                return;
            }

            // Display module
            currentLayout.LayoutObjectAdvance.Dock = DockStyle.Fill;

            currentLayout.LayoutObjectAdvance.EditCellEvent += EditCell;
            currentLayout.LayoutObjectAdvance.UnFilterEvent += UnFilter;
            currentLayout.LayoutObjectAdvance.ActiveMenuFreezeEvent += ActiveMenuFreeze;
            currentLayout.LayoutObjectAdvance.ActiveMenuHasDataEvent += ActiveMenuHasData;
            currentLayout.LayoutObjectAdvance.LayoutEditMode(currentLayout.EditMode);
            panelMain.Controls.Add(CurrentLayout.LayoutObjectAdvance);
        }

        public override void ActiveMenuFreeze(bool? isActive)
        {
            if (ActiveMenuFreezeEvent != null)
                ActiveMenuFreezeEvent(isActive);
        }

        public override void ActiveMenuHasData(bool? isActive)
        {
            if (ActiveMenuHasDataEvent != null)
                ActiveMenuHasDataEvent(isActive);

            if (btnAllOn.Visible)
                btnAllOn.Enabled = (bool)isActive;
            if (btnAllOff.Visible)
                btnAllOff.Enabled = (bool)isActive;
            if (btnRowSelectUnselect.Visible)
                btnRowSelectUnselect.Enabled = (bool)isActive;

            if (CurrentLayout.EditMode == EnumEditMode.Edit)
            {
                if (btnSave.Visible)
                    btnSave.Enabled = (bool)isActive;
                if (btnAllInPut.Visible)
                    btnAllInPut.Enabled = (bool)isActive;
            }
        }

        /// <summary>
        /// Display value on datagridview selected
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="cellValue"></param>
        public override void EditCell(DataGridViewCell cell)
        {
            if (cell == null)
                return;

            Invoke(new Action(() =>
            {
                currentCell = cell;

                if (currentCell.RowIndex == -1 || currentCell.ColumnIndex == -1)
                    return;

                lblColumnText.Text = currentCell.OwningColumn.HeaderText;

                // Get current cell value               
                txtEditCell.Visible = false;
                dateInput.Visible = false;
                cboStatus.Visible = false;

                txtEditCell.KeyPress -= TxtEditCell_KeyPress;

                cboStatus.Size = txtEditCell.Size;
                cboStatus.Location = txtEditCell.Location;
                cboStatus.Dock = DockStyle.Bottom;

                dateInput.Size = txtEditCell.Size;
                dateInput.Location = txtEditCell.Location;
                dateInput.Dock = DockStyle.Bottom;
                txtEditCell.ReadOnly = true;
                dateInput.IsInputReadOnly = true;
                cboStatus.Enabled = false;

                labelFunction.Visible = !currentCell.ReadOnly;

                //Default set menu readonly
                if (ActiveMenuColumnEvent != null)
                    ActiveMenuColumnEvent((cell.ReadOnly));

                if (currentCell.GetType().Equals(typeof(DataGridViewTextBoxCell)))
                {
                    txtEditCell.MaxLength = ((DataGridViewTextBoxColumn)currentCell.OwningColumn).MaxInputLength;
                    // Set data for cell
                    txtEditCell.Visible = true;

                    txtEditCell.Text = Convert.ToString(cell.Value);
                    // Focus last data
                    txtEditCell.SelectionStart = txtEditCell.Text.Length;
                }
                else if (currentCell.GetType().Equals(typeof(DataGridViewDateTimeInputCell)))
                {
                    dateInput.Visible = true;
                    dateInput.Text = Convert.ToString(cell.Value);
                }
                else if (currentCell.GetType().Equals(typeof(DataGridViewMaskedTextBoxAdvCell))
                )
                {
                    dateInput.Visible = true;
                    dateInput.Text = Utils.ConvertToDataTime(cell.Value.ToString()).ToString();
                }
                else if (currentCell.GetType().Equals(typeof(DataGridViewCheckBoxXCell)))
                {
                    cboStatus.Visible = true;
                    cboStatus.DataSource = null;

                    cboStatus.Items.Clear();
                    cboStatus.Items.AddRange(Constants.LIST_BOOLEAN);
                    cboStatus.SelectedItem = Convert.ToString(cell.Value);
                }
                else if (currentCell.GetType().Equals(typeof(DataGridViewNumericCell)))
                {
                    // Get max value input
                    int MaxLength = ((DataGridViewNumericColumn)currentCell.OwningColumn).MaxInputLength;
                    txtEditCell.MaxLength = MaxLength;

                    txtEditCell.Visible = true;
                    // Status edit text
                    txtEditCell.ReadOnly = cell.ReadOnly;
                    txtEditCell.Text = Convert.ToString(cell.Value);
                    // Focus last data
                    txtEditCell.SelectionStart = txtEditCell.Text.Length;

                    // Input key numeric
                    txtEditCell.KeyPress += TxtEditCell_KeyPress;
                }
                else if (currentCell.GetType().Equals(typeof(DataGridViewComboBoxExCell)))
                {
                    cboStatus.Visible = true;
                    cboStatus.DataSource = null;

                    var cbo = (DataGridViewComboBoxExColumn)currentCell.OwningColumn;
                    DataTable dtSource = cbo.DataSource as DataTable;
                    if (dtSource != null)
                    {
                        cboStatus.DataSource = dtSource;
                        cboStatus.ValueMember = dtSource.Columns[0].ColumnName;
                        cboStatus.DisplayMember = dtSource.Columns[1].ColumnName;
                    }

                    int index = -1;
                    for (int i = 0; i < cboStatus.Items.Count; i++)
                    {
                        cboStatus.SelectedIndex = i;
                        if (cboStatus.SelectedValue != null && cboStatus.SelectedValue.Equals(cell.Value))
                        {
                            index = i;
                            break;
                        }
                    }
                    cboStatus.SelectedIndex = index;
                }
            }));

            DisableBulkInput(cell);
        }

        private void DisableBulkInput(DataGridViewCell cell)
        {
            btnAllInPut.Enabled = true;

            if (cell == null)
                return;
            var exist = CurrentLayout.LayoutObjectAdvance.GetDisableBulkInsertColumns().Where(r => r.Equals(currentCell.OwningColumn.DataPropertyName)).FirstOrDefault();

            if (exist != null || cell.ReadOnly)
                btnAllInPut.Enabled = false;
        }

        private void TxtEditCell_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            base.OnKeyPress(e);
        }

        public override void Copy()
        {
            if (CurrentLayout.LayoutObjectAdvance != null)
                CurrentLayout.LayoutObjectAdvance.Copy();
        }

        public override void Cut()
        {
            if (CurrentLayout.LayoutObjectAdvance != null)
                CurrentLayout.LayoutObjectAdvance.Cut();
        }

        public override void Paste()
        {
            if (CurrentLayout.LayoutObjectAdvance != null)
                CurrentLayout.LayoutObjectAdvance.Paste();
        }

        private void UpdateCell(object dataUpdate)
        {
            CheckDataType(currentCell, dataUpdate);
        }

        private void CheckDataType(DataGridViewCell cell, object data)
        {
            if (cell == null)
                return;

            if (cell.GetType().Equals(typeof(DataGridViewComboBoxExCell)) && data != DBNull.Value)
            {
                var cbo = (DataGridViewComboBoxExColumn)cell.OwningColumn;
                DataTable dtSource = cbo.DataSource as DataTable;
                if (dtSource == null || cbo == null)
                {
                    return;
                }

                if (data != DBNull.Value && data != null && !string.IsNullOrWhiteSpace(data.ToString()))
                {
                    // Check data exist in source
                    var exist = dtSource.AsEnumerable().Where(r => r.Field<object>(0) != null && r.Field<object>(0).ToString().Equals(data.ToString())).FirstOrDefault();
                    if (exist == null)
                    {
                        MessageBox.Show(string.Format("存在する{0}を指定してください。", cell.OwningColumn.HeaderText), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            // Check maxlenht
            int MaxLength = 0;
            int MinLength = 0;
            bool checkLength = false;
            if (cell.OwningColumn.GetType().Equals(typeof(DataGridViewNumericColumn)))
            {
                MaxLength = ((DataGridViewNumericColumn)cell.OwningColumn).MaxInputLength;
                MinLength = ((DataGridViewNumericColumn)cell.OwningColumn).MinInputLength;
                checkLength = true;
            }
            else if (cell.OwningColumn.GetType().Equals(typeof(DataGridViewTextBoxColumn)))
            {
                MaxLength = ((DataGridViewTextBoxColumn)cell.OwningColumn).MaxInputLength;
                checkLength = true;
            }

            if (checkLength && data != DBNull.Value && data != null && !string.IsNullOrWhiteSpace(data.ToString()))
            {
                if (data.ToString().Length > MaxLength)
                {
                    MessageBox.Show(string.Format("{0}は、{1}文字以下にしてください。", cell.OwningColumn.HeaderText, MaxLength), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MinLength != 0 && data.ToString().Length < MinLength)
                {
                    MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGE024), MinLength), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (KatakanaColumns.Count > 0)
            {
                if (KatakanaColumns.Contains(cell.OwningColumn.DataPropertyName))
                    if (!Utils.IsKatakana(data.ToString()))
                    {
                        MessageBox.Show("カタカナで入力してください。", GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
            }

            if (HiraganaColumns.Count > 0)
            {
                if (HiraganaColumns.Contains(cell.OwningColumn.DataPropertyName))
                    if (!Utils.IsHiragana(data.ToString()))
                    {
                        MessageBox.Show("ひらがなで入力してください。", GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
            }

            // Update data for cell           
            CurrentLayout.LayoutObjectAdvance.UpdateCell(currentCell, data);
        }

        private void btnSearchCondition_Click(object sender, EventArgs e)
        {
            OpenSearchByLayoutDisplay();
        }

        private void OpenSearchByLayoutDisplay()
        {
            if (!btnSearchCondition.Enabled)
                return;
            if (CurrentLayout == null)
            {
                return;
            }

            if (CurrentLayout.LayoutObjectAdvance.IsDataUpdated)
            {
                DialogResult rst = MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGI004), "\n"), GetResources.GetResourceMesssage(Constants.INFO_TITLE_MESSAGE), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rst == DialogResult.No)
                    return;
            }

            CurrentLayout.LayoutObjectAdvance.OpenSearchingCondition(CurrentLayout);
            IsDisplayItemSeleted = false;
            CurrentLayout.LayoutObjectAdvance.IsDisplayItemSeleted = false;
        }

        private void btnRowSelectUnselect_Click(object sender, EventArgs e)
        {
            if (CurrentLayout.LayoutObjectAdvance == null)
                return;

            if (IsDisplayItemSeleted == null || IsDisplayItemSeleted == false)
            {
                IsDisplayItemSeleted = true;
            }
            else if (IsDisplayItemSeleted == true)
            {
                IsDisplayItemSeleted = false;
            }

            CurrentLayout.LayoutObjectAdvance.DisplayItemSeleted(IsDisplayItemSeleted);
        }

        private void btnAllOn_Click(object sender, EventArgs e)
        {
            if (!btnAllOn.Enabled) return;

            if (CurrentLayout.LayoutObjectAdvance != null)
                CurrentLayout.LayoutObjectAdvance.Choise(true);
        }

        private void btnAllOff_Click(object sender, EventArgs e)
        {
            if (!btnAllOff.Enabled)
                return;
            if (CurrentLayout.LayoutObjectAdvance != null)
                CurrentLayout.LayoutObjectAdvance.Choise(false);
            // Disable select item
            if (IsDisplayItemSeleted == true)
                btnRowSelectUnselect_Click(null, null);
        }

        private void btnAllInPut_Click(object sender, EventArgs e)
        {
            if (!btnAllInPut.Enabled || CurrentLayout == null)
                return;
            // set update column
            IsUpdateColumn = true;
            OpenInput();
        }

        private void OpenInput()
        {
            if (CurrentLayout == null || currentCell == null || currentCell.DataGridView == null || CurrentLayout.LayoutObjectAdvance == null)
                return;

            if (currentCell.ReadOnly || currentCell.OwningColumn.Index == CurrentLayout.LayoutObjectAdvance.ColChoiseIndex)
            {
                MessageBox.Show(GetResources.GetResourceMesssage(Constants.MSGI010), GetResources.GetResourceMesssage(Constants.INFO_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool isActive = false;
            object valueUpdate = null;

            // Check cell type textbox
            if (currentCell.GetType().Equals(typeof(DataGridViewComboBoxExCell)))
            {
                ComboxColumnInput comboxColumnInput = new ComboxColumnInput(currentCell, IsUpdateColumn, CurrentLayout.LayoutObjectAdvance.IsFilterActive);
                comboxColumnInput.ShowDialog();

                isActive = comboxColumnInput.IsActive;
                valueUpdate = comboxColumnInput.DataUpdate;
            }
            else
            {
                CommonInput commonInPut = new CommonInput(currentCell, IsUpdateColumn, CurrentLayout.LayoutObjectAdvance.IsFilterActive);

                commonInPut.HiraganaColumns = CurrentLayout.LayoutObjectAdvance.GetHiraganaColumns();
                commonInPut.KatakanaColumns = CurrentLayout.LayoutObjectAdvance.GetKatakanaColumns();
                commonInPut.HankakuEiSuColumns = CurrentLayout.LayoutObjectAdvance.GetHankakuEiSuColumns();
                commonInPut.ShowDialog();

                isActive = commonInPut.IsActive;
                valueUpdate = commonInPut.DataUpdate;
            }

            // Update data
            if (isActive)
            {
                UpdateCellOrColumn(currentCell, CurrentLayout, valueUpdate, IsUpdateColumn);
            }
        }

        private void UpdateCellOrColumn(DataGridViewCell currentCell, LayOutEntity currentLayout, object dataUpdate, bool isUpdateColumn)
        {
            if (currentLayout.LayoutObjectAdvance == null)
            {
                return;
            }

            if (currentCell.GetType().Equals(typeof(DataGridViewComboBoxExCell)))
            {
                int index = -1;
                for (int i = 0; i < cboStatus.Items.Count; i++)
                {
                    cboStatus.SelectedIndex = i;
                    if (cboStatus.SelectedValue.Equals(dataUpdate))
                    {
                        index = i;
                        break;
                    }

                }
                cboStatus.SelectedIndex = index;
            }
            else if (currentCell.GetType().Equals(typeof(DataGridViewTextBoxCell)) ||
                     currentCell.GetType().Equals(typeof(DataGridViewNumericCell)) ||
                     currentCell.GetType().Equals(typeof(DataGridViewMaskedTextBoxAdvCell)))
            {
                txtEditCell.Text = dataUpdate == null ? null : dataUpdate.ToString();
            }
            else if (currentCell.GetType().Equals(typeof(DataGridViewCheckBoxXCell)))
            {
                cboStatus.SelectedValue = dataUpdate;
            }
            else if (currentCell.GetType().Equals(typeof(DataGridViewDateTimeInputCell)))
            {
                DateTime? dtValue = dataUpdate as DateTime?;
                if (dtValue != null && dtValue != DateTime.MinValue)
                    dateInput.Value = dtValue.Value;
                else
                    dateInput.Value = DateTime.MinValue;
            }

            if (isUpdateColumn)
            {
                currentLayout.LayoutObjectAdvance.UpdateColumnSelected(currentCell, dataUpdate);
            }
            else
            {
                UpdateCell(dataUpdate);
            }
        }

        /// <summary>
        /// Save data before close form
        /// </summary>
        public override void CloseAndSave()
        {
            if (CurrentLayout == null)
                return;

            //SaveConfig
            CurrentLayout.LayoutObjectAdvance.SaveConfig();

            if (CurrentLayout.EditMode == EnumEditMode.Edit)
            {
                CancelClose = false;

                if (CurrentLayout.LayoutObjectAdvance.IsDataUpdated)
                {
                    DialogResult rst = MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGI004), "\n"), GetResources.GetResourceMesssage(Constants.INFO_TITLE_MESSAGE), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rst == DialogResult.No)
                        CancelClose = true;
                }
            }

            if (CancelCloseEvent != null)
                CancelCloseEvent(CancelClose);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!btnSave.Enabled || CurrentLayout.LayoutObjectAdvance == null)
                return;
            CurrentLayout.LayoutObjectAdvance.Save();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F11)
            {
                btnAllInPut_Click(null, null);
                return true;
            }
            else if (keyData == Keys.F5)
            {
                btnSearchCondition_Click(null, null);
                return true;
            }
            else if (keyData == Keys.F10)
            {
                btnRowSelectUnselect_Click(null, null);
                return true;
            }
            else
            if (keyData == (Keys.Alt | Keys.D1))
            {
                btnAllOn_Click(null, null);
            }
            else if (keyData == (Keys.Alt | Keys.D0))
            {
                btnAllOff_Click(null, null);
            }           
            else if (keyData == Keys.Space || keyData == Keys.F2)
            {
                EnableEditDataByShortCutKey();
            }    
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void EnableEditDataByShortCutKey()
        {
            if (currentCell == null || currentCell.ColumnIndex == -1 || currentCell.RowIndex == -1) return;
            var columnCheckBox = currentCell.OwningColumn as DataGridViewCheckBoxXColumn;
            if (CurrentLayout.LayoutObjectAdvance == null || currentCell == null || currentCell.OwningColumn.ReadOnly)
            {
                return;
            }
            if (columnCheckBox != null)
            {
                cboStatus.SelectedIndex = (bool)currentCell.Value ? 1 : 0;
                UpdateCell(cboStatus.SelectedItem);
                return;
            }

            // Set input single
            IsUpdateColumn = false;
            OpenInput();
        }

        private void txtEditCell_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (currentCell == null)
                    return;
                if (txtEditCell.Visible)
                {
                    txtEditCell.Text = Convert.ToString(currentCell.Value);
                    txtEditCell.SelectionLength = txtEditCell.Text.Length;
                }
                else if (cboStatus.Visible)
                {
                    cboStatus.SelectedItem = Convert.ToString(currentCell.Value);
                }
                else if (dateInput.Visible)
                {
                    dateInput.Text = Convert.ToString(currentCell.Value);
                }
            }
        }

        private void txtEditCell_Enter(object sender, EventArgs e)
        {
            txtEditCell.ReadOnly = true;
        }

        private void dateInput_Enter(object sender, EventArgs e)
        {
            dateInput.IsInputReadOnly = true;
        }

        private void btnImportData_Click(object sender, EventArgs e)
        {
            if (!btnImportData.Enabled || CurrentLayout == null || !btnImportData.Visible)
                return;

            if (CurrentLayout.LayoutObjectAdvance.IsDataUpdated)
            {
                DialogResult rst = MessageBox.Show(string.Format("編集中のデーターが存在しますが、処理を実行してよろしいですか？"), GetResources.GetResourceMesssage(Constants.INFO_TITLE_MESSAGE), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rst != DialogResult.Yes)
                    return;
            }

            CurrentLayout.LayoutObjectAdvance.OpenImportFile();
        }

        private void LoadInitLayoutPosition()
        {
            if (CurrentLayout.EditMode == EnumEditMode.None || CurrentLayout.EditMode == EnumEditMode.ReadOnly || (!btnImportData.Visible && !btnAddNew.Visible))
            {
                panelMain.Location = new System.Drawing.Point(btnImportData.Location.X, btnImportData.Location.Y);
                this.panelMain.Size = new Size(this.Size.Width - 2 * panelMain.Margin.Left, this.Size.Height - btnAddNew.Height - 3 * txtEditCell.Height);
            }
            else if (CurrentLayout.EditMode == EnumEditMode.Edit)
            {
                panelMain.Location = new System.Drawing.Point(btnImportData.Location.X, 2 * btnImportData.Location.Y - 5);
                this.panelMain.Size = new Size(this.Size.Width - 2 * panelMain.Margin.Left, this.Size.Height - 5 * txtEditCell.Height);
            }
        }
        
    }
}
