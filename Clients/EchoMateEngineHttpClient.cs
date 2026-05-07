using echo_mate_backend.Models.Responses;

namespace echo_mate_backend.Clients
{
    public class EchoMateEngineHttpClient
    {
        private readonly HttpClient _http;

        public EchoMateEngineHttpClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<EngineTextToPicsResponse?> TranslateTextAsync(string input)
        {
            var response = await _http.PostAsJsonAsync(
                "/translate_text",
                new { input_text = input });

            response.EnsureSuccessStatusCode();

            return await response.Content
                .ReadFromJsonAsync<EngineTextToPicsResponse>();

        }
        public async Task<EnginePicsToTextResponse?> TranslatePicsAsync(List<string> keywords)
        {
            var response = await _http.PostAsJsonAsync(
                "/translate_pics",
                new { input_keywords = keywords });

            response.EnsureSuccessStatusCode();

            return await response.Content
                .ReadFromJsonAsync<EnginePicsToTextResponse>();
        }
        public async Task<List<PicsCatalogResult>?> GetPicsCatalogAsync()
        {
            var response = await _http.GetAsync("/pics_catalog");

            response.EnsureSuccessStatusCode();

            return await response.Content
                .ReadFromJsonAsync<List<PicsCatalogResult>>();
        }
    }
}
