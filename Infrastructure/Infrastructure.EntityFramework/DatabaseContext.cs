using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.EntityFramework
{
    /// <summary>
    /// Контекст.
    /// </summary>
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        
        /// <summary>
        /// Курсы.
        /// </summary>
        public DbSet<Course> Courses { get; set; }
        
        /// <summary>
        /// Уроки.
        /// </summary>
        public DbSet<Lesson> Lessons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);            
            
            modelBuilder.Entity<Course>()
                .HasMany(u => u.Lessons)
                .WithOne(c=> c.Course)
                .IsRequired();
            
            //modelBuilder.Entity<Course>().HasIndex(c=>c.Name);

            modelBuilder.Entity<Course>().Property(c => c.Name).HasMaxLength(100);
            modelBuilder.Entity<Lesson>().Property(c => c.Subject).HasMaxLength(100);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);   
        }
    }
}