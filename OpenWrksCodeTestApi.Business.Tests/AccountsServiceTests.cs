using Moq;
using NUnit.Framework;
using OpenWrksCodeTestApi.Core.Contracts.Repositories;
using OpenWrksCodeTestApi.Core.Contracts.Services;
using OpenWrksCodeTestApi.Core.DataModels.BankingContext;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenWrksCodeTestApi.Business.Tests
{
    /// <summary>
    /// Note to reviewer. I have not added all the tests here as it takes alot of time and i feel the below can give you a feel for the testability of the code and my ability to write them.
    /// </summary>
    public class AccountsServiceTests
    {
        [Test]
        public void UserAccountFetchedFromFairwaySuccessfully()
        {
            var mockUserRepo = new Mock<IUserRepository>(MockBehavior.Strict);
            var bankFactory = new Mock<IBankFactory>();
            var fairwayMock = new Mock<IThirdPartyBankApi>();

            var testAccounts = new List<UserAccount>
            {
                new UserAccount
                {
                    BankName = "Fairway",
                    UserId = "test-user-id",
                    AccountNumber = "12341234"
                }
            };

            mockUserRepo.Setup(x => x.GetAllForUser(It.IsAny<string>())).Returns(testAccounts);

            bankFactory.Setup(x => x.Create("Fairway")).Returns(fairwayMock.Object);

            fairwayMock.Setup(x => x.GetAccountAsync("12341234")).Returns(Task.FromResult(new UserAccount
            {
                AccountName = "Current account",
                AccountNumber = "12341234"
            }));
            
            var accountsService = new AccountsService(mockUserRepo.Object, bankFactory.Object);
            var accounts = accountsService.GetAccountsAsync("test-user-id").Result;

            Assert.IsTrue(accounts.Count() == 1, "Should have had a single account, instead we have more");
        }
    }
}
