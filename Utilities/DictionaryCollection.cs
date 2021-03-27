using System.Collections.Generic;
using System.Linq;

namespace FestivalUtilities
{
    public class DictionaryCollection
    {
        private IList<IDictionary<string, object>> dictionaryList;

        public DictionaryCollection()
        {
            dictionaryList = new List<IDictionary<string, object>>();
        }

        public int Count
        {
            get { return this.dictionaryList.Count; }
        }

        /// <summary>
        /// Add item to list
        /// </summary>
        /// <param name="diction"></param>
        public void Add(IDictionary<string, object> diction)
        {
            this.dictionaryList.Add(diction);
        }

        /// <summary>
        /// Distint diction list
        /// </summary>
        /// <returns></returns>
        public List<IDictionary<string, object>> GetDictionariesWithDistint()
        {
            return dictionaryList.GroupBy(x => string.Join("", x.Select(i => string.Format("{0}{1}", i.Key, i.Value)))).Select(x => x.First()).ToList();
        }
    }
}
