using AIPFramework.Commands;
using BitPay.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Application.Sms.Commands.VerifyCode
{
    public class VerifyCodeCommand : ICommand<ApplicationResponse>
    {
        public string PhoneNumber { get; set; }
        public string Code { get; set; }
    }
}
