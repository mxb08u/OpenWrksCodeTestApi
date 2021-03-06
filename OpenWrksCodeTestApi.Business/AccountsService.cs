﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenWrksCodeTestApi.Core.Contracts.Repositories;
using OpenWrksCodeTestApi.Core.Contracts.Services;
using OpenWrksCodeTestApi.Core.DataModels.BankingContext;

namespace OpenWrksCodeTestApi.Business
{
    public class AccountsService : IAccountsService
    {
        private readonly IUserRepository _userRepository;
        private readonly IBankFactory _bankingFactory;

        public AccountsService(IUserRepository userRepository, IBankFactory bankFactory)
        {
            _userRepository = userRepository;
            _bankingFactory = bankFactory;
        }

        public async Task<UserAccount> GetAccountAsync(string userId, string accountNumber, bool includeDetails = false)
        {
            var foundAccount = _userRepository.GetAccountForUser(userId, accountNumber);

            if(foundAccount == null)
            {
                return null;
            }

            if (includeDetails)
            {
                return await GetAccountFromProviderAsync(foundAccount);
            }

            return foundAccount;
        }

        public async Task<IEnumerable<UserAccount>> GetAccountsAsync(string userId)
        {
            var userTasks = new List<Task<UserAccount>>();

            //Get all the accounts we have for this user.
            var foundAccounts = _userRepository.GetAllForUser(userId);

            //Lookup these accounts agaisnt the bank as fast as possible.
            foreach(var account in foundAccounts)
            {
                userTasks.Add(GetAccountFromProviderAsync(account));
            }

            await Task.WhenAll(userTasks);

            return userTasks.Select(x => x.Result);
        }

        private async Task<UserAccount> GetAccountFromProviderAsync(UserAccount account)
        {
            var bankApi = _bankingFactory.Create(account.BankName);

            var userAccountResult = await bankApi.GetAccountAsync(account.AccountNumber);

            // *** Decorate *** //
            userAccountResult.BankName = account.BankName;
            userAccountResult.UserId = account.UserId;

            return userAccountResult;
        }
    }
}
