using System.ComponentModel.DataAnnotations;

namespace OpenWrksCodeTestApi.Core.DataModels.ClientContext
{
    public class Client
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
