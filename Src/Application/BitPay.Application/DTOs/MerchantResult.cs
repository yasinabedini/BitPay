using BitPay.Domain.Merchant.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Application.DTOs
{
    public record MerchantResult(string MerchantName, string Description, string WalletAddress, string MerchantCode, long MemberId) { }
}
