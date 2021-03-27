using System.Windows.Forms;
using Festival.Base;
using FestivalBusiness;
using System;
using FestivalUtilities;
using FestivalCommon;
using System.Reflection;

namespace Festival.Common
{
    public partial class FesModeOpen : FormBase
    {
        private CommonBusiness commonBusiness = new CommonBusiness();

        public FesModeOpen(LayOutEntity currentLayout)
        {
            InitializeComponent();

            this.CurrentLayOut = currentLayout;
            this.Text = currentLayout.ModeTitle;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.U)
            {
                btnEdit_Click(null, null);
            }
            else if (keyData == Keys.R)
            {
                btnReadOnly_Click(null, null);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnClosed_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            OpenEdit();
        }

        private void OpenEdit()
        {
            this.Hide();

            try
            {
                string userNameLocking = commonBusiness.GetFesEditLockSatus(this.CurrentLayOut.TagId);
                if (!string.IsNullOrWhiteSpace(userNameLocking))
                {
                    DialogResult rst = MessageBox.Show(string.Format("ユーザー{0} が更新中です。参照モードで表示しますか？", userNameLocking), Constants.ALERT_TITLE_MESSAGE, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rst == DialogResult.Yes)
                        btnReadOnly_Click(null, null);

                    return;
                }

                bool lockStatus = commonBusiness.SetFesEditLock(this.CurrentLayOut.TagId, true);
                if (!lockStatus)
                {
                    MessageBox.Show(string.Format("編集ロックの獲得に失敗しました"), Constants.ERROR_TITLE_MESSAGE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
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
                return;
            }

            FesDisplayCommonMain wii = new FesDisplayCommonMain(this.CurrentLayOut);
            wii.CloseParentFormEvent += ClosedForm;
            wii.ShowDialog();
        }

        private void btnReadOnly_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            this.CurrentLayOut.EditMode = EnumEditMode.ReadOnly;
            FesDisplayCommonMain wii = new FesDisplayCommonMain(this.CurrentLayOut);
            wii.CloseParentFormEvent += ClosedForm;
            wii.ShowDialog();
        }

        public void ClosedForm()
        {
            btnClosed_Click(null, null);
        }
    }
}
