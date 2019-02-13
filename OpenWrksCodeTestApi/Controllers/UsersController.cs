﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenWrksCodeTestApi.Core.Contracts.Services;
using OpenWrksCodeTestApi.Core.DataModels.BankingContext;
using OpenWrksCodeTestApi.Core.Exceptions;
using OpenWrksCodeTestApi.ViewModels;
using System.Collections.Generic;
using System.Linq;

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
        public ActionResult<IEnumerable<UserViewModel>> Get()
        {
            var allDataUsers = _userService.GetAll();

            var allMappedUsers = _mapper.Map<IEnumerable<UserViewModel>>(allDataUsers);
            
            return Ok(allMappedUsers);
        }

        /// <summary>
        /// Get a single user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{userId}")]
        public ActionResult<IEnumerable<UserViewModel>> Get(string userId)
        {
            var users = _userService.GetUsers(userId);

            if (users == null || !users.Any())
            {
                return NotFound();
            }

            var mappedUser = _mapper.Map<IEnumerable<UserViewModel>>(users);

            return Ok(mappedUser);
        }

        [HttpPost]
        public ActionResult<UserViewModel> CreateUser(UserViewModel user)
        {
            UserAccount createdUser = null;
            try
            {
                createdUser = _userService.CreateUser(user.BankName, user.AccountNumber);
            }catch(NotUniqueException)
            {
                return BadRequest("Account number must be unique");
            }

            var mappedUser = _mapper.Map<UserViewModel>(createdUser);

            return CreatedAtAction("CreateUser", mappedUser);
        }
    }
}
