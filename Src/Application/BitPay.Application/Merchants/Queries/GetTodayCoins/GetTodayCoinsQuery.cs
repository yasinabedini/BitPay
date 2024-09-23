using AIPFramework.Queries;
using BitPay.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Application.Merchants.Queries.GetTodayCoins
{
    public class GetTodayCoinsQuery:IQuery<ApplicationResponse<double>>
    {
        public long MerchantId { get; set; }
    }
}
