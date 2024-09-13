using AIPFramework.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Domain.Payment.Repositories
{
    public interface IPaymentRepository : IRepository<Entities.Payment>
    {
    }
}
