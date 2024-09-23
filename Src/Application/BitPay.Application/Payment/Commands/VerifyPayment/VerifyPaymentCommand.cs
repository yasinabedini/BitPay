using AIPFramework.Commands;
using BitPay.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Application.Payment.Commands.VerifyPayment
{
    public class VerifyPaymentCommand:ICommand<ApplicationResponse>
    {
        public long PaymentId { get; set; }
        public string? Rrn { get; private set; }
        public string ReferenceNumber { get; private set; }        
        public bool IsSuccess { get; private set; }
    }
}
