﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Shamane.Common.Extensions;
using Shamane.Common.Tools;
using Shamane.DataAccess.UnitOfWorks;
using Shamane.Domain;
using Shamane.Service.Authentication.Common;
using Shamane.Service.Authentication.Dtos;
using Shamane.Service.Definition.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Shamane.Service.Authentication.Service
{
    public interface IUserService
    {
        Task<string> GetSerialNumberAsync(Guid userId);
        Task<User> FindUserAsync(string username, string password);
        Task<User> FindUserAsync(Guid userId);
        Task UpdateUserLastActivityDateAsync(Guid userId);
        Task<User> GetCurrentUserAsync();
        string GetCurrentUserId();
        Task<(bool Succeeded, string Error)> ChangePasswordAsync(User user, string currentPassword,
            string newPassword);
        Task<UserRegisterDto> Register(UserRegisterDto user);
        ProfileDto GetProfile(string id);
        ProfileDto UpdateProfile(string userId, ProfileUpdateDto profile);
    }

    public class UserService : IUserService
    {
        private readonly IAuthenticationUnitOfWork _uow;
        private readonly DbSet<User> _users;
        private readonly DbSet<City> _citites;
        private readonly ISecurityService _securityService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IRolesService rolesService;
        public UserService(
            IAuthenticationUnitOfWork uow,
            ISecurityService securityService,
            IHttpContextAccessor contextAccessor,
            IRolesService rolesService)
        {
            _uow = uow;
            _uow.CheckArgumentIsNull(nameof(_uow));

            _users = _uow.Set<User>();
            _citites = _uow.Set<City>();

            _securityService = securityService;
            _securityService.CheckArgumentIsNull(nameof(_securityService));

            _contextAccessor = contextAccessor;
            _contextAccessor.CheckArgumentIsNull(nameof(_contextAccessor));
            this.rolesService = rolesService;
        }

        public Task<User> FindUserAsync(Guid userId)
        {
            return _users.FindAsync(userId);
        }

        public Task<User> FindUserAsync(string username, string password)
        {
            var passwordHash = _securityService.GetSha256Hash(password);
            return _users.FirstOrDefaultAsync(x => x.Username == username && x.Password == passwordHash);
        }

        public async Task<string> GetSerialNumberAsync(Guid userId)
        {
            var user = await FindUserAsync(userId);
            return user.SerialNumber;
        }

        public async Task UpdateUserLastActivityDateAsync(Guid userId)
        {
            var user = await FindUserAsync(userId);
            if (user.LastLoggedIn != null)
            {
                var updateLastActivityDate = TimeSpan.FromMinutes(2);
                var currentUtc = DateTimeOffset.UtcNow;
                var timeElapsed = currentUtc.Subtract(user.LastLoggedIn.Value);
                if (timeElapsed < updateLastActivityDate)
                {
                    return;
                }
            }
            user.LastLoggedIn = DateTimeOffset.UtcNow;
            await _uow.SaveChangesAsync();
        }

        public string GetCurrentUserId()
        {
            var claimsIdentity = _contextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            var userDataClaim = claimsIdentity?.FindFirst(ClaimTypes.UserData);
            var _userId = userDataClaim?.Value;
            return _userId;
        }

        public Task<User> GetCurrentUserAsync()
        {
            var userId = GetCurrentUserId();
            return FindUserAsync(userId.ToGuid());
        }

        public async Task<(bool Succeeded, string Error)> ChangePasswordAsync(User user, string currentPassword, string newPassword)
        {
            var currentPasswordHash = _securityService.GetSha256Hash(currentPassword);
            if (user.Password != currentPasswordHash)
            {
                return (false, "Current password is wrong.");
            }

            user.Password = _securityService.GetSha256Hash(newPassword);
            user.SerialNumber = Guid.NewGuid().ToString("N"); // To force other logins to expire.
            await _uow.SaveChangesAsync();
            return (true, string.Empty);
        }

        public async Task<UserRegisterDto> Register(UserRegisterDto userDto)
        {
            if (await IsExistsMobileAsync(userDto.Mobile))
            {
                throw new Exception("Exists");
            }
            var normalUserRole = await rolesService.GetRole(CustomRoles.User);
            var userRoles = new UserRole()
            {
                RoleId = normalUserRole.Id
            };
            var user = new User()
            {
                Address = userDto.Address,
                BirthDate = userDto.BirthDate,
                CityId = userDto.CityId.ToGuid(),
                Family = userDto.Family,
                Name = userDto.Name,
                IsActive = true,
                Mobile = userDto.Mobile,
                Password = _securityService.GetSha256Hash(userDto.Password),
                Username = userDto.Mobile,
                Image = userDto.Image,
                UserRoles = new List<UserRole>() { userRoles },
                SerialNumber = Guid.NewGuid().ToString("N"),
                CreatedAt = DateTime.Now,
                DisplayName = userDto.Mobile,
                CreatedBy = Guid.Empty
            };
            var result = await _users.AddAsync(user);
            var saveChnage = await _uow.SaveChangesAsync();
            userDto.Id = user.Id.ToString();
            userDto.Password = null;
            return userDto;
        }

        public async Task<bool> IsExistsMobileAsync(string mobile)
        {
            var user = await _users.FirstOrDefaultAsync(x => x.Mobile == mobile);
            return user != null;
        }

        public User Get(string id)
        {
            var user = _users.FirstOrDefault(x => x.Id == id.ToGuid());
            return user;
        }

        public ProfileDto GetProfile(string id)
        {
            var user = _users.Include("City").Include("City.Province")
                .FirstOrDefault(x => x.Id == id.ToGuid());
            var profileDto = ObjectEx.ShallowCopy<ProfileDto>(user);

            profileDto.BirthDate = user.BirthDate ?? null;
            profileDto.CityId = user.CityId.ToString();
            profileDto.CityName = user.City.Name;
            profileDto.ProvinceId = user.City.Province.Id.ToString();
            profileDto.ProvinceName = user.City.Province.Name;
            profileDto.Id = user.Id.ToString();
            profileDto.FullName = profileDto.Name + " " + profileDto.Family;
            return profileDto;
        }

        public ProfileDto UpdateProfile(string userId, ProfileUpdateDto profile)
        {
            var user = _users.FirstOrDefault(x => x.Id == userId.ToGuid());
            if (userId == null)
            {
                //exception
            }
            if (isDuplicatedUsername(userId, profile.Username))
            {
                //exception
            }
            if (isDuplicatedMobile(userId, profile.Mobile))
            {
                //exception
            }
            City city = null;
            if (profile.CityId.IsValidGuid())
            {
                city = _citites.Include("Province").FirstOrDefault(x => x.Id == profile.CityId.ToGuid());
                if (city == null)
                {
                    //exception
                }
            }
            else
            {
                //exception
            }
            user.Address = profile.Address;
            user.Name = profile.Name;
            user.Family = profile.Family;
            user.BirthDate = profile.BirthDate;
            user.CityId = profile.CityId.ToGuid();
            user.Family = profile.Family;
            user.Image = profile.Image;
            user.Mobile = profile.Mobile;
            user.Username = profile.Username;
            user.SerialNumber = Guid.NewGuid().ToString("N");
            user.UpdateBy = GetCurrentUserId().ToGuid();
            user.UpdatedAt = DateTime.Now;
            _uow.SaveChanges();
            var profileDto = ObjectEx.ShallowCopy<ProfileDto>(profile);
            profileDto.CityId = city.Id.ToString();
            profileDto.CityName = city.Name;
            profileDto.ProvinceId = city.ProvinceId.ToString();
            profileDto.ProvinceName = city.Province.Name;
            profileDto.FullName = profile.Name + " " + profile.Family;
            profileDto.Id = userId;
            return profileDto;
        }

        private bool isDuplicatedMobile(string userId, string mobile)
        {
            var user = _users.FirstOrDefault(x => x.Mobile == mobile);
            if (user != null && user.Id != userId.ToGuid())
            {
                return true;
            }
            return false;
        }
        private bool isDuplicatedUsername(string userId, string username)
        {
            var user = _users.FirstOrDefault(x => x.Username.ToLower() == username.ToLower());
            if (user != null && user.Id != userId.ToGuid())
            {
                return true;
            }
            return false;
        }
        private bool isValidPassword(User user, string password)
        {
            throw new NotImplementedException();
        }
    }
}
