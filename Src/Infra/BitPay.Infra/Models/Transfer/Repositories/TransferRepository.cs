using BitPay.Domain.Common;
using BitPay.Domain.Transfer.Repositories;
using BitPay.Infra.Common;
using BitPay.Infra.Context;
using TransferModel = BitPay.Domain.Transfer.Entities.Transafer;

namespace BitPay.Infra.Models.Transfer.Repositories
{
    public class TransferRepository : BaseRepository<TransferModel>, ITransferRepository
    {
        private readonly BitPayDbContext _context;

        public TransferRepository(BitPayDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ApplicationResponse> SettlementMerchant(long merchantId, string walletAddress)
        {
            var reciveCoin = _context.Payments.Where(t => t.MerchantId == merchantId && t.IsSuccess).Sum(t => t.Price);
            var sendCoin = _context.Transafers.Where(t => t.MerchantId == merchantId).Sum(t => t.CoinTransfered);

            var coinTransfer = reciveCoin - sendCoin;

            Add(TransferModel.Create(merchantId, coinTransfer, walletAddress));
            Save();

            return new ApplicationResponse
            {
                IsSuccess = true,
                Message = "عملیات تسویه به طور کامل انجام شد"
            };
            
        }
    }
}
