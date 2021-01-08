using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UniversityTik_Db.Domain.Search;
using UniversityTik_Db.Models;
using UniversityTik_Db.Utils;

namespace UniversityTik_Db.Service.Contract
{
   public interface IUniversityService
    {
        Task<bool> DeleteStudentAsync(int id);
        Task<StudentModel> UpdateStudentAsync(int idPhoneBook, StudentModel item);
        Task<StudentModel> CreateStudentAsync(StudentModel item);
        Task<StudentModel> GetStudentAsync(int id);
        Task<IEnumerable<StudentModel>> SearchStudentsAsync(StudentSearchCriteria searchCriteria);

        Task<EnEntityExistsStatus> StudentExistsAsync(int Id);


    }
}
