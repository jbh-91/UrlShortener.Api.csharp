using Microsoft.AspNetCore.Mvc;
using UrlShortener.Api.DTOs;
using UrlShortener.Api.Services;

namespace UrlShortener.Api.Controllers;

[ApiController]
[Route("/api/v1/url")]
public class UrlShortenerController : ControllerBase
{
    private readonly IUrlShortenerService urlShortenerService;

    public UrlShortenerController(IUrlShortenerService urlShortenerService) {
        this.urlShortenerService = urlShortenerService;
    }

        [HttpPost("/shorten")]
    public IActionResult ShortenUrl([FromBody] CreateUrlRequest request) {
        var shortenedUrl = urlShortenerService.Shorten(request.OriginalUrl);
        return Ok(new { ShortenedUrl = shortenedUrl });
    }
}
