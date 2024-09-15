using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Infra.Models.Transfer.Configs
{
    public class TransferConfig : IEntityTypeConfiguration<Domain.Member.Entities.Member>
    {
        public void Configure(EntityTypeBuilder<Domain.Member.Entities.Member> builder)
        {
            throw new NotImplementedException();
        }
    }
}
