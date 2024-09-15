using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Infra.Context
{
    public class BitPayContextFactory : IDesignTimeDbContextFactory<BitPayDbContext>
    {
        public BitPayDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BitPayDbContext>();
            optionsBuilder.UseSqlServer("Data Source=ABDN\\ABDN;Database=bitpay-db;User Id=abdn;Password=1;TrustServerCertificate=True;");

            return new BitPayDbContext(optionsBuilder.Options);
        }
    }
}
