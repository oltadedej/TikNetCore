using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityTik_Db.Domain;
using UniversityTik_Db.Models;

namespace UniversityTik.Profiles
{
    public class EnrollmentProfile:Profile
    {
        public EnrollmentProfile()
        {
            CreateMap<Enrollment, EnrollmentModel>().ReverseMap();
        }
    }
}
