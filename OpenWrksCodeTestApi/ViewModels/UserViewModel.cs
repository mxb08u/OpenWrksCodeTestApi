using System.ComponentModel.DataAnnotations;

namespace OpenWrksCodeTestApi.ViewModels
{
    public class UserViewModel
    {
        public string UserId { get; set; }
        [Required]
        public string BankName { get; set; }
        [Required]
        [RegularExpression("^[\\d]{8}$")]
        public string AccountNumber { get; set; }
    }
}
