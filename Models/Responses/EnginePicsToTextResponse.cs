using System.Text.Json.Serialization;

namespace echo_mate_backend.Models.Responses
{
    public record EnginePicsToTextResponse(
        [property: JsonPropertyName("sentence")]
        string OutputText
    );
}
