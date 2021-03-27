using System;
using System.Collections.Generic;
using System.Linq;

namespace Festival.Common
{
    public class ActiveMenuCollection
    {
        public List<MenuEntity> ActiveMenus;
        public ActiveMenuCollection()
        {
            ActiveMenus = new List<MenuEntity>();
        }

        public void Add(MenuEntity menu)
        {
            ActiveMenus.Add(menu);
        }

        public MenuEntity GetMenuByName(string menuName)
        {
            EnumMenusSearchMain menu = EnumMenusSearchMain.None;
            Enum.TryParse(menuName, out menu);
            return ActiveMenus.Where(r => r.MenuName == menu).FirstOrDefault();
        }
    }

    public class MenuEntity
    {
        public string MenuText { get; set; }
        public EnumMenusSearchMain MenuName { get; set; }
    }

    public enum EnumMenusSearchMain
    {
        None,
        btnSearchCondition,
        btnRowSelectUnselect,
        btnAllOn,
        btnAllOff,
        btnAllInPut,
        btnSave,
        btnImportData,
        btnAddNew,
        btnExportFile
    }
}
