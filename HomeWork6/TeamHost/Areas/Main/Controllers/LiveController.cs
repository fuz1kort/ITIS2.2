using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Areas.Main.Controllers;

[Area("Main")]
public class LiveController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SendStreamUrl(string streamUrl)
    {
        return Ok();
    }
}