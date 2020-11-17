using Cambialo.Api.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Cambialo.Api.Data
{
    public class Seed
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager,
            ApplicationDbContext dbContext)
        {
            try
            {
                await dbContext.Database.EnsureCreatedAsync();
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
            }

            if (!userManager.Users.Any())
            {
                var user1 = GenerateUser("Luis", "Avila", "avilaluis0@hotmail.com", DateTime.UtcNow);
                var user2 = GenerateUser("Juan", "Avila", "ultron_lmn4@hotmail.com", DateTime.UtcNow);

                try
                {
                    await userManager.CreateAsync(user1, "123456");
                    await userManager.CreateAsync(user2, "123456");
                }
                catch (Exception ex)
                {

                    Debug.WriteLine(ex.Message);
                }

                await dbContext.Articles.AddAsync(GenerateArticle("Celular Moto G 4 Play",
                    "Celular Moto G 4 Play en excelente estado y 4 años de uso.",
                    user1));
                await dbContext.Articles.AddAsync(GenerateArticle("Impresora HP Disject 3050",
                    "Impresora multifuncional con 5 años en excelente estado.",
                    user2));

                try
                {
                    await dbContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {

                    Debug.WriteLine(ex.Message);
                }
            }
        }


        private static User GenerateUser(string firtsName, string lastName, string email, DateTime registrationDate)
        {
            return new User()
            {
                Id = Guid.NewGuid(),
                FirstName = firtsName,
                LastName = lastName,
                Email = email,
                UserName = email,
                RegistrationDate = registrationDate
            };
        }

        private static Article GenerateArticle(string name, string description, User user)
        {
            return new Article()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                Status = ArticleStatus.Available,
                User = user
            };
        }
    }
}
