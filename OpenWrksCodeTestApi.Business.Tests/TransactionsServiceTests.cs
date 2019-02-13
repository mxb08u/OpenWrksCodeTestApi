using Moq;
using NUnit.Framework;
using OpenWrksCodeTestApi.Core.Contracts.Services;
using OpenWrksCodeTestApi.Core.DataModels.BankingContext;
using OpenWrksCodeTestApi.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenWrksCodeTestApi.Business.Tests
{
    /// <summary>
    /// Note: The tests here are not comprehensive. They are just an example of how i would test this.
    /// </summary>
    public class TransactionsServiceTests
    {
        [Test]
        public void UserAndAccountAreMismatching()
        {
            var accountsServiceMock = new Mock<IAccountsService>();
            var bankFactoryMock = new Mock<IBankFactory>();

            accountsServiceMock.Setup(x => x.GetAccount(It.IsAny<string>(), It.IsAny<string>(), false)).Returns(Task.FromResult((UserAccount)null));

            var transactionsService = new TransactionsService(accountsServiceMock.Object, bankFactoryMock.Object);

            try
            {
                var transactions = transactionsService.GetTransactions("123", "123").Result;
            }
            catch (AggregateException agg)
            {
                Assert.IsInstanceOf<MismatchException>(agg.InnerException);
                return;
            }

            Assert.Fail("Expected 'MismatchException' but it was not thrown");
        }

        [Test]
        public void GetTransactionsFindsTransactions()
        {
            var accountsServiceMock = new Mock<IAccountsService>();
            var bankFactoryMock = new Mock<IBankFactory>();
            var fairwayMock = new Mock<IThirdPartyBankApi>();

            accountsServiceMock.Setup(x => x.GetAccount(It.IsAny<string>(), It.IsAny<string>(), false)).Returns(Task.FromResult(new UserAccount { BankName = "fairways" }));
            bankFactoryMock.Setup(x => x.Create(It.IsAny<string>())).Returns(fairwayMock.Object);
            fairwayMock.Setup(x => x.GetTransactionsAsync(It.IsAny<string>())).Returns(Task.FromResult<IEnumerable<Transaction>>(new List<Transaction>()));

            var transactionsService = new TransactionsService(accountsServiceMock.Object, bankFactoryMock.Object);
            var transactions = transactionsService.GetTransactions("123", "123").Result;

            Assert.IsNotNull(transactions);
        }
    }
}
