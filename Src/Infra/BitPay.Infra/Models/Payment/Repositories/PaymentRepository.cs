using BitPay.Domain.Payment.Repositories;
using BitPay.Infra.Common;
using BitPay.Infra.Context;
using PaymentModel = BitPay.Domain.Payment.Entities.Payment;


namespace BitPay.Infra.Models.Payment.Repositories
{
    public class PaymentRepository : BaseRepository<PaymentModel>, IPaymentRepository
    {
        public PaymentRepository(BitPayDbContext context) : base(context)
        {
        }
    }
}
