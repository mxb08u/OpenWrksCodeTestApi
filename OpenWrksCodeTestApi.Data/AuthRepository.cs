using OpenWrksCodeTestApi.Core.Contracts;
using OpenWrksCodeTestApi.Core.DataModels.Auth;
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
