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

        public IEnumerable<UserAccount> GetUsers(string userId)
        {
            return _userRepository.GetUsers(userId);
        }

        public IEnumerable<UserAccount> GetAll()
        {
            return _userRepository.GetAll();
        }

        public UserAccount CreateUser(string bankName, string accountNumber, string userId)
        {
            var foundAccountNumber = _userRepository.FindAccountNumber(accountNumber);

            if (foundAccountNumber)
            {
                throw new NotUniqueException($"Cannot create a user with account number: {accountNumber} as it already exists for another user");
            }

            if (string.IsNullOrEmpty(userId))
            {
                userId = Guid.NewGuid().ToString();
            }

            return _userRepository.Create(userId, bankName, accountNumber);
        }
    }
}
