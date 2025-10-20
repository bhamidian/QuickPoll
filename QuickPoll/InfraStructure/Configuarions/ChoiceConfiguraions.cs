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
    public class ChoiceConfiguraions : IEntityTypeConfiguration<Choice>

    {
        public void Configure(EntityTypeBuilder<Choice> builder)
        {
            builder.HasKey(c => c.Id);


            builder.HasMany(u => u.NormalUsers)
                   .WithOne(c => c.Choice)
                   .HasForeignKey(c => c.ChoiceId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
