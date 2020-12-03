using Cambialo.Api.Data.Entities;
using Cambialo.Api.Models.Requests;
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

        public async Task<int> AuthenticateAsync(AuthenticateRequest authenticateRequest)
        {
            return await Task.FromResult<int>(0);
        }

        public async Task<int> RegisterAsync(RegisterRequest registerRequest)
        {
            return await Task.FromResult<int>(0);
        }
    }
}
