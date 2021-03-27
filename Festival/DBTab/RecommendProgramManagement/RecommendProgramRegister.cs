using DevComponents.DotNetBar.Controls;
using DevComponents.Editors.DateTimeAdv;
using Festival.Base;
using FestivalBusiness;
using FestivalCommon;
using FestivalUtilities;
using System;
using System.Data;
using System.Reflection;
using System.Windows.Forms;

namespace Festival.DBTab.RecommendProgramManagement
{
    public partial class RecommendProgramRegister : FormBase
    {
        private DataTable dtData = new DataTable();

        private RecommendProgramBusiness recommendProgramBusiness;
        private string updateId = string.Empty;
        public RecommendProgramRegister()
        {
            InitializeComponent();
        }

        public RecommendProgramRegister(string updateId)
        {
            InitializeComponent();
            this.updateId = updateId;
            this.Text = "歌手更新";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClearn_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            foreach (Control ctrl in groupBox1.Controls)
            {
                TextBoxX txt = ctrl as TextBoxX;
                if (txt != null)
                    txt.Text = string.Empty;
                DateTimeInput dt = ctrl as DateTimeInput;
                if (dt != null)
                    dt.Text = string.Empty;
            }
        }

        private void LoadUpdate()
        {
            try
            {
                dtData = recommendProgramBusiness.GetProgramById(updateId);
                if (dtData.Rows.Count == 0)
                    return;
                DataRow row = dtData.Rows[0];
                txtプログラム名.Text = row["プログラム名"].ToString();
                txt備考.Text = row["備考"].ToString();
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

                this.Close();
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            AddNew();
        }

        private void TxtInputText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            base.OnKeyPress(e);
        }

        private bool Valid()
        {
            if (string.IsNullOrEmpty(txtプログラム名.Text))
            {
                MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGA002), lblプログラム名.Text), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtプログラム名.Focus();
                txtプログラム名.SelectAll();
                return false;
            }

            return true;
        }

        private void AddNew()
        {
            try
            {
                if (!Valid())
                    return;

                if (dtData.Rows.Count == 0)
                {
                    dtData.Rows.Add();
                }                    

                DataRow updateRow = dtData.Rows[0];
                updateRow["プログラム名"] = txtプログラム名.Text;
                updateRow["備考"] = txt備考.Text;

                recommendProgramBusiness.Save(dtData, updateId);

                if (!string.IsNullOrWhiteSpace(updateId))
                {
                    IsActive = true;
                    btnClose_Click(null, null);
                    if (UpdateRowEvent != null)
                    {
                        UpdateRowEvent(dtData);
                    }
                    return;
                }

                txtプログラム名.Text = string.Empty;
                txt備考.Text = string.Empty;
                txtプログラム名.Focus();

                if (AddNewRowEvent != null)
                {                   
                    AddNewRowEvent(dtData);
                    dtData.Rows.Clear();
                }
                GC.Collect();                
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

        private void SingerRegister_Load(object sender, EventArgs e)
        {
            if (recommendProgramBusiness == null)
                recommendProgramBusiness = new RecommendProgramBusiness();
            LoadUpdate();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                btnAddNew_Click(null, null);
            }
            else if (keyData == (Keys.Control | Keys.C))
            {
                btnClearn_Click(null, null);
            }
            else if (keyData == (Keys.Control | Keys.E))
            {
                btnClose_Click(null, null);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
