using AIPFramework.Commands;
using AIPFramework.Queries;
using BitPay.Application.DTOs;
using BitPay.Domain.Common;
using BitPay.Domain.Member.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Application.Memeber.Queries.GetMemberMerchant
{
    public class GetMemberMerchantQueryHandler : IQueryHandler<GetMemberMerchantQuery, ApplicationResponse<MerchantResult>>
    {
        private readonly IMemberRepository _memberRepository;

        public GetMemberMerchantQueryHandler(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<ApplicationResponse<MerchantResult>> Handle(GetMemberMerchantQuery request, CancellationToken cancellationToken)
        {
            var result =await _memberRepository.GetMemeberMerchant(request.MemberId);

            return new ApplicationResponse<MerchantResult>
            {
                Result = new MerchantResult(result.Result.MerchantName, result.Result.Description, result.Result.WalletAddress, result.Result.MerchantCode, result.Result.MemberId),
                Error = result.Error,
                IsSuccess = result.IsSuccess,
                Message = result.Message,
                ResponseCode = result.ResponseCode,
                Warning = result.Warning,
            };
        }
    }
}
