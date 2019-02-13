using OpenWrksCodeTestApi.Core.DataModels.BankingContext;
using System.Threading.Tasks;

namespace OpenWrksCodeTestApi.Core.Contracts.Services
{
    public interface IBankingLookup
    {
        Task<string> LookupAccountInfo(string accountNumber);
        UserAccount DeserialiseJson(string json);
    }
}
