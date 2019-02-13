using OpenWrksCodeTestApi.Core.DataModels.BankingContext;

namespace OpenWrksCodeTestApi.Core.Contracts.Integration
{
    public interface ITransactionConverter
    {
        Transaction Convert();
    }
}
