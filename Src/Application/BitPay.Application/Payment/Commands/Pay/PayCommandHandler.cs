using AIPFramework.Commands;
using BitPay.Domain.Common;
using BitPay.Domain.Payment.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Application.Payment.Commands.Pay
{
    public class PayCommandHandler : ICommandHandler<PayCommand, ApplicationResponse>
    {
        private readonly IPaymentRepository _paymentRepository;

        public PayCommandHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public Task<ApplicationResponse> Handle(PayCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _paymentRepository.Add(Domain.Payment.Entities.Payment.Create(request.MemberId, request.MerchantId, request.Price, null, null, maskcard: request.Maskcard, isSuccess: false));
                _paymentRepository.Save();


                return Task.FromResult(new ApplicationResponse
                {
                    IsSuccess = true,
                    Message = "پرداخت با موفقیت ثبت شد.",
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
