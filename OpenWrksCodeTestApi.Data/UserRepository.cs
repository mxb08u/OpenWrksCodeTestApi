using OpenWrksCodeTestApi.Core.Contracts.Repositories;
using OpenWrksCodeTestApi.Core.DataModels.BankingContext;
using OpenWrksCodeTestApi.Data.DbContexts;
using System.Collections.Generic;
using System.Linq;

namespace OpenWrksCodeTestApi.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly BankingContext _bankingContext;
        public UserRepository(BankingContext bankingContext)
        {
            _bankingContext = bankingContext;
        }

        public bool CheckAccountNumberIsUnique(string accountNumber)
        {
            return !_bankingContext.Users.Any(x => x.AccountNumber == accountNumber);
        }

        public UserAccount Create(string userId, string bankName, string accountNumber)
        {
            var userAccount = new UserAccount { UserId = userId, BankName = bankName, AccountNumber = accountNumber };
            _bankingContext.Users.Add(userAccount);
            _bankingContext.SaveChanges();

            return userAccount;
        }

        public IEnumerable<UserAccount> GetAll()
        {
            return _bankingContext.Users;
        }

        public IEnumerable<UserAccount> GetAllForUser(string userId)
        {
            return _bankingContext.Users.Where(x => x.UserId == userId);
        }

        public IEnumerable<UserAccount> GetUsers(string userId)
        {
            return _bankingContext.Users.Where(x => x.UserId == userId);
        }
    }
}
