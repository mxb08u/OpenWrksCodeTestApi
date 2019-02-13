using Newtonsoft.Json;
using OpenWrksCodeTestApi.Core.Contracts.Integration;
using OpenWrksCodeTestApi.Core.DataModels.BankingContext;

namespace OpenWrksCodeTestApi.Business.Integration.FairwayBank.Models
{
    public class Account : IConverter<UserAccount>
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "identifier")]
        public AccountIdentifierViewModel Identifier { get; set; }

        public UserAccount Convert()
        {
            var userAccount = new UserAccount
            {
                AccountName = Name,
                AccountNumber = Identifier.AccountNumber,
                SortCode = Identifier.SortCode
            };

            return userAccount;
        }
    }
}
