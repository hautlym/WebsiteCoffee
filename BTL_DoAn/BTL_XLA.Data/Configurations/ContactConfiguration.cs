using BTL_DoAn.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_KTPM.Data.configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(x => x.ContactId);
            builder.Property(x => x.ContactName).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.NumberPhone).IsRequired();
            builder.Property(x => x.Message).IsRequired();
        }
    }
}
