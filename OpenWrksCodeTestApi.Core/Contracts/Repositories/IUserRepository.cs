using OpenWrksCodeTestApi.Core.DataModels.BankingContext;
using System.Collections.Generic;

namespace OpenWrksCodeTestApi.Core.Contracts.Repositories
{
    public interface IUserRepository
    {
        UserAccount GetUser(string accountNumber);
        IEnumerable<UserAccount> GetAll();
        UserAccount Create(string id, string bankName, string accountNumber);
    }
}
