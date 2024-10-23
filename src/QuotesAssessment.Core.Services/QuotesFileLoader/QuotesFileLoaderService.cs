using QuotesAssessment.Core.Domain;
using System.Text;
using System.Text.Json;

namespace QuotesAssessment.Core.Services.QuotesFileLoader;

public class QuotesFileLoaderService : IQuotesFileLoaderService
{
    private const char ObjectBeginDiscriminator = '{';
    private const char ObjectEndDiscriminator = '}';

    public Task<List<int>> GetQuotesLengths(string filePath) => Task.Factory.StartNew(() =>
    {
        List<int> response = new();

        Stream stream = new FileStream(filePath, FileMode.Open);

        while (true)
        {
            int value = stream.ReadByte();
            if (value == -1) break;

            char character = (char)value;
            if (character != ObjectBeginDiscriminator) continue;

            StringBuilder quoteJsonBuilder = new();
            quoteJsonBuilder.Append(character);

            int quoteLength = GetQuoteLength(stream);
            response.Add(quoteLength);
        }

        response.Sort();
        return response;

    }, TaskCreationOptions.LongRunning);


    private int GetQuoteLength(Stream stream)
    {
        StringBuilder quoteJsonBuilder = new();

        quoteJsonBuilder.Append(ObjectBeginDiscriminator);

        char character = ObjectBeginDiscriminator;

        while (character != ObjectEndDiscriminator)
        {
            int value = stream.ReadByte();
            character = (char)value;
            quoteJsonBuilder.Append(character);
        }

        string quoteJson = quoteJsonBuilder.ToString();

        Quote quote = JsonSerializer.Deserialize<Quote>(quoteJson)!;

        return quote.Text.Length;
    }
}
