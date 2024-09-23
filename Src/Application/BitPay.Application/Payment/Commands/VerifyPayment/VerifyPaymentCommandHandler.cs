using AIPFramework.Commands;
using BitPay.Domain.Common;
using BitPay.Domain.Payment.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Application.Payment.Commands.VerifyPayment
{
    public class VerifyPaymentCommandHandler : ICommandHandler<VerifyPaymentCommand, ApplicationResponse>
    {
        private readonly IPaymentRepository _paymentRepository;

        public VerifyPaymentCommandHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }


        public Task<ApplicationResponse> Handle(VerifyPaymentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _paymentRepository.VerfiyPayment(request.PaymentId, request.IsSuccess, request.Rrn, request.ReferenceNumber);
                _paymentRepository.Save();


                return Task.FromResult(new ApplicationResponse
                {
                    IsSuccess = true,
                    Message = "پرداخت با موفقیت تایید شد.",
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
