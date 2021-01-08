using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using UniversityTik_Db.Configuration;
using UniversityTik_Db.Domain;
using UniversityTik_Db.Utils;

namespace UniversityTik_Db.Service
{
  public  class StaticCache
    {

        #region Private Property

        private readonly string ServiceName = nameof(StaticCache);
        private readonly ILogger<StaticCache> _logger;
        private readonly CacheConfiguration _configuration;

        private static ReaderWriterLock _lock = new ReaderWriterLock();
        private static int _lockTimeOut = 10000;//10 seconds
        private static DateTime? _lastRefreshCache;
        private static List<ApplicationsAuthorized> _cacheApplicationAuthorized = null;




        #endregion

        #region Constructor

        public StaticCache(ILogger<StaticCache> logger, IOptions<CacheConfiguration> options)
        {
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this._configuration = options.Value;
            LoadOrRefreshInternalCache();
            StartAutomaticCacheRefreshThread();

        }
        #endregion

        #region implementation

        public void LoadOrRefreshInternalCache()
        {
            _lock.AcquireWriterLock(_lockTimeOut);
            try
            {
                //start/reset cache
                _cacheApplicationAuthorized = LoadApplicationsAuthorized();
                _lastRefreshCache = SystemTime.Now();

            }
            finally
            {
                _lock.ReleaseWriterLock();
            }
        }


        public void StartAutomaticCacheRefreshThread()
        {
            //configuration di update
            int checkIntervalMinutes = 1;

            //configured cache minutes

            int chacheValidityMinutes = _configuration.CacheValidityMinutes;


            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (sender, args) =>
            {
                while (true)
                {
                    try
                    {
                        //check interval every minute
                        Thread.Sleep(checkIntervalMinutes * 60000);

                        //verify conditions to refresh
                        if ((SystemTime.Now() - _lastRefreshCache.Value).TotalMinutes > chacheValidityMinutes)
                        {
                            var freshData = LoadApplicationsAuthorized();
                            _lock.AcquireWriterLock(_lockTimeOut);
                            try
                            {
                                //start/reset cache
                                _cacheApplicationAuthorized = freshData;
                                _lastRefreshCache = SystemTime.Now();
                            }
                            finally
                            {
                                _lock.ReleaseWriterLock();
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _logger.LogError(e.ToString());

                    }
                }
            };

            worker.RunWorkerAsync();
        }



        public static List<ApplicationsAuthorized> GetApplicationsAuthorized()
        {
            _lock.AcquireReaderLock(_lockTimeOut);
            try
            {
                if (_cacheApplicationAuthorized == null)
                {
                    throw new Exception("The cache has not been started calling the method LoadOrRefreshInternalCache.");

                }
                else
                {
                    return _cacheApplicationAuthorized.Select(i => i).ToList();
                }
            }
            finally
            {
                _lock.ReleaseReaderLock();
            }
        }



        private static List<ApplicationsAuthorized> LoadApplicationsAuthorized()
        {
            //thirrsni bazen e te dhenave per te marre autorizimet
            return new List<ApplicationsAuthorized>();
        }


        public void AddAplicationIntoCache(ApplicationsAuthorized applicationToAdd)
        {

            _cacheApplicationAuthorized.Add(applicationToAdd);
        }


        #endregion


    }
}
