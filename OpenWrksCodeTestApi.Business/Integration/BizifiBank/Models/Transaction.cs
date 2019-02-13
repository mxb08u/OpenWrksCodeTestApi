using Newtonsoft.Json;
using OpenWrksCodeTestApi.Core.Contracts.Integration;
using System;

namespace OpenWrksCodeTestApi.Business.Integration.BizifiBank.Models
{
    public class Transaction : IConverter<Core.DataModels.BankingContext.Transaction>
    {
        [JsonProperty(PropertyName = "amount")]
        public double Amount { get; set; }

        [JsonProperty(PropertyName = "merchant")]
        public string Merchant { get; set; }

        [JsonProperty(PropertyName = "cleared_date")]
        public DateTime ClearedDate { get; set; }

        public Core.DataModels.BankingContext.Transaction Convert()
        {
            return new Core.DataModels.BankingContext.Transaction
            {
                Amount = Amount,
                Description = Merchant,
                Mode = string.Empty,
                TransactDate = ClearedDate
            };
        }
    }
}
