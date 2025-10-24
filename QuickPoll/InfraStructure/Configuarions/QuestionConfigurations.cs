using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickPoll.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPoll.InfraStructure.Configuarions
{
    public class QuestionConfigurations : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(q => q.Id);

            builder.HasOne(p => p.Poll)
                .WithMany(q => q.Questions)
                .HasForeignKey(q => q.PollId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Choices)
                .WithOne(q => q.Question)
                .HasForeignKey(c => c.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);






        }
    }
}
