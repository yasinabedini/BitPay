using AIPFramework.Entities;
using BitPay.Domain.Merchant.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Domain.Payment.Entities
{
    public class Payment : AggregateRoot
    {
        #region Properties
        public long MemberId { get; private set; }
        public long MerchantId { get; private set; }
        public double Price { get; private set; }
        public string? Rrn { get; private set; }
        public string ReferenceNumber { get; private set; }
        public string Maskcard { get; private set; }
        public bool IsSuccess { get; private set; }


        public Member.Entities.Member  Member { get; set; }
        public Merchant.Entities.Merchant Merchant { get; set; }
        #endregion

        #region Constructors and Factories        
        public Payment(long memberId, long merchantId, double price, string? rrn, string referenceNumber, string maskcard, bool isSuccess)
        {
            MemberId = memberId;
            MerchantId = merchantId;
            Price = price;
            Rrn = rrn;
            ReferenceNumber = referenceNumber;
            Maskcard = maskcard;
            IsSuccess = isSuccess;
        }
        public Payment Create(long memberId, long merchantId, double price, string? rrn, string referenceNumber, string maskcard, bool isSuccess)
        {
            return new Payment(memberId, merchantId, price, rrn, referenceNumber, maskcard, isSuccess);
        }
        #endregion

        #region Methods
        public void ChangeMemberId(long memberId)
        {
            MemberId = memberId;
            Modified();
        }

        public void ChangeMerchantId(long merchantId)
        {
            MerchantId = merchantId;
            Modified();
        }

        public void ChangePrice(double price)
        {
            Price = price;
            Modified();
        }

        public void SetRrn(string rrn)
        {
            Rrn = rrn;
            Modified();
        }
        public void ChangeReferenceNumber(string referenceNumber)
        {
            ReferenceNumber = referenceNumber;
            Modified();
        }

        public void ChangeMaskcard(string maskcard)
        {
            Maskcard = maskcard;
            Modified();
        }
        #endregion

    }
}