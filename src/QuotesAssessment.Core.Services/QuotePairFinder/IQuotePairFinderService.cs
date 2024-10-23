namespace QuotesAssessment.Core.Services.QuotePairFinder
{
    public interface IQuotePairFinderService
    {
        Task<long> GetNumberOfQuotePairs(List<int> quotesLength, int targetLength);
    }
}
