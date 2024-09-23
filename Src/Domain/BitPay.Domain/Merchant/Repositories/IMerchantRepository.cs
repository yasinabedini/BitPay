using AIPFramework.Repository;
using BitPay.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Domain.Merchant.Repositories
{
    public interface IMerchantRepository:IRepository<Entities.Merchant>
    {
        Task<ApplicationResponse<double>> GetTodayCoins(long merchantId);
        Task<ApplicationResponse<double>> GetRemainingCoins(long merchantId);
        Task<ApplicationResponse<List<Transfer.Entities.Transafer>>> GetMerchantTransfers(long merchantId);
    }
}
