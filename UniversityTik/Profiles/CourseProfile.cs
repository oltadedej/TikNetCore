using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityTik_Db.Domain;
using UniversityTik_Db.Models;

namespace UniversityTik.Profiles
{
    public class CourseProfile:Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseModel>().ReverseMap();
        }
    }
}
