using BTL_DoAn.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_DoAn.Data.Configurations
{
    public class PolicyConfiguration : IEntityTypeConfiguration<Policy>
    {
        public void Configure(EntityTypeBuilder<Policy> builder)
        {
            builder.HasKey(x => x.PolicyId);
            builder.Property(x => x.PolicyId).UseIdentityColumn();
            builder.Property(x => x.PolicyName).IsRequired();
            builder.Property(x => x.Voucher).IsRequired();
        }
    }
}
