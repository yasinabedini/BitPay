using AIPFramework.Commands;
using AIPFramework.Queries;
using BitPay.Application.DTOs;
using BitPay.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Application.Memeber.Queries.GetMemberMerchant
{
    public class GetMemberMerchantQuery:IQuery<ApplicationResponse<MerchantResult>>
    {
        public long MemberId { get; set; }
    }
}
