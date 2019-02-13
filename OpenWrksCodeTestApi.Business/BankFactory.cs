using OpenWrksCodeTestApi.Business.Integration.BizifiBank;
using OpenWrksCodeTestApi.Business.Integration.FairwayBank;
using OpenWrksCodeTestApi.Core.Contracts.Services;
using System;

namespace OpenWrksCodeTestApi.Business
{
    public class BankFactory : IBankFactory
    {
        public IThirdPartyBankApi Create(string bankName)
        {
            bankName = bankName.ToLower();
            switch (bankName)
            {
                case "bizfibank":
                    return new BizfiBank();

                case "fairwaybank":
                    return new FairwayBank();
            }

            throw new NotImplementedException(bankName);
        }
    }
}
