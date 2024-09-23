using AIPFramework.Commands;
using BitPay.Domain.Common;
using BitPay.Domain.Sms.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Application.Sms.Commands.VerifyCode
{
    public class VerifyCodeCommandHandler : ICommandHandler<VerifyCodeCommand, ApplicationResponse>
    {
        private readonly ISmsRepository _smsRepository;

        public VerifyCodeCommandHandler(ISmsRepository smsRepository)
        {
            _smsRepository = smsRepository;
        }

        public async Task<ApplicationResponse> Handle(VerifyCodeCommand request, CancellationToken cancellationToken)
        {
            var result = await (_smsRepository.VerifiedCode(request.PhoneNumber, request.Code));

            return result;
        }
    }
}
