﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Shamane.Common.Extensions;
using Shamane.DataAccess.UnitOfWorks;
using Shamane.Domain;
using Shamane.Service.Authentication.Common;
using Shamane.Service.Authentication.Dtos;
using Shamane.Service.Authentication.Service;
using Shamane.Service.Definition.Dto;

namespace Shamane.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [EnableCors("CorsPolicy")]
    public class AccountsController : ControllerBase
    {
        private readonly IUserService _usersService;
        private readonly ITokenStoreService _tokenStoreService;
        private readonly IAuthenticationUnitOfWork _uow;
        private readonly IAntiForgeryCookieService _antiforgery;
        private readonly ITokenFactoryService _tokenFactoryService;
        public AccountsController(
            IUserService usersService,
            ITokenStoreService tokenStoreService,
            ITokenFactoryService tokenFactoryService,
            IAuthenticationUnitOfWork uow,
            IAntiForgeryCookieService antiforgery)
        {
            _usersService = usersService;
            _usersService.CheckArgumentIsNull(nameof(usersService));

            _tokenStoreService = tokenStoreService;
            _tokenStoreService.CheckArgumentIsNull(nameof(tokenStoreService));

            _uow = uow;
            _uow.CheckArgumentIsNull(nameof(_uow));

            _antiforgery = antiforgery;
            _antiforgery.CheckArgumentIsNull(nameof(antiforgery));

            _tokenFactoryService = tokenFactoryService;
            _tokenFactoryService.CheckArgumentIsNull(nameof(tokenFactoryService));
        }

        [HttpPost("")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserRegisterDto user)
        {
            var result = await _usersService.Register(user);
            return Created("", result);
        }


        [HttpPost("Ex")]
        [AllowAnonymous]
        public IActionResult Ex(int n)
        {
            switch (n)
            {
                case 0:
                    return Ok();
                case 1:
                    throw new Exception();
                case 2:
                    throw new Exception("عدد نباید 2 باشد");
                case 3:
                    throw new NotImplementedException();
                case 4:
                    throw new NotImplementedException("این گزینه وجود ندارد");
                case 5:
                    throw new ArgumentException("مقدار ایکس باید عددی زیر 10 باشد");
                case 6:
                    throw new ArgumentNullException("مقدار ایکس وارد نشده است");
                case 7:
                    throw new ArgumentOutOfRangeException("موجودی کافی نیست");

            }
            return Ok();
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDto loginUser)
        {
            if (loginUser == null)
            {
                return BadRequest("user is not set.");
            }

            var user = await _usersService.FindUserAsync(loginUser.Username, loginUser.Password);
            if (user == null || !user.IsActive)
            {
                return Unauthorized();
            }

            var result = await _tokenFactoryService.CreateJwtTokensAsync(user);
            await _tokenStoreService.AddUserTokenAsync(user, result.RefreshTokenSerial, result.AccessToken, null);
            await _uow.SaveChangesAsync();

            _antiforgery.RegenerateAntiForgeryCookies(result.Claims);
            return Ok(new { access_token = result.AccessToken, refresh_token = result.RefreshToken });
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> RefreshToken(JToken jsonBody)
        {
            var refreshTokenValue = jsonBody.Value<string>("refreshToken");
            if (string.IsNullOrWhiteSpace(refreshTokenValue))
            {
                return BadRequest("refreshToken is not set.");
            }

            var token = await _tokenStoreService.FindTokenAsync(refreshTokenValue);
            if (token == null)
            {
                return Unauthorized();
            }

            var result = await _tokenFactoryService.CreateJwtTokensAsync(token.User);
            await _tokenStoreService.AddUserTokenAsync(token.User, result.RefreshTokenSerial, result.AccessToken, _tokenFactoryService.GetRefreshTokenSerial(refreshTokenValue));
            await _uow.SaveChangesAsync();

            _antiforgery.RegenerateAntiForgeryCookies(result.Claims);

            return Ok(new { access_token = result.AccessToken, refresh_token = result.RefreshToken });
        }

        [HttpGet("[action]")]
        public async Task<bool> Logout(string refreshToken)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userIdValue = claimsIdentity.FindFirst(ClaimTypes.UserData)?.Value;

            // The Jwt implementation does not support "revoke OAuth token" (logout) by design.
            // Delete the user's tokens from the database (revoke its bearer token)
            await _tokenStoreService.RevokeUserBearerTokensAsync(userIdValue.ToGuid(), refreshToken);
            await _uow.SaveChangesAsync();

            _antiforgery.DeleteAntiForgeryCookies();

            return true;
        }

        [HttpPut("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto passwordDto)
        {
            var user = await _usersService.GetCurrentUserAsync();
            var result = await _usersService
                .ChangePasswordAsync(user, passwordDto.OldPassword, passwordDto.NewPassword);
            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.Error);
            }
        }


        [HttpGet("[action]"), HttpPost("[action]")]
        public bool IsAuthenticated()
        {
            return User.Identity.IsAuthenticated;
        }

        [HttpGet("[action]"), HttpPost("[action]")]
        public IActionResult UserInfo()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.Claims.Where(c =>
                        c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)
                        .Select(c => c.Value).SingleOrDefault();
            var user = _usersService.GetProfile(userId);
            return Ok(user);
        }

        [HttpPut("")]
        public IActionResult UpdaeProfile(ProfileUpdateDto profile)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var userDataClaim = claimsIdentity?.FindFirst(ClaimTypes.UserData);
            var _userId = userDataClaim?.Value;
            var user = _usersService.UpdateProfile(_userId, profile);
            return Ok(user);
        }

    }
}