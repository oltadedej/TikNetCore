using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityTik_Db.Configuration
{
   public class CacheConfiguration
    {
        public int CacheValidityMinutes { get; set; }
        public bool IsDebugMode { get; set; }
        public int DebugIDApplication { get; set; }
    }
}
