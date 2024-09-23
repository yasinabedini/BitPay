using AIPFramework.Entities;
using AIPFramework.ValueObjects;
using BitPay.Domain.Member.Entities;
using BitPay.Domain.Member.ValueObjects.Conversion;
using BitPay.Domain.Merchant.Entities;
using BitPay.Domain.Merchant.ValueObjects.Conversion;
using BitPay.Domain.Payment.Entities;
using BitPay.Domain.Sms.Entites;
using BitPay.Domain.Transfer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Infra.Context
{
    public class BitPayDbContext : DbContext
    {
        public BitPayDbContext(DbContextOptions<BitPayDbContext> options) : base(options) { }

        public DbSet<Member> Members { get; set; }
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Transafer> Transafers { get; set; }

        public DbSet<Sms> Sms { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Member>().Property(t => t.FirstName).HasConversion<PersonNameConversion>();
            //modelBuilder.Entity<Member>().Property(t => t.LastName).HasConversion<PersonNameConversion>();


            //modelBuilder.Entity<Member>().Property(t => t.Mobile).HasConversion<PhoneNumberConversion>();
            //modelBuilder.Entity<Member>().Property(t => t.NationalCode).HasConversion<NationalCodeConversion>();

            //modelBuilder.Entity<Merchant>().Property(t => t.WalletAddress).HasConversion<WalletAddressConversion>();

            modelBuilder.Entity<Payment>().HasOne(t => t.Member).WithMany().HasForeignKey(t => t.MemberId).OnDelete(DeleteBehavior.NoAction); 
            modelBuilder.Entity<Payment>().HasOne(t => t.Merchant).WithMany().HasForeignKey(t=>t.MerchantId).OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }
    }
}
