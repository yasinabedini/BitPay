using AIPFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Domain.Transfer.Entities
{
    public class Transafer:AggregateRoot
    {
        public long MerchantId { get; set; }
        public long CoinTransfered { get; set; }

        public Merchant.Entities.Merchant Merchant { get; set; }
    }
}
