using Microsoft.IdentityModel.Tokens;
using OpenWrksCodeTestApi.Core.Contracts.Repositories;
using OpenWrksCodeTestApi.Core.Contracts.Services;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OpenWrksCodeTestApi.Business
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _clientContext;
        public AuthService(IAuthRepository clientContext)
        {
            _clientContext = clientContext;
        }

        public bool IsValid(string username, string password)
        {
            var client = _clientContext.GetNamedClient(username);

            if(client == null)
            {
                return false;
            }

            if(client.Password == password)
            {
                return true;
            }

            return false;
        }

        public string GenerateToken(string client)
        {
            // Anything we like could go in the claim. It doesn't really matter for this example so ill include name, expiration and not before as examples
            // We would include things in the claim for access control. 
            // Things like expiration dates, not before dates, areas we are allowed access to etc etc..
            var claims = new Claim[] {
                new Claim(ClaimTypes.Name, client),
                new Claim(JwtRegisteredClaimNames.Exp, $"{new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds()}"),
                new Claim(JwtRegisteredClaimNames.Nbf, $"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}")
            };

            // Now create the actual security token.
            // SecurityAlgorithms are a whole different topic. We will just use a hashed SHA256 as an example
            var jwtToken = new JwtSecurityToken(
                issuer: "OpenWrksCodeTestApi",
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddDays(28),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes("OpenWrksOpenWrksOpenWrks")), SecurityAlgorithms.HmacSha256)
            );

            ///Create te bearer token
            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
