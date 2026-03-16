using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Api.Data;
using UrlShortener.Api.DTOs;
using UrlShortener.Api.Services;

namespace UrlShortener.Api.Controllers;

[ApiController]
[Route("/api/v1/url")]
public class UrlShortenerController : ControllerBase
{
    private readonly IUrlShortenerService _urlShortenerService;

    public UrlShortenerController(IUrlShortenerService urlShortenerService, AppDbContext appDbContext)
    {
        _urlShortenerService = urlShortenerService;
    }

        [HttpPost("/shorten")]
    public async Task<IActionResult> ShortenUrl([FromBody] CreateUrlRequest request)
    {
        var shortUrl = await _urlShortenerService.ShortenAsync(request.OriginalUrl);
        return Ok(shortUrl);
    }

    [HttpGet("/{shortUrl}")]
    public async Task<IActionResult> RedirectToOriginalUrl(string shortUrl)
    {
        var originalUrl = await _urlShortenerService.GetOriginalUrlAsync(shortUrl);

        if (originalUrl == null)
            return NotFound();

        return Redirect(originalUrl);
    }
}
