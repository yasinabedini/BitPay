using AIPFramework.Commands;
using BitPay.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Application.Payment.Commands.Pay
{
    public class PayCommand:ICommand<ApplicationResponse>
    {
        public long MemberId { get; private set; }
        public long MerchantId { get; private set; }
        public double Price { get; private set; }                
        public string Maskcard { get; private set; }        
    }
}
