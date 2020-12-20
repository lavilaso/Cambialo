using Cambialo.Api.Data.Entities;
using Cambialo.Api.Models.Requests;
using Cambialo.Api.Models.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
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
                return new Response<string>("Usuario creado correctamente.");
            }

            return new Response<string>("Usuario no creado.", result.Errors
                .Select(e => e.Description).ToList());

            //TODO: Refactorizar esto apra para usar Wrapper o ResultPatterm o exceptions
        }

        /*
        public async Task<string> Authenticate(AuthenticateRequest authenticateRequest)
        {
            var user = await userManager.FindByEmailAsync(authenticateRequest.Email);

            if (user == null)
            {
                return $"No hay usuario con el email {authenticateRequest.Email}";
            }

            if (await !userManager.CheckPasswordAsync(user, authenticateRequest.Password))
            {
                return $"Password incorrecta.";
            }


        }
        */
    }
}
