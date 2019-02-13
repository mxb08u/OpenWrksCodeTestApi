using OpenWrksCodeTestApi.Core.DataModels.BankingContext;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenWrksCodeTestApi.Core.Contracts.Services
{
    public interface IThirdPartyBankApi
    {
        Task<string> LookupAccountInfo(string accountNumber);
        UserAccount DeserialiseJson(string json);
        Task<IEnumerable<Transaction>> GetTransactionsAsync(string accountNumber);
    }
}
