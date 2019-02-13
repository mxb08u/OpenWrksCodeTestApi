using System.ComponentModel.DataAnnotations;

namespace OpenWrksCodeTestApi.ViewModels
{
    public class TokenCredentialsViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
