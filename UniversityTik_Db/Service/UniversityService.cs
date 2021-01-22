using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityTik_Db.DAL;
using UniversityTik_Db.Domain;
using UniversityTik_Db.Domain.Search;
using UniversityTik_Db.Models;
using UniversityTik_Db.Service.Contract;
using UniversityTik_Db.Utils;
using Utf8Json;

namespace UniversityTik_Db.Service
{
 public class UniversityService : BaseService<UniversityService> , IUniversityService
    {

        private readonly string ServiceName = nameof(UniversityService);
        private readonly string ModelName = "University";
        private readonly UniversityContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<UniversityService> _logger;
        public UniversityService(UniversityContext phoneBookContext, IMapper mapper, ILogger<UniversityService> logger) : base(phoneBookContext, mapper, logger)
        {
            this._dbContext = phoneBookContext ?? throw new ArgumentNullException(nameof(phoneBookContext));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<EnEntityExistsStatus> StudentExistsAsync(int StudentId)
        {
            _logger.LogInformation($"Checking if {typeof(Student).Name} with id: {StudentId} exists");
            if (StudentId < 1)
            {
                _logger.LogError($"Validation error while checking if {typeof(Student).Name} exists. {typeof(Student).Name} with student id: {StudentId} is not valid");
                return EnEntityExistsStatus.BadRequest;
            }
            return await _dbContext.Student.AsNoTracking().AnyAsync(c => c.StudentId == StudentId) ? EnEntityExistsStatus.Found : EnEntityExistsStatus.NotFound;
        }
        public async Task<StudentModel> GetStudentAsync(int id)
        {
            _logger.LogInformation($"Searching for {typeof(Student).Name} with ID: {id}");
            if (id < 1)
            {
                _logger.LogError($"Validation error while searching for {typeof(Student).Name}. {typeof(Student)} with id: {id} is not valid");
                return null;
            }
            Student student = await _dbContext.Student.AsNoTracking().FirstOrDefaultAsync(i => i.StudentId == id);
            if (student != null)
            {
                return _mapper.Map<StudentModel>(student);
            }
            else
            {
                _logger.LogWarning($"No result found. Searching for {typeof(Student).Name} with id: {id}");
            }
            return null;
        }

        public async Task<StudentModel> CreateStudentAsync(StudentModel item)
        {
            _logger.LogInformation($"Creating new {typeof(Student).Name}");
            Student student = _mapper.Map<Student>(item);
            await AddAsync(student);
            if (await this.SaveChangesAsync())
            {
                return _mapper.Map<StudentModel>(student);
            }
            else
            {
                _logger.LogError($"Save new {typeof(Student).Name} error. {typeof(Student).Name} parameters: {JsonSerializer.ToJsonString(item)}");
            }
            return null;

        }

        public async Task<StudentModel> UpdateStudentAsync(int studentId, StudentModel item)
        {
            _logger.LogInformation($"Updating {typeof(Student).Name} with id: {studentId}");

            Student student = await _dbContext.Student.AsNoTracking().FirstOrDefaultAsync(c => c.StudentId == studentId);

            if (student == null)
            {
                _logger.LogWarning($"Update {typeof(Student).Name} failed. {typeof(Student).Name} with id: {studentId} not found");
                return null;
            }
            _mapper.Map(item, student);
            _dbContext.Entry(student).State = EntityState.Modified;
            if (await this.SaveChangesAsync())
            {
                return _mapper.Map<StudentModel>(student);
            }
            else
            {
                _logger.LogError($"Update {typeof(Student).Name} error. {typeof(Student).Name} with id: {studentId} and parameters: {JsonSerializer.ToJsonString(item)}");
            }
            return null;

        }


        public async Task<IEnumerable<StudentModel>> SearchStudentsAsync(StudentSearchCriteria searchCriteria)
        {

            IQueryable<Student> query = _dbContext.Student.AsNoTracking();
            query = searchCriteria.ApplySearchCriteriaFilter(query);
            List<Student> students = await query.ToListAsync();
            if (!students.IsNullOrEmpty())
            {
                return _mapper.Map<IEnumerable<StudentModel>>(students);
            }
            else
            {
                _logger.LogWarning($"No result found. Searching for {typeof(Student).Name} Type with search parameters: {JsonSerializer.ToJsonString(searchCriteria)}");
            }
            return null;
        }



        public async Task<bool> DeleteStudentAsync(int studentId)
        {
            _logger.LogInformation($"Deleting {typeof(Student).Name}");
            Student student = await _dbContext.Student.AsNoTracking().FirstOrDefaultAsync(i => i.StudentId == studentId);
            if (student == null)
            {
                _logger.LogWarning($"Delete {typeof(Student).Name} failed. {typeof(Student).Name} with Id: {studentId}");
                return false;
            }
            Delete(student);
            if (await this.SaveChangesAsync())
            {
                return true;
            }
            else
            {
                _logger.LogError($"Delete {typeof(Student).Name} error. {typeof(Student).Name} with Id: {studentId}");
            }
            return false;
        }


        public async Task<CourseModel> MaximumCourse(DateTime dt1, DateTime dt2)
        {

            //var maximumCourse =  this._dbContext.Student.







            return null;
        }
       




    }
}
