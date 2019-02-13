using System.Collections.Generic;
using System.Threading.Tasks;
using OpenWrksCodeTestApi.Core.Contracts.Services;
using OpenWrksCodeTestApi.Core.DataModels.BankingContext;
using OpenWrksCodeTestApi.Core.Exceptions;

namespace OpenWrksCodeTestApi.Business
{
    public class TransactionsService : ITransactionsService
    {
        private readonly IAccountsService _accountsService;
        private readonly IBankFactory _bankFactory;
        public TransactionsService(IAccountsService accountsService, IBankFactory bankFactory)
        {
            _accountsService = accountsService;
            _bankFactory = bankFactory;
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsAsync(string userId, string accountNumber)
        {
            // Make sure the account belongs to the user.
            var foundAccount = await _accountsService.GetAccountAsync(userId, accountNumber, false);

            if (foundAccount == null)
            {
                return null;
            }

            var concreteBank = _bankFactory.Create(foundAccount.BankName);

            return await concreteBank.GetTransactionsAsync(accountNumber);
        }
    }
}
