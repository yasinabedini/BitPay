using AIPFramework.Repository;
using BitPay.Domain.Common;
using BitPay.Domain.Merchant.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Domain.Member.Repositories
{
    public interface IMemberRepository : IRepository<Entities.Member>
    {
        Task<ApplicationResponse<Merchant.Entities.Merchant>> GetMemeberMerchant(long memeberId);
        
    }
}
