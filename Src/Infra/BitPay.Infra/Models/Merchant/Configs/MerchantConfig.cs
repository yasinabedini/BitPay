using BitPay.Domain.Member.ValueObjects.Conversion;
using BitPay.Domain.Merchant.ValueObjects.Conversion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Infra.Models.Merchant.Configs
{
    public class MerchantConfig : IEntityTypeConfiguration<Domain.Merchant.Entities.Merchant>
    {
        public void Configure(EntityTypeBuilder<Domain.Merchant.Entities.Merchant> builder)
        {
            builder.Property(t => t.WalletAddress).HasConversion<WalletAddressConversion>();
        }
    }
}
