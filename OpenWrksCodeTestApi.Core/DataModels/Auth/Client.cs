using System.ComponentModel.DataAnnotations;

namespace OpenWrksCodeTestApi.Core.DataModels.Auth
{
    public class Client
    {
        [Key]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
