using BitPay.Domain.Common;
using BitPay.Domain.Member.Entities;
using BitPay.Domain.Member.Repositories;
using BitPay.Infra.Common;
using BitPay.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemberModel = BitPay.Domain.Member.Entities.Member;

namespace BitPay.Infra.Models.Member.Repositories
{
    public class MemberRepository : BaseRepository<MemberModel>, IMemberRepository
    {
        public MemberRepository(BitPayDbContext context) : base(context)
        {
        }

        public Task<ApplicationResponse<Domain.Merchant.Entities.Merchant>> GetMemeberMerchant(long memeberId)
        {
            throw new NotImplementedException();
        }
    }
}
