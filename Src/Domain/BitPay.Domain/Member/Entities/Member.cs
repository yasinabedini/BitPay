using AIPFramework.Entities;
using BitPay.Domain.Member.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Domain.Member.Entities
{
    public class Member : AggregateRoot
    {
        #region Properties
        public PersonName FirstName { get; private set; }
        public PersonName LastName { get; private set; }
        public PhoneNumber Mobile { get; private set; }
        public NationalCode NationalCode { get; private set; }
        #endregion

        #region Constructor And Factories
        private Member() { }

        public Member(string firstName, string lastName, string mobile, string nationalCode)
        {
            FirstName = firstName;
            LastName = lastName;
            Mobile = mobile;
            NationalCode = nationalCode;
        }

        public Member Create(string firstName, string lastName, string mobile, string nationalCode)
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
        #endregion
    }
}
