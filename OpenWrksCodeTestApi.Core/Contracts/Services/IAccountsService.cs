using OpenWrksCodeTestApi.Core.DataModels.BankingContext;
using System.Collections.Generic;

namespace OpenWrksCodeTestApi.Core.Contracts.Services
{
    public interface IAccountsService
    {
        IEnumerable<UserAccount> GetAccountsForUser(string userId);
    }
}
