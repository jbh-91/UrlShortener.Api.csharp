namespace UrlShortener.Api.Models;

public class UrlMapping
{
    public int Id { get; private set; }
    public string OriginalUrl { get; private set; }
    
    public string? ShortUrl { get; set; }

    public DateTime CreatedAt { get; private set; }

    public UrlMapping(string originalUrl)
    {
        if (string.IsNullOrWhiteSpace(originalUrl))
            throw new ArgumentException("URL darf nicht leer sein.");

        OriginalUrl = originalUrl;
        CreatedAt = DateTime.UtcNow;
    }

    // Von EF Core benötigt; sollte nicht direkt verwendet werden
    private UrlMapping() { }
}