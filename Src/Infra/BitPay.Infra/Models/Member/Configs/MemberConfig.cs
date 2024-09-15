using BitPay.Domain.Member.ValueObjects.Conversion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Infra.Models.Member.Configs
{
    public class MemberConfig : IEntityTypeConfiguration<Domain.Member.Entities.Member>
    {
        public void Configure(EntityTypeBuilder<Domain.Member.Entities.Member> builder)
        {
            builder.Property(t => t.FirstName).HasConversion<PersonNameConversion>();
            builder.Property(t => t.LastName).HasConversion<PersonNameConversion>();
            
            
            builder.Property(t => t.Mobile).HasConversion<PhoneNumberConversion>();
            builder.Property(t => t.NationalCode).HasConversion<NationalCodeConversion>();
        }
    }
}
