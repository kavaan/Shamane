using Microsoft.EntityFrameworkCore;
using Shamane.DataAccess.Repositories;
using Shamane.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.DataAccess.MSSQL.Repositories
{
    public class ProvinceRepository : BaseRepository<Province>, IProvinceRepository
    {
        public ProvinceRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Province> GetWithCities()
        {
            return set.Include("Cities");
        }
    }
}
