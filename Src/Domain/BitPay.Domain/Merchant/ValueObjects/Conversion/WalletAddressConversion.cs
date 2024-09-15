using BitPay.Domain.Member.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Domain.Merchant.ValueObjects.Conversion
{
    public class WalletAddressConversion : ValueConverter<WalletAddress, string>
    {
        public WalletAddressConversion() : base(c => c.Value, c => WalletAddress.FromString(c))
        {

        }
    }
}
