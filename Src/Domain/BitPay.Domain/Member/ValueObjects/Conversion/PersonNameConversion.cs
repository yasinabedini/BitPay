using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Domain.Member.ValueObjects.Conversion
{
    public class PersonNameConversion : ValueConverter<PersonName, string>
    {
        public PersonNameConversion() : base(c => c.Value, c => PersonName.FromString(c))
        {

        }
    }
}
