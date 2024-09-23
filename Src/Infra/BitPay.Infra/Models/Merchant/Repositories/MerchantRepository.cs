using BitPay.Domain.Common;
using BitPay.Domain.Merchant.Repositories;
using BitPay.Domain.Transfer.Entities;
using BitPay.Infra.Common;
using BitPay.Infra.Context;
using Microsoft.EntityFrameworkCore;
using MerchantModel = BitPay.Domain.Merchant.Entities.Merchant;


namespace BitPay.Infra.Models.Merchant.Repositories
{
    public class MerchantRepository : BaseRepository<MerchantModel>, IMerchantRepository
    {
        private readonly BitPayDbContext _context;
        public MerchantRepository(BitPayDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ApplicationResponse<List<Transafer>>> GetMerchantTransfers(long merchantId)
        {
            var result = _context.Transafers.Where(t => t.MerchantId == merchantId).ToList();
            if (!result.Any())
            {
                return new ApplicationResponse<List<Transafer>>
                {
                    Result = new List<Transafer>(),
                    IsSuccess = true,
                    Message = "جابجایی یافت نشد",
                    ResponseCode = "404"
                };
            }
            else
            {
                return new ApplicationResponse<List<Transafer>>
                {
                    Result = result,
                    IsSuccess = true,
                    Message = "عملیات واکشی جابجایی با موفقیت انجام شد",
                    ResponseCode = "200"
                };
            }
        }

        public async Task<ApplicationResponse<double>> GetRemainingCoins(long merchantId)
        {
            var reciveCoin = _context.Payments.Where(t => t.MerchantId == merchantId && t.IsSuccess).Sum(t => t.Price);

            var sendCoin = _context.Transafers.Where(t => t.MerchantId == merchantId).Sum(t => t.CoinTransfered);

            return new ApplicationResponse<double>
            {
                Result = reciveCoin - sendCoin,
                IsSuccess = true,
                Message = "عملیات واکشی مجموع مبلغ قابل تسویه با موفقیت انجام شد",
                ResponseCode = "200"
            };
        }

        public async Task<ApplicationResponse<double>> GetTodayCoins(long merchantId)
        {
            var result = _context.Payments.Where(t => t.CreateAt == DateTime.Today && t.IsSuccess).Sum(t => t.Price);

            return new ApplicationResponse<double>
            {
                Result = result,
                IsSuccess = true,
                Message = "عملیات واکشی مجموع تراکنش های روزانه با موفقیت انجام شد",
                ResponseCode = "200"
            };
        }
    }
}
