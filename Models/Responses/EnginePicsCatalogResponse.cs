using System.Text.Json.Serialization;

namespace echo_mate_backend.Models.Responses
{
    //public record EnginePicsCatalogResponse(
    //    [property: JsonPropertyName("result")]
    //    List<PicsCatalogResult> Result
    //);

    public record PicsCatalogResult(
        [property: JsonPropertyName("keyword")]
        string Keyword,
        [property: JsonPropertyName("file")]
        string File,
        [property: JsonPropertyName("category_id")]
        int CategoryId
    );
}
