using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cambialo.Api.Models.Requests;
using Cambialo.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cambialo.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ArticlesController : BaseApiController
    {
        private readonly IArticlesService _articleService;

        public ArticlesController(IArticlesService articleService)
        {
            _articleService = articleService;
        }

        [HttpPost]
        public async Task<IActionResult> CrateArticle(ArticleRequest request)
        {
            var result = await _articleService.CreateArticleAsync(request);

            if (result.Message == "El usuario no existe.")
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
