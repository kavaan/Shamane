using Microsoft.EntityFrameworkCore;
using Shamane.DataAccess.Repositories;
using Shamane.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace Shamane.DataAccess.MSSQL.Repositories
{
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        public CityRepository(DbContext dbContext, IPrincipal principal) : base(dbContext,principal)
        {
        }

        public IEnumerable<City> GetCities(Guid provinceId)
        {
            var cities = set.Where(c => c.ProvinceId == provinceId);
            return cities;
        }

        public IEnumerable<City> GetCities()
        {
            var cities = set.Include("Province");
            return cities;
        }

    }
}
