using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityTik_Db.Models;

namespace UniversityTik_Db.Domain.Search
{
   //[StudentSearchCriteriaAllowed]
   public class StudentSearchCriteria
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IQueryable<Student> ApplySearchCriteriaFilter(IQueryable<Student> source)
        {
            source = source.Where((Student x) => (String.IsNullOrWhiteSpace(FirstName) || x.Name.Equals(FirstName))
                                            && (String.IsNullOrWhiteSpace(LastName) || x.Surname.Equals(LastName))

                     );

            return source;
        }

    }
}
