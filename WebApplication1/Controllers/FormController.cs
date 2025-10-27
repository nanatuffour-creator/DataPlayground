using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;


public class FormController : Controller
{
    private readonly ILogger<FormController> _logger;

    public FormController(ILogger<FormController> logger)
    {
        _logger = logger;
    }

    public IActionResult Talk()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Post()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Posts([Bind] FormModel model)
    {
        ViewBag.Message = "Message successfully sent.";
        return RedirectToAction("Talk");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
