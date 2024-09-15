using AIPFramework.Entities;
using BitPay.Domain.Merchant.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Domain.Merchant.Entities
{
    public class Merchant : AggregateRoot
    {
        #region Properties
        public string MerchantName { get; private set; }        
        public string Description { get; private set; }
        public WalletAddress WalletAddress { get; private set; }
        public string MerchantCode { get; private set; }
        public long MemberId { get; private set; }
        public Member.Entities.Member? Member { get; private set; }
        #endregion

        #region Constructor And Factories        
        public Merchant(string merchantName, string description, WalletAddress walletAddress, string merchantCode, long memberId)
        {
            MerchantName = merchantName;
            Description = description;
            WalletAddress = walletAddress;
            MerchantCode = merchantCode;
            MemberId = memberId;        
        }
        public static Merchant Create(string merchantName, string description, string walletAddress, string merchantCode, long memberId)
        {
            return new Merchant(merchantName, description, walletAddress, merchantCode, memberId);
        }
        #endregion

        #region Methods
        public void ChangeMerchantName(string merchantName)
        {
            MerchantName = merchantName;
            Modified();
        }
        public void ChangeDescription(string description)
        {
            Description = description;
            Modified();
        }
        public void ChangeWalletAddress(string walletAddress)
        {
            WalletAddress = walletAddress;
            Modified();
        }
        public void ChangeMerchantCode(string merchantCode)
        {
            MerchantCode = merchantCode;
            Modified();
        }
        public void ChangeMemberId(long memberId)
        {
            MemberId = memberId;
            Modified();
        } 
        private string GetUniqueUsername()
        {
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                byte[] randomNumber = new byte[4];
                rng.GetBytes(randomNumber);
                uint result = BitConverter.ToUInt32(randomNumber, 0) % 1000000000;

                return result.ToString();
            }
        }
        #endregion
    }
}
