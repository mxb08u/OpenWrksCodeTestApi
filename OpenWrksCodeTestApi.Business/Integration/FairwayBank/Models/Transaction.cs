using Newtonsoft.Json;
using OpenWrksCodeTestApi.Core.Contracts.Integration;
using System;

namespace OpenWrksCodeTestApi.Business.Integration.FairwayBank.Models
{
    public class Transaction : ITransactionConverter
    {
        [JsonProperty(PropertyName = "amount")]
        public double Amount { get; set; }

        [JsonProperty(PropertyName = "transactionInformation")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Mode { get; set; }

        [JsonProperty(PropertyName = "bookedDate")]
        public DateTime BookedDate { get; set; }

        public Core.DataModels.BankingContext.Transaction Convert()
        {
            return new Core.DataModels.BankingContext.Transaction
            {
                Amount = Amount,
                Description = Description,
                Mode = Mode,
                TransactDate = BookedDate
            };
        }
    }
}
