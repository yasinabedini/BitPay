using AIPFramework.Repository;
using BitPay.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Domain.Payment.Repositories
{
    public interface IPaymentRepository : IRepository<Entities.Payment>
    {
        Task<ApplicationResponse> VerfiyPayment(long paymentId,bool isSuccess, string? rrn, string? refrenceNumber);
    }
}
