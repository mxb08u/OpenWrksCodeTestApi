using OpenWrksCodeTestApi.Core.DataModels.ClientContext;

namespace OpenWrksCodeTestApi.Core.Contracts.Repositories
{
    public interface IAuthRepository
    {
        Client GetNamedClient(string name);
    }
}
