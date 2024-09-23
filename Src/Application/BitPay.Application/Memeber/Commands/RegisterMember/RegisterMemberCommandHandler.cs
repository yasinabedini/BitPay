using AIPFramework.Commands;
using BitPay.Domain.Common;
using BitPay.Domain.Member.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Application.Memeber.Commands.RegisterMember
{
    public class RegisterMemberCommandHandler : ICommandHandler<RegisterMemberCommand, ApplicationResponse>
    {
        private readonly IMemberRepository _repository;

        public RegisterMemberCommandHandler(IMemberRepository repository)
        {
            _repository = repository;
        }

        public Task<ApplicationResponse> Handle(RegisterMemberCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = Domain.Member.Entities.Member.Create(request.FirstName, request.LastName, request.Mobile, request.NationalCode);
                _repository.Add(user);
                _repository.Save();

                return Task.FromResult(new ApplicationResponse
                {
                    IsSuccess = true,
                    Message = "کاربر با موفقیت ثبت نام شد.",
                    ResponseCode = "200"
                });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new ApplicationResponse
                {
                    IsSuccess = false,
                    Message = "خطایی رخ داده است. با پشتیبانی تماس بگیرید!",
                    ResponseCode = "400",
                    Error = ex.Message
                });
            }
        }
    }
}
