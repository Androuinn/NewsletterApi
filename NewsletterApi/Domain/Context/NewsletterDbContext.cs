using Microsoft.EntityFrameworkCore;
using NewsletterApi.Domain.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace NewsletterApi.Domain.Context
{
    public class NewsletterDbContext : DbContext
    {
        public NewsletterDbContext(DbContextOptions<NewsletterDbContext> options)
            : base(options)
        {
        }
        public DbSet<Subscriber> Subscribers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subscriber>().ToTable("Subscribers");
        }
    }

}
