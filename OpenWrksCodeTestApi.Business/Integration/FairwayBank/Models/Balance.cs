using System;

namespace OpenWrksCodeTestApi.Business.Integration.FairwayBank.Models
{
    public class Balance
    {
        public double Amount { get; set; }
        public string Mode { get; set; }
        public DateTime Date { get; set; }
        public Overdraft Overdraft { get; set; }
    }
}
