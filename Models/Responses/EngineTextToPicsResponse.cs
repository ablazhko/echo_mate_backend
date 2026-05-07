using System.Text.Json.Serialization;

namespace echo_mate_backend.Models.Responses
{
    public record EngineTextToPicsResponse(
        [property: JsonPropertyName("summary")]
        string OutputText,
        [property: JsonPropertyName("files")]
        List<string> ImageUrls
    );
}
