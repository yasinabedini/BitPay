using BitPay.Domain.Common;
using BitPay.Domain.Merchant.Repositories;
using BitPay.Domain.Transfer.Entities;
using BitPay.Infra.Common;
using BitPay.Infra.Context;
using MerchantModel = BitPay.Domain.Merchant.Entities.Merchant;


namespace BitPay.Infra.Models.Merchant.Repositories
{
    public class MerchantRepository : BaseRepository<MerchantModel>, IMerchantRepository
    {
        public MerchantRepository(BitPayDbContext context) : base(context)
        {
        }

        public Task<ApplicationResponse<Transafer>> GetMerchantTransfers()
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationResponse<double>> GetRemainingCoins()
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationResponse<double>> GetTodayConins()
        {
            throw new NotImplementedException();
        }
    }
}
