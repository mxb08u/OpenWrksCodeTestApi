using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenWrksCodeTestApi.Core.Contracts.Services;
using OpenWrksCodeTestApi.Core.DataModels.BankingContext;
using OpenWrksCodeTestApi.Core.Exceptions;
using OpenWrksCodeTestApi.ViewModels;
using System.Collections.Generic;

namespace OpenWrksCodeTestApi.Controllers
{
    [Route("api/v{version:apiVersion}/users")]
    [ApiVersion("1.0")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<UserAccountViewModel>> Get()
        {
            var allDataUsers = _userService.GetAll();

            var allMappedUsers = _mapper.Map<IEnumerable<UserAccountViewModel>>(allDataUsers);
            
            return Ok(allMappedUsers);
        }

        /// <summary>
        /// Get a single user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{userId}")]
        public ActionResult<UserAccountViewModel> Get(string userId)
        {
            var user = _userService.GetUser(userId);

            if (user == null)
            {
                return NotFound();
            }

            var mappedUser = _mapper.Map<UserAccountViewModel>(user);

            return Ok(mappedUser);
        }

        [HttpPost]
        public ActionResult<UserAccountViewModel> CreateUser(UserAccountViewModel user)
        {
            UserAccount createdUser = null;
            try
            {
                createdUser = _userService.CreateUser(user.BankName, user.AccountNumber);
            }catch(NotUniqueException)
            {
                return BadRequest("Account number must be unique");
            }

            var mappedUser = _mapper.Map<UserAccountViewModel>(createdUser);

            return CreatedAtAction("CreateUser", mappedUser);
        }
    }
}
