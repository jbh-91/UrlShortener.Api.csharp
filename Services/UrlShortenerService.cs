namespace UrlShortener.Api.Services
{
    public class UrlShortenerService : IUrlShortenerService
    {
        public string Shorten(string originalUrl)
        {
            return "https://short.ly/xyz"; // Dummy-String als Platzhalter für die tatsächliche Logik zur URL-Verkürzung
        }
    }
}
