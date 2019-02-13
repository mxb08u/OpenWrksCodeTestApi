using Microsoft.EntityFrameworkCore;
using OpenWrksCodeTestApi.Core.DataModels.Auth;
using System.Linq;

namespace OpenWrksCodeTestApi.Data.DbContexts
{
    public class ClientContext : DbContext
    {
        public ClientContext(DbContextOptions<ClientContext> options) :base(options)
        {
            //Ensure some base data exists for example purposes. This would be persisted to a actual data source
            if (!Clients.Any())
            {
                Clients.Add(new Client { Username = "OpenWrks", Password = "OpenWrks" });
                SaveChanges();
            }
        }

        public DbSet<Client> Clients { get; set; }
    }
}
