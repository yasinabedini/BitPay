using AIPFramework.ValueObjects;
using AIPFramework.ValueObjects.Rule;
using BitPay.Domain.Member.Rule;
using BitPay.Domain.Member.ValueObjects;
using BitPay.Domain.Merchant.Rule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Domain.Merchant.ValueObjects
{
    public class WalletAddress:BaseValueObject<WalletAddress>
    {
        public static WalletAddress FromString(string value) => new(value);

        public WalletAddress(string value)
        {
            CheckRule(new TheValueMustNotBeEmpty(value));
            CheckRule(new WalletAddressValidation(value));
        }
        private WalletAddress()
        {

        }

        public string Value { get; private set; }

        public override string ToString()
        {
            return Value.ToString();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static explicit operator string(WalletAddress title) => title.Value.ToString();
        public static implicit operator WalletAddress(string value) => new(value);
    }
}
