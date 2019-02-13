using Newtonsoft.Json;
using OpenWrksCodeTestApi.Core.Contracts.Integration;
using OpenWrksCodeTestApi.Core.DataModels.BankingContext;

namespace OpenWrksCodeTestApi.Business.Integration.BizifiBank.Models
{
    public class Account : IConverter<UserAccount>
    {
        [JsonProperty(PropertyName = "account_name")]
        public string AccountName { get; set; }

        [JsonProperty(PropertyName = "account_number")]
        public string AccountNumber { get; set; }

        [JsonProperty(PropertyName = "sort_code")]
        public string SortCode { get; set; }

        [JsonProperty(PropertyName = "balance")]
        public double Balance { get; set; }

        [JsonProperty(PropertyName = "available_balance")]
        public double AvailableBalance { get; set; }

        [JsonProperty(PropertyName = "overdraft")]
        public double Overdraft { get; set; }

        public UserAccount Convert()
        {
            var userAccount = new UserAccount
            {
                AccountName = AccountName,
                AccountNumber = AccountNumber,
                SortCode = SortCode,
                Balance = Balance,
                AvailableBalance = AvailableBalance,
                Overdraft = Overdraft
            };

            return userAccount;
        }
    }
}
