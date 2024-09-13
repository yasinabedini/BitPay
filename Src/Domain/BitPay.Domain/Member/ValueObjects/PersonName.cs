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
    public class PersonName:BaseValueObject<PersonName>
    {
        public static PhoneNumber FromString(string value) => new(value);

        public PersonName(string value)
        {
            CheckRule(new TheValueMustNotBeEmpty(value));
            CheckRule(new PersonNameValidation(value));            
        }
        private PersonName()
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

        public static explicit operator string(PersonName title) => title.Value.ToString();
        public static implicit operator PersonName(string value) => new(value);
    }
}
