using AIPFramework.Queries;
using BitPay.Application.DTOs;
using BitPay.Application.Memeber.Queries.GetMemberMerchant;
using BitPay.Domain.Common;
using BitPay.Domain.Member.Repositories;
using BitPay.Domain.Merchant.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Application.Merchants.Queries.GetMerchantTransfers
{
    public class GetMerchantTransfersQueryHandler:IQueryHandler<GetMerchantTransfersQuery,ApplicationResponse<List<TransferResult>>>
    {
        private readonly IMerchantRepository _merchantRepository;

        public GetMerchantTransfersQueryHandler(IMerchantRepository merchantRepository)
        {
            _merchantRepository = merchantRepository;
        }

        public async Task<ApplicationResponse<List<TransferResult>>> Handle(GetMerchantTransfersQuery request, CancellationToken cancellationToken)
        {
            var result = await _merchantRepository.GetMerchantTransfers(request.MerchantId);

            return new ApplicationResponse<List<TransferResult>>
            {
                Result = result.Result.Select(t=>new TransferResult(t.MerchantId,t.CoinTransfered,t.WalletAdress)).ToList(),
                Error = result.Error,
                IsSuccess = result.IsSuccess,
                Message = result.Message,
                ResponseCode = result.ResponseCode,
                Warning = result.Warning,
            };
        }
    }
}
