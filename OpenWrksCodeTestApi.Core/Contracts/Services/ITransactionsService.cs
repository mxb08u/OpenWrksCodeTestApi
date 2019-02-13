using OpenWrksCodeTestApi.Core.DataModels.BankingContext;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenWrksCodeTestApi.Core.Contracts.Services
{
    public interface ITransactionsService
    {
        Task<IEnumerable<Transaction>> GetTransactionsAsync(string userId, string accountNumber);
    }
}
