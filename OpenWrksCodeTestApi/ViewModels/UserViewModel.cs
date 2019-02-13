using System.ComponentModel.DataAnnotations;

namespace OpenWrksCodeTestApi.ViewModels
{
    public class UserViewModel
    {
        public string UserId { get; set; }
        [Required]
        public string BankName { get; set; }
        [Required]
        public string AccountNumber { get; set; }
    }
}
