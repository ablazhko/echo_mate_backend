using echo_mate_backend.Clients;
using echo_mate_backend.Models.Responses;

namespace echo_mate_backend.Services
{
    public class TranslationService
    {
        private readonly EchoMateEngineHttpClient _client;

        public TranslationService(EchoMateEngineHttpClient client)
        {
            _client = client;
        }

        public async Task<TextToPicsResponse?> TranslateTextAsync(string input)
        {
            var result = await _client.TranslateTextAsync(input);

            if (result == null)
                return null;

            return new TextToPicsResponse(
                    result.OutputText,
                    result.ImageUrls
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
                result.Select(c => new PicsCatalogItem(c.Keyword, c.File, c.CategoryId)).ToList() // TODO: change File to ImageUrl in the response from engine
                );
        }
    }
}
