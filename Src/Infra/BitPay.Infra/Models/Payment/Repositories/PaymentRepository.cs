using BitPay.Domain.Common;
using BitPay.Domain.Payment.Repositories;
using BitPay.Infra.Common;
using BitPay.Infra.Context;
using PaymentModel = BitPay.Domain.Payment.Entities.Payment;


namespace BitPay.Infra.Models.Payment.Repositories
{
    public class PaymentRepository : BaseRepository<PaymentModel>, IPaymentRepository
    {
        private readonly BitPayDbContext _context;
        public PaymentRepository(BitPayDbContext context) : base(context)
        {
            _context = context;
        }
  
        public async Task<ApplicationResponse> VerfiyPayment(long paymentId, bool isSuccess, string? rrn, string? refrenceNumber)
        {
            var payment = _context.Payments.FirstOrDefault(t => t.Id == paymentId);

            if (payment is null)
            {
                return new ApplicationResponse
                {
                    IsSuccess = false,
                    Message = "تراکنش یافت نشد",
                    ResponseCode = "400"
                };

            }

            payment.VerifyPayment(isSuccess, rrn, refrenceNumber);
            Update(payment);
            Save();

            return new ApplicationResponse
            {
                IsSuccess = true,
                Message = "تراکنش با موفقیت تایید شد",
                ResponseCode = "200"
            };
        }
    }
}
