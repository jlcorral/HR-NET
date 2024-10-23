using QuotesAssessment.Core.Domain;
using System.Collections.Concurrent;

namespace QuotesAssessment.Infrastructure.Repositories
{
    public class QuoteRepository : IQuoteRepository
    {
        private static readonly ConcurrentDictionary<int, Quote> _store = new ConcurrentDictionary<int, Quote>();
        private static int _id = 0;

        private int GenerateId()
        {
            return Interlocked.Increment(ref _id);
        }

        public Task Create(Quote quote)
        {
            quote.Id = GenerateId();

            bool inserted = _store.TryAdd(quote.Id, quote);

            if (!inserted)
                throw new Exception("Unable to insert record");

            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            bool deleted = false;
            if (_store.ContainsKey(id))
                deleted = _store.TryRemove(id, out var quote);

            if (!deleted)
                throw new Exception($"Unable to delete object with id: {id}");

            return Task.CompletedTask;
        }

        public Task<IEnumerable<Quote>> Get()
        {
            IEnumerable<Quote> response = _store.Select(x => x.Value);

            return Task.FromResult(response);
        }

        public Task<Quote> Get(int id)
        {
            bool retrieved = _store.TryGetValue(id, out var response);
            if (!retrieved)
                response = default;

            return Task.FromResult(response);

        }

        public async Task Update(Quote quote)
        {
            Quote storedQuote = await Get(quote.Id);
            if (storedQuote == default)
                throw new Exception($"No object matches given id: {quote.Id}");

            storedQuote.Author = quote.Author;
            storedQuote.Text = quote.Text;
            storedQuote.Name = quote.Name;
        }
    }
}
