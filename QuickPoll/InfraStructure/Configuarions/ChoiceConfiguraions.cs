using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickPoll.Domain.Entities;

namespace QuickPoll.InfraStructure.Configuarions
{
    public class ChoiceConfigurations : IEntityTypeConfiguration<Choice>
    {
        public void Configure(EntityTypeBuilder<Choice> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.HasOne(c => c.Question)
                   .WithMany(q => q.Choices)
                   .HasForeignKey(c => c.QuestionId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.NormalUsers)
                   .WithMany(u => u.Choices);

        }
    }
}
