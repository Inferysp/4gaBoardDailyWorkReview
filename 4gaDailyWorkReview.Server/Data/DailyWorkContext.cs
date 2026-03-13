using Microsoft.EntityFrameworkCore;
using _4gaDailyWorkReview.Server.Models;

namespace _4gaDailyWorkReview.Server.Data
{
    public class DailyWorkContext : DbContext
    {
        public DailyWorkContext (DbContextOptions<DailyWorkContext> options)
            : base(options)
        {
        }
        //public DbSet<Card> Cards => Set<Card>();

        public DbSet<Card> Cards { get; set; } = default!;
        public DbSet<Project> Projects { get; set; } = default!;

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Project>().ToTable("projects");
        //}

        //Wymaga zmigowania bazy
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Project>().Property(p => p.CreatedAt).HasColumnName("CreatedAt");
        //}


    }
}
