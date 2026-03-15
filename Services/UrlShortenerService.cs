using Microsoft.EntityFrameworkCore;
using UrlShortener.Api.Data;
using UrlShortener.Api.Models;

namespace UrlShortener.Api.Services
{
    public class UrlShortenerService : IUrlShortenerService
    {
        private readonly AppDbContext appDbContext;

        public UrlShortenerService(AppDbContext appDbContext) {
            this.appDbContext = appDbContext;
        }

        public string Shorten(string originalUrl)
        {
            UrlMapping urlMapping = new UrlMapping {
                OriginalUrl = originalUrl,
                ShortUrl = "https://short.ly/xyz",
                CreatedAt = DateTime.UtcNow
            };
            appDbContext.UrlMappings.Add(urlMapping);
            appDbContext.SaveChanges();

            return urlMapping.ShortUrl;
        }
    }
}
