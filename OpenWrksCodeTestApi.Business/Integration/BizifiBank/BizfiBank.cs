using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenWrksCodeTestApi.Business.Integration.BizifiBank.Models;
using OpenWrksCodeTestApi.Core.Contracts.Services;
using OpenWrksCodeTestApi.Core.DataModels.BankingContext;

namespace OpenWrksCodeTestApi.Business.Integration.BizifiBank
{
    public class BizfiBank : IThirdPartyBankApi
    {
        private const string Host = "http://bizfibank-bizfitech.azurewebsites.net/api";
        public async Task<UserAccount> GetAccountDetailsAsync(string accountNumber)
        {
            var url = $"{Host}/v1/accounts/{accountNumber}";

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var jsonResult = await response.Content.ReadAsStringAsync();
                var accountResult = JsonConvert.DeserializeObject<Account>(jsonResult);
                return accountResult.Convert();
            }
            else
            {
                //TODO: what do we do if its not a response success?
                return null;
            }
        }

        public async Task<IEnumerable<Core.DataModels.BankingContext.Transaction>> GetTransactionsAsync(string accountNumber)
        {
            var url = $"{Host}/v1/accounts/{accountNumber}/transactions";

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);

            var transactions = new List<Core.DataModels.BankingContext.Transaction>();
            if (response.IsSuccessStatusCode)
            {
                var jsonResult = await response.Content.ReadAsStringAsync();
                var transactionsResult = JsonConvert.DeserializeObject<IEnumerable<Models.Transaction>>(jsonResult);
                foreach(var transaction in transactionsResult)
                {
                    transactions.Add(transaction.Convert());
                }
            }
            else
            {
                //TODO: what do we do if its not a response success?
            }

            return transactions;
        }
    }
}
