using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenWrksCodeTestApi.Core.Contracts.Services;
using OpenWrksCodeTestApi.ViewModels;
using System.Collections.Generic;

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
        public ActionResult<IEnumerable<UserAccountViewModel>> Get(string userId)
        {
            var accounts = _accountsService.GetAccountsForUser(userId);

            var mappedAccounts = _mapper.Map<IEnumerable<UserAccountViewModel>>(accounts);

            return Ok(mappedAccounts);
        }
    }
}
