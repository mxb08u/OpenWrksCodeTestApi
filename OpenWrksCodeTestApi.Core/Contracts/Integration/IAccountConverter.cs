using OpenWrksCodeTestApi.Core.DataModels.BankingContext;

namespace OpenWrksCodeTestApi.Core.Contracts.Integration
{
    public interface IAccountConverter
    {
        UserAccount Convert();
    }
}
