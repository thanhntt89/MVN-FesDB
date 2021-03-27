using DevComponents.DotNetBar;
using System.Collections.Generic;
using System.Linq;

namespace FestivalObjects
{
    public class MenuCommonCollection
    {
        public IList<ButtonItem> menuItems = null;

        public MenuCommonCollection()
        {
            menuItems = new List<ButtonItem>();
        }

        public void Add(ButtonItem item)
        {
            menuItems.Add(item);
        }

        public ButtonItem GetMenu(ButtonItem item)
        {
            return menuItems.Where(m => m.Name.Equals(item.Name)).FirstOrDefault<ButtonItem>();
        }
    }
}
