using HttpRepository.Contract;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpRepository.Service
{
    public class BaseRepository : IBaseHttpRepository
    {
        private readonly HttpClient _httpClient;
        protected BaseRepository(HttpClient client)
        {
            _httpClient = client;
        }
        public Dictionary<string, string> HeaderProperties { get; set; }
        public string ContentType { get; set; } = "application/json";

        public async Task<bool> Delete<T>(T request, string requestUri)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(ContentType));
            PopulateHeader();
            var response = await _httpClient.PutAsync(requestUri, new StringContent(JsonConvert.SerializeObject(request)));
            return response.IsSuccessStatusCode;
        }

        public async Task<U> Get<U>(string requestUri)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(ContentType));
            PopulateHeader();
            var response = await _httpClient.GetAsync(requestUri);
            if (response.IsSuccessStatusCode)
            {
                var responseMessage = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<U>(responseMessage);
            }
            else return default(U);
        }

        public async Task<U> Post<T, U>(T request, string requestUri)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(ContentType));
            PopulateHeader();
            var response = await _httpClient.PostAsync(requestUri, new StringContent(JsonConvert.SerializeObject(request)));
            if (response.IsSuccessStatusCode)
            {
                var responseMessage = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<U>(responseMessage);
            }
            else return default(U);
        }

        public async Task<bool> Put<T>(T request, string requestUri)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(ContentType));
            PopulateHeader();
            var response = await _httpClient.PutAsync(requestUri, new StringContent(JsonConvert.SerializeObject(request)));
            return response.IsSuccessStatusCode;
        }

        private void PopulateHeader()
        {
            foreach (var element in HeaderProperties)
            {
                _httpClient.DefaultRequestHeaders.Add(element.Key, element.Value);
            }
        }
    }
}
