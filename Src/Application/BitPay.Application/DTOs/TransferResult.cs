using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Application.DTOs
{
    public record TransferResult(long MerchantId, double CoinTransfered, string WalletAdress)
    {
    }
}
