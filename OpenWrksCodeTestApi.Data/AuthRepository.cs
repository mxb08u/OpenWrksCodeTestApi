using OpenWrksCodeTestApi.Core.Contracts.Repositories;
using OpenWrksCodeTestApi.Core.DataModels.ClientContext;
using OpenWrksCodeTestApi.Data.DbContexts;

namespace OpenWrksCodeTestApi.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ClientContext _clientContext;
        public AuthRepository(ClientContext clientContext)
        {
            _clientContext = clientContext;
        }

        public Client GetNamedClient(string name)
        {
            return _clientContext.Clients.Find(name);
        }
    }
}
