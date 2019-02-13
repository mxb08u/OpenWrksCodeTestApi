using System;

namespace OpenWrksCodeTestApi.Core.DataModels.BankingContext
{
    public class Transaction
    {
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime TransactDate { get; set; }
        public string Mode { get; set; }
    }
}
