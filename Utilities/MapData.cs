using System;
using System.Collections.Generic;

namespace FestivalUtilities
{
    public static class MapData
    {
        public static void Map<T>(this IEnumerable<T> source, Action<T> func)
        {
            foreach (T i in source)
                func(i);
        }
    }
}
