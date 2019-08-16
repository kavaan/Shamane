using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Shamane.DataAccess.MSSQL.Context;
using Shamane.Domain;
using Shamane.Service.Authentication.Common;
namespace Shamane.Service.Authentication.Service
{
    public interface IDbInitializerService
    {
        /// <summary>
        /// Applies any pending migrations for the context to the database.
        /// Will create the database if it does not already exist.
        /// </summary>
        void Initialize();

        /// <summary>
        /// Adds some default values to the Db
        /// </summary>
        void SeedData();
    }

    public class DbInitializerService : IDbInitializerService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ISecurityService _securityService;

        public DbInitializerService(
            IServiceScopeFactory scopeFactory,
            ISecurityService securityService)
        {
            _scopeFactory = scopeFactory;
            _scopeFactory.CheckArgumentIsNull(nameof(_scopeFactory));

            _securityService = securityService;
            _securityService.CheckArgumentIsNull(nameof(_securityService));
        }

        public void Initialize()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>())
                {
                    // context.Database.Migrate();
                }
            }
        }

        public void SeedData()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>())
                {
                    // Add default roles
                    var adminRole = new Role { Name = CustomRoles.Admin };
                    var userRole = new Role { Name = CustomRoles.User };
                    if (!context.Roles.Any())
                    {
                        context.Add(adminRole);
                        context.Add(userRole);
                        context.SaveChanges();
                    }
                    if (!context.Provinces.Any())
                    {
                        var province = new Province
                        {
                            Name = "مازندران",
                            Id = Guid.Parse("470ed19a-c478-4654-8cc3-5f53cfd0681a"),
                            IsActive = true
                        };
                        context.Add(province);
                        context.SaveChanges();
                        var city = new City
                        {
                            Name = "بابل",
                            Id = Guid.Parse("13357ed9-40d8-4420-9103-12eb20c0e020"),
                            ProvinceId = Guid.Parse("470ed19a-c478-4654-8cc3-5f53cfd0681a"),
                            IsActive = true
                        };
                        context.Add(city);
                        context.SaveChanges();
                    }
                    // Add Admin user
                    if (!context.Users.Any())
                    {
                        var adminUser = new User
                        {
                            Username = "09109117923",
                            Name = "کیوان",
                            Family = "دمیرچی",
                            Address = "موزیرج، ارشاد 11، ابوذر 6، پلاک 7",
                            BirthDate = new DateTime(1995, 08, 02),
                            CityId = Guid.Parse("13357ed9-40d8-4420-9103-12eb20c0e020"),
                            Mobile = "09109117923",
                            DisplayName = "k1",
                            IsActive = true,
                            LastLoggedIn = null,
                            Password = _securityService.GetSha256Hash("k1374"),
                            SerialNumber = Guid.NewGuid().ToString("N")
                        };
                        context.Add(adminUser);
                        context.SaveChanges();

                        context.Add(new UserRole { Role = adminRole, User = adminUser });
                        context.Add(new UserRole { Role = userRole, User = adminUser });
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
