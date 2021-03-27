using Festival.Base;
using Festival.Common;
using System;
using System.Windows.Forms;
using Festival.DiscVideoTab.FesVideoAssigment;
using Festival.DiscVideoTab.FesSongWithDisc;
using FestivalCommon;
using Festival.DiscVideoTab.FesIndiVidualVideoDisc;
using Festival.DiscVideoTab.FesVideoAddDelete;
using Festival.DiscVideoTab.FesSongAddDelete;
using Festival.DiscVideoTab.FesChapterAddDelete;
using Festival.DiscVideoTab.PackageIDInfo;
using Festival.DiscVideoTab.FesDiskCapacity;

namespace Festival.DiscVideoTab
{
    public partial class TabDis : UserControlBaseAdvance
    {
        public TabDis()
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
                btnFesVideoAssigment_Click(null, null);
            }
            else if (keyData == Keys.B)
            {
                btnFesSongWithDiscV1_Click(null, null);
            }
            else if (keyData == Keys.C)
            {
                btnFesSongWithDiscV2_Click(null, null);
            }
            else if (keyData == Keys.D)
            {
                btnInvidualVideoDISCrecordInfoV1_Click(null, null);
            }
            else if (keyData == Keys.F)
            {
                btnPackageIDInfo_Click(null, null);
            }
            else if (keyData == Keys.E)
            {
                btnInvidualVideoDISCrecordInfoV2_Click(null, null);
            }
            else if (keyData == Keys.G)
            {
                btnesVideoAddDelete_Click(null, null);
            }
            else if (keyData == Keys.H)
            {
                btnFesSongAddDelete_Click(null, null);
            }
            else if (keyData == Keys.I)
            {
                btnFesChapterAddDelete_Click(null, null);
            }
            else if (keyData == Keys.J)
            {
                btnCheckDiskCapacity_Click(null, null);
            }
            
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnFesVideoAssigment_Click(object sender, EventArgs e)
        {
            if (!btnFesVideoAssigment.Enabled)
                return;
            CurrentLayout = new LayOutEntity()
            {
                TagId = btnFesVideoAssigment.Tag.ToString(),
                EditTitle = "個別映像割付＜更新モード＞",
                ReadOnlyTitle = "個別映像割付＜参照モード＞",
                ModeTitle = string.Format("モード選択＜{0}＞", btnFesVideoAssigment.Text.Remove(btnFesVideoAssigment.Text.Length - 3, 3)),
                LayoutName = LayOut.FesVideoAssigmentMainAdvance,
                LayoutObjectAdvance = new FesVideoAssigmentMainAdvance(),
                EditMode = MainMenuEditModeCollection.GetEditModeByTagId(btnFesVideoAssigment.Tag.ToString())
            };
            OpenWiiByEditMode(CurrentLayout);
        }

        private void OpenWiiByEditMode(LayOutEntity currentLayout)
        {
            if (currentLayout == null)
                return;

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

        private void btnFesSongWithDiscV1_Click(object sender, EventArgs e)
        {
            if (!btnFesSongWithDiscV1.Enabled) return;

            CurrentLayout = new LayOutEntity()
            {
                TagId = btnFesSongWithDiscV1.Tag.ToString(),
                EditTitle = "DISC搭載曲管理＜更新モード＞",
                ReadOnlyTitle = "DISC搭載曲管理＜参照モード＞",
                ModeTitle = string.Format("モード選択＜{0}＞", btnFesSongWithDiscV1.Text.Remove(btnFesSongWithDiscV1.Text.Length - 3, 3)),
                LayoutName = LayOut.FesSongWithDiscMainAdvance,
                LayoutObjectAdvance = new FesSongWithDiscMainAdvance(DisVersion.VERSION_NUMBER_V1),
                EditMode = MainMenuEditModeCollection.GetEditModeByTagId(btnFesSongWithDiscV1.Tag.ToString()),
                Version = DisVersion.VERSION_NUMBER_V1
            };

            OpenWiiByEditMode(CurrentLayout);
        }

        private void btnFesSongWithDiscV2_Click(object sender, EventArgs e)
        {
            if (!btnFesSongWithDiscV2.Enabled) return;
            CurrentLayout = new LayOutEntity()
            {
                TagId = btnFesSongWithDiscV2.Tag.ToString(),
                EditTitle = "DISC搭載曲管理＜更新モード＞",
                ReadOnlyTitle = "DISC搭載曲管理＜参照モード＞",
                ModeTitle = string.Format("モード選択＜{0}＞", btnFesSongWithDiscV2.Text.Remove(btnFesSongWithDiscV2.Text.Length - 3, 3)),
                LayoutName = LayOut.FesSongWithDiscMainAdvance,
                LayoutObjectAdvance = new FesSongWithDiscMainAdvance(DisVersion.VERSION_NUMBER_V2),
                EditMode = MainMenuEditModeCollection.GetEditModeByTagId(btnFesSongWithDiscV2.Tag.ToString()),
                Version = DisVersion.VERSION_NUMBER_V2
            };
            OpenWiiByEditMode(CurrentLayout);
        }

        private void btnInvidualVideoDISCrecordInfoV2_Click(object sender, EventArgs e)
        {
            if (!btnInvidualVideoDISCrecordInfoV2.Enabled)
                return;
            FesVideoDiscDisplay fesVideoDiscDisplay = new FesVideoDiscDisplay();
            fesVideoDiscDisplay.ShowDialog();
        }

        private void btnPackageIDInfo_Click(object sender, EventArgs e)
        {
            if (!btnPackageIDInfo.Enabled)
                return;
            PackageIDMain packageIDMain = new PackageIDMain();
            packageIDMain.ShowDialog();
        }

        private void btnesVideoAddDelete_Click(object sender, EventArgs e)
        {
            if (!btnVideoAddDelete.Enabled) return;
            CurrentLayout = new LayOutEntity()
            {
                TagId = btnVideoAddDelete.Tag.ToString(),
                EditTitle = "個別映像DISC追加削除管理＜更新モード＞",
                ReadOnlyTitle = "個別映像DISC追加削除管理＜参照モード＞",
                ModeTitle = string.Format("モード選択＜{0}＞", btnVideoAddDelete.Text.Remove(btnVideoAddDelete.Text.Length - 3, 3)),
                LayoutName = LayOut.FesVideoAddDeleteMainAdvance,
                LayoutObjectAdvance = new FesVideoAddDeleteMainAdvance(),
                EditMode = MainMenuEditModeCollection.GetEditModeByTagId(btnVideoAddDelete.Tag.ToString())
            };
            OpenWiiByEditMode(CurrentLayout);
        }

        private void btnFesSongAddDelete_Click(object sender, EventArgs e)
        {
            if (!btnFesSongAddDelete.Enabled) return;
            CurrentLayout = new LayOutEntity()
            {
                TagId = btnFesSongAddDelete.Tag.ToString(),
                EditTitle = "DISC搭載曲追加削除管理＜更新モード＞",
                ReadOnlyTitle = "DISC搭載曲追加削除管理＜参照モード＞",
                ModeTitle = string.Format("モード選択＜{0}＞", btnFesSongAddDelete.Text.Remove(btnFesSongAddDelete.Text.Length - 3, 3)),
                LayoutName = LayOut.FesSongAddDeleteMainAdvance,
                LayoutObjectAdvance = new FesSongAddDeleteMainAdvance(),
                EditMode = MainMenuEditModeCollection.GetEditModeByTagId(btnFesSongAddDelete.Tag.ToString())
            };
            OpenWiiByEditMode(CurrentLayout);
        }

        private void btnFesChapterAddDelete_Click(object sender, EventArgs e)
        {
            if (!btnFesChapterAddDelete.Enabled) return;
            CurrentLayout = new LayOutEntity()
            {
                TagId = btnFesChapterAddDelete.Tag.ToString(),
                EditTitle = "チャプター追加削除管理＜更新モード＞",
                ReadOnlyTitle = "チャプター追加削除管理＜参照モード＞",
                ModeTitle = string.Format("モード選択＜{0}＞", btnFesChapterAddDelete.Text.Remove(btnFesChapterAddDelete.Text.Length - 3, 3)),
                LayoutName = LayOut.FesChapterAddDeleteMainAdvance,
                LayoutObjectAdvance = new FesChapterAddDeleteMainAdvance(),
                EditMode = MainMenuEditModeCollection.GetEditModeByTagId(btnFesChapterAddDelete.Tag.ToString())
            };
            OpenWiiByEditMode(CurrentLayout);
        }

        private void btnCheckDiskCapacity_Click(object sender, EventArgs e)
        {
            if (!btnCheckDiskCapacity.Enabled)
                return;
            DiskCapacityManagement diskCapacityManagement = new DiskCapacityManagement();
            diskCapacityManagement.ShowDialog();
        }

        private void btnInvidualVideoDISCrecordInfoV1_Click(object sender, EventArgs e)
        {

        }
       
    }
}
