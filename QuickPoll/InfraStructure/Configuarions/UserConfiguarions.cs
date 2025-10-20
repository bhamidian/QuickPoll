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
    public class UserConfiguarions : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasKey(u => u.Id);

            builder.HasMany(p => p.Polls)
                   .WithOne(a => a.Admin)
                   .HasForeignKey(a => a.AdminId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
                new Admin{ Id = 1, UserName = "admin", Password = "123"}
            );


           
        }
    }
}
