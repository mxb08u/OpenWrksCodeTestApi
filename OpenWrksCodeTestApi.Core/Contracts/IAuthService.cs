using System.IdentityModel.Tokens.Jwt;

namespace OpenWrksCodeTestApi.Core.Contracts
{
    public interface IAuthService
    {
        /// <summary>
        /// Check to make sure the client is an allowed client
        /// </summary>
        /// <param name="client">The clients name</param>
        /// <param name="secret">The clients secret</param>
        /// <returns>true or false</returns>
        bool IsValid(string client, string secret);

        /// <summary>
        /// Generate our bearer token
        /// </summary>
        /// <param name="client"></param>
        /// <param name="secret"></param>
        /// <returns></returns>
        string GenerateToken(string client);
    }
}
