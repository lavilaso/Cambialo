using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cambialo.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cambialo.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ChangesController : BaseApiController
    {
        private readonly IChangesService changesService;

        public ChangesController(IChangesService changesService)
        {
            this.changesService = changesService;
        }

        [HttpGet("{userId}")]
        public IActionResult Get(Guid userId)
        {
            var result = changesService.GetChangesByUser(userId);

            switch (result.Message)
            {
                case "No data":
                    return NotFound(result);
                case "Recovered data":
                    return Ok(result);
            }
            return BadRequest();
        }
    }
}
