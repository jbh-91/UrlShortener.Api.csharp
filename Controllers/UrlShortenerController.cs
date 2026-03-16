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
    private readonly IUrlShortenerService _urlShortenerService;
    private readonly AppDbContext _appDbContext;

    public UrlShortenerController(IUrlShortenerService urlShortenerService, AppDbContext appDbContext) {
        _urlShortenerService = urlShortenerService;
        _appDbContext = appDbContext;
    }

        [HttpPost("/shorten")]
    public IActionResult ShortenUrl([FromBody] CreateUrlRequest request) {
        return Ok(_urlShortenerService.Shorten(request.OriginalUrl));
    }

    [HttpGet("/{shortUrl}")]
    public IActionResult RedirectToOriginalUrl(string shortUrl) {
        UrlMapping? urlMapping = _appDbContext.UrlMappings.FirstOrDefault(x => x.ShortUrl == shortUrl);
        return urlMapping != null ? Redirect(urlMapping.OriginalUrl) : NotFound();
    }
}
