namespace QuotesAssessment.Core.DTOs.Quotes.Requests;

public class UpdateQuoteRequestDto
{
    public int Id { get; set; }
    public string Author { get; set; }
    public string Name { get; set; }
    public string Text { get; set; }
}
