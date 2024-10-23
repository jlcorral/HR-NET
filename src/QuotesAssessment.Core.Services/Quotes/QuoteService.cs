using QuotesAssessment.Core.Domain;
using QuotesAssessment.Core.DTOs.Quotes.Requests;
using QuotesAssessment.Core.DTOs.Quotes.Responses;
using QuotesAssessment.Infrastructure.Repositories;


namespace QuotesAssessment.Core.Services.Quotes;


public class QuoteService : IQuoteService
{

    private readonly IQuoteRepository _quoteRepository;

    public QuoteService(IQuoteRepository quoteRepository) => _quoteRepository = quoteRepository;

    public async Task<CreateQuoteResponseDto> Create(CreateQuoteRequestDto request)
    {
        // TODO create a mapping class or implement automapper
        Quote quote = new()
        {
            Author = request.Author,
            Name = request.Name,
            Text = request.Text
        };

        await _quoteRepository.Create(quote);
        CreateQuoteResponseDto response = new()
        {
            Id = quote.Id
        };


        return response;
    }

    public Task Delete(int id) => _quoteRepository.Delete(id);


    public async Task<QuoteResponseDto> Get(int id)
    {
        Quote quote = await _quoteRepository.Get(id);

        QuoteResponseDto response = new()
        {
            Id = quote.Id,
            Author = quote.Author,
            Name = quote.Name,
            Text = quote.Text
        };

        return response;
    }

    public async Task<IEnumerable<QuoteResponseDto>> Get()
    {

        IEnumerable<Quote> quotes = await _quoteRepository.Get();

        // TODO create a mapping class or implement automapper
        IEnumerable<QuoteResponseDto> response = quotes
            .Select(x => new QuoteResponseDto
            {
                Id = x.Id,
                Author = x.Author,
                Name = x.Name,
                Text = x.Text
            });

        return response;
    }

    public Task Update(UpdateQuoteRequestDto request)
    {
        // TODO create a mapping class or implement automapper
        Quote quote = new()
        {

            Id = request.Id,
            Author = request.Author,
            Name = request.Name,
            Text = request.Text
        };

        return _quoteRepository.Update(quote);
    }
}
