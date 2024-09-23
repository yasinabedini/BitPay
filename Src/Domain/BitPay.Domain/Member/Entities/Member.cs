using AIPFramework.Entities;
using BitPay.Domain.Member.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Domain.Member.Entities
{
    public class Member : AggregateRoot
    {
        #region Properties
        public string CustomerCode { get; set; }        
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Mobile { get; private set; }
        public string NationalCode { get; private set; }
        #endregion

        #region Constructor And Factories        
        public Member(string firstName, string lastName, string mobile, string nationalCode)
        {
            FirstName = firstName;
            LastName = lastName;
            Mobile = mobile;
            NationalCode = nationalCode;
            CustomerCode = GetUniqueUsername();
        }

        public static Member Create(string firstName, string lastName, string mobile, string nationalCode)
        {
            return new Member(firstName, lastName, mobile, nationalCode);
        }
        #endregion

        #region Methods
        public void ChangeFirstName(string name)
        {
            FirstName = name;
            Modified();
        }

        public void ChangeLastName(string name)
        {
            LastName = name;
            Modified();
        }

        public void ChangePhoneNumber(string phoneNumber)
        {
            Mobile = phoneNumber;
            Modified();
        }

        public void ChangeNationalCode(string nationalCode)
        {
            NationalCode = nationalCode;
            Modified();
        }

        public string GetFulName()
        {
            return FirstName + " " + LastName;
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
