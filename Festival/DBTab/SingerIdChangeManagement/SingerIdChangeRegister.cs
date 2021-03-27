using DevComponents.DotNetBar.Controls;
using DevComponents.Editors.DateTimeAdv;
using Festival.Base;
using FestivalBusiness;
using FestivalCommon;
using FestivalObjects;
using FestivalUtilities;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace Festival.DBTab.SingerIdChangeManagement
{
    public partial class SingerIdChangeRegister : FormBase
    {
        private SingerIdChangeManagementBusiness singerIdChangeManagementBusiness;
        private string updateId = string.Empty;
        public SingerIdChangeRegister()
        {
            InitializeComponent();
        }

        public SingerIdChangeRegister(string updateId)
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
                if (string.IsNullOrEmpty(updateId))
                    return;
                SingerIdChangeManagementObject singerManagement = singerIdChangeManagementBusiness.GetSingerIdChangeById(updateId);

                if (singerManagement == null)
                    return;

                txt変更前_歌手ID.Text = singerManagement.変更前_歌手ID.ToString();
                txt変更前_歌手名.Text = singerManagement.変更前_歌手名;
                txt変更前_歌手名検索用カナ.Text = singerManagement.変更前_歌手名検索用カナ;
                txt変更前_歌手名ソート用カナ.Text = singerManagement.変更前_歌手名ソート用カナ;
                txt変更後_歌手ID.Text = singerManagement.変更後_歌手ID.ToString();
                txt変更後_歌手名.Text = singerManagement.変更後_歌手名;
                txt変更後_歌手名検索用カナ.Text = singerManagement.変更後_歌手名検索用カナ;
                txt変更後_歌手名ソート用カナ.Text = singerManagement.変更後_歌手名ソート用カナ;
                dt変更日時.Value = (DateTime)singerManagement.変更日時;
                txt変更利用者ID.Text = singerManagement.変更利用者ID;
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
            if (string.IsNullOrEmpty(txt変更後_歌手ID.Text))
            {
                MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGA002), lbl変更前_歌手ID.Text), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt変更後_歌手ID.Focus();
                txt変更後_歌手ID.SelectAll();
                return false;
            }
            if (string.IsNullOrEmpty(txt変更前_歌手ID.Text))
            {
                MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGA002), lbl変更後_歌手ID.Text), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt変更前_歌手ID.Focus();
                txt変更前_歌手ID.SelectAll();
                return false;
            }

            if (string.IsNullOrEmpty(txt変更利用者ID.Text))
            {
                MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGA002), lbl変更利用者ID.Text), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt変更利用者ID.Focus();
                txt変更利用者ID.SelectAll();
                return false;
            }

            if (dt変更日時.Value == DateTime.MinValue)
            {
                MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGA002), lbl変更日時.Text), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dt変更日時.Focus();
                return false;
            }

            if (!Utils.IsNumeric(txt変更前_歌手ID.Text))
            {
                MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGA003), lbl変更前_歌手ID.Text), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt変更前_歌手ID.Focus();
                txt変更前_歌手ID.SelectAll();
                return false;
            }
            if (!Utils.IsNumeric(txt変更後_歌手ID.Text))
            {
                MessageBox.Show(string.Format(GetResources.GetResourceMesssage(Constants.MSGA003), lbl変更後_歌手ID.Text), GetResources.GetResourceMesssage(Constants.ALERT_TITLE_MESSAGE), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt変更後_歌手ID.Focus();
                txt変更後_歌手ID.SelectAll();
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

                SingerIdChangeManagementObject singerManagement = new SingerIdChangeManagementObject();

                singerManagement.履歴No = updateId;

                if (!string.IsNullOrEmpty(txt変更前_歌手ID.Text))
                    singerManagement.変更前_歌手ID = int.Parse(txt変更前_歌手ID.Text);
                singerManagement.変更前_歌手名 = txt変更前_歌手名.Text;
                singerManagement.変更前_歌手名検索用カナ = txt変更前_歌手名検索用カナ.Text;
                singerManagement.変更前_歌手名ソート用カナ = txt変更前_歌手名ソート用カナ.Text;
                if (!string.IsNullOrEmpty(txt変更後_歌手ID.Text))
                    singerManagement.変更後_歌手ID = int.Parse(txt変更後_歌手ID.Text);
                singerManagement.変更後_歌手名 = txt変更後_歌手名.Text;
                singerManagement.変更後_歌手名検索用カナ = txt変更後_歌手名検索用カナ.Text;
                singerManagement.変更後_歌手名ソート用カナ = txt変更後_歌手名ソート用カナ.Text;
                if (!string.IsNullOrEmpty(dt変更日時.Text))
                    singerManagement.変更日時 = dt変更日時.Value;
                singerManagement.変更利用者ID = txt変更利用者ID.Text;

                singerIdChangeManagementBusiness.Save(singerManagement);
                singerManagement = null;

                GC.Collect();
                IsActive = true;
                btnClearn_Click(null, null);
                txt変更前_歌手ID.Focus();
                // Close form if update data
                if (!string.IsNullOrEmpty(updateId))
                    btnClose_Click(null, null);
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
            if (singerIdChangeManagementBusiness == null)
                singerIdChangeManagementBusiness = new SingerIdChangeManagementBusiness();
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
