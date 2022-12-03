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
    public class AboutConfiguration : IEntityTypeConfiguration<About>
    {

        public void Configure(EntityTypeBuilder<About> builder)
        {
            builder.HasKey(x => x.ShopId);
            builder.Property(x => x.ShopId).UseIdentityColumn();
        }
    }
}
