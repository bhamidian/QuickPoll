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
    public class NormalUserConfigurations : IEntityTypeConfiguration<NormalUser>
    {
        public void Configure(EntityTypeBuilder<NormalUser> builder)
        {
            builder.HasKey(n => n.Id);

            builder.HasMany(p => p.Polls)
                .WithMany(n => n.NormalUsers);

            builder.HasOne(c => c.Choice)
                .WithMany(n => n.NormalUsers)
                .HasForeignKey(c => c.ChoiceId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.HasData(
                new NormalUser { Id = 2, UserName = "ali", Password = "123" });
                
        }
    }
}
