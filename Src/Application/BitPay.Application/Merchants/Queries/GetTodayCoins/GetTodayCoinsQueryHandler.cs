using AIPFramework.Queries;
using BitPay.Application.Merchants.Queries.GetRemainingCoins;
using BitPay.Domain.Common;
using BitPay.Domain.Merchant.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Application.Merchants.Queries.GetTodayCoins
{
    public class GetTodayCoinsQueryHandler:IQueryHandler<GetTodayCoinsQuery,ApplicationResponse<double>>
    {
        private readonly IMerchantRepository _merchantRepository;

        public GetTodayCoinsQueryHandler(IMerchantRepository merchantRepository)
        {
            _merchantRepository = merchantRepository;
        }
        public async Task<ApplicationResponse<double>> Handle(GetTodayCoinsQuery request, CancellationToken cancellationToken)
        {
            var result = await _merchantRepository.GetTodayCoins(request.MerchantId);

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
