using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using QuickPoll.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPoll.InfraStructure.Configuarions
{
    public class PollConfigurations : IEntityTypeConfiguration<Poll>
    {
        public void Configure(EntityTypeBuilder<Poll> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Subject).IsRequired();

            builder.HasOne(a => a.Admin)
            .WithMany(p => p.Polls)
            .HasForeignKey(a => a.AdminId)
            .OnDelete(DeleteBehavior.NoAction);





            builder.HasData(
                new Poll { Id = 1, AdminId = 1, Subject = "new form" });
        }
    }
}
