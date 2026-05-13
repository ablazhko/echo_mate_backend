using echo_mate_backend.Clients;
using echo_mate_backend.Models.Responses;

namespace echo_mate_backend.Services
{
    public class TranslationService
    {
        private readonly EchoMateEngineHttpClient _client;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TranslationService(EchoMateEngineHttpClient client, IHttpContextAccessor httpContextAccessor)
        {
            _client = client;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<TextToPicsResponse?> TranslateTextAsync(string input)
        {
            var result = await _client.TranslateTextAsync(input);

            if (result == null)
                return null;

            return new TextToPicsResponse(
                    result.OutputText,
                    result.Files.Select(f => BuildImageUrl(f)).ToList()
                );
        }

        public async Task<PicsToTextResponse?> TranslatePicsAsync(List<string> keywords)
        {
            var result = await _client.TranslatePicsAsync(keywords);

            if (result == null)
                return null;

            return new PicsToTextResponse(
                    result.OutputText
                );
        }

        public async Task<PicsCatalog?> GetPicsCatalogAsync()
        {
            var result = await _client.GetPicsCatalogAsync();
            if (result == null)
                return null;
            return new PicsCatalog(
                result.Select(c => new PicsCatalogItem(c.Keyword, BuildImageUrl(c.File), c.CategoryId)).ToList() // TODO: change File to ImageUrl in the response from engine
                );
        }

        private string BuildImageUrl(string file)
        {
            var request = _httpContextAccessor.HttpContext?.Request;
            var baseUrl = $"{request.Scheme}://{request.Host}";
            return $"{baseUrl}/images/pics/{file}";
        }
    }
}
