namespace UrlShortener.Api.Models
{
    public class UrlMapping
    {
        public int Id { get; set; }
        public required string OriginalUrl { get; set; }
        
        public string? ShortUrl { get; set; }

        public required DateTime CreatedAt { get; set; }
    }
}
