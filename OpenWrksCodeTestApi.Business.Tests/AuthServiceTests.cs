using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using OpenWrksCodeTestApi.Core.Contracts;
using OpenWrksCodeTestApi.Core.DataModels.Auth;

namespace OpenWrksCodeTestApi.Business.Tests
{
    public class AuthServiceTests
    {
        [Test]
        public void ValidClientReturnsTrue()
        {
            var authRepoMock = new Mock<IAuthRepository>(MockBehavior.Strict);
            authRepoMock.Setup(x => x.GetNamedClient(It.IsAny<string>())).Returns(new Client
            {
                Username = "UnitTestClient", 
                Password = "UnitTestSecret"
            });

            var authService = new AuthService(authRepoMock.Object);
            var result = authService.IsValid("UnitTestClient", "UnitTestSecret");

            Assert.IsTrue(result, "Auth service failed to validate a client when it should have been able to");
        }

        [Test]
        public void ValidClientInvalidSecretReturnsFalse()
        {
            var authRepoMock = new Mock<IAuthRepository>(MockBehavior.Strict);
            authRepoMock.Setup(x => x.GetNamedClient(It.IsAny<string>())).Returns(new Core.DataModels.Auth.Client
            {
                Username = "UnitTestClient",
                Password = "UnitTestSecret"
            });

            var authService = new AuthService(authRepoMock.Object);
            var result = authService.IsValid("UnitTestClient", "IncorrectValue");

            Assert.IsFalse(result, "Auth service authorised a client when it should not have as the secret is incorrect");
        }

        [Test]
        public void InvalidClientReturnsFalse()
        {
            var authRepoMock = new Mock<IAuthRepository>(MockBehavior.Strict);
            authRepoMock.Setup(x => x.GetNamedClient(It.IsAny<string>())).Returns((Client)null);

            var authService = new AuthService(authRepoMock.Object);
            var result = authService.IsValid("IncorrectValue", "UnitTestSecret");

            Assert.IsFalse(result, "Auth service authorised a client when the client should not have existed");
        }
    }
}
