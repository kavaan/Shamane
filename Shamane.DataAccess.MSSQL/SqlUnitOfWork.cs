using Shamane.DataAccess.MSSQL.Context;
using Shamane.DataAccess.MSSQL.Repositories;
using Shamane.DataAccess.Repositories;
using Shamane.DataAccess.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.DataAccess.MSSQL
{
    public class SqlUnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext applicationDbContext;
        private  ICenterRepository centerRepository;
        private  IProvinceRepository provinceRepository;
        private  ICityRepository cityRepository;
        public SqlUnitOfWork(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public ICenterRepository CenterRepository => centerRepository ??
            (centerRepository = new CenterRepository(applicationDbContext));

        public IProvinceRepository ProvinceRepository=> provinceRepository??
            (provinceRepository = new ProvinceRepository(applicationDbContext));
        public ICityRepository CityRepository=> cityRepository??
            (cityRepository = new CityRepository(applicationDbContext));

        public void Dispose()
        {
            applicationDbContext.Dispose();
        }

        public int SaveChanges()
        {
            return applicationDbContext.SaveChanges();
        }
    }
}
