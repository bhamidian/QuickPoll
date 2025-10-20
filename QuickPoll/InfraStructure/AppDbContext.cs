using Microsoft.EntityFrameworkCore;
using QuickPoll.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPoll.InfraStructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<NormalUser> NormalUsers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Choice> Choices { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=QuickPollDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Poll>(builder =>
            {
                builder.HasMany(p => p.Questions)
                       .WithOne(q => q.Poll)
                       .HasForeignKey(q => q.PollId)
                       .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Question>(builder =>
            {
                builder.HasMany(q => q.Choices)
                       .WithOne(c => c.Question)
                       .HasForeignKey(c => c.QuestionId)
                       .OnDelete(DeleteBehavior.Restrict);
            });
        }
        

    }
}
