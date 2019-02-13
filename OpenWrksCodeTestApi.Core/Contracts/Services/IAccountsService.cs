using OpenWrksCodeTestApi.Core.DataModels.BankingContext;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenWrksCodeTestApi.Core.Contracts.Services
{
    public interface IAccountsService
    {
        IEnumerable<UserAccount> GetAccounts(string userId);
        Task<UserAccount> GetAccountAsync(string userId, string accountNumber,bool includeDetails = false);
    }
}
