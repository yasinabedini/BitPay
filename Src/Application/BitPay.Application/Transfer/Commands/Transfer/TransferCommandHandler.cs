using AIPFramework.Commands;
using BitPay.Domain.Common;
using BitPay.Domain.Transfer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Application.Transfer.Commands.Transfer
{
    public class TransferCommandHandler : ICommandHandler<TransferCommand, ApplicationResponse>
    {
        private readonly ITransferRepository _repository;

        public TransferCommandHandler(ITransferRepository repository)
        {
            _repository = repository;
        }

        public Task<ApplicationResponse> Handle(TransferCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _repository.Add(Domain.Transfer.Entities.Transafer.Create(request.MerchantId, request.CoinTransfered, request.WalletAdress));
                _repository.Save();
                return Task.FromResult(new ApplicationResponse
                {
                    IsSuccess = true,
                    Message = "جابجایی با موفقیت انجام شد.",
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
