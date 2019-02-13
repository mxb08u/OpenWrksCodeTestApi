using OpenWrksCodeTestApi.Core.DataModels.BankingContext;
using System.Collections.Generic;

namespace OpenWrksCodeTestApi.Core.Contracts.Services
{
    public interface IUserService
    {
        IEnumerable<UserAccount> GetAll();
        IEnumerable<UserAccount> GetUsers(string userId);
        UserAccount CreateUser(string bankName, string accountNumber);
    }
}
