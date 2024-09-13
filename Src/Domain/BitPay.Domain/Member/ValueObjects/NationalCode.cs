using AIPFramework.ValueObjects;
using AIPFramework.ValueObjects.Rule;
using BitPay.Domain.Member.Rule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Domain.Member.ValueObjects
{
    public class NationalCode:BaseValueObject<NationalCode>
    {
        public static NationalCode FromString(string value) => new(value);

        public NationalCode(string value)
        {
            CheckRule(new TheValueMustNotBeEmpty(value));

            CheckRule(new NationalCodeValidation(value));
        }
        private NationalCode()
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

        public static explicit operator string(NationalCode title) => title.Value.ToString();
        public static implicit operator NationalCode(string value) => new(value);
    }
}
