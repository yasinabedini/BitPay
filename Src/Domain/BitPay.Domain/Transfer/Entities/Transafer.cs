using AIPFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Domain.Transfer.Entities
{
    public class Transafer : AggregateRoot<long>
    {
        public long MerchantId { get; private set; }
        public long CoinTransfered { get; private set; }
        public string WalletAdress { get; private set; }

        public Merchant.Entities.Merchant Merchant { get; set; }

        public Transafer(long merchantId, long coinTransfered, string walletAdress)
        {
            MerchantId = merchantId;
            CoinTransfered = coinTransfered;
            WalletAdress = walletAdress;
        }
        public Transafer Create(long merchantId, long coinTransfered, string walletAdress)
        {
            return new Transafer(merchantId, coinTransfered, walletAdress);
        }
        
    }
}
