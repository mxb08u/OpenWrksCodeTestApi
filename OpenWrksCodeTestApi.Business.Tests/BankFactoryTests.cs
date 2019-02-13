using NUnit.Framework;
using OpenWrksCodeTestApi.Business.Integration.BizifiBank;
using OpenWrksCodeTestApi.Business.Integration.FairwayBank;
using System;

namespace OpenWrksCodeTestApi.Business.Tests
{
    public class BankFactoryTests
    {
        [Test]
        public void BankFactoryBizifiBank()
        {
            var bf = new BankFactory();
            var objResult = bf.Create("bizfibank");

            Assert.IsInstanceOf(typeof(BizfiBank), objResult, "Bank factory produced an incorrect type when it was meant to produce bizfibank");
        }

        [Test]
        public void BankFactoryFairwayBank()
        {
            var bf = new BankFactory();
            var objResult = bf.Create("fairwaybank");

            Assert.IsInstanceOf(typeof(FairwayBank), objResult, "Bank factory produced an incorrect type when it was meant to produce fairwaybank");
        }

        [Test]
        public void BankFactoryUnknownBank()
        {
            var bf = new BankFactory();
            try
            {
                var objResult = bf.Create("mattsBank");
            }
            catch (NotImplementedException)
            {
                Assert.Pass();
                return;
            }

            Assert.Fail("Not implemented exception was not thrown. Matts bank appears to be a real bank when it should not have been");
        }
    }
}
