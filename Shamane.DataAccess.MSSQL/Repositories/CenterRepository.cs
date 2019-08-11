using Microsoft.EntityFrameworkCore;
using Shamane.DataAccess.Repositories;
using Shamane.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.DataAccess.MSSQL.Repositories
{
    public class CenterRepository : BaseRepository<Center>, ICenterRepository
    {
        public CenterRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
