namespace UrlShortener.Api.Services;

public interface IUrlShortenerService
{
    Task<string> ShortenAsync(string originalUrl);
    Task<string?> GetOriginalUrlAsync(string shortUrl);
}
