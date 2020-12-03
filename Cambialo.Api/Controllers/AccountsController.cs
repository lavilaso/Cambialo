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

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateRequest model)
        {
            return Ok(await Task.FromResult<string>("Test"));
        }
    }
}
