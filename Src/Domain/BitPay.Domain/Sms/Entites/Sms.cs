using AIPFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Domain.Sms.Entites
{
    public class Sms : AggregateRoot
    {
        public string Code { get;private set; }
        public string Text { get; private set; }
        public string PhoneNumber { get; private set; }

        public Sms()
        {
            
        }
        public Sms(string code, string text, string phoneNumber)
        {
            Code = code;
            Text = text;
            PhoneNumber = phoneNumber;
        }
        public static Sms Create(string code, string text, string phoneNumber)
        {
            return new Sms(code, text, phoneNumber);
        }

        public bool HasVerfied()
        {            
            if (CreateAt.AddMinutes(2) < DateTime.Now) return false;
            else return true;
        }
    }
}
