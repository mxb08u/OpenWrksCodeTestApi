using System.Collections.Generic;
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

        public async Task<UserAccount> GetAccount(string userId, string accountNumber, bool includeDetails = false)
        {
            var foundAccount = _userRepository.GetAccountForUser(userId, accountNumber);

            if(foundAccount == null)
            {
                return null;
            }

            if (includeDetails)
            {
                return await GetAccountFromProvider(foundAccount);
            }

            return foundAccount;
        }

        public IEnumerable<UserAccount> GetAccounts(string userId)
        {
            var userTasks = new List<Task<UserAccount>>();

            //Get all the accounts we have for this user.
            var foundAccounts = _userRepository.GetAllForUser(userId);

            //Lookup these accounts agaisnt the bank as fast as possible.
            foreach(var account in foundAccounts)
            {
                userTasks.Add(GetAccountFromProvider(account));
            }

            Task.WaitAll(userTasks.ToArray());

            return userTasks.Select(x => x.Result);
        }

        private async Task<UserAccount> GetAccountFromProvider(UserAccount account)
        {
            var bankApi = _bankingFactory.Create(account.BankName);

            var userAccountResult = await bankApi.GetAccountDetailsAsync(account.AccountNumber);

            // *** Decorate *** //
            // Todo: Do this generically and gracefully?
            userAccountResult.BankName = account.BankName;
            userAccountResult.UserId = account.UserId;

            return userAccountResult;
        }
    }
}
