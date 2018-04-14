using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HhVacancyViewer.Core.Pg
{
    public partial class HeadHunterDbContext : DbContext
    {
        public virtual DbSet<Vacancies> Vacancies { get; set; }

        public HeadHunterDbContext(DbContextOptions<HeadHunterDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vacancies>(entity =>
            {
                entity.ToTable("vacancies", "hhvac");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });
        }
    }
}
