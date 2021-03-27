using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FestivalObjects
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
            return functionList.Where(l => l.LyoutName == layOut).FirstOrDefault<LayOutEntity>();
        }

    }
    public class LayOutEntity
    {
        public LayOut LyoutName { get; set; }
        public Control LayoutObject { get; set; }
    }

    public enum LayOut { SearchFestivalContent, UCSearchWiiCommon, TabDatabase, TabManagement }
}
