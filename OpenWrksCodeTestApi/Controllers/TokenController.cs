using Microsoft.AspNetCore.Mvc;
using OpenWrksCodeTestApi.Core.Contracts.Services;
using OpenWrksCodeTestApi.ViewModels;

namespace OpenWrksCodeTestApi.Controllers
{
    /// <summary>
    /// This controller is here for development purposes. The behaviour of this controller would normally be handled by a authentication provider such as identity server or openidconnect or any other provider.
    /// It is simply here so i can secure the api with a jwt bearer token in an automated way.
    /// </summary>
    [Route("api/v{version:apiVersion}/token")]
    [ApiVersion("1.0")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthService _authService;
        public TokenController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public IActionResult Post(TokenCredentialsViewModel tokenCredentials)
        {
            var isValid = _authService.IsValid(tokenCredentials.Username, tokenCredentials.Password);

            if (!isValid)
            {
                return BadRequest();
            }

            var bearer = _authService.GenerateToken(tokenCredentials.Username);
            return new ObjectResult(bearer);
        }
    }
}