using EBookStore.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EBookStore.Persistence.Configurations
{
    class UserConfiguration: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);
            builder.Property(user => user.Id).HasDefaultValueSql($"nextval('{DatabaseGlobal.Schema}.auto_increment')");

            builder.HasIndex(user => user.Email).IsUnique();

            builder.Property(user => user.Password).IsRequired();
        }
                  
    }
}
