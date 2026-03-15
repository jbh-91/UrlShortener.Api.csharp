using Microsoft.AspNetCore.Mvc;
using UrlShortener.Api.DTOs;

namespace UrlShortener.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/url")]
    public class UrlShortenerController : ControllerBase
    {

        [HttpPost("/shorten")]
        public IActionResult ShortenUrl([FromBody] CreateUrlRequest url) {
            return Ok("Platzhalter-URL");
        }
    }
}