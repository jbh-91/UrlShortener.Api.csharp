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

        public string Shorten(string originalUrl)
        {
            UrlMapping urlMapping = new UrlMapping(originalUrl);

            _appDbContext.UrlMappings.Add(urlMapping);
            _appDbContext.SaveChanges();

            urlMapping.ShortUrl = Utils.Base62Converter.Encode(urlMapping.Id);
            _appDbContext.SaveChanges();

            return urlMapping.ShortUrl;
        }
    }
}
