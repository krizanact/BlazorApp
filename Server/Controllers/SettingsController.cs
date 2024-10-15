using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers;

[ApiController]
[Route("[controller]")]
public class SettingsController : ControllerBase
{
    [HttpGet("base-url")]
    public ActionResult GetBaseUrl(CancellationToken cancellationToken)
    {
        return Ok($"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.Value}");
    }
}
