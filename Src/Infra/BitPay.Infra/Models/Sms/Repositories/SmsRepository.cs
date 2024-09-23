using BitPay.Domain.Common;
using BitPay.Domain.Sms.Entites;
using BitPay.Domain.Sms.Repositories;
using BitPay.Infra.Common;
using BitPay.Infra.Context;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Infra.Models.Sms.Repositories
{
    public class SmsRepository : BaseRepository<Domain.Sms.Entites.Sms>, ISmsRepository
    {
        private readonly BitPayDbContext _context;

        public SmsRepository(BitPayDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<ApplicationResponse<bool>> SendCode(string phoneNumber)
        {
            string code = "0000";
            //Send sms

            bool userAvailable = _context.Members.Any(t => t.Mobile == phoneNumber);

            if (_context.Sms.Any(t => t.PhoneNumber == phoneNumber && t.CreateAt.AddMinutes(2) > DateTime.Now))
            {
                return Task.FromResult(new ApplicationResponse<bool>
                {
                    Error = "پس از گذشت 2 دقیقه میتوانید برای ارسال مجدد پیامک تلاش کنید.",
                    IsSuccess = false,
                    Message = "پس از گذشت 2 دقیقه میتوانید برای ارسال مجدد پیامک تلاش کنید.",
                    ResponseCode = "400",
                    Result = userAvailable
                });
            }

            Add(Domain.Sms.Entites.Sms.Create(code, $"کد اعتبار سنجی شما {phoneNumber} است", phoneNumber));
            Save();

            return Task.FromResult(new ApplicationResponse<bool>
            {
                IsSuccess = true,
                Message = "کد اعتبار سنجی با موفقیت ارسال شد.",
                ResponseCode = "200",
                Result= userAvailable
            });
        }

        public Task<ApplicationResponse> VerifiedCode(string phoneNumber, string code)
        {
            var sms = _context.Sms.Where(t => t.PhoneNumber == phoneNumber && t.CreateAt.AddMinutes(2) < DateTime.Now).OrderBy(t=>t.CreateAt).LastOrDefault();
            if (sms is null || sms.Code != code)
            {
                return Task.FromResult(new ApplicationResponse
                {
                    Error = "کد اعتبار سنجی را به درستی وارد کنید!",
                    IsSuccess = false,
                    Message = "کد اعتبار سنجی را به درستی وارد کنید!",
                    ResponseCode = "400",
                });
            }
            else
            {
                return Task.FromResult(new ApplicationResponse
                {
                    IsSuccess = true,
                    Message = "کد اعتبار سنجی تایید شد.",
                    ResponseCode = "200",
                });
            }
        }
    }
}
