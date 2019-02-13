using System.ComponentModel.DataAnnotations;

namespace OpenWrksCodeTestApi.Core.DataModels.BankingContext
{
    public class UserAccount
    {
        public string UserId { get; set; }
        public string BankName { get; set; }

        [Key]
        public string AccountNumber { get; set; }
    }
}
