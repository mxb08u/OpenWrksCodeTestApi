using Moq;
using NUnit.Framework;
using OpenWrksCodeTestApi.Core.Contracts.Repositories;
using OpenWrksCodeTestApi.Core.DataModels.BankingContext;
using OpenWrksCodeTestApi.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenWrksCodeTestApi.Business.Tests
{
    public class UserServiceTests
    {
        [Test]
        public void GetUserCallsRepoOnlyOnce()
        {
            var userRepoMock = new Mock<IUserRepository>();
            userRepoMock.Setup(x => x.GetUsers(It.IsAny<string>())).Returns(new List<UserAccount>());

            var userService = new UserService(userRepoMock.Object);
            userService.GetUsers(Guid.NewGuid().ToString());

            userRepoMock.Verify(x => x.GetUsers(It.IsAny<string>()), Times.Exactly(1), "Get user was called multiple times when it should have only been called once");
        }

        [Test]
        public void GetUserReturnsValidUser()
        {
            var userRepoMock = new Mock<IUserRepository>();
            userRepoMock.Setup(x => x.GetUsers(It.IsAny<string>())).Returns(new List<UserAccount> { new UserAccount() });

            var userService = new UserService(userRepoMock.Object);
            var foundUsers = userService.GetUsers(Guid.NewGuid().ToString());
            
            Assert.IsTrue(foundUsers.Any(), "Atleast 1 valid user should have been returned but none where");
        }

        [Test]
        public void GetUserReturnsNoUsers()
        {
            var userRepoMock = new Mock<IUserRepository>();
            userRepoMock.Setup(x => x.GetUsers(It.IsAny<string>())).Returns(new List<UserAccount>());

            var userService = new UserService(userRepoMock.Object);
            var foundUsers = userService.GetUsers(Guid.NewGuid().ToString());

            Assert.IsFalse(foundUsers.Any(), "A user was returned when no users should have been returned");
        }

        [Test]
        public void CreateUserReturnsCreatedUser()
        {
            var userRepoMock = new Mock<IUserRepository>();
            userRepoMock.Setup(x => x.CheckAccountNumberIsUnique(It.IsAny<string>())).Returns(false);
            userRepoMock.Setup(x => x.Create(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(new UserAccount());

            var userService = new UserService(userRepoMock.Object);
            var userAccount = userService.CreateUser("TestBank", "12345678");

            Assert.IsNotNull(userAccount, "user account was null when it should not have been");

            userRepoMock.Verify(x => x.CheckAccountNumberIsUnique(It.IsAny<string>()), Times.Exactly(1), "Get user should have only been called once, but it was called more");
            userRepoMock.Verify(x => x.Create(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(1), "Create user should have only been called once, but it was called more");
        }

        [Test]
        public void CreateUserFailsToCreateUserNonUniqueAccountAndThrowsException()
        {
            var userRepoMock = new Mock<IUserRepository>();
            userRepoMock.Setup(x => x.CheckAccountNumberIsUnique(It.IsAny<string>())).Returns(true);

            var userService = new UserService(userRepoMock.Object);

            try
            {
                var userAccount = userService.CreateUser("TestBank", "12345678");
            }catch(NotUniqueException)
            {
                Assert.Pass();
            }

            Assert.Fail("A NotUniqueException was expected and it didn't get thrown");

        }
    }
}
