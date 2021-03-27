using Festival.Base;
using System.Windows.Forms;
using Festival.Common;
using Festival.ManagementTab.FunctionID;
using Festival.ManagementTab.User;
using Festival.ManagementTab.AuthGroup;
using Festival.ManagementTab.ProjectID;
using Festival.ManagementTab.Authority;
using Festival.ManagementTab.ExecuteManagement;

namespace Festival.ManagementTab
{
    public partial class TabManagement : UserControlBaseAdvance
    {
        public TabManagement()
        {
            InitializeComponent();
            DisableMenu();
        }

        private void DisableMenu()
        {
            foreach (Control ctrl in this.Controls)
            {
                Button btn = ctrl as Button;
                if (btn != null)
                {
                    btn.Enabled = false;
                }
            }
        }

        public override bool ActiveMenuByTagId(string tagId, EnumEditMode editMode)
        {
            return base.ActiveMenuByTagId(tagId, editMode);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.A)
            {
                btnFunctionID_Click(null, null);
            }
            else if (keyData == Keys.B)
            {
                btnUser_Click(null, null);
            }
            else if (keyData == Keys.C)
            {
                btnAuthorityGroup_Click(null, null);
            }
            else if (keyData == Keys.D)
            {
                btnAuthorityAllocate_Click(null, null);
            }
            else if (keyData == Keys.F)
            {
                btnExclusiveManagement_Click(null, null);
            }
            else if (keyData == Keys.E)
            {
                btnProjectID_Click(null, null);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnFunctionID_Click(object sender, System.EventArgs e)
        {
            if (!btnFunctionID.Enabled)
                return;

            FunctionIDMain functionID = new FunctionIDMain();
            functionID.ShowDialog();
        }

        private void btnUser_Click(object sender, System.EventArgs e)
        {
            if (!btnUser.Enabled)
                return;

            UserMain user = new UserMain();
            user.ShowDialog();
        }

        private void btnAuthorityGroup_Click(object sender, System.EventArgs e)
        {
            if (!btnAuthorityGroup.Enabled)
                return;
            AuthGroupMain authGroup = new AuthGroupMain();
            authGroup.ShowDialog();
        }

        private void btnProjectID_Click(object sender, System.EventArgs e)
        {
            if (!btnProjectID.Enabled)
                return;
            ProjectIDMain projectId = new ProjectIDMain();
            projectId.ShowDialog();
        }

        private void btnAuthorityAllocate_Click(object sender, System.EventArgs e)
        {
            if (!btnAuthorityAllocate.Enabled)
                return;
            AuthorityMain auth = new AuthorityMain();
            auth.ShowDialog();
        }

        private void btnExclusiveManagement_Click(object sender, System.EventArgs e)
        {
            if (!btnExclusiveManagement.Enabled)
                return;
            ExecuteMain executeMain = new ExecuteMain();
            executeMain.ShowDialog();
        }
    }
}
