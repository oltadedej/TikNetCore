using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityTik_Db.Models
{
   public class StudentModel
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}
