using OpenWrksCodeTestApi.Core.DataModels.BankingContext;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenWrksCodeTestApi.Core.Contracts.Services
{
    public interface IThirdPartyBankApi
    {
        Task<UserAccount> GetAccountDetailsAsync(string accountNumber);
        Task<IEnumerable<Transaction>> GetTransactionsAsync(string accountNumber);
    }
}
