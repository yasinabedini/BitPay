using AIPFramework.Commands;
using BitPay.Domain.Common;
using BitPay.Domain.Merchant.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BitPay.Application.Merchants.Commands.RegisterMerchant
{
    public class RegisterMerchantCommandHandler : ICommandHandler<RegisterMerchantCommand, ApplicationResponse>
    {
        private readonly IMerchantRepository _merchantRepository;

        public RegisterMerchantCommandHandler(IMerchantRepository merchantRepository)
        {
            _merchantRepository = merchantRepository;
        }

        public Task<ApplicationResponse> Handle(RegisterMerchantCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _merchantRepository.Add(Domain.Merchant.Entities.Merchant.Create(request.MerchantName, request.Description, request.WalletAddress, request.MerchantCode, request.MemberId));
                _merchantRepository.Save();

                return Task.FromResult(new ApplicationResponse
                {
                    IsSuccess = true,
                    Message = "پزشک با موفقیت ثبت شد",
                    ResponseCode = "200"
                });
            }
            catch (Exception ex)
            {

                return Task.FromResult(new ApplicationResponse
                {
                    IsSuccess = false,
                    Message = "خطایی رخ داده است. با پشتیبانی تماس بگیرید!",
                    ResponseCode = "400" ,
                    Error = ex.Message
                });
            }
        }
    }
}
