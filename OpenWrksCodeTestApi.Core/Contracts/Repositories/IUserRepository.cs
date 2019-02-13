using OpenWrksCodeTestApi.Core.DataModels.BankingContext;
using System.Collections.Generic;

namespace OpenWrksCodeTestApi.Core.Contracts.Repositories
{
    public interface IUserRepository
    {
        bool FindAccountNumber(string accountNumber);
        IEnumerable<UserAccount> GetUsers(string userId);
        IEnumerable<UserAccount> GetAll();
        IEnumerable<UserAccount> GetAllForUser(string userId);
        UserAccount GetAccountForUser(string userId, string accountNumber);
        UserAccount Create(string id, string bankName, string accountNumber);
    }
}
