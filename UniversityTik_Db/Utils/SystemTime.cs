using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityTik_Db.Utils
{
    public static class SystemTime
    {
        private static DateTime? _overriddenNowValue = null;
        private static DateTime? _overriddenTodayValue = null;

        public static void OverrideSystemTime(DateTime overriddenNowValue)
        {
            _overriddenNowValue = overriddenNowValue;
            _overriddenTodayValue = overriddenNowValue.Date;
        }


        public static DateTime Now()
        {
            //overrided value from test
            if (_overriddenNowValue.HasValue)
            {
                return _overriddenNowValue.Value;
            }

            //real value
            return DateTime.Now;
        }

        public static DateTime Today()
        {
            //overrided value from test
            if (_overriddenTodayValue.HasValue)
            {
                return _overriddenTodayValue.Value;
            }

            //valore reale
            return DateTime.Today;
        }
    }
}
