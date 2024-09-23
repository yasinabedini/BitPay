using AIPFramework.Repository;
using BitPay.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Domain.Sms.Repositories
{
    public interface ISmsRepository : IRepository<Sms.Entites.Sms>
    {
        Task<ApplicationResponse> VerifiedCode(string phoneNumber,string code);
        Task<ApplicationResponse<bool>> SendCode(string phoneNumber);
    }
}
