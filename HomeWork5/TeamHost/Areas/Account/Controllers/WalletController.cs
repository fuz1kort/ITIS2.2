using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Areas.Account.Controllers;

[Area("Account")]
public class WalletController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}