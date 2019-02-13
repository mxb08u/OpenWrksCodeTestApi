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
        public async Task<string> LookupAccountInfo(string accountNumber)
        {
            var url = $"{Host}/v1/accounts/{accountNumber}";

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return string.Empty;
        }

        /// <summary>
        /// TODO: write this out.
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public UserAccount DeserialiseJson(string json)
        {
            var account = JsonConvert.DeserializeObject<Account>(json);

            var userAccount = account.ToUserAccount();

            return userAccount;
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
