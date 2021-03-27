using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Festival.Common
{
    public class SearchConditionCollection
    {
        public List<Control> searchingConditions;

        public SearchConditionCollection()
        {
            this.searchingConditions = new List<Control>();
        }

        public void Add(Control control)
        {
            this.searchingConditions.Add(control);
        }

        public void Clear()
        {
            this.searchingConditions.Clear();
        }

        public Control GetControlByName(string controlName)
        {
            var query = from ctr in searchingConditions
                        where ctr.Name.Equals(controlName)
                        select ctr;
            if (query.Count() == 0)
                return null;
            else
                return query.First();
        }

        public int Count
        {
            get { return this.searchingConditions.Count; }
        }
    }
}
