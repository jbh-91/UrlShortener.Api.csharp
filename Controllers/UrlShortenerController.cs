using Microsoft.AspNetCore.Mvc;
using UrlShortener.Api.Data;
using UrlShortener.Api.DTOs;
using UrlShortener.Api.Models;
using UrlShortener.Api.Services;

namespace UrlShortener.Api.Controllers;

[ApiController]
[Route("/api/v1/url")]
public class UrlShortenerController : ControllerBase
{
    private readonly IUrlShortenerService urlShortenerService;
    private readonly AppDbContext appDbContext;

    public UrlShortenerController(IUrlShortenerService urlShortenerService, AppDbContext appDbContext) {
        this.urlShortenerService = urlShortenerService;
        this.appDbContext = appDbContext;
    }

        [HttpPost("/shorten")]
    public IActionResult ShortenUrl([FromBody] CreateUrlRequest request) {
        return Ok(urlShortenerService.Shorten(request.OriginalUrl));
    }

    [HttpGet("{shortUrl}")]
    public IActionResult RedirectToOriginalUrl(string shortUrl) {
        UrlMapping urlMapping = appDbContext.UrlMappings.FirstOrDefault(x => x.ShortUrl == shortUrl);
        return urlMapping != null ? Redirect(urlMapping.OriginalUrl) : NotFound();
    }
}
