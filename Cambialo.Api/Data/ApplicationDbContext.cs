using Cambialo.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cambialo.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Change> Changes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Change>().HasMany(c => c.RequestedArticles)
                .WithOne(a => a.RequestedInChange).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Change>().HasMany(c => c.OffertedArticles)
                .WithOne(a => a.OfferInChange).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
