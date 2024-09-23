using AIPFramework.Repository;
using BitPay.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Domain.Transfer.Repositories
{
    public interface ITransferRepository:IRepository<Entities.Transafer>
    {
        Task<ApplicationResponse> SettlementMerchant(long merchantId,string walletAddress);
    }
}
