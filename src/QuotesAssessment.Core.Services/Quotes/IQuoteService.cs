using QuotesAssessment.Core.DTOs.Quotes.Requests;
using QuotesAssessment.Core.DTOs.Quotes.Responses;

namespace QuotesAssessment.Core.Services.Quotes
{
    public interface IQuoteService
    {
        Task<CreateQuoteResponseDto> Create(CreateQuoteRequestDto request);
        Task Update(UpdateQuoteRequestDto request);
        Task Delete(int id);
        Task<QuoteResponseDto> Get(int id);
        Task<IEnumerable<QuoteResponseDto>> Get();
    }
}
