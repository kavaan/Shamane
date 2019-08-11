﻿using Shamane.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.DataAccess.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        ICenterRepository CenterRepository { get; }
        IProvinceRepository ProvinceRepository{ get; }
        ICityRepository CityRepository{ get; }
        int SaveChanges();

    }
}