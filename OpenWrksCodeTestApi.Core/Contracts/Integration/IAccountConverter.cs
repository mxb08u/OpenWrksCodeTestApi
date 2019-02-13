using OpenWrksCodeTestApi.Core.DataModels.BankingContext;

namespace OpenWrksCodeTestApi.Core.Contracts.Integration
{
    public interface IAccountConverter
    {
        //TODO : use a generic interface
        UserAccount Convert();
    }
}
