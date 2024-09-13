using AIPFramework.Exceptions;
using AIPFramework.ValueObjects.Rule;
using AIPFramework.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitPay.Domain.Member.Rule;

namespace BitPay.Domain.Member.ValueObjects
{
    public class PhoneNumber:BaseValueObject<PhoneNumber>
    {
        public static PhoneNumber FromString(string value) => new(value);        

        public PhoneNumber(string value)
        {
            CheckRule(new TheValueMustNotBeEmpty(value));

            CheckRule(new PhoneNumberValidation(value));          
        }
        private PhoneNumber()
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

        public static explicit operator string(PhoneNumber title) => title.Value.ToString();
        public static implicit operator PhoneNumber(string value) => new(value);                
    }
}
