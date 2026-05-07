namespace echo_mate_backend.Models.Responses
{
    public record PicsCatalog
    (
        List<PicsCatalogItem> picsItems
    );

    public class PicsCatalogItem
    {
        public PicsCatalogItem(string keyword, string imageUrl, int categoryId)
        {
            Keyword = keyword;
            ImageUrl = imageUrl;
            CategoryId = categoryId;
        }

        public string Keyword { get; }

        public string ImageUrl { get; }

        public int CategoryId { get; }
    }
}

