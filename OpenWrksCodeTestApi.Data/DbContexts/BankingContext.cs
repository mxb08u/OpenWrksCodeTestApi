using Microsoft.EntityFrameworkCore;
using OpenWrksCodeTestApi.Core.DataModels.BankingContext;
using System;
using System.Linq;

namespace OpenWrksCodeTestApi.Data.DbContexts
{
    public class BankingContext : DbContext
    {
        public BankingContext(DbContextOptions<BankingContext> options) : base(options)
        {
            // Ensure we have some sample data to demo with.
            if (!Users.Any())
            {
                var userId = Guid.Parse("1a44cb46-5556-4788-908a-1863b1898ed0").ToString();
                Users.Add(new UserAccount { UserId = userId, BankName = "FairWayBank", AccountNumber = "12345678" });
                Users.Add(new UserAccount { UserId = userId, BankName = "BizfiBank", AccountNumber = "12345679" });
                SaveChanges();
            }

        }

        public DbSet<UserAccount> Users { get; set; }
    }
}
