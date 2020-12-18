using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityTik_Db.Models
{
   public class EnrollmentModel
    {
        public int EnrollmentId { get; set; }

        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public int? Grade { get; set; }
    }
}
