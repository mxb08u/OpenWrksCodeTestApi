namespace OpenWrksCodeTestApi.Core.Contracts.Services
{
    public interface IBankFactory
    {
        IThirdPartyBankApi Create(string bankName);
    }
}
