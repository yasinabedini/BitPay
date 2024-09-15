using BitPay.Domain.Transfer.Repositories;
using BitPay.Infra.Common;
using BitPay.Infra.Context;
using TransferModel = BitPay.Domain.Transfer.Entities.Transafer;

namespace BitPay.Infra.Models.Transfer.Repositories
{
    public class TransferRepository : BaseRepository<TransferModel>, ITransferRepository
    {
        public TransferRepository(BitPayDbContext context) : base(context)
        {
        }
    }
}
