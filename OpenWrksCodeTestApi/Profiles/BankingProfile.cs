using AutoMapper;
using OpenWrksCodeTestApi.Core.DataModels.BankingContext;
using OpenWrksCodeTestApi.ViewModels;

namespace OpenWrksCodeTestApi.Profiles
{
    public class BankingProfile : Profile
    {
        public BankingProfile()
        {
            CreateMap<UserAccountViewModel, UserAccount>();
            CreateMap<TransactionsViewModel, Transaction>();
        }
    }
}
