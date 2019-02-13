
using Newtonsoft.Json;
using OpenWrksCodeTestApi.Business.Integration.FairwayBank.Models;
using OpenWrksCodeTestApi.Core.Contracts.Services;
using OpenWrksCodeTestApi.Core.DataModels.BankingContext;
using OpenWrksCodeTestApi.Core.Exceptions;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace OpenWrksCodeTestApi.Business.Integration.FairwayBank
{
    public class FairwayBank : IThirdPartyBankApi
    {
        private const string Host = "http://fairwaybank-bizfitech.azurewebsites.net/api";
        public async Task<UserAccount> GetAccountAsync(string accountNumber)
        {
            var accountBasicTask = GetBasicAccountAsync(accountNumber);
            var accountDetailTask = GetAccountDetailsAsync(accountNumber);

            await Task.WhenAll(accountBasicTask, accountDetailTask);

            var account = accountBasicTask.Result;
            var details = accountDetailTask.Result;

            account.Balance = details.Amount;
            account.Overdraft = details.Overdraft.Amount;

            return account;
        }

        private async Task<UserAccount> GetBasicAccountAsync(string accountNumber)
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
                throw new ThirdPartyApiException($"{url} returned {response.StatusCode}");
            }
        }

        private async Task<Balance> GetAccountDetailsAsync(string accountNumber)
        {
            var url = $"{Host}/v1/accounts/{accountNumber}/balance";

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var jsonResult = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Balance>(jsonResult);
            }
            else
            {
                throw new ThirdPartyApiException($"{url} returned {response.StatusCode}");
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
                throw new ThirdPartyApiException($"{url} returned {response.StatusCode}");
            }
            
            return transactions;
        }
    }
}
