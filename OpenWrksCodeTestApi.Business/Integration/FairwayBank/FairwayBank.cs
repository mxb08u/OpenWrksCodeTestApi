﻿using Newtonsoft.Json;
using OpenWrksCodeTestApi.Business.Integration.FairwayBank.Models;
using OpenWrksCodeTestApi.Core.Contracts.Services;
using OpenWrksCodeTestApi.Core.DataModels.BankingContext;
using System.Net.Http;
using System.Threading.Tasks;

namespace OpenWrksCodeTestApi.Business.Integration.FairwayBank
{
    public class FairwayBank : IBankingLookup
    {
        private const string Host = "http://fairwaybank-bizfitech.azurewebsites.net/api";
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

        public UserAccount DeserialiseJson(string json)
        {
            var account = JsonConvert.DeserializeObject<Account>(json);

            var userAccount = account.ToUserAccount();

            return userAccount;
        }
    }
}