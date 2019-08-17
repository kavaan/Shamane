using Microsoft.EntityFrameworkCore;
using Shamane.DataAccess.Repositories;
using Shamane.Domain;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Shamane.DataAccess.MSSQL.Repositories
{
    public class ProvinceRepository : BaseRepository<Province>, IProvinceRepository
    {
        public ProvinceRepository(DbContext dbContext, IPrincipal principal) : base(dbContext,principal)
        {
        }

        public IEnumerable<Province> GetWithCities()
        {
            return set.Include("Cities");
        }
    }
}
