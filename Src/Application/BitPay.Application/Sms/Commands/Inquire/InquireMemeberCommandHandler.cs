using AIPFramework.Commands;
using BitPay.Domain.Common;
using BitPay.Domain.Sms.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Application.Sms.Commands.Inquire
{
    public class InquireMemeberCommandHandler : ICommandHandler<InquireMemeberCommand, ApplicationResponse<bool>>
    {
        private readonly ISmsRepository _repository;

        public InquireMemeberCommandHandler(ISmsRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApplicationResponse<bool>> Handle(InquireMemeberCommand request, CancellationToken cancellationToken)
        {
            var result = _repository.SendCode(request.PhoneNumber);

            return await result;
        }
    }
}
