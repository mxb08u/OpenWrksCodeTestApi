using System;
using System.Collections.Generic;
using OpenWrksCodeTestApi.Core.Contracts.Repositories;
using OpenWrksCodeTestApi.Core.Contracts.Services;
using OpenWrksCodeTestApi.Core.DataModels.BankingContext;
using OpenWrksCodeTestApi.Core.Exceptions;

namespace OpenWrksCodeTestApi.Business
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserAccount GetUser(string accountNumber)
        {
            return _userRepository.GetUser(accountNumber);
        }

        public IEnumerable<UserAccount> GetAll()
        {
            return _userRepository.GetAll();
        }

        public UserAccount CreateUser(string bankName, string accountNumber)
        {
            var foundUser = _userRepository.GetUser(accountNumber);

            if (foundUser != null)
            {
                throw new NotUniqueException($"Cannot create a user with account number: {accountNumber} as it already exists for another user");
            }

            var userId = Guid.NewGuid().ToString();

            return _userRepository.Create(userId, bankName, accountNumber);
        }
    }
}
