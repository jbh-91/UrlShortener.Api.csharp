namespace UrlShortener.Api.Services;

public interface IUrlShortenerService
{
    public string Shorten(string originalUrl);
}
