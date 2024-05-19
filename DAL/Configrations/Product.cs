using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configrations
{
    public class ProductConfigrations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Sold).HasDefaultValue(0);
            builder.Property(p=>p.RattingQty).HasDefaultValue(0);
            builder.Property(p=>p.RattingAve).HasDefaultValue(0);
        }
    }
}
