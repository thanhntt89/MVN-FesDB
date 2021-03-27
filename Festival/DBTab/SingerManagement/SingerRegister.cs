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

namespace Festival.DBTab.SingerManagement
{
    public partial class SingerRegister : FormBase
    {
        private SingerManagementBusiness singerManagementBusiness;
        private DataTable tbData = new DataTable();

        private string updateId = string.Empty;
        public SingerRegister()
        {
            InitializeComponent();
        }

        public SingerRegister(string updateId)
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

        private void LoadInit()
        {
            try
            {             
                tbData = singerManagementBusiness.GetSingerDataById(updateId);
                if (tbData.Rows.Count == 0)
                    return;
                DataRow row = tbData.Rows[0];
                txtFes独自歌手ID.ReadOnly = true;
                txtFes独自歌手ID.Text = row["Fes独自歌手ID"].ToString();
                txt歌手名.Text = row["歌手名"].ToString();
                txt歌手名検索用カナ.Text = row["歌手名検索用カナ"].ToString();
                txt歌手名ソート用カナ.Text = row["歌手名ソート用カナ"].ToString();
                txt歌手名ソート用英数.Text = row["歌手名ソート用英数"].ToString();
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
            if (string.IsNullOrEmpty(txtFes独自歌手ID.Text))
            {
                MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGA002), lbl歌手名ソート用英数.Text), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFes独自歌手ID.Focus();
                txtFes独自歌手ID.SelectAll();
                return false;
            }

            if (!Utils.IsNumeric(txtFes独自歌手ID.Text))
            {
                MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGA003), lblFes独自歌手ID.Text), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFes独自歌手ID.Focus();
                txtFes独自歌手ID.SelectAll();
                return false;
            }

            try
            {
                if (string.IsNullOrWhiteSpace(updateId))
                {
                    DataTable dt = singerManagementBusiness.GetSingerDataById(txtFes独自歌手ID.Text);
                    if (dt.Rows.Count != 0)
                    {
                        MessageBox.Show(string.Format("このID:{0} は存在しています。他のIDを入力してください。", txtFes独自歌手ID.Text), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtFes独自歌手ID.Focus();
                        txtFes独自歌手ID.SelectAll();
                        return false;
                    }
                }
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
            return true;
        }

        private void AddNew()
        {
            try
            {
                if (!Valid())
                    return;

                tbData.Rows.Clear();
                if (tbData.Rows.Count == 0)
                    tbData.Rows.Add();

                DataRow updateRow = tbData.Rows[0];

                updateRow["Fes独自歌手ID"] = txtFes独自歌手ID.Text;
                updateRow["歌手名"] = txt歌手名.Text;
                updateRow["歌手名検索用カナ"] = txt歌手名検索用カナ.Text;
                updateRow["歌手名ソート用カナ"] = txt歌手名ソート用カナ.Text;
                updateRow["歌手名ソート用英数"] = txt歌手名ソート用英数.Text;

                singerManagementBusiness.Save(tbData, updateId);

                if (!string.IsNullOrWhiteSpace(updateId))
                {
                    IsActive = true;
                    if (UpdateRowEvent != null)
                    {
                        UpdateRowEvent(tbData);
                    }
                    btnClose_Click(null, null);
                    return;
                }

                txtFes独自歌手ID.Focus();
                txtFes独自歌手ID.Text = string.Empty;
                txt歌手名.Text = string.Empty;
                txt歌手名検索用カナ.Text = string.Empty;
                txt歌手名ソート用カナ.Text = string.Empty;
                txt歌手名ソート用英数.Text = string.Empty;

                if (AddNewRowEvent != null)
                {
                    AddNewRowEvent(tbData);
                }                
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
            if (singerManagementBusiness == null)
                singerManagementBusiness = new SingerManagementBusiness();
            LoadInit();
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

        private void SingerRegister_FormClosing(object sender, FormClosingEventArgs e)
        {
            tbData = null;
            GC.Collect();
        }
    }
}
