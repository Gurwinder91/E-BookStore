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
            builder.HasKey(e => e.Id);

            builder.HasIndex(user => user.Email).IsUnique();

            builder.Property(user => user.Password).IsRequired();
        }
                  
    }
}
