using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Data;

namespace WebApplication1.Controllers;


public class FormController : Controller
{
    private readonly ILogger<FormController> _logger;
    private readonly FormDbContext _context;

    public FormController(ILogger<FormController> logger, FormDbContext context)
    {
        _logger = logger;
        _context = context;
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
