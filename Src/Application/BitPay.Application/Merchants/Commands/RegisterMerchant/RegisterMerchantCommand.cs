using AIPFramework.Commands;
using BitPay.Domain.Common;
using BitPay.Domain.Merchant.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Application.Merchants.Commands.RegisterMerchant
{
    public class RegisterMerchantCommand:ICommand<ApplicationResponse>
    {
        public string MerchantName { get;  set; }
        public string Description { get;  set; }
        public string WalletAddress { get;  set; }
        public string MerchantCode { get;  set; }
        public long MemberId { get;  set; }

        public RegisterMerchantCommand(string merchantName, string description, string walletAddress, string merchantCode, long memberId)
        {
            MerchantName = merchantName;
            Description = description;
            WalletAddress = walletAddress;
            MerchantCode = merchantCode;
            MemberId = memberId;
        }
    }
}
