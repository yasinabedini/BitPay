using AIPFramework.Queries;
using BitPay.Application.DTOs;
using BitPay.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Application.Merchants.Queries.GetMerchantTransfers
{
    public class GetMerchantTransfersQuery : IQuery<ApplicationResponse<TransferResult>>
    {
        public long MerchantId { get; set; }
    }
}
