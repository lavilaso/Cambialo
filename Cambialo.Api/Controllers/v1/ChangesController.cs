using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cambialo.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ChangesController : BaseApiController
    {
        [HttpGet]
        public string Get()
        {
            return "Test";
        }
    }
}
