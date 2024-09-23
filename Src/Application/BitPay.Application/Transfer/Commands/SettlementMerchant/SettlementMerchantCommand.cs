using AIPFramework.Commands;
using BitPay.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Application.Transfer.Commands.SettlementMerchant
{
    public class SettlementMerchantCommand:ICommand<ApplicationResponse>
    {
        public long MerchantId { get; set; }
        public string WalletAddress { get; set; }

        public SettlementMerchantCommand(long merchantId, string walletAddress)
        {
            MerchantId = merchantId;
            WalletAddress = walletAddress;
        }
    }
}
