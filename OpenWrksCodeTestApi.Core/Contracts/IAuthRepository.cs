using OpenWrksCodeTestApi.Core.DataModels.Auth;

namespace OpenWrksCodeTestApi.Core.Contracts
{
    public interface IAuthRepository
    {
        Client GetNamedClient(string name);
    }
}
