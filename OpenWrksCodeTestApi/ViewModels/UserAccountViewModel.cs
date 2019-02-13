using System.ComponentModel.DataAnnotations;

namespace OpenWrksCodeTestApi.ViewModels
{
    public class UserAccountViewModel
    {
        public string UserId { get; set; }
        [Required]
        public string BankName { get; set; }

        [MinLength(8)]
        [MaxLength(8)]
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string SortCode { get; set; }
        public double? Balance { get; set; }
        public double? AvailableBalance { get; set; }
        public double? Overdraft { get; set; }
    }
}
