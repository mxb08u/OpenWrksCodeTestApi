﻿using Moq;
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

            accountsServiceMock.Setup(x => x.GetAccountAsync(It.IsAny<string>(), It.IsAny<string>(), false)).Returns(Task.FromResult((UserAccount)null));

            var transactionsService = new TransactionsService(accountsServiceMock.Object, bankFactoryMock.Object);

            var transactions = transactionsService.GetTransactionsAsync("123", "123").Result;

            Assert.IsNull(transactions, "Transactions was not null when it should have been");
        }

        [Test]
        public void GetTransactionsFindsTransactions()
        {
            var accountsServiceMock = new Mock<IAccountsService>();
            var bankFactoryMock = new Mock<IBankFactory>();
            var fairwayMock = new Mock<IThirdPartyBankApi>();

            accountsServiceMock.Setup(x => x.GetAccountAsync(It.IsAny<string>(), It.IsAny<string>(), false)).Returns(Task.FromResult(new UserAccount { BankName = "fairways" }));
            bankFactoryMock.Setup(x => x.Create(It.IsAny<string>())).Returns(fairwayMock.Object);
            fairwayMock.Setup(x => x.GetTransactionsAsync(It.IsAny<string>())).Returns(Task.FromResult<IEnumerable<Transaction>>(new List<Transaction>()));

            var transactionsService = new TransactionsService(accountsServiceMock.Object, bankFactoryMock.Object);
            var transactions = transactionsService.GetTransactionsAsync("123", "123").Result;

            Assert.IsNotNull(transactions);
        }
    }
}
