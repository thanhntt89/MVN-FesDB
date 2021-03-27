using Festival.Common;
using System.Collections.Generic;
using System.Linq;

namespace Festival.Base
{
    public class MenuMainCollection
    {
        public IList<MenuMainEntity> MenuMains;
        public MenuMainCollection()
        {
            MenuMains = new List<MenuMainEntity>();
        }

        public void Add(MenuMainEntity menuEntity)
        {
            this.MenuMains.Add(menuEntity);
        }

        public EnumEditMode GetEditModeByTagId(string tagId)
        {
            if (this.MenuMains.Count == 0)
                return 0;

            var query = this.MenuMains.Where(r => r.TagId.Equals(tagId));
            if (query == null)
                return 0;
            return query.FirstOrDefault().EditMode;
        }
    }

    public class MenuMainEntity
    {
        public string TagId { get; set; }
        public EnumEditMode EditMode { get; set; }
    }
}
