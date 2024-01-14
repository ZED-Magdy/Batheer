using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Batheer.WebUI.Utls
{
    public static class DateTimeExtensions
    {
        public static string TimeAgo(this DateTime dateTime)
        {
            string result = string.Empty;
            var timeSpan = DateTime.Now.Subtract(dateTime);

            if (timeSpan <= TimeSpan.FromSeconds(60))
            {
                result = $"{timeSpan.Seconds} منذ ثانية"; // string.Format("{0} منذ ثانية", timeSpan.Seconds);
            }
            else if (timeSpan <= TimeSpan.FromMinutes(60))
            {
                result = timeSpan.Minutes > 1 ?
                    $"منذ {timeSpan.Minutes} دقائق" :
                    "منذ دقيقة";
            }
            else if (timeSpan <= TimeSpan.FromHours(24))
            {
                result = timeSpan.Hours > 1 ?
                    $"منذ {timeSpan.Hours} ساعات" :
                    "منذ ساعة";
            }
            else if (timeSpan <= TimeSpan.FromDays(30))
            {
                result = timeSpan.Days > 1 ?
                    $"منذ {timeSpan.Days} أيام" :
                    "يوم أمس";
            }
            else if (timeSpan <= TimeSpan.FromDays(365))
            {
                result = timeSpan.Days > 30 ?
                    $"منذ {timeSpan.Days / 30} أشهر" :
                    "منذ شهر";
            }
            else
            {
                result = timeSpan.Days > 365 ?
                    $"منذ {timeSpan.Days / 365} أعوام" :
                    "منذ سنة";
            }

            return result;
        }
    }
}
