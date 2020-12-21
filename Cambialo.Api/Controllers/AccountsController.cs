using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cambialo.Api.Models.Requests;
using Cambialo.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cambialo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountsController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest model)
        {
            return Ok(await accountService.RegisterAsync(model));
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateRequest model)
        {

            var result = await accountService.AuthenticateAsync(model);

            if (!result.Succeeded)
            {
                return NotFound(result.Message); 
                
            }
            return Ok(result);
        }
    }
}
