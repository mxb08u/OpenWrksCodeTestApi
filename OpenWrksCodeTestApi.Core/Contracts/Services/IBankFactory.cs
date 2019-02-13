namespace OpenWrksCodeTestApi.Core.Contracts.Services
{
    public interface IBankFactory
    {
        IThirdPartyBankApi Create(string bankName);
        bool IsSupported(string bankName);
    }
}
