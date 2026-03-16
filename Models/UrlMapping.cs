namespace UrlShortener.Api.Models;

public class UrlMapping
{
    // required by EF Core; should not be used directly in application code
    protected UrlMapping()
    {
        OriginalUrl = null!;
    }
    public UrlMapping(string originalUrl)
    {
        if (string.IsNullOrWhiteSpace(originalUrl))
            throw new ArgumentException("The URL cannot be null or empty.", nameof(originalUrl));

        bool isValidUrl = Uri.TryCreate(originalUrl, UriKind.Absolute, out Uri? uriResult)
                          && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        if (!isValidUrl)
            throw new ArgumentException("Invalid URL format. Must be an absolute HTTP or HTTPS URL.", nameof(originalUrl));

        // uriResult is a clean, validated URL at this point
        OriginalUrl = uriResult!.ToString();
        CreatedAt = DateTime.UtcNow;
    }

    public int Id { get; private set; }

    public string OriginalUrl { get; private set; }
    
    public string? ShortUrl { get; set; }

    public DateTime CreatedAt { get; private set; }
}