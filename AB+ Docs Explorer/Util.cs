using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListViewItem;

namespace AB__Docs_Explorer
{
    public static class Util
    {
        public static ListViewSubItem AddSubItemWithName(this ListViewItem coll, string name, string text, Color? forecolor = null)
        {
            var itm = new ListViewSubItem(coll, text);
            itm.Name = name;
            if (forecolor != null)
            {
                coll.UseItemStyleForSubItems = false;
                itm.ForeColor = (Color)forecolor;
            }
            return coll.SubItems.Add(itm);
        }

        public static int GetColumnIndexFromPoint(this ListView lv, Point p)
        {
            int colindex = -1;
            int totalw = 0;

            foreach (ColumnHeader item in lv.Columns)
            {
                if (p.X > totalw && p.X < totalw + item.Width)
                {
                    colindex = item.DisplayIndex;
                    break;
                }
                else
                {
                    totalw += item.Width;
                }
            }

            return colindex;
        }

        public static int IndexOfKey<TKey, TValue>(this Dictionary<TKey, TValue> dic, TKey key)
        {
            for (int i = 0; i < dic.Count; i++)
            {
                if (dic.Keys.ElementAt(i).Equals(key))
                {
                    return i;
                }
            }
            return -1;
        }

        public static String ToHex(this Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        public static bool EqualsIgnore(this string stra, string strb, bool ignorecase)
        {
            return stra.Equals(strb, ignorecase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);
        }

        public static bool CompareComplex(this string str, string val)
        {
            return str.EqualsIgnore(val, true) || str.ToLower().Contains(val.ToLower()) || val.ToLower().Contains(str.ToLower());
        }
    }
}
