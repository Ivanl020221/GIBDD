using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitesLibruary
{
    public static class Converting
    {
        public static int ToInt(this object obj) => Convert.ToInt32(obj);
        public static int ToExpInt(this object obj)
        {
            try
            {
                return Convert.ToInt32(obj);
            }
            catch
            {
                return 0;
            }
        }
        public static long ToExpLong(this object obj)
        {
            try
            {
                return Convert.ToInt64(obj);
            }
            catch
            {
                return 0;
            }
        }
        public static long ToLong(this object obj) => Convert.ToInt64(obj);
        public static decimal ToDecimal(this object obj) => Convert.ToDecimal(obj);
        public static DateTime ToDateTime(this object obj) => Convert.ToDateTime(obj);
    }
}
