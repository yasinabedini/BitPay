using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Domain.Member.ValueObjects.Conversion
{

    public class PhoneNumberConversion : ValueConverter<PhoneNumber, string>
    {
        public PhoneNumberConversion() : base(c => c.Value, c => PhoneNumber.FromString(c))
        {

        }
    }
}
