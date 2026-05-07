namespace echo_mate_backend.Models.Requests
{
    public record PicsToTextRequest(
        List<string> Keywords
    );
}
