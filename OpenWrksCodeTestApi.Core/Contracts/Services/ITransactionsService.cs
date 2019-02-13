using OpenWrksCodeTestApi.Core.DataModels.BankingContext;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenWrksCodeTestApi.Core.Contracts.Services
{
    public interface ITransactionsService
    {
        Task<IEnumerable<Transaction>> GetTransactions(string userId, string accountNumber);
    }
}
