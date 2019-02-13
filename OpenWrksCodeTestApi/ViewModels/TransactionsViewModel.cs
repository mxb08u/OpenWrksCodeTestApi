using System;

namespace OpenWrksCodeTestApi.ViewModels
{
    public class TransactionsViewModel
    {
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime TransactDate { get; set; }
        public string Mode { get; set; }
    }
}
