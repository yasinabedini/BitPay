using AIPFramework.Commands;
using BitPay.Domain.Common;
using BitPay.Domain.Member.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Application.Memeber.Commands.RegisterMember
{
    public class RegisterMemberCommand : ICommand<ApplicationResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string NationalCode { get; set; }

        public RegisterMemberCommand(string firstName, string lastName, string mobile, string nationalCode)
        {
            FirstName = firstName;
            LastName = lastName;
            Mobile = mobile;
            NationalCode = nationalCode;
        }
    }
}
