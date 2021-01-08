using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UniversityTik_Db.DAL;

namespace UniversityTik_Db.Service
{
    public abstract class BaseService<T> where T : class
    {
        public readonly string ServiceName = nameof(BaseService<T>);
        public readonly UniversityContext _dbContext;
        public readonly IMapper _mapper;
        public readonly ILogger _logger;


        public async Task AddAsync<TEntity>(TEntity entity) where TEntity : class
        {

            await _dbContext.Set<TEntity>().AddAsync(entity);
        }


        public BaseService(UniversityContext dbContext,
                                     IMapper mapper,
                                     ILogger logger
                                   )
        {
            this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this._logger = logger ?? throw new ArgumentNullException(nameof(_logger));
        }


        //ADD LOG ERRORS HERE

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {

            _dbContext.Set<TEntity>().Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {

            try
            {
                return (await _dbContext.SaveChangesAsync()) > 0;
            }
            catch (Exception ex)
            {

                return false;
            }
        }


    }
}
