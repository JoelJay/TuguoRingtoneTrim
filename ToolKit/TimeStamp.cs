using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Utility
{
    public class TimeStamp
    {
    //    public string TimeStampTodate(string s)
    //    {
    //        string timeStamp = s;
    //        DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
    //        long lTime = long.Parse(timeStamp + "0000000");
    //        TimeSpan toNow = new TimeSpan(lTime);
    //        DateTime dtResult = dtStart.Add(toNow);
    //        return dtResult.ToString("yyyy-MM-dd");
    //    }

        /// <summary>
        /// 获得当前时间的时间戳.
        /// </summary>
        /// <returns></returns>
        public static long GetCurTimeStamp()
        {
            DateTime time0 = new DateTime(1970, 1, 1);
            DateTime time= DateTime.Now;
            long aTimeStamp = (time.Ticks - time0.Ticks) / 10000000 - 8 * 60 * 60;
            return aTimeStamp;
        }
    }
}
