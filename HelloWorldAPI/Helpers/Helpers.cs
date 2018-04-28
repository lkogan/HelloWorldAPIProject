using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace HelloWorldAPI.Helpers
{
    public class Helpers
    {

    }

    public static class Extensions
    { 
        public static string FormatDateTimePerCulture(this DateTime dt, CultureInfo ci)
        {
            return dt.ToString(ci.DateTimeFormat.ShortDatePattern + " " + ci.DateTimeFormat.ShortTimePattern);
        }
         
        public static long LongRandom(long min = 0, long max = long.MaxValue)
        {
            Random rand = new Random();
            byte[] buf = new byte[8];
            rand.NextBytes(buf);
            long longRand = BitConverter.ToInt64(buf, 0);

            return (Math.Abs(longRand % (max - min)) + min);
        }
    }
}