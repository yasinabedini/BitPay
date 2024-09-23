using AIPFramework.Commands;
using BitPay.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Application.Sms.Commands.Inquire
{
    public class InquireMemeberCommand:ICommand<ApplicationResponse<bool>>
    {
        public string PhoneNumber { get; set; }
    }
}
