using System;
using System.Collections.Generic;
using System.Text;

namespace Afonsoft.Amadeus
{
    public class DateTimeHelper
    {
        public static DateTime UnixEpoch()
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        }

        public static DateTime FromMillisecondsSinceUnixEpoch(long milliseconds)
        {
            return UnixEpoch().AddMilliseconds(milliseconds).ToUniversalTime();
        }

        public static long ToMillisecondsSinceUnixEpoch(DateTime dateTime)
        {
            return (long)(dateTime - UnixEpoch()).TotalMilliseconds;
        }

        public static long CurrentUnixTimeMillis()
        {
            return ToMillisecondsSinceUnixEpoch(DateTime.Now);
        }
    }
}