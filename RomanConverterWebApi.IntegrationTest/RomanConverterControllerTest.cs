using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using RomanConvertWebApi;
using RomanConvertWebApi.Controllers;

namespace RomanConverterWebApi.IntegrationTest
{
    public class Tests
    {
        private StartupWebApplicationFactory<Startup, RomanConverterController> _webApplicationFactory;
        private HttpClient _client;
        private const string _endpoint = "protectedattributesetups";

        [SetUp]
        public void Setup()
        {
            _webApplicationFactory = new StartupWebApplicationFactory<Startup, RomanConverterController>();
            _client = _webApplicationFactory.CreateClient();
        }

        [Test]
        public async Task RomanToDigitalTestSucceed()
        {
            var response = await _client.GetAsync("RomanConverter/RomanToDigital/XX");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            string content = response.Content.ReadAsStringAsync().Result;
            Assert.AreEqual("20", content);
        }

        [Test]
        public async Task RomanToDigitalTestFailed()
        {
            var response = await _client.GetAsync("RomanConverter/RomanToDigital/xx");
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            string content = response.Content.ReadAsStringAsync().Result;
            Assert.AreEqual("Specified argument was out of the range of valid values. (Parameter 'Insert only Roman character (IVXLCDM)')", content);
        }

        [Test]
        public async Task DigitalToRomanTestSucceed()
        {
            var response = await _client.GetAsync("RomanConverter/DigitalToRoman/20");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            string content = response.Content.ReadAsStringAsync().Result;
            Assert.AreEqual("XX", content);
        }

        [Test]
        public async Task DigitalToRomanTestFail()
        {
            var response = await _client.GetAsync("RomanConverter/DigitalToRoman/20000");
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            string content = response.Content.ReadAsStringAsync().Result;
            Assert.AreEqual("Specified argument was out of the range of valid values. (Parameter 'Insert value between 1 and 4000')", content);
        }

    }
}