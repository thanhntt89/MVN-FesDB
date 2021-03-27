using Festival.Base;
using FestivalCommon;
using System.Collections.Generic;
using System.Linq;

namespace Festival.Common
{
    public class LayoutCollection
    {
        private IList<LayOutEntity> functionList;
        public LayoutCollection()
        {
            functionList = new List<LayOutEntity>();
        }

        public void Add(LayOutEntity function)
        {
            functionList.Add(function);
        }

        /// <summary>
        /// Get layout by layout
        /// </summary>
        /// <param name="layOut"></param>
        /// <returns></returns>
        public LayOutEntity GetLayOut(LayOut layOut)
        {
            return functionList.Where(l => l.LayoutName == layOut).FirstOrDefault<LayOutEntity>();
        }
    }

    public class LayOutEntity
    {
        public DisVersion Version { get; set; }
        public LayOut LayoutName { get; set; }
        public EnumEditMode EditMode { get; set; }
        public UserControlBaseAdvance LayoutObjectAdvance { get; set; }
        public string ReadOnlyTitle { get; set; }
        public string EditTitle { get; set; }
        public string ModeTitle { get; set; }
        public string TagId { get; set; }
    }   

    public enum LayOut { FesContentMainAdvance, RecommendSongMainAdvance, FesVideoAssigmentMainAdvance, FesSongWithDiscMainAdvance, DISCEquippedSongManagementV1, DISCEquippedSongManagementV2, FesVideoAddDeleteMainAdvance, FesSongAddDeleteMainAdvance, FesChapterAddDeleteMainAdvance }
}
