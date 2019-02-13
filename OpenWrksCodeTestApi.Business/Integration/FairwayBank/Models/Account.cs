using OpenWrksCodeTestApi.Core.Contracts.Integration;
using OpenWrksCodeTestApi.Core.DataModels.BankingContext;

namespace OpenWrksCodeTestApi.Business.Integration.FairwayBank.Models
{
    public class Account : IAccountConverter
    {
        public string Name { get; set; }
        public AccountIdentifierViewModel Identifier { get; set; }

        public UserAccount ToUserAccount()
        {
            var userAccount = new UserAccount
            {
                AccountName = Name,
                AccountNumber = Identifier.AccountNumber,
                SortCode = Identifier.SortCode
            };

            return userAccount;
        }
    }
}
