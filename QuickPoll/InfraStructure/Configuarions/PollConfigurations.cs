using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickPoll.Domain.Entities;

namespace QuickPoll.InfraStructure.Configuarions
{
    public class PollConfigurations : IEntityTypeConfiguration<Poll>
    {
        public void Configure(EntityTypeBuilder<Poll> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Subject)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.HasOne(p => p.Admin)
                   .WithMany(a => a.Polls)
                   .HasForeignKey(p => p.AdminId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(p => p.Questions)
                   .WithOne(q => q.Poll)
                   .HasForeignKey(q => q.PollId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.NormalUsers)
                   .WithMany(u => u.Polls);




        }
    }
}
