using AIPFramework.Queries;
using BitPay.Application.DTOs;
using BitPay.Domain.Common;
using BitPay.Domain.Merchant.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Application.Merchants.Queries.GetRemainingCoins
{
    public class GetRemainingCoinsQueryHandler : IQueryHandler<GetRemainingCoinsQuery, ApplicationResponse<double>>
    {
        private readonly IMerchantRepository _merchantRepository;

        public GetRemainingCoinsQueryHandler(IMerchantRepository merchantRepository)
        {
            _merchantRepository = merchantRepository;
        }
        public async Task<ApplicationResponse<double>> Handle(GetRemainingCoinsQuery request, CancellationToken cancellationToken)
        {
            var result = await _merchantRepository.GetRemainingCoins(request.MerchantId);

            return new ApplicationResponse<double>
            {
                Result = result.Result,
                Error = result.Error,
                IsSuccess = result.IsSuccess,
                Message = result.Message,
                ResponseCode = result.ResponseCode,
                Warning = result.Warning,
            };
        }
    }
}
