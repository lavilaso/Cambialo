using Cambialo.Api.Models.Requests;
using Cambialo.Api.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cambialo.Api.Services
{
    public interface IArticlesService
    {
        Task<Response<string>> CreateArticleAsync(ArticleRequest request);
    }
}
