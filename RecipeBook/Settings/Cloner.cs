using System;
using System.Collections.Generic;

namespace RecipeBook.Settings
{
    public static class Cloner<T>
    {
        public static void CloneList(List<T> from, List<T> to)
        {
            if (to == null) to = new List<T>();
            if (from == null) from = new List<T>();
            to.Clear();
            foreach (var item in from) to.Add((T)(item as ICloneable).Clone());
        }
    }
}
