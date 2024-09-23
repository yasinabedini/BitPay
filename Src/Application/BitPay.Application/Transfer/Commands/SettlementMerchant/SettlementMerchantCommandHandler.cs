using AIPFramework.Commands;
using BitPay.Domain.Common;
using BitPay.Domain.Transfer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Application.Transfer.Commands.SettlementMerchant
{
    public class SettlementMerchantCommandHandler : ICommandHandler<SettlementMerchantCommand, ApplicationResponse>
    {
        private readonly ITransferRepository _transferRepository;

        public SettlementMerchantCommandHandler(ITransferRepository transferRepository)
        {
            _transferRepository = transferRepository;
        }

        public Task<ApplicationResponse> Handle(SettlementMerchantCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _transferRepository.SettlementMerchant(request.MerchantId, request.WalletAddress);
                return Task.FromResult(new ApplicationResponse
                {
                    IsSuccess = true,
                    Message = "تسویه با موفقیت انجام شد.",
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
