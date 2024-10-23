using QuotesAssessment.Core.Services.QuotePairFinder;
using QuotesAssessment.Core.Services.QuotesFileLoader;
using System.Reflection;

namespace QuotesAssessment.Tests.Core.Services
{
    [TestClass]
    public class QuotePairFinderServiceTests
    {
        private readonly string fullFilePath;
        private const string FilePath = @"Assets\ShortDb.json";
        IQuotePairFinderService _quotePairFinderService = new QuotePairFinderService();
        private static List<int> _quotesLengths = new List<int>();


        public QuotePairFinderServiceTests()
        {
            fullFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), FilePath);
        }


        [TestInitialize]
        public async Task InitTest()
        {
            IQuotesFileLoaderService quotesFileLoaderService = new QuotesFileLoaderService();
            _quotesLengths = quotesFileLoaderService.GetQuotesLengths(fullFilePath).Result;
        }

        [TestMethod]
        public async Task can_get_combinations_for_length_19()
        {
            int targetLength = 19;

            long result = await _quotePairFinderService.GetNumberOfQuotePairs(_quotesLengths, targetLength);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public async Task can_get_combinations_for_length_22()
        {
            int targetLength = 22;

            long result = await _quotePairFinderService.GetNumberOfQuotePairs(_quotesLengths, targetLength);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public async Task can_get_combinations_for_length_32()
        {
            int targetLength = 32;

            long result = await _quotePairFinderService.GetNumberOfQuotePairs(_quotesLengths, targetLength);

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public async Task can_get_combinations_for_length_40()
        {
            int targetLength = 40;

            long result = await _quotePairFinderService.GetNumberOfQuotePairs(_quotesLengths, targetLength);

            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public async Task can_get_combinations_for_length_200()
        {
            int targetLength = 200;

            long result = await _quotePairFinderService.GetNumberOfQuotePairs(_quotesLengths, targetLength);

            Assert.AreEqual(21, result);
        }
    }
}
