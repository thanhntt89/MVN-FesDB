using Festival.Base;
using Festival.Common;
using Festival.DBTab.ExportTsv;
using Festival.DBTab.TieupConfirm;
using System;
using System.Windows.Forms;
using Festival.DBTab.TieupDuplicate;
using Festival.DBTab.FesContent;
using Festival.DBTab.RecommendSong;
using Festival.DBTab.SingerIdChangeManagement;
using Festival.DBTab.SingerManagement;
using Festival.DBTab.RecommendProgramManagement;

namespace Festival.DBTab
{
    public partial class TabDatabase : UserControlBaseAdvance
    {
        public TabDatabase()
        {
            InitializeComponent();
            DisableMenu();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.A)
            {
                btnFestivalContent_Click(null, null);
            }
            else if (keyData == Keys.B)
            {
                btnFestivalTSVoutput_Click(null, null);
            }
            else if (keyData == Keys.C)
            {
                btnGenreTieUpConfirm_Click(null, null);
            }
            else if (keyData == Keys.D)
            {
                btnTieUpDuplicateConfirm_Click(null, null);
            }
            else if (keyData == Keys.F)
            {
                btnFesOriginalSingerManage_Click(null, null);
            }
            else if (keyData == Keys.E)
            {
                btnSingerIDChangeManage_Click(null, null);
            }
            else if (keyData == Keys.G)
            {
                btnRecommendSongmanage_Click(null, null);
            }
            else if (keyData == Keys.H)
            {
                btnRecommendProgramManage_Click(null, null);
            }

            return base.ProcessCmdKey(ref msg, keyData);
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

        private void btnFestivalContent_Click(object sender, EventArgs e)
        {
            if (!btnFestivalContent.Enabled) return;
            CurrentLayout = new LayOutEntity()
            {
                TagId = btnFestivalContent.Tag.ToString(),
                EditTitle = "Festivalコンテンツ＜更新モード＞",
                ReadOnlyTitle = "Festivalコンテンツ＜参照モード＞",
                ModeTitle = string.Format("モード選択＜{0}＞", btnFestivalContent.Text.Remove(btnFestivalContent.Text.Length - 3, 3)),
                LayoutName = LayOut.FesContentMainAdvance,
                LayoutObjectAdvance = new FesContentMainAdvance(),
                EditMode = (EnumEditMode)MainMenuEditModeCollection.GetEditModeByTagId(btnFestivalContent.Tag.ToString())
            };
            OpenWiiByEditMode(CurrentLayout);
        }

        private void OpenWiiByEditMode(LayOutEntity currentLayout)
        {
            if (currentLayout.EditMode == EnumEditMode.None || currentLayout.EditMode == EnumEditMode.ReadOnly)
            {
                FesDisplayCommonMain wii = new FesDisplayCommonMain(currentLayout);
                wii.ShowDialog();
            }
            else
            {
                FesModeOpen fesModeOpen = new FesModeOpen(currentLayout);
                fesModeOpen.ShowDialog();
            }
        }

        private void btnFestivalTSVoutput_Click(object sender, EventArgs e)
        {
            if (!btnFestivalTSVoutput.Enabled) return;

            FesTSVExportMain fesTSVExport = new FesTSVExportMain();
            fesTSVExport.ShowDialog();
        }


        public override bool ActiveMenuByTagId(string tagId, EnumEditMode editMode)
        {
            return base.ActiveMenuByTagId(tagId, editMode);
        }

        private void btnRecommendSongmanage_Click(object sender, EventArgs e)
        {
            if (!btnRecommendSongmanage.Enabled) return;
            CurrentLayout = new LayOutEntity()
            {
                TagId = btnRecommendSongmanage.Tag.ToString(),
                EditTitle = "おすすめ曲管理＜更新モード＞",
                ReadOnlyTitle = "おすすめ曲管理＜参照モード＞",
                ModeTitle = string.Format("モード選択＜{0}＞", btnRecommendSongmanage.Text.Remove(btnRecommendSongmanage.Text.Length - 3, 3)),
                LayoutName = LayOut.RecommendSongMainAdvance,
                LayoutObjectAdvance = new RecommendSongMainAdvance(),
                EditMode = MainMenuEditModeCollection.GetEditModeByTagId(btnRecommendSongmanage.Tag.ToString())
            };
            OpenWiiByEditMode(CurrentLayout);
        }

        private void TabDatabase_Load(object sender, EventArgs e)
        {

        }

        private void btnSingerIDChangeManage_Click(object sender, EventArgs e)
        {
            if (!btnSingerIDChangeManage.Enabled) return;
            SingerIdChangeManagementMain singerIdChangeManagementMain = new SingerIdChangeManagementMain();
            singerIdChangeManagementMain.ShowDialog();
        }

        private void btnFesOriginalSingerManage_Click(object sender, EventArgs e)
        {
            if (!btnFesOriginalSingerManage.Enabled) return;
            SingerManagementMain singerManagementMain = new SingerManagementMain();
            singerManagementMain.ShowDialog();
        }

        private void btnRecommendProgramManage_Click(object sender, EventArgs e)
        {
            if (!btnRecommendProgramManage.Enabled) return;
            RecommendProgramMain recommendProgramMain = new RecommendProgramMain();
            recommendProgramMain.ShowDialog();
        }

        private void btnGenreTieUpConfirm_Click(object sender, EventArgs e)
        {
            if (!btnGenreTieUpConfirm.Enabled) return;
            TieupConfirmMain fesTSVExport = new TieupConfirmMain();
            fesTSVExport.ShowDialog();
        }

        private void btnTieUpDuplicateConfirm_Click(object sender, EventArgs e)
        {
            if (!btnTieUpDuplicateConfirm.Enabled) return;
            TieupDuplicateMain fesTSVExport = new TieupDuplicateMain();
            fesTSVExport.ShowDialog();
        }
    }
}
