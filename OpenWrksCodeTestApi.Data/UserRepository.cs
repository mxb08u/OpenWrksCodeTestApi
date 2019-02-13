using OpenWrksCodeTestApi.Core.Contracts.Repositories;
using OpenWrksCodeTestApi.Core.DataModels.BankingContext;
using OpenWrksCodeTestApi.Data.DbContexts;
using System;
using System.Collections.Generic;

namespace OpenWrksCodeTestApi.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly BankingContext _bankingContext;
        public UserRepository(BankingContext bankingContext)
        {
            _bankingContext = bankingContext;
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

        public UserAccount GetUser(string accountNumber)
        {
            return _bankingContext.Users.Find(accountNumber);
        }
    }
}
