using Newtonsoft.Json;
using System;

namespace OpenWrksCodeTestApi.Business.Integration.FairwayBank.Models
{
    public class Balance
    {
        [JsonProperty(PropertyName = "amount")]
        public double Amount { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Mode { get; set; }

        [JsonProperty(PropertyName = "dateTime")]
        public DateTime Date { get; set; }

        [JsonProperty(PropertyName = "overdraft")]
        public Overdraft Overdraft { get; set; }
    }
}
