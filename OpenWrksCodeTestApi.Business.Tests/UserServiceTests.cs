using Moq;
using NUnit.Framework;
using OpenWrksCodeTestApi.Core.Contracts.Repositories;
using OpenWrksCodeTestApi.Core.DataModels.BankingContext;
using OpenWrksCodeTestApi.Core.Exceptions;
using System;

namespace OpenWrksCodeTestApi.Business.Tests
{
    public class UserServiceTests
    {
        [Test]
        public void GetUserCallsRepoOnlyOnce()
        {
            var userRepoMock = new Mock<IUserRepository>();
            userRepoMock.Setup(x => x.GetUser(It.IsAny<string>())).Returns(new UserAccount());

            var userService = new UserService(userRepoMock.Object);
             userService.GetUser(Guid.NewGuid().ToString());

            userRepoMock.Verify(x => x.GetUser(It.IsAny<string>()), Times.Exactly(1), "Get user was called multiple times when it should have only been called once");
        }

        [Test]
        public void GetUserReturnsValidUser()
        {
            var userRepoMock = new Mock<IUserRepository>();
            userRepoMock.Setup(x => x.GetUser(It.IsAny<string>())).Returns(new UserAccount());

            var userService = new UserService(userRepoMock.Object);
            var foundUser = userService.GetUser(Guid.NewGuid().ToString());

            Assert.IsNotNull(foundUser, "There was no user found but the repo returned a user");
        }

        [Test]
        public void GetUserReturnsNullUser()
        {
            var userRepoMock = new Mock<IUserRepository>();
            userRepoMock.Setup(x => x.GetUser(It.IsAny<string>())).Returns((UserAccount)null);

            var userService = new UserService(userRepoMock.Object);
            var foundUser = userService.GetUser(Guid.NewGuid().ToString());

            Assert.IsNull(foundUser, "The found user was not null when it should have been");
        }

        [Test]
        public void CreateUserReturnsCreatedUser()
        {
            var userRepoMock = new Mock<IUserRepository>();
            userRepoMock.Setup(x => x.GetUser(It.IsAny<string>())).Returns((UserAccount)null);
            userRepoMock.Setup(x => x.Create(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(new UserAccount());

            var userService = new UserService(userRepoMock.Object);
            var userAccount = userService.CreateUser("TestBank", "12345678");

            Assert.IsNotNull(userAccount, "user account was null when it should not have been");

            userRepoMock.Verify(x => x.GetUser(It.IsAny<string>()), Times.Exactly(1), "Get user should have only been called once, but it was called more");
            userRepoMock.Verify(x => x.Create(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(1), "Create user should have only been called once, but it was called more");
        }

        [Test]
        public void CreateUserFailsToCreateUserNonUniqueAccountAndThrowsException()
        {
            var userRepoMock = new Mock<IUserRepository>();
            userRepoMock.Setup(x => x.GetUser(It.IsAny<string>())).Returns(new UserAccount());

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
