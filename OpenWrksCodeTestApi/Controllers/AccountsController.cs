using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenWrksCodeTestApi.Core.Contracts.Services;
using OpenWrksCodeTestApi.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenWrksCodeTestApi.Controllers
{
    [Route("api/v{version:apiVersion}/users/{userId}/accounts")]
    [ApiVersion("1.0")]
    [ApiController]
    [Authorize]
    public class AccountsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAccountsService _accountsService;
        public AccountsController(IMapper mapper, IAccountsService accountsService)
        {
            _mapper = mapper;
            _accountsService = accountsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserAccountViewModel>>> Get(string userId)
        {
            var accounts = await _accountsService.GetAccountsAsync(userId);

            var mappedAccounts = _mapper.Map<IEnumerable<UserAccountViewModel>>(accounts);

            return Ok(mappedAccounts);
        }

        [HttpGet]
        [Route("{accountNumber}")]
        public async Task<ActionResult<UserAccountViewModel>> Get(string userId, string accountNumber)
        {
            var accounts = await _accountsService.GetAccountAsync(userId, accountNumber, true);

            var mappedAccounts = _mapper.Map<UserAccountViewModel>(accounts);

            return Ok(mappedAccounts);
        }
    }
}
