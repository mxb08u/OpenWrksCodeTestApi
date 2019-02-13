namespace OpenWrksCodeTestApi.Core.Contracts.Services
{
    public interface IBankFactory
    {
        IBankingLookup Create(string bankName);
    }
}
