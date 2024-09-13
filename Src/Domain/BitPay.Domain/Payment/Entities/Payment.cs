using AIPFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Domain.Payment.Entities
{
    public class Payment : AggregateRoot
    {
        public long MemberId { get;private set; }
        public long MerchantId { get; private set; }
        public double Price { get; private set; }
        public string Rrn { get; set; }
        public string ReferenceNumber { get; private set; }
        public string Maskcard { get; private set; }
        public bool IsSuccess { get; private set; }
    }
}
