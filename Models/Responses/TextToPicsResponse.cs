namespace echo_mate_backend.Models.Responses
{
    public record TextToPicsResponse(string Summary, List<string> imageUrls);
}
