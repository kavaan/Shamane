using Shamane.DataAccess.MSSQL.Context;
using Shamane.DataAccess.MSSQL.Repositories;
using Shamane.DataAccess.Repositories;
using Shamane.DataAccess.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace Shamane.DataAccess.MSSQL
{
    public class SqlUnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext applicationDbContext;
        private ICenterRepository centerRepository;
        private IProvinceRepository provinceRepository;
        private ICityRepository cityRepository;
        private IProductRepository productRepository;
        private ICenterProductRepository centerProductRepository;
        private IOrderRepository orderRepository;
        private IUserRepository userRepository;
        private readonly ClaimsPrincipal _principal;
        public SqlUnitOfWork(ApplicationDbContext applicationDbContext, IPrincipal principal)
        {
            this.applicationDbContext = applicationDbContext;
            _principal = principal as ClaimsPrincipal;

        }
        public ICenterRepository CenterRepository => centerRepository ??
            (centerRepository = new CenterRepository(applicationDbContext,_principal));

        public IProvinceRepository ProvinceRepository => provinceRepository ??
            (provinceRepository = new ProvinceRepository(applicationDbContext, _principal));

        public ICityRepository CityRepository => cityRepository ??
            (cityRepository = new CityRepository(applicationDbContext, _principal));

        public IProductRepository ProductRepository => productRepository ??
            (productRepository = new ProductRepository(applicationDbContext, _principal));

        public ICenterProductRepository CenterProductRepository => centerProductRepository ??
            (centerProductRepository = new CenterProductRepository(applicationDbContext, _principal));

        public IOrderRepository OrderRepository => orderRepository ??
            (orderRepository = new OrderRepository(applicationDbContext, _principal));

        public IUserRepository UserRepository => userRepository ??
            (userRepository = new UserRepository(applicationDbContext, _principal));

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
