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
        Task<ApplicationResponse<double>> GetTodayConins();
        Task<ApplicationResponse<double>> GetRemainingCoins();
        Task<ApplicationResponse<Transfer.Entities.Transafer>> GetMerchantTransfers(long merchantId);
    }
}
