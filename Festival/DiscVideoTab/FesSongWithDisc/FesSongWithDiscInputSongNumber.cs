using Festival.Base;
using FestivalBusiness;
using FestivalCommon;
using FestivalUtilities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace Festival.DiscVideoTab.FesSongWithDisc
{
    public partial class FesSongWithDiscInputSongNumber : FormBase
    {
        private CommonBusiness commonBusiness;
        private FesSongWithDiscInputSongNumberBusiness inputSongNumberBusiness;
        private List<string> songNumberList = new List<string>();
        private FesInputNumberTypeFunctionCollection functionCollection = new FesInputNumberTypeFunctionCollection();
        private FunctionEntity function = new FunctionEntity();
        private DisVersion currentVersion;

        public FesSongWithDiscInputSongNumber(EnumInputTypeName functionName, DisVersion version)
        {
            InitializeComponent();
            dtgSongNumber.Focus();
            InitTitle(functionName);
            currentVersion = version;
            function = functionCollection.GetFunctionInfo(functionName);
            if (function != null)
            {
                this.Text = function.FunctionText;
            }
            else
                this.Close();
            dtgSongNumber.Rows.Clear();
        }

        private void InitTitle(EnumInputTypeName function)
        {

            if (function == EnumInputTypeName.Fes_DISCID)
            {
                colSongNumber.HeaderText = "Fes_DISCID";
            }
            else if (function == EnumInputTypeName.選曲番号入力)
            {
                colSongNumber.HeaderText = "選曲番号";
            }
            else if (function == EnumInputTypeName.選曲番号入力カラオケ)
            {
                colSongNumber.HeaderText = "選曲番号";
            }

        }

        private void DisableInputEvent()
        {
            if (function.FunctionName == EnumInputTypeName.背景映像コード入力)
            {
                dtgSongNumber.UserDeletedRow -= dtgSongNumber_UserDeletedRow;
                dtgSongNumber.PreviewKeyDown -= dtgSongNumber_PreviewKeyDown;
                dtgSongNumber.KeyPress -= dtgSongNumber_KeyPress;
                dtgSongNumber.EditingControlShowing -= dtgSongNumber_EditingControlShowing;
            }
        }

        private void CopyFromClipbroad()
        {
            string s = Clipboard.GetText();
            string[] lines = s.Split('\n');

            if (lines.Length == 0)
                return;
            // Current row selected 
            int rowIndex = dtgSongNumber.CurrentRow.Index;
            int totalRows = dtgSongNumber.Rows.Count;
            for (int i = 0; i < lines.Length; i++)
            {
                int input = -1;
                // Check data is numeric
                if (Int32.TryParse(lines[i], out input))
                {
                    rowIndex++;

                    if (rowIndex >= totalRows)
                    {
                        dtgSongNumber.Rows.Add();
                    }
                    dtgSongNumber.Rows[rowIndex - 1].Cells[0].Value = lines[i];
                    dtgSongNumber.Rows[rowIndex - 1].Cells[0].Value = input;
                }
            }
        }

        private void dtgSongNumber_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
            {
                CopyFromClipbroad();
            }
        }

        private void dtgSongNumber_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (dtgSongNumber.Rows.Count < 5)
                dtgSongNumber.Rows.Add(5 - dtgSongNumber.Rows.Count);
        }

        private void dtgSongNumber_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(dtgSongNumber_KeyPress);
            if (dtgSongNumber.CurrentCell.ColumnIndex == 0)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(dtgSongNumber_KeyPress);
                }
            }
        }

        private void dtgSongNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void InputSongNumber_Load(object sender, EventArgs e)
        {
            DisableInputEvent();
            dtgSongNumber.Rows.Add(4);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchProcess();
        }

        private void SearchProcess()
        {
            if (!Valid())
                return;
            if (commonBusiness == null)
                commonBusiness = new CommonBusiness();
            if (inputSongNumberBusiness == null)
                inputSongNumberBusiness = new FesSongWithDiscInputSongNumberBusiness();

            bgwProcess = CreateThread();
            bgwProcess.RunWorkerCompleted += BgwProcess_RunWorkerCompleted;
            bgwProcess.DoWork += BgwProcess_DoWork;
            bgwProcess.RunWorkerAsync();
            this.ShowWating();
        }

        private void BgwProcess_DoWork
            (object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            InsertWorkTableTmp();
        }

        private void BgwProcess_RunWorkerCompleted
            (object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (bgwProcess != null)
            {
                bgwProcess.RunWorkerCompleted -= BgwProcess_RunWorkerCompleted;
                bgwProcess.DoWork -= BgwProcess_DoWork;
                bgwProcess.Dispose();
            }
            bgwProcess = null;
            GC.Collect();
            this.ClosedWaiting();

            if (IsActive)
                this.Close();
        }

        private bool Valid()
        {
            dtgSongNumber.EndEdit();
            songNumberList.Clear();
            foreach (DataGridViewRow row in dtgSongNumber.Rows)
            {
                if (row.Cells[0].Value == null || row.Cells[0].Value !=null && string.IsNullOrWhiteSpace(row.Cells[0].Value.ToString()))
                    continue;
                songNumberList.Add(row.Cells[0].Value.ToString().Trim());
            }

            if (songNumberList.Count == 0)
            {
                return false;
            }

            return true;
        }

        private void InsertWorkTableTmp()
        {
            try
            {
                // Truncate SongNumber tmp table
                inputSongNumberBusiness.TruncateInputSongNumberTableTmp();

                inputSongNumberBusiness.InsertSongNumberTableTmp(function, songNumberList);
                // Insert song number 
                InsertFesAssigmentSongTableTmp();

                IsActive = true;
            }
            catch (Exception ex)
            {
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
                    MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGE038), error.LogTime, error.ModuleName, error.ErrorMessage, error.FilePath), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }
        }

        private void InsertFesAssigmentSongTableTmp()
        {
            try
            {
                // Step1: truncdate table work
                inputSongNumberBusiness.TruncateFesSongWithDiscWorkTable(function, currentVersion);
                // Step2: insert tmp table
                inputSongNumberBusiness.InsertFesSongWithDiscWorkTable(function, currentVersion);
            }
            catch (Exception ex)
            {
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
                    MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGE038), error.LogTime, error.ModuleName, error.ErrorMessage, error.FilePath), GetResources.GetResourceMesssage(Constants.ERROR_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)
            {
                btnSearch_Click(null, null);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
