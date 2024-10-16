using RestSharp;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace Cyber_Proj.Services
{
    public class VirusTotalService
    {
        private const string ApiUrl = "https://www.virustotal.com/api/v3/";
        private readonly RestClient _client;

        public VirusTotalService(string apiKey)
        {
            _client = new RestClient(ApiUrl);
            _client.AddDefaultHeader("x-apikey", apiKey);
        }

        public async Task<JObject> UrlScanAsync(string url)
        {
            var request = new RestRequest("urls", Method.Post); // Fixed POST method
            request.AddParameter("url", url);
            var response = await _client.ExecuteAsync(request);
            var jsonResponse = JObject.Parse(response.Content);
            return jsonResponse;
        }

        public async Task<JObject> GetUrlScanReportAsync(string scanId)
        {
            var request = new RestRequest($"urls/{scanId}", Method.Get); // Fixed GET method
            var response = await _client.ExecuteAsync(request);
            var jsonResponse = JObject.Parse(response.Content);
            return jsonResponse;
        }
    }
}
