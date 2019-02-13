using System.ComponentModel.DataAnnotations;

namespace OpenWrksCodeTestApi.Core.DataModels.BankingContext
{
    public class UserAccount
    {
        public string UserId { get; set; }
        public string BankName { get; set; }

        [Key]
        public string AccountNumber { get; set; }

        public string AccountName { get; set; }
        public string SortCode { get; set; }
        public double? Balance { get; set; }
        public double? AvailableBalance { get; set; }
        public double? Overdraft { get; set; }
    }
}
