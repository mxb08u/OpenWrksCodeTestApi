using Newtonsoft.Json;

namespace OpenWrksCodeTestApi.Business.Integration.FairwayBank.Models
{
    public class Overdraft
    {
        [JsonProperty(PropertyName = "amount")]
        public double Amount { get; set; }
    }
}
