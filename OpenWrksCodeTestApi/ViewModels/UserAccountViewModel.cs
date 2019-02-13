using System.ComponentModel.DataAnnotations;

namespace OpenWrksCodeTestApi.ViewModels
{
    public class UserAccountViewModel
    {
        public string UserId { get; set; }
        [Required]
        public string BankName { get; set; }

        [Key]
        [MinLength(8)]
        [MaxLength(8)]
        public string AccountNumber { get; set; }
    }
}
