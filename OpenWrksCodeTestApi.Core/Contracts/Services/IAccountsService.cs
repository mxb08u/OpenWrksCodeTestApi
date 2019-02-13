using OpenWrksCodeTestApi.Core.DataModels.BankingContext;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenWrksCodeTestApi.Core.Contracts.Services
{
    public interface IAccountsService
    {
        Task<IEnumerable<UserAccount>> GetAccountsAsync(string userId);
        Task<UserAccount> GetAccountAsync(string userId, string accountNumber,bool includeDetails = false);
    }
}
