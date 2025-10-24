using Microsoft.EntityFrameworkCore;
using QuickPoll.Domain.Entities;
using QuickPoll.InfraStructure.Configuarions;

namespace QuickPoll.InfraStructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Choice> Choices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB;Database=QuickPollDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new AdminConfiguration());
            modelBuilder.ApplyConfiguration(new NormalUserConfiguration());
            modelBuilder.ApplyConfiguration(new PollConfigurations());
            modelBuilder.ApplyConfiguration(new QuestionConfigurations());
            modelBuilder.ApplyConfiguration(new ChoiceConfigurations());
        }
    }
}
