using Newtonsoft.Json;

namespace OpenWrksCodeTestApi.Business.Integration.FairwayBank.Models
{
    public class AccountIdentifierViewModel
    {
        [JsonProperty(PropertyName = "accountNumber")]
        public string AccountNumber { get; set; }

        [JsonProperty(PropertyName = "sortCode")]
        public string SortCode { get; set; }
    }
}
