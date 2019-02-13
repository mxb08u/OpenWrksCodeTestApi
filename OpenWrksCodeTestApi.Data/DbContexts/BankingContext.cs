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
                Users.Add(new UserAccount { UserId = Guid.NewGuid().ToString(), BankName = "MattsBank", AccountNumber = "12345678" });
                SaveChanges();
            }

        }

        public DbSet<UserAccount> Users { get; set; }
    }
}
