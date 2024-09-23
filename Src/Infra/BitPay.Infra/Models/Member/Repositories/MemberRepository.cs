using BitPay.Domain.Common;
using BitPay.Domain.Member.Entities;
using BitPay.Domain.Member.Repositories;
using BitPay.Infra.Common;
using BitPay.Infra.Context;
using Microsoft.EntityFrameworkCore;
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
        private readonly BitPayDbContext _context;
        public MemberRepository(BitPayDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ApplicationResponse<Domain.Merchant.Entities.Merchant>> GetMemeberMerchant(long memeberId)
        {
            var result =await _context.Merchants.FirstOrDefaultAsync(t => t.MemberId == memeberId && t.IsEnable);
            if (result is null)
            {
                return new ApplicationResponse<Domain.Merchant.Entities.Merchant>
                {
                    Result = new Domain.Merchant.Entities.Merchant(),
                    IsSuccess = true,
                    Message = "پذیرنده ای یافت نشد",
                    ResponseCode = "404"
                };
            }
            return new ApplicationResponse<Domain.Merchant.Entities.Merchant>
            {
                Result = result,
                IsSuccess = true,
                Message = "عملیات واکشی پذیرنده با موفقیت انجام شد",
                ResponseCode = "200"
            };
        }
    }
}
