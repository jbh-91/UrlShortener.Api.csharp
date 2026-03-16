using Microsoft.EntityFrameworkCore;
using UrlShortener.Api.Data;
using UrlShortener.Api.Models;

namespace UrlShortener.Api.Services
{
    public class UrlShortenerService : IUrlShortenerService
    {
        private readonly AppDbContext _appDbContext;

        public UrlShortenerService(AppDbContext appDbContext) {
            _appDbContext = appDbContext;
        }

        public async Task<string> ShortenAsync(string originalUrl)
        {
            var urlMapping = new UrlMapping(originalUrl);

            _appDbContext.UrlMappings.Add(urlMapping);

            await _appDbContext.SaveChangesAsync();

            urlMapping.ShortUrl = Utils.Base62Converter.Encode(urlMapping.Id);
            
            await _appDbContext.SaveChangesAsync();

            return urlMapping.ShortUrl;
        }

        public async Task<string?> GetOriginalUrlAsync(string shortUrl)
        {
            var urlMapping = await _appDbContext.UrlMappings
                .FirstOrDefaultAsync(x => x.ShortUrl == shortUrl);

            return urlMapping?.OriginalUrl;
        }
    }
}
