﻿using FarmCentral.Library.Identity.Models;
using FarmCentral.Library.Shared.Identity;
using FarmCentral.Library.Shared.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FarmCentral.Library.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtSettings _jwtSettings;
        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager; 
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
        }
        public async Task<AuthResponse> Login(AuthRequest request)
        {
            //Checks if user exists.
            ApplicationUser? user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                throw new Exception($"User with email: {request.Email} not found.");
            }

            //Attempts sign in
            SignInResult? result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (result.Succeeded == false)
            {
                throw new Exception($"Sign in credentials for {request.Email} are invalid.");
            }

            //Sends token to reply with in a successful login attempt.
            JwtSecurityToken jwtSecurity = await GenerateToken(user);

            AuthResponse response = new AuthResponse
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurity),
                Email = user.Email,
                Address = user.Address,
            };

            return response;
        }

        //Registers the user in the identity db.
        public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            //Creates user from the registration request.
            ApplicationUser user = new ApplicationUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = request.Address,
                EmailConfirmed = true,
                UserName = request.Email
            };

            IdentityResult result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, request.Role);
                return new RegistrationResponse { Id = user.Id };
            }
            else
            {
                var message = string.Join(", ", result.Errors.Select(x => "Code " + x.Code + " Description" + x.Description));

                throw new Exception(message);
            }
        }


        //Generates the token for login using the users claims.
        //Code Attribution
        //Author: Trevoir Williams
        //Link: https://www.udemy.com/course/aspnet-core-solid-and-clean-architecture-net-5-and-up/
        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);

            var userRoleClaims = userRoles.Select(r => new Claim(ClaimTypes.Role, r)).ToList();

            //Creates the entire claim to parse.
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(userRoleClaims);

            //Generates security key required for the JWT
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            //Creates JWT with the corresponding values regarding the user.
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
        //End of code attribution.
    }
}
