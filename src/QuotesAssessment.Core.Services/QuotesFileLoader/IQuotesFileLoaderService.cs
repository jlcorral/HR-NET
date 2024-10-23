namespace QuotesAssessment.Core.Services.QuotesFileLoader;

public interface IQuotesFileLoaderService
{
    Task<List<int>> GetQuotesLengths(string filePath);
}