using Shamane.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.DataAccess.Repositories
{
    public interface ICityRepository : IRepository<City>
    {
        IEnumerable<City> GetCities(Guid provinceId);
        IEnumerable<City> GetCities();
    }
}
