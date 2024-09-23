using AIPFramework.Commands;
using BitPay.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Application.Transfer.Commands.Transfer
{
    public class TransferCommand:ICommand<ApplicationResponse>
    {
        public long MerchantId { get; private set; }
        public long CoinTransfered { get; private set; }
        public string WalletAdress { get; private set; }

        public TransferCommand(long merchantId, long coinTransfered, string walletAdress)
        {
            MerchantId = merchantId;
            CoinTransfered = coinTransfered;
            WalletAdress = walletAdress;
        }
    }
}
