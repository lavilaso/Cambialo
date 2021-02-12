using Cambialo.Api.Data;
using Cambialo.Api.Data.Entities;
using Cambialo.Api.Models.Requests;
using Cambialo.Api.Models.Responses;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cambialo.Api.Services
{
    public class ArticlesService : IArticlesService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<User> _userManager;

        public ArticlesService(ApplicationDbContext dbContext, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }


        public async Task<Response<string>> CreateArticleAsync(ArticleRequest request)
        {
            if (!_userManager.Users.Any(u => u.Id == request.UserId))
            {
                return new Response<string>("El usuario no existe.");
            }

            var article = new Article()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                UserId = request.UserId,
                Status = request.Status
            };

            _dbContext.Articles.Add(article);
            await _dbContext.SaveChangesAsync();

            return new Response<string>("Correcto.", true);
        }
    }
}
