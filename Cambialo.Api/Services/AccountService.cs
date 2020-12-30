using Cambialo.Api.Data.Entities;
using Cambialo.Api.Models.Requests;
using Cambialo.Api.Models.Responses;
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

namespace Cambialo.Api.Services
{
    public class AccountService : IAccountService
    {
        public readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole<Guid>> roleManager;
        private readonly SignInManager<User> signInManager;
        private readonly JWTSettings jwtSettings;

        public AccountService(UserManager<User> userManager,
            RoleManager<IdentityRole<Guid>> roleManager,
            IOptions<JWTSettings> jwtSettings,
            SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.jwtSettings = jwtSettings.Value;
            this.signInManager = signInManager;
        }

        public async Task<Response<string>> RegisterAsync(RegisterRequest registerRequest)
        {
            var user = await userManager.FindByEmailAsync(registerRequest.Email);

            if (user != null)
            {
                return new Response<string>("Usuario no creado.", new List<string>() { "El usuario ya existe."});
            }

            user = new User()
            {
                FirstName = registerRequest.FirstName,
                LastName = registerRequest.LastName,
                Email = registerRequest.Email,
                UserName = registerRequest.Email,
                RegistrationDate = DateTime.UtcNow
            };

            var result = await userManager.CreateAsync(user, registerRequest.Password);

            if (result.Succeeded)
            {
                return new Response<string>("Usuario creado correctamente.", true);
            }

            return new Response<string>("Usuario no creado.", result.Errors
                .Select(e => e.Description).ToList());

            //TODO: Refactorizar esto para usar Wrapper o ResultPatterm o exceptions
        }

        public async Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticateRequest authenticateRequest)
        {
            var user = await userManager.FindByEmailAsync(authenticateRequest.Email);

            if (user == null)
            {
                return new Response<AuthenticationResponse>($"No hay usuario con el email {authenticateRequest.Email}");
            }

            if (!await userManager.CheckPasswordAsync(user, authenticateRequest.Password))
            {
                return new Response<AuthenticationResponse>($"Password incorrecta.");
            }

            var jwt = await GenerateJwtAsync(user);
            var authenticationResponse = new AuthenticationResponse();
            authenticationResponse.JWToken = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new Response<AuthenticationResponse>("Autenticado", authenticationResponse);
        }

        private async Task<JwtSecurityToken> GenerateJwtAsync(User user)
        {
            var userClaims = await userManager.GetClaimsAsync(user);
            var roles = await userManager.GetRolesAsync(user);

            var roleClaims = roles.Select(r => new Claim("roles", r)).ToList();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.FirstName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id.ToString())
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey));
            var signingCredentials = new SigningCredentials(symetricKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: jwtSettings.Issuer,
                audience: jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(jwtSettings.DurationInMinutes));
            return jwtSecurityToken;
        }
    }
}
