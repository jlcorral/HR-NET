using QuotesAssessment.Core.Domain;

namespace QuotesAssessment.Infrastructure.Repositories
{
    public interface IQuoteRepository
    {
        Task Create(Quote quote);
        Task Update(Quote quote);
        Task Delete(int id);
        Task<IEnumerable<Quote>> Get();
        Task<Quote> Get(int id);
    }
}
