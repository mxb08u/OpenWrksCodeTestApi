using System.ComponentModel.DataAnnotations;

namespace OpenWrksCodeTestApi.Models
{
    public class TokenCredentials
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
