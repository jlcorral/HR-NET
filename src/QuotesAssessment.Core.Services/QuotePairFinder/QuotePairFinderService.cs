namespace QuotesAssessment.Core.Services.QuotePairFinder;

public class QuotePairFinderService : IQuotePairFinderService
{
    public Task<long> GetNumberOfQuotePairs(List<int> quotesLength, int targetLength) => Task
        .Factory
        .StartNew(() => GetNumberOfQuotePairsSync(quotesLength, targetLength), TaskCreationOptions.LongRunning);
 
    private long GetNumberOfQuotePairsSync(IList<int> quotesLength, int targetLength)
    {
        if (quotesLength.Count <= 1) return 0;

        long response = 0;


        for (int left = 0; left < quotesLength.Count - 1; left++)
        {
            if (quotesLength[left] > targetLength) continue;
            for (int right = left + 1; right < quotesLength.Count; right++)
            {
                int sum = quotesLength[left] + quotesLength[right];
                if (sum > targetLength) break;
                response++;
            }
        }

        return response;
    }
}
