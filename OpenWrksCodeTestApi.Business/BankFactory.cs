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
            switch (bankName.ToLower())
            {
                case "bizfibank":
                    return new BizfiBank();

                case "fairwaybank":
                    return new FairwayBank();
            }

            throw new NotImplementedException(bankName);
        }

        public bool IsSupported(string bankName)
        {
            switch (bankName.ToLower())
            {
                case "bizfibank":
                case "fairwaybank":
                    return true;
            }

            return false;
        }
    }
}
