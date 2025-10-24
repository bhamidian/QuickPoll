using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickPoll.Domain.Entities;
using QuickPoll.Domain.Enum;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.UserName).IsRequired();
        builder.Property(u => u.Password).IsRequired();

        builder.HasDiscriminator<Role>("Role")
            .HasValue<User>(Role.Guest)
            .HasValue<NormalUser>(Role.NormalUser)
            .HasValue<Admin>(Role.Admin);
    }
}

public class NormalUserConfiguration : IEntityTypeConfiguration<NormalUser>
{
    public void Configure(EntityTypeBuilder<NormalUser> builder)
    {
        builder.HasMany(n => n.Polls)
               .WithMany(p => p.NormalUsers);

        builder.HasMany(n => n.Choices)
               .WithMany(c => c.NormalUsers);

        
    }
}

public class AdminConfiguration : IEntityTypeConfiguration<Admin>
{
    public void Configure(EntityTypeBuilder<Admin> builder)
    {

    }
}
