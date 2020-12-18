using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UniversityTik_Db.Domain
{
  public  class Enrollment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EnrollmentId { get; set; }

        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public int? Grade { get; set; }

        public Student student { get; set; }
        public Course course { get; set; }
    }
}
